namespace MyBlog.Service.Services.Abstract;
public interface IArticleService
{
    Task<List<ArticleViewModel>> GetAllArticlesWithCategoryNonDeletedAsync();
    Task CreateArticleAsync(ArticleAddViewModel model);
    Task UpdateArticleAsync(ArticleUpdateViewModel model);
    Task<ArticleViewModel> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
}