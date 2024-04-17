using System.Security.Claims;

namespace MyBlog.Service.Extensions;
public static class LoggedInUserExtensions
{
    public static Guid GetLoggedInUserId(this ClaimsPrincipal principal) 
    {
        return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
    }
    public static string GetLoggedInUserName(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(ClaimTypes.Name);
    }
}