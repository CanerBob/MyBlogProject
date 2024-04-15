namespace MyBlog.Service.AutoMapper.Articles;
public class ArticleProfiles: Profile
{
    public ArticleProfiles()
    {
        CreateMap<Article, ArticleViewModel>().ReverseMap();
        CreateMap<Article, ArticleUpdateViewModel>().ReverseMap();
        CreateMap<ArticleViewModel, ArticleUpdateViewModel>().ReverseMap();
        CreateMap<Article, ArticleAddViewModel>().ReverseMap();
    }
}