using AutoMapper;
using BlogProjectWeb.Uı.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Categories;
using MyBlog.Service.Extensions;
using MyBlog.Service.Services.Abstract;
using NToastNotify;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService categoryService;
    private readonly IMapper mapper;
    private readonly IValidator<Category> validator;
    private readonly IToastNotification toast;

    public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator, IToastNotification toast)
    {
        this.categoryService = categoryService;
        this.mapper = mapper;
        this.validator = validator;
        this.toast = toast;
    }
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.GetAllCategoriesNonDeleted();
        return View(categories);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(CategoryAddViewModel model)
    {
        var map = mapper.Map<Category>(model);
        var result = await validator.ValidateAsync(map);
        if (result.IsValid)
        {
            await categoryService.CreateCategoryAsync(model);
            toast.AddSuccessToastMessage(Messages.Category.Add(model.Name),new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        result.AddToModelState(this.ModelState);
        return View(model);
    }
    [HttpGet]
    public async Task<IActionResult> Update(Guid categoryId) 
    {
        var category = await categoryService.GetCategoryByGuid(categoryId);
        var map = mapper.Map<Category, CategoryUpdateViewModel>(category);
        return View(map);
    }
    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateViewModel model) 
    {
        var map = mapper.Map<Category>(model);
        var result= await validator.ValidateAsync(map);
        if (result.IsValid) 
        {
           var name = await categoryService.UpdateCategoryAsync(model);
            toast.AddWarningToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        result.AddToModelState(this.ModelState);
        return View(model);
    }
    public async Task<IActionResult> Delete(Guid categoryId) 
    {
        var name = await categoryService.SafeDeleteCategoryAsync(categoryId);
        toast.AddWarningToastMessage(Messages.Category.Delete(name), new ToastrOptions { Title = "İşlem Başarılı" });
        return RedirectToAction("Index", "Category", new { Area = "Admin" });
    }
}