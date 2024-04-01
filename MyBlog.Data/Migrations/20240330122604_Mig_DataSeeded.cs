using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_DataSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiesDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"), "Admin Test", new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(1998), null, null, false, null, null, "Yazılım Mimarisi" },
                    { new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"), "Admin Test", new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(1994), null, null, false, null, null, "ASP .Net Core" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiesDate" },
                values: new object[,]
                {
                    { new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"), "Admin Test", new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(3054), null, null, "/images/test", "jpeg", false, null, null },
                    { new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"), "Admin Test", new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(3058), null, null, "/images/test", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiesDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"), new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"), "Bir bina yapılmaya başlamadan önce mimarlar tarafından projenin ön çizimi, tasarımı çizilir. Tıpkı bunun gibi bir yazılım projesinin de yapılmaya başlamadan önce planlanması gerekir. Bu planlamaya “Yazılım Mimarisi” bu planı tasarlayan kişilere de “Yazılım Mimarı” denir. Mimari, yazılım uygulamasının bir donanımın, ağların ve bir işletmenin diğer bileşenleriyle nasıl etkileşime gireceğini ana hatlarıyla anlatan eksiksiz bir tasarım belgeleri seti içerir. Böylelikle yazılım geliştiricilerin izleyeceği yol genel hatları ile belirlenmiş olur.", "Admin Test", new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(765), null, null, new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"), false, null, null, "Yazılım Mimarisi", 16 },
                    { new Guid("f90267ab-e120-46a2-a235-3cad215e7953"), new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"), "Günümüzde İnternetin gelişimi birçok alanda değişiklik ve yeniliklerin oluşmasına olanak sağlamıştır. Bu alanlardan biri de hiç şüphesiz Elektronik Ticaret alanı alanıdır. Elektronik Ticaret’in gelişimi ve değişimi internetten sonra büyük ölçüde değiştiren ve geliştiren ise Mobil Dünyadaki gelişmeler ve değişimler olmuştur. Mobil Araçların gelişimi ve yaygınlaşması ile birlikte insanların İnternet’e ve dolayısı ile Elektronik Web Sitelerine ulaşmaları ve alışveriş yapma oranlarında büyük bir artış olmuştur.", "Admin Test", new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(759), null, null, new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"), false, null, null, "AspNet Core Deneme Makalesi", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f90267ab-e120-46a2-a235-3cad215e7953"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"));
        }
    }
}
