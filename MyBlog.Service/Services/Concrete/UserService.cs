namespace MyBlog.Service.Services.Concrete;
public class UserService : IUserService
{
	private readonly IUnitOfWork unitOfWork;
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly SignInManager<AppUser> signInManager;
	private readonly IMapper mapper;
	private readonly UserManager<AppUser> userManager;
	private readonly RoleManager<AppRole> roleManager;
	private readonly ClaimsPrincipal _user;

	public UserService(IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor,SignInManager<AppUser> signInManager, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
	{
		this.unitOfWork = unitOfWork;
		this.httpContextAccessor = httpContextAccessor;
		this.signInManager = signInManager;
		_user = httpContextAccessor.HttpContext.User;
		this.mapper = mapper;
		this.userManager = userManager;
		this.roleManager = roleManager;
	}

	public async Task<IdentityResult> CreateUserAsync(UserAddViewModel userAddViewModel)
	{
		var map = mapper.Map<AppUser>(userAddViewModel);
		var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddViewModel.Password) ? "" :userAddViewModel.Password);
		if (result.Succeeded)
		{
			var findRole = await roleManager.FindByIdAsync(userAddViewModel.roleId.ToString());
			await userManager.AddToRoleAsync(map,findRole.ToString());
			return result;
		}
		else
			return result;
	}

	public async Task<(IdentityResult identityResult, string? userName)> DeleteUserAsync(Guid userId)
	{
		var user = await GetAppUserByIdAsync(userId);
		var result = await userManager.DeleteAsync(user);
		if (result.Succeeded)
			return (result,user.UserName);
		else
			return (result, null);
	}

	public async Task<List<AppRole>> GetAllRolesAsync()
	{
		return await roleManager.Roles.ToListAsync();
	}

	public async Task<List<UserViewModel>> GetAllUsersWithRoleAsync()
	{
		var users = await userManager.Users.ToListAsync();
		var map = mapper.Map<List<UserViewModel>>(users);
		foreach (var item in map)
		{
			var findUser = await userManager.FindByIdAsync(item.Id.ToString());
			var role = string.Join("", await userManager.GetRolesAsync(findUser));
			item.Role = role;
		}
		return map;
	}

	public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
	{
		return await userManager.FindByIdAsync(userId.ToString());
	}

	public async Task<string> GetUserRoleAsync(AppUser user)
	{
		return string.Join("", await userManager.GetRolesAsync(user));
	}

	public async Task<IdentityResult> UpdateUserAsync(UserUpdateViewModel userUpdateViewModel)
	{
		var user = await GetAppUserByIdAsync(userUpdateViewModel.Id);
		user.SecurityStamp = Guid.NewGuid().ToString();
		var userRole = await GetUserRoleAsync(user);
		var result = await userManager.UpdateAsync(user);
		if (result.Succeeded)
		{
			await userManager.RemoveFromRoleAsync(user, userRole);
			var findRole = await roleManager.FindByIdAsync(userUpdateViewModel.roleId.ToString());
			await userManager.AddToRoleAsync(user, findRole.Name);
			return result;
		}
		else 
		{
			return result;
		}
	}
	public async Task<UserProfileViewModel> GetUserProfileAsync() 
	{
		var userId = _user.GetLoggedInUserId();
		var user = await GetAppUserByIdAsync(userId);  
		var map = mapper.Map<UserProfileViewModel>(user);
		return map;
	}
	public async Task<bool> UserProfileEditAsync(UserProfileViewModel userProfileViewModel) 
	{
		var userId = _user.GetLoggedInUserId();
		var user = await GetAppUserByIdAsync(userId);
		var isVerified = await userManager.CheckPasswordAsync(user, userProfileViewModel.CurrentPassword);
		if (isVerified && userProfileViewModel.NewPassword != null)
		{
			var result = await userManager.ChangePasswordAsync(user, userProfileViewModel.CurrentPassword, userProfileViewModel.NewPassword);
			if (result.Succeeded)
			{
				await userManager.UpdateSecurityStampAsync(user);
				await signInManager.SignOutAsync();
				await signInManager.PasswordSignInAsync(user, userProfileViewModel.NewPassword, true, false);


				mapper.Map(userProfileViewModel, user);
				
				await userManager.UpdateAsync(user);
				await unitOfWork.SaveAsync();
				return true;
			}
			else
				return false;
		}
		else if (isVerified)
		{
			await userManager.UpdateSecurityStampAsync(user);
			mapper.Map(userProfileViewModel, user);
			await userManager.UpdateAsync(user);
			await unitOfWork.SaveAsync();
			return true;
		}
		else
			return false;
	}
}