namespace MyBlog.Data.Mappings;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(new Category()
        {
            Id = Guid.Parse("AF5FDFE2-A680-4EB9-929E-8270F1AE2849"),
            Name = "ASP .Net Core",
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        },
        new Category() 
        {
            Id = Guid.Parse("0EB19997-5C94-4FCD-A327-FDD99E7B807C"),
            Name = "Yazılım Mimarisi",
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        });
    }
}