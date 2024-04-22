using MyBlog.Entity.Entities;

namespace MyBlog.Entity.ViewModels.Users;
public class UserUpdateViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid roleId { get; set; }
    public List<AppRole> Roles { get; set; }
}