using Microsoft.AspNetCore.Http;

namespace MyBlog.Entity.ViewModels.Users;
public class UserProfileViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
    public IFormFile? Photo { get; set; }
}