namespace MyBlog.Service.Services.Abstract;
public interface IArticleService
{
    Task<List<ArticleViewModel>> GetAllArticlesWithCategoryNonDeletedAsync();
    Task CreateArticleAsync(ArticleAddViewModel model);
    Task<string> UpdateArticleAsync(ArticleUpdateViewModel articleUpdateVm);
    Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
    Task<string> SafeDeleteArticleAsync(Guid articleId);
}