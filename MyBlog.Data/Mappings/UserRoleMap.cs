namespace MyBlog.Data.Mappings;
public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasKey(r => new { r.UserId, r.RoleId });
        builder.ToTable("AspNetUserRoles");
        builder.HasData(new AppUserRole
        {
            UserId = Guid.Parse("8A860501-DE39-474C-9FA0-91D8D7DBDE05"),
            RoleId = Guid.Parse("BCB92AFC-A26C-4E9C-BFA8-802DFCAF9DE7")
        }, 
        new AppUserRole 
        {
             UserId = Guid.Parse("8BBD8F46-95C1-4E5F-BF8B-DC5A1A8630DD"),
             RoleId = Guid.Parse("17E138BA-5416-47DE-BB0D-39FA981697F1")
        });
    }
}