namespace MyBlog.Service.Services.Abstract;
public interface IArticleService
{
    Task<List<Article>> GetAllArticleAsync();
}