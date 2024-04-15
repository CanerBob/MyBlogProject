namespace MyBlog.Service.AutoMapper.Categories;
public class CategoryProfiles: Profile
{
    public CategoryProfiles()
    {
        CreateMap<CategoryViewModel, Category>().ReverseMap();
    }
}