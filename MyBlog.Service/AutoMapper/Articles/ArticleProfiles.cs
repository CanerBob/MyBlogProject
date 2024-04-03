﻿namespace MyBlog.Service.AutoMapper.Articles;
public class ArticleProfiles: Profile
{
    public ArticleProfiles()
    {
        CreateMap<Article, ArticleViewModel>().ReverseMap();
    }
}