﻿namespace MyBlog.Service.Services.Concrete;
public class ArticleService : IArticleService
{
	private readonly IUnitOfWork unitOfWork;
	private readonly IMapper mapper;
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly IImageHelper imageHelper;
	private readonly ClaimsPrincipal _user;
	public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
	{
		this.unitOfWork = unitOfWork;
		this.mapper = mapper;
		this.httpContextAccessor = httpContextAccessor;
		_user = httpContextAccessor.HttpContext.User;
		this.imageHelper = imageHelper;
	}
	public async Task<ArticleListViewModel> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
	{
		pageSize = pageSize > 20 ? 20 : pageSize;

		var articles = categoryId == null
			? await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category, c => c.Image)
			: await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.CategoryId == categoryId && !x.IsDeleted, a => a.Category, c => c.Image);

		var sortedArticles = isAscending
			? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
			: articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

		return new ArticleListViewModel
		{
			Articles = sortedArticles,
			CategoryId = categoryId == null ? null : categoryId.Value,
			CurrentPage = currentPage,
			PageSize = pageSize,
			TotalCount = articles.Count,
			IsAscending = isAscending
		};
	}
	public async Task<List<ArticleViewModel>> GetAllArticlesWithCategoryNonDeletedAsync()
	{
		var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
		var map = mapper.Map<List<ArticleViewModel>>(articles);
		return map;
	}
	public async Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
	{
		var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, x => x.Image);
		var map = mapper.Map<ArticleViewModel>(article);
		return map;
	}
	public async Task CreateArticleAsync(ArticleAddViewModel model)
	{
		var userId = _user.GetLoggedInUserId();
		var userName = _user.GetLoggedInUserName();
		var imageUpload = await imageHelper.Upload(model.Title, model.Photos, ImageType.Post);
		Image image = new(imageUpload.FullName, model.Photos.ContentType, userName);
		await unitOfWork.GetRepository<Image>().AddAsync(image);
		var article = new Article(model.Title, model.Content, userId, userName, model.CategoryId, image.Id);
		await unitOfWork.GetRepository<Article>().AddAsync(article);
		await unitOfWork.SaveAsync();
	}
	public async Task<string> UpdateArticleAsync(ArticleUpdateViewModel articleUpdateVm)
	{
		var userName = _user.GetLoggedInUserName();
		var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateVm.Id, x => x.Category, x => x.Image);
		if (articleUpdateVm.Photo != null)
		{
			imageHelper.Delete(article.Image.FileName);
			var imageUpload = await imageHelper.Upload(articleUpdateVm.Title, articleUpdateVm.Photo, ImageType.Post);
			Image image = new(imageUpload.FullName, articleUpdateVm.Photo.ContentType, userName);
			await unitOfWork.GetRepository<Image>().AddAsync(image);
			article.ImageId = image.Id;
		}
		article.Title = articleUpdateVm.Title;
		article.Content = articleUpdateVm.Content;
		article.CategoryId = articleUpdateVm.CategoryId;
		article.ModifiesDate = DateTime.Now;
		article.ModifiedBy = userName;
		await unitOfWork.GetRepository<Article>().UpdateAsync(article);
		await unitOfWork.SaveAsync();
		return article.Title;
	}
	public async Task<string> SafeDeleteArticleAsync(Guid articleId)
	{
		var userName = _user.GetLoggedInUserName();
		var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
		article.IsDeleted = true;
		article.DeletedDate = DateTime.Now;
		article.DeletedBy = userName;
		await unitOfWork.GetRepository<Article>().UpdateAsync(article);
		await unitOfWork.SaveAsync();
		return article.Title;
	}
	public async Task<List<ArticleViewModel>> GetAllArticlesWithCategoryDeletedAsync()
	{
		var article = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
		var map = mapper.Map<List<ArticleViewModel>>(article);
		return map;
	}
	public async Task<string> UndoDeleteArticleAsync(Guid articleId)
	{
		var userName = _user.GetLoggedInUserName();
		var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
		article.IsDeleted = false;
		article.DeletedDate = null;
		article.DeletedBy = null;
		await unitOfWork.GetRepository<Article>().UpdateAsync(article);
		await unitOfWork.SaveAsync();
		return article.Title;
	}
}