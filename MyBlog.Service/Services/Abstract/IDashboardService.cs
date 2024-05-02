namespace MyBlog.Service.Services.Abstract;
public interface IDashboardService
{
	Task<List<int>> GetYearlyArticleCounts();
	Task<int> GetTotalArticleCounts();
	Task<int> GetTotalCategoryCounts();
	Task<int> GetTotalUserCount();
}