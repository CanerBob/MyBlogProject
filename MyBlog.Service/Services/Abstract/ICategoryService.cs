namespace MyBlog.Service.Services.Abstract;
public interface ICategoryService
{
    Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted();
    Task<List<CategoryViewModel>> GetAllCategoriesDeleted();
    Task CreateCategoryAsync(CategoryAddViewModel model);
    Task<Category> GetCategoryByGuid(Guid categoryId);
    Task<string> UpdateCategoryAsync(CategoryUpdateViewModel model);
    Task<string> SafeDeleteCategoryAsync(Guid categoryId);
    Task<string> UndoDeleteCategoryAsync(Guid categoryId);
}