using MyBlog.Entity.Entities;

namespace MyBlog.Entity.ViewModels.UserViewModels;
public class UserAddViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public Guid roleId { get; set; }
    public List<AppRole> Roles { get; set; }
}