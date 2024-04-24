using Microsoft.AspNetCore.Http;

namespace MyBlog.Service.Services.Concrete;
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IHttpContextAccessor httpContextAccesso;
    private readonly ClaimsPrincipal _user;
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.httpContextAccesso = httpContextAccessor;
        _user = httpContextAccessor.HttpContext.User;
    }
    public async Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted()
    {
        var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
        var map = mapper.Map<List<CategoryViewModel>>(categories);
        return map;
    }
    public async Task CreateCategoryAsync(CategoryAddViewModel model) 
    {
        //var userId = _user.GetLoggedInUserId();
        var userName = _user.GetLoggedInUserName();
        Category category = new(model.Name,userName);
        await unitOfWork.GetRepository<Category>().AddAsync(category);
        await unitOfWork.SaveAsync();
    }
    public async Task<Category> GetCategoryByGuid(Guid categoryId) 
    {
        var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
        return category;
    }
    public async Task<string> UpdateCategoryAsync(CategoryUpdateViewModel model) 
    {
        var userName = _user.GetLoggedInUserName();
        var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == model.Id);
        
        category.Name = model.Name;
        category.ModifiedBy = userName;
        category.ModifiesDate = DateTime.UtcNow;
        await unitOfWork.GetRepository<Category>().UpdateAsync(category);
        await unitOfWork.SaveAsync();
        return model.Name;
    }

    public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
    {
        var userName = _user.GetLoggedInUserName();
        var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
        category.IsDeleted = true;
        category.DeletedDate = DateTime.UtcNow;
        category.DeletedBy = userName;
        await unitOfWork.GetRepository<Category>().UpdateAsync(category);
        await unitOfWork.SaveAsync();
        return category.Name;
    }

    public async Task<List<CategoryViewModel>> GetAllCategoriesDeleted()
    {
        var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
        var map = mapper.Map<List<CategoryViewModel>>(categories);
        return map;
    }

    public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
    {
        var userName = _user.GetLoggedInUserName();
        var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
        category.IsDeleted = false;
        category.DeletedDate = null;
        category.DeletedBy = null;
        await unitOfWork.GetRepository<Category>().UpdateAsync(category);
        await unitOfWork.SaveAsync();
        return category.Name;
    }
}