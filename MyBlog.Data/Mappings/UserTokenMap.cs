﻿namespace MyBlog.Data.Mappings;
public class UserTokenMap : IEntityTypeConfiguration<AppUserToken>
{
    public void Configure(EntityTypeBuilder<AppUserToken> builder)
    {
        builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        builder.Property(t => t.LoginProvider);
        builder.Property(t => t.Name);
        builder.ToTable("AspNetUserTokens");
    }
}