using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Services.Abstract;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class HomeController : Controller
{
    private readonly IArticleService articleService;

    public HomeController(IArticleService articleService)
    {
        this.articleService = articleService;
    }
    public async Task<IActionResult> Index()
    {
        var articles = await articleService.GetAllArticleAsync();
        return View(articles);
    }
}
