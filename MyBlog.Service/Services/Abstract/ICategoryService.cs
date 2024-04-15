namespace MyBlog.Service.Services.Abstract;
public interface ICategoryService
{
    public Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted();
}