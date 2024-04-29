namespace MyBlog.Service.Services.Abstract;
public interface IUserService
{
	Task<List<UserViewModel>> GetAllUsersWithRoleAsync();
	Task<List<AppRole>> GetAllRolesAsync();
	Task<IdentityResult> CreateUserAsync(UserAddViewModel userAddViewModel);
	Task<IdentityResult> UpdateUserAsync(UserUpdateViewModel  userUpdateViewModel);
	Task<AppUser> GetAppUserByIdAsync(Guid userId);
	Task<string> GetUserRoleAsync(AppUser user);
	Task<(IdentityResult identityResult, string? userName)> DeleteUserAsync(Guid userId);
	Task<UserProfileViewModel> GetUserProfileAsync();
	Task<bool> UserProfileEditAsync(UserProfileViewModel userProfileViewModel);
}