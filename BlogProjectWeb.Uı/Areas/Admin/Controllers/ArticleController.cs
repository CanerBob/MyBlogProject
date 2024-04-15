using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Service.Services.Abstract;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class ArticleController : Controller
{
    private readonly IArticleService articleService;
    private readonly ICategoryService categoryService;
    private readonly IMapper mapper;

    public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
    {
        this.articleService = articleService;
        this.categoryService = categoryService;
        this.mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
        return View(articles);
    }
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var categories = await categoryService.GetAllCategoriesNonDeleted();
        return View(new ArticleAddViewModel { Categories = categories });
    }
    [HttpPost]
    public async Task<IActionResult> Add(ArticleAddViewModel model)
    {
        await articleService.CreateArticleAsync(model);
        return RedirectToAction("Index", "Article", new { Area = "Admin" });
    }
    [HttpGet]
    public async Task<IActionResult> Update(Guid articleId)
    {
        var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
        var categories = await categoryService.GetAllCategoriesNonDeleted();

        var articleUpdateVm = mapper.Map<ArticleUpdateViewModel>(article);
        articleUpdateVm.Categories = categories;

        return View(articleUpdateVm);
    }
    [HttpPost]
    public async Task<IActionResult> Update(ArticleUpdateViewModel articleUpdateVm)
    {
        await articleService.UpdateArticleAsync(articleUpdateVm);
        var categories = await categoryService.GetAllCategoriesNonDeleted();
        articleUpdateVm.Categories = categories;
        return View(articleUpdateVm);
    }
    public async Task<IActionResult> Delete(Guid articleId)
    {
        await articleService.SafeDeleteArticleAsync(articleId);
        return RedirectToAction("Index", "Article", new { Area = "Admin" });
    }
}