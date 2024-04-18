namespace MyBlog.Service.AutoMapper.Categories;
public class CategoryProfiles: Profile
{
    public CategoryProfiles()
    {
        CreateMap<CategoryViewModel, Category>().ReverseMap();
        CreateMap<Category, CategoryAddViewModel>().ReverseMap();
        CreateMap<Category,CategoryUpdateViewModel>().ReverseMap();
    }
}