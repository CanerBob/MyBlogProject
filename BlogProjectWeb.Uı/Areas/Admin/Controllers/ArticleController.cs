using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using MyBlog.Service.FluentValidations;
using MyBlog.Service.Services.Abstract;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class ArticleController : Controller
{
    private readonly IArticleService articleService;
    private readonly ICategoryService categoryService;
    private readonly IMapper mapper;
    private readonly IValidator<Article> validator;

    public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator)
    {
        this.articleService = articleService;
        this.categoryService = categoryService;
        this.mapper = mapper;
        this.validator = validator;
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
        var map = mapper.Map<Article>(model);
        var result = await validator.ValidateAsync(map);
        if (result.IsValid)
        {
            await articleService.CreateArticleAsync(model);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
        else 
        {
            result.AddToModelState(this.ModelState);
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddViewModel { Categories = categories });
        }
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
        var map = mapper.Map<Article>(articleUpdateVm);
        var result = await validator.ValidateAsync(map);
        if (result.IsValid)
        {
            await articleService.UpdateArticleAsync(articleUpdateVm);
        }
        else 
        {
            result.AddToModelState(this.ModelState);
        }
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