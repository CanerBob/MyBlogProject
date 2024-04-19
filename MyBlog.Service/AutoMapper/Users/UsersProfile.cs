using MyBlog.Entity.ViewModels.UserViewModels;

namespace MyBlog.Service.AutoMapper.Users;
public class UsersProfile: Profile
{
    public UsersProfile()
    {
        CreateMap<AppUser, UserViewModel>().ReverseMap();
    }
}