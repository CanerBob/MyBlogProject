using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Service.Services.Abstract;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
//[Authorize]
public class HomeController : Controller
{
    private readonly IArticleService articleService;
	private readonly IDashboardService dashboardService;

	public HomeController(IArticleService articleService, IDashboardService dashboardService)
    {
        this.articleService = articleService;
		this.dashboardService = dashboardService;
	}
    public async Task<IActionResult> Index()
    {
        var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
        return View(articles);
    }
    [HttpGet]
    public async Task<IActionResult> YearlyArticleCounts() 
    {
        var count = await dashboardService.GetYearlyArticleCounts();
        return Json(JsonConvert.SerializeObject(count));
    }
    [HttpGet]
    public async Task<IActionResult> TotalArticleCount() 
    {
        var articleCount = await dashboardService.GetTotalArticleCounts();
        return Json(articleCount);
    }
    [HttpGet]
    public async Task<IActionResult> TotalCategoryCount() 
    {
        var categoryCount = await dashboardService.GetTotalCategoryCounts();
        return Json(categoryCount);
    }
    [HttpGet]
    public async Task<IActionResult> TotalUserCount() 
    {
        var userCount = await dashboardService.GetTotalUserCount();
        return Json(userCount);
    }
}
