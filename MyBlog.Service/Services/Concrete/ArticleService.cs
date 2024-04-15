using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyBlog.Service.Services.Concrete;
public class ArticleService : IArticleService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<List<ArticleViewModel>> GetAllArticlesWithCategoryNonDeletedAsync()
    {

        var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = mapper.Map<List<ArticleViewModel>>(articles);
        return map;
    }
    public async Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
    {

        var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category);
        var map = mapper.Map<ArticleViewModel>(article);
        return map;
    }

    public async Task CreateArticleAsync(ArticleAddViewModel model)
    {
        var userId = Guid.Parse("EEB3A51F-5450-4C4F-8562-550D2DEAE903");
        var imageId = Guid.Parse("F406068B-EC45-4D22-B22E-084B4705D8B5");
        var article = new Article(model.Title,model.Content, userId,model.CategoryId, imageId);
        await unitOfWork.GetRepository<Article>().AddAsync(article);
        await unitOfWork.SaveAsync();
    }
    public async Task UpdateArticleAsync(ArticleUpdateViewModel model)
    {
        var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == model.Id, x => x.Category);
        model.Title = article.Title;
        model.Content = article.Content;
        model.CategoryId = article.CategoryId;


        await unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await unitOfWork.SaveAsync();
    }
    public async Task SafeDeleteArticleAsync(Guid articleId)
    {
        var article = await unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
        article.IsDeleted = true;
        article.DeletedDate = DateTime.Now;
        await unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await unitOfWork.SaveAsync();
    }
}