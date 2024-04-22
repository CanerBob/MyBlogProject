namespace MyBlog.Entity.ViewModels.UserViewModels;
public class UserViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; }
    public int AccessFailed { get; set; }
    public string Role { get; set; }
}