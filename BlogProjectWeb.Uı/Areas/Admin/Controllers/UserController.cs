using AutoMapper;
using BlogProjectWeb.Uı.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Users;
using MyBlog.Entity.ViewModels.UserViewModels;
using MyBlog.Service.Extensions;
using NToastNotify;
using System.Data;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
    private readonly UserManager<AppUser> userManager;
    private readonly IValidator<AppUser> validator;
    private readonly RoleManager<AppRole> roleManager;
    private readonly IMapper mapper;
    private readonly IToastNotification toast;

    public UserController(UserManager<AppUser> userManager,IValidator<AppUser> validator, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification toast)
    {
        this.userManager = userManager;
        this.validator = validator;
        this.roleManager = roleManager;
        this.mapper = mapper;
        this.toast = toast;
    }
    public async Task<IActionResult> Index()
    {
        var users = await userManager.Users.ToListAsync();
        var map = mapper.Map<List<UserViewModel>>(users);

        foreach (var item in map)
        {
            var findUser = await userManager.FindByIdAsync(item.Id.ToString());
            var role = string.Join("", await userManager.GetRolesAsync(findUser));
            item.Role = role;
        }
        return View(map);
    }
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var roles = await roleManager.Roles.ToListAsync();
        return View(new UserAddViewModel { Roles = roles });
    }
    [HttpPost]
    public async Task<IActionResult> Add(UserAddViewModel model)
    {
        var map = mapper.Map<AppUser>(model);
        var validation = await validator.ValidateAsync(map);
        var roles = await roleManager.Roles.ToListAsync();
        if (ModelState.IsValid)
        {
            map.UserName = model.UserName;
            var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(model.Password) ? "" : model.Password);
            if (result.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(model.roleId.ToString());
                await userManager.AddToRoleAsync(map, findRole.ToString());
                toast.AddSuccessToastMessage(Messages.User.Add(model.UserName), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else 
            {
                result.AddToIdentityModelState(this.ModelState);
                validation.AddToModelState(this.ModelState);
                return View(new UserAddViewModel { Roles = roles });
            }
        }
        return View(new UserAddViewModel { Roles = roles });
    }
    [HttpGet]
    public async Task<IActionResult> Update(Guid userId) 
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        var roles = await roleManager.Roles.ToListAsync();
        var map = mapper.Map<UserUpdateViewModel>(user);
        map.Roles = roles;
        return View(map);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UserUpdateViewModel model)
    {
        var user = await userManager.FindByIdAsync(model.Id.ToString());
        if (user != null)
        {
            var userRole = string.Join("", await userManager.GetRolesAsync(user));
            var roles = await roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                mapper.Map(model, user);
                var validation = await validator.ValidateAsync(user);
                if (validation.IsValid)
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await roleManager.FindByIdAsync(model.roleId.ToString());
                        await userManager.AddToRoleAsync(user, findRole.Name);
                        toast.AddSuccessToastMessage(Messages.User.Update(model.UserName), new ToastrOptions { Title = "İşlem Başarılı" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        result.AddToIdentityModelState(this.ModelState);
                        return View(new UserUpdateViewModel { Roles = roles });
                    }
                }
                else 
                {
                    validation.AddToModelState(this.ModelState);
                    return View(new UserUpdateViewModel { Roles = roles });
                }
            }
        }
        return NotFound();
    }
    public async Task<IActionResult> Delete(Guid userId) 
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        var result = await userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            toast.AddSuccessToastMessage(Messages.User.Delete(user.UserName), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "User", new { Area = "Admin" });
        }
        else 
        {
            result.AddToIdentityModelState(this.ModelState);
            return NotFound();
        }
    }
}