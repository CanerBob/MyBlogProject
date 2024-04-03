namespace MyBlog.Data.Mappings;
public class RoleMap : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
        builder.ToTable("AspNetRoles");
        builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
        builder.Property(u => u.Name).HasMaxLength(256);
        builder.Property(u => u.NormalizedName).HasMaxLength(256);
        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
        builder.HasData(new AppRole
        {
            Id = Guid.Parse("BCB92AFC-A26C-4E9C-BFA8-802DFCAF9DE7"),
            Name = "SuperAdmin",
            NormalizedName = "SUPERADMIN",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        }, new AppRole
        {
            Id = Guid.Parse("17E138BA-5416-47DE-BB0D-39FA981697F1"),
            Name = "Admin",
            NormalizedName = "ADMİN",
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
    }
}