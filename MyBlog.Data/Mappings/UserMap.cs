﻿using Microsoft.AspNetCore.Identity;

namespace MyBlog.Data.Mappings;
public class UserMap : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
        builder.ToTable("AspNetUsers");
        builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
        builder.Property(u => u.UserName).HasMaxLength(256);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
        builder.Property(u => u.Email).HasMaxLength(256);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(256);
        builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
        builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
        builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        var superadmin = new AppUser
        { 
            Id = Guid.Parse("8A860501-DE39-474C-9FA0-91D8D7DBDE05"),
            UserName = "superadmin@gmail.com",
            NormalizedUserName = "SUPERADMIN@GMAİL.COM",
            Email = "superadmin@gmail.com",
            NormalizedEmail = "SUPERADMIN@GMAİL.COM",
            PhoneNumber = "0555 555 55 55",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            FirstName = "Caner",
            LastName = "Bayraktar",
        };
        superadmin.PasswordHash = CreatePasswpordHash(superadmin, "Superadmin123");
        var admin = new AppUser 
        {
            Id = Guid.Parse("8BBD8F46-95C1-4E5F-BF8B-DC5A1A8630DD"),
            UserName = "admin@gmail.com",
            NormalizedUserName = "ADMİN@GMAİL.COM",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMİN@GMAİL.COM",
            PhoneNumber = "0555 555 55 11",
            EmailConfirmed= false,
            PhoneNumberConfirmed = false,
            FirstName = "Çağatay",
            LastName = "Bayraktar"
        };
        admin.PasswordHash = CreatePasswpordHash(admin, "Admin123");
        builder.HasData(superadmin, admin);
    }
    private string CreatePasswpordHash(AppUser user, string password) 
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        return passwordHasher.HashPassword(user,password);
    }
}