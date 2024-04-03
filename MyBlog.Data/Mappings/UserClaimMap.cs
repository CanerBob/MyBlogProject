namespace MyBlog.Data.Mappings;
public class UserClaimMap : IEntityTypeConfiguration<AppUserClaim>
{
    public void Configure(EntityTypeBuilder<AppUserClaim> builder)
    {
        builder.HasKey(uc => uc.Id);
        builder.ToTable("AspNetUserClaims");
    }
}