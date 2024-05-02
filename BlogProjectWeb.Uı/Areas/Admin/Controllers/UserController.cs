namespace BlogProjectWeb.Uı.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
	private readonly IUserService userService;
	private readonly IValidator<AppUser> validator;
	private readonly IMapper mapper;
	private readonly IToastNotification toast;
	public UserController(IUserService userService, IValidator<AppUser> validator, IMapper mapper, IToastNotification toast)
	{
		this.userService = userService;
		this.validator = validator;
		this.mapper = mapper;
		this.toast = toast;
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
		var profile = await userService.GetUserProfileAsync();
		return View(profile);
	}
	[HttpPost]
	public async Task<IActionResult> Profile(UserProfileViewModel model)
	{
		if (ModelState.IsValid)
		{
			var result = await userService.UserProfileEditAsync(model);
			if (result)
			{
				toast.AddSuccessToastMessage("Profil Güncelleme İşlemleri Tamanlandı", new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Home", new { Area = "Admin" });
			}
			else
			{ 
				toast.AddErrorToastMessage("Profil Güncellenirken Bir Hata Oluştu", new ToastrOptions { Title = "Hata" });
			return View(model);
			}
		}
		return View(model);
	}
}