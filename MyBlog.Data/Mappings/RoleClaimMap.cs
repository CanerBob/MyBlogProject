namespace MyBlog.Data.Mappings;
public class RoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
{
    public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
    {
        builder.HasKey(rc => rc.Id);
        builder.ToTable("AspNetRoleClaims");
    }
}