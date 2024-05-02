namespace MyBlog.Service.Services.Concrete;
public class DashboardService : IDashboardService
{
	private readonly IUnitOfWork unitOfWork;

	public DashboardService(IUnitOfWork unitOfWork)
	{
		this.unitOfWork = unitOfWork;
	}
	public async Task<List<int>> GetYearlyArticleCounts()
	{
		var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);
		var startDate = DateTime.Now.Date;
		startDate = new DateTime(startDate.Year, 1, 1);
		List<int> datas = new();
		for (int i = 1; i <= 12; i++)
		{
			var startedDate = new DateTime(startDate.Year, i, 1);	
			var endedDate = startedDate.AddMonths(1);
			var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
			datas.Add(data);
		}
		return datas;
	}
	public async Task<int> GetTotalArticleCounts() 
	{
		var articleCount = await unitOfWork.GetRepository<Article>().CountAsync();
		return articleCount;
	}
	public async Task<int> GetTotalCategoryCounts() 
	{
		var categoryCounts = await unitOfWork.GetRepository<Category>().CountAsync();
		return categoryCounts;
	}
	public async Task<int> GetTotalUserCount() 
	{
		var userCounts = await unitOfWork.GetRepository<AppUser>().CountAsync();
		return userCounts;
	}
}