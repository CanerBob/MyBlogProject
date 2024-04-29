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
using MyBlog.Service.Services.Abstract;
using NToastNotify;
using System.Data;

namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
	private readonly UserManager<AppUser> userManager;
	private readonly IUserService userService;
	private readonly IValidator<AppUser> validator;
	private readonly RoleManager<AppRole> roleManager;
	private readonly IMapper mapper;
	private readonly IToastNotification toast;
	private readonly SignInManager<AppUser> signInManager;

	public UserController(UserManager<AppUser> userManager,IUserService userService, IValidator<AppUser> validator, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification toast, SignInManager<AppUser> signInManager)
	{
		this.userManager = userManager;
		this.userService = userService;
		this.validator = validator;
		this.roleManager = roleManager;
		this.mapper = mapper;
		this.toast = toast;
		this.signInManager = signInManager;
	}
	public async Task<IActionResult> Index()
	{
		var result = await userService.GetAllUsersWithRoleAsync();

		return View(result);
	}
	[HttpGet]
	public async Task<IActionResult> Add()
	{
		var roles = await userService.GetAllRolesAsync();
		return View(new UserAddViewModel { Roles = roles });
	}
	[HttpPost]
	public async Task<IActionResult> Add(UserAddViewModel userAddViewModel)
	{
		var map = mapper.Map<AppUser>(userAddViewModel);
		var validation = await validator.ValidateAsync(map);
		var roles = await userService.GetAllRolesAsync();
		if (ModelState.IsValid)
		{
			var result = await userService.CreateUserAsync(userAddViewModel);
			if (result.Succeeded)
			{
				toast.AddSuccessToastMessage(Messages.User.Add(userAddViewModel.UserName), new ToastrOptions { Title = "İşlem Başarılı" });
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
		var user = await userService.GetAppUserByIdAsync(userId);
		var roles = await userService.GetAllRolesAsync();
		var map = mapper.Map<UserUpdateViewModel>(user);
		map.Roles = roles;
		return View(map);
	}
	[HttpPost]
	public async Task<IActionResult> Update(UserUpdateViewModel model)
	{
		var user = await userService.GetAppUserByIdAsync(model.Id);
		if (user != null)
		{
			var userRole = await userService.GetUserRoleAsync(user);
			var roles = await userService.GetAllRolesAsync();
			if (ModelState.IsValid)
			{
				mapper.Map(model, user);
				var validation = await validator.ValidateAsync(user);
				if (validation.IsValid)
				{
					var result = await userService.UpdateUserAsync(model);
					if (result.Succeeded)
					{
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
		var result = await userService.DeleteUserAsync(userId);
		if (result.identityResult.Succeeded)
		{
			toast.AddSuccessToastMessage(Messages.User.Delete(result.userName), new ToastrOptions { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "User", new { Area = "Admin" });
		}
		else
		{
			result.identityResult.AddToIdentityModelState(this.ModelState);
			return NotFound();
		}
	}
	[HttpGet]
	public async Task<IActionResult> Profile()
	{
		var user = await userManager.GetUserAsync(HttpContext.User);
		var map = mapper.Map<UserProfileViewModel>(user);
		return View(map);
	}
	[HttpPost]
	public async Task<IActionResult> Profile(UserProfileViewModel model)
	{
		var user = await userManager.GetUserAsync(HttpContext.User);
		if (ModelState.IsValid)
		{
			var isVerified = await userManager.CheckPasswordAsync(user, model.CurrentPassword);
			if (isVerified && model.NewPassword != null)
			{
				var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
				if (result.Succeeded)
				{
					await userManager.UpdateSecurityStampAsync(user);
					await signInManager.SignOutAsync();
					await signInManager.PasswordSignInAsync(user, model.NewPassword, true, false);
					user.FirstName = model.FirstName;
					user.LastName = model.LastName;
					user.PhoneNumber = model.PhoneNumber;
					user.UserName = model.UserName;
					await userManager.UpdateAsync(user);
					toast.AddSuccessToastMessage("Şifreniz ve Bilgileriniz Başarıyla Güncellenmiştir.");
					return View();
				}
				else
				{
					result.AddToIdentityModelState(ModelState);
					return View(model);
				}
			}
			else if (isVerified)
			{
				await userManager.UpdateSecurityStampAsync(user);
				user.FirstName = model.FirstName;
				user.LastName = model.LastName;
				user.PhoneNumber = model.PhoneNumber;
				user.UserName = model.UserName;
				await userManager.UpdateAsync(user);
				toast.AddSuccessToastMessage("Bilgileriniz Başarıyla Güncellenmiştir.");
				return View();
			}
			else 
			{
				toast.AddErrorToastMessage("Bilgilerinirz Güncellenirken Bir Hata Oluştu");
			}
		}
		return View(model);
	}
}