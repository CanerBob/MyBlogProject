using MyBlog.Entity.Entities;

namespace MyBlog.Entity.ViewModels.Articles;
public class ArticleListViewModel
{
    public IList<Article> Articles { get; set; }
    public Guid? CategoryId { get; set; }
    public virtual int CurrentPage { get; set; } = 1;
    public virtual int PageSize { get; set; } = 3;
    public virtual int TotalCount { get; set; }
    public virtual int TotalPage => (int)Math.Ceiling(decimal.Divide(TotalCount , PageSize));
    public virtual bool ShowPrevius => CurrentPage > 1;
    public virtual bool ShowNext => CurrentPage < TotalPage;
    public virtual bool IsAscending { get; set; } = false;
}