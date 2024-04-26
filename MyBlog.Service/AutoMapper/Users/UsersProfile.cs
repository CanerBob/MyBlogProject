using MyBlog.Entity.ViewModels.Users;
using MyBlog.Entity.ViewModels.UserViewModels;

namespace MyBlog.Service.AutoMapper.Users;
public class UsersProfile: Profile
{
    public UsersProfile()
    {
        CreateMap<AppUser, UserViewModel>().ReverseMap();
        CreateMap<AppUser, UserAddViewModel>().ReverseMap();
        CreateMap<AppUser, UserUpdateViewModel>().ReverseMap();
        CreateMap<AppUser, UserProfileViewModel>().ReverseMap();
    }
}