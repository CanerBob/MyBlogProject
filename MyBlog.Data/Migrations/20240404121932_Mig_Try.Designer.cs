﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Data.Database;

#nullable disable

namespace MyBlog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240404121932_Mig_Try")]
    partial class Mig_Try
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBlog.Entity.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bcb92afc-a26c-4e9c-bfa8-802dfcaf9de7"),
                            ConcurrencyStamp = "f97bfee1-4cd1-474b-baee-73263256ab01",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("17e138ba-5416-47de-bb0d-39fa981697f1"),
                            ConcurrencyStamp = "60bf787c-7fae-4cd0-a45c-c585d3af4ce5",
                            Name = "Admin",
                            NormalizedName = "ADMİN"
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a860501-de39-474c-9fa0-91d8d7dbde05"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a969330d-5dcd-4221-bf16-3555525deee6",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Caner",
                            ImageId = new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                            LastName = "Bayraktar",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAİL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAİL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELEgl0VhPF3kZe93RoaLWtiAAD22ImRHb2WV4hR7/Q81bBPF9tWm0TUDpMI83q9Q+A==",
                            PhoneNumber = "0555 555 55 55",
                            PhoneNumberConfirmed = true,
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a516c27a-84c2-4e88-bce5-165dc0143f5d",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Çağatay",
                            ImageId = new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                            LastName = "Bayraktar",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMİN@GMAİL.COM",
                            NormalizedUserName = "ADMİN@GMAİL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAENy8ZhsyiUZAi6P58xLpDVYxtWG5faQpftQUxRyKrOj9yzzsvk53BzqsP9LY5x8Jlw==",
                            PhoneNumber = "0555 555 55 11",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("eeb3a51f-5450-4c4f-8562-550d2deae903"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7877d411-ae18-4f32-8ad2-aca0ce3e29ce",
                            Email = "deneme@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Çağatay",
                            ImageId = new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                            LastName = "Bayraktar",
                            LockoutEnabled = false,
                            NormalizedEmail = "DENEME@GMAİL.COM",
                            NormalizedUserName = "CANERBOB ",
                            PasswordHash = "AQAAAAIAAYagAAAAENKIlopouKrvsWfXnxuc38/U3e+Lyj7ZQFUNxDXdmrD64VBL5FTi5N8Tq71Z/lQx5A==",
                            PhoneNumber = "0555 555 55 11",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "CanerBob"
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8a860501-de39-474c-9fa0-91d8d7dbde05"),
                            RoleId = new Guid("bcb92afc-a26c-4e9c-bfa8-802dfcaf9de7")
                        },
                        new
                        {
                            UserId = new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                            RoleId = new Guid("17e138ba-5416-47de-bb0d-39fa981697f1")
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f90267ab-e120-46a2-a235-3cad215e7953"),
                            CategoryId = new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                            Content = "Günümüzde İnternetin gelişimi birçok alanda değişiklik ve yeniliklerin oluşmasına olanak sağlamıştır. Bu alanlardan biri de hiç şüphesiz Elektronik Ticaret alanı alanıdır. Elektronik Ticaret’in gelişimi ve değişimi internetten sonra büyük ölçüde değiştiren ve geliştiren ise Mobil Dünyadaki gelişmeler ve değişimler olmuştur. Mobil Araçların gelişimi ve yaygınlaşması ile birlikte insanların İnternet’e ve dolayısı ile Elektronik Web Sitelerine ulaşmaları ve alışveriş yapma oranlarında büyük bir artış olmuştur.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 4, 4, 15, 19, 31, 955, DateTimeKind.Local).AddTicks(9128),
                            ImageId = new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                            IsDeleted = false,
                            Title = "AspNet Core Deneme Makalesi",
                            UserId = new Guid("8a860501-de39-474c-9fa0-91d8d7dbde05"),
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                            CategoryId = new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                            Content = "Bir bina yapılmaya başlamadan önce mimarlar tarafından projenin ön çizimi, tasarımı çizilir. Tıpkı bunun gibi bir yazılım projesinin de yapılmaya başlamadan önce planlanması gerekir. Bu planlamaya “Yazılım Mimarisi” bu planı tasarlayan kişilere de “Yazılım Mimarı” denir. Mimari, yazılım uygulamasının bir donanımın, ağların ve bir işletmenin diğer bileşenleriyle nasıl etkileşime gireceğini ana hatlarıyla anlatan eksiksiz bir tasarım belgeleri seti içerir. Böylelikle yazılım geliştiricilerin izleyeceği yol genel hatları ile belirlenmiş olur.",
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 4, 4, 15, 19, 31, 955, DateTimeKind.Local).AddTicks(9139),
                            ImageId = new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                            IsDeleted = false,
                            Title = "Yazılım Mimarisi",
                            UserId = new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                            ViewCount = 16
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(388),
                            IsDeleted = false,
                            Name = "ASP .Net Core"
                        },
                        new
                        {
                            Id = new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(391),
                            IsDeleted = false,
                            Name = "Yazılım Mimarisi"
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiesDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(1509),
                            FileName = "/images/test",
                            FileType = "jpeg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(1513),
                            FileName = "/images/test",
                            FileType = "png",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUser", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserClaim", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserLogin", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserRole", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUserToken", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Article", b =>
                {
                    b.HasOne("MyBlog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBlog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.HasOne("MyBlog.Entity.Entities.AppUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MyBlog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}