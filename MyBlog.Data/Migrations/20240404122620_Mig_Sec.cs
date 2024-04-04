using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_Sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 26, 19, 825, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f90267ab-e120-46a2-a235-3cad215e7953"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 26, 19, 825, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17e138ba-5416-47de-bb0d-39fa981697f1"),
                column: "ConcurrencyStamp",
                value: "e7b9ea68-115f-4acb-89eb-35dd43133bbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcb92afc-a26c-4e9c-bfa8-802dfcaf9de7"),
                column: "ConcurrencyStamp",
                value: "81625d80-e331-4ba3-8f28-458659ece754");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a860501-de39-474c-9fa0-91d8d7dbde05"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fb94cd6-7e3c-4a58-8f7a-8ddff5ab1869", "AQAAAAIAAYagAAAAEBYH0fevVFkYbIVZYz5fkk35xwL2HarXSvV73UkHHzt6r0Vnl8OrxS/eJVrCWd0DDg==", "c562891c-23cb-49c2-9a0a-59689d4be0bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2426d847-43ec-4793-8379-0c6bf3e25ba5", "AQAAAAIAAYagAAAAEFLYdF7RMqxSVS8Y9Bnb9vAUwP9zyBJarj2IuUCuqRNRO1c2SDm+r4pRC69fMbut8A==", "b56e5e92-de63-4d9d-ac93-ba6c2c29e149" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeb3a51f-5450-4c4f-8562-550d2deae903"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6a451d6-c844-4936-9c0d-ca383d6bcc5f", "AQAAAAIAAYagAAAAEBbzBzmKCkaV041oJrV9CHSj5ewL42Jn2Apk48CHPZcE6B1IKB+EhjZ9W/W+aYhdkA==", "ff404cf4-9232-49e4-8eba-733d677a9ff1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 26, 19, 825, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 26, 19, 825, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 26, 19, 825, DateTimeKind.Local).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 26, 19, 825, DateTimeKind.Local).AddTicks(8595));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 19, 31, 955, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f90267ab-e120-46a2-a235-3cad215e7953"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 19, 31, 955, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17e138ba-5416-47de-bb0d-39fa981697f1"),
                column: "ConcurrencyStamp",
                value: "60bf787c-7fae-4cd0-a45c-c585d3af4ce5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcb92afc-a26c-4e9c-bfa8-802dfcaf9de7"),
                column: "ConcurrencyStamp",
                value: "f97bfee1-4cd1-474b-baee-73263256ab01");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a860501-de39-474c-9fa0-91d8d7dbde05"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a969330d-5dcd-4221-bf16-3555525deee6", "AQAAAAIAAYagAAAAELEgl0VhPF3kZe93RoaLWtiAAD22ImRHb2WV4hR7/Q81bBPF9tWm0TUDpMI83q9Q+A==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a516c27a-84c2-4e88-bce5-165dc0143f5d", "AQAAAAIAAYagAAAAENy8ZhsyiUZAi6P58xLpDVYxtWG5faQpftQUxRyKrOj9yzzsvk53BzqsP9LY5x8Jlw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeb3a51f-5450-4c4f-8562-550d2deae903"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7877d411-ae18-4f32-8ad2-aca0ce3e29ce", "AQAAAAIAAYagAAAAENKIlopouKrvsWfXnxuc38/U3e+Lyj7ZQFUNxDXdmrD64VBL5FTi5N8Tq71Z/lQx5A==", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 15, 19, 31, 956, DateTimeKind.Local).AddTicks(1513));
        }
    }
}
