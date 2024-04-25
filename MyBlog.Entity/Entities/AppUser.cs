namespace MyBlog.Entity.Entities;
public class AppUser: IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid ImageId { get; set; } = Guid.Parse("F406068B-EC45-4D22-B22E-084B4705D8B5");
    public Image Image { get; set; }

    public ICollection<Article> Articles { get; set; }
}