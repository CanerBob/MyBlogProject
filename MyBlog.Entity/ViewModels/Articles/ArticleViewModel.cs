using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;

namespace MyBlog.Entity.ViewModels.Articles;
public class ArticleViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public CategoryViewModel Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public Image Image { get; set; }
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
}