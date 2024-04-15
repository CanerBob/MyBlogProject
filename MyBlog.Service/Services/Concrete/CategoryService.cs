namespace MyBlog.Service.Services.Concrete;
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<List<CategoryViewModel>> GetAllCategoriesNonDeleted()
    {
        var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
        var map = mapper.Map<List<CategoryViewModel>>(categories);
        return map;
    }
}