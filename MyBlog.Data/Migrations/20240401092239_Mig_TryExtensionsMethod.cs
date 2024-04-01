using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_TryExtensionsMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 12, 22, 39, 495, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f90267ab-e120-46a2-a235-3cad215e7953"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 12, 22, 39, 495, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 12, 22, 39, 495, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 12, 22, 39, 495, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 12, 22, 39, 495, DateTimeKind.Local).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 1, 12, 22, 39, 495, DateTimeKind.Local).AddTicks(6993));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f90267ab-e120-46a2-a235-3cad215e7953"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 30, 15, 26, 4, 901, DateTimeKind.Local).AddTicks(3058));
        }
    }
}
