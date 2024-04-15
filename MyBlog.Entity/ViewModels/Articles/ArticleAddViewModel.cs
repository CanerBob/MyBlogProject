﻿namespace MyBlog.Entity.ViewModels.Articles;
public class ArticleAddViewModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
    public IList<CategoryViewModel> Categories { get; set; }
}