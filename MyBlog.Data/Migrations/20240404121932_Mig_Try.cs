using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig_Try : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a969330d-5dcd-4221-bf16-3555525deee6", "AQAAAAIAAYagAAAAELEgl0VhPF3kZe93RoaLWtiAAD22ImRHb2WV4hR7/Q81bBPF9tWm0TUDpMI83q9Q+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a516c27a-84c2-4e88-bce5-165dc0143f5d", "AQAAAAIAAYagAAAAENy8ZhsyiUZAi6P58xLpDVYxtWG5faQpftQUxRyKrOj9yzzsvk53BzqsP9LY5x8Jlw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("eeb3a51f-5450-4c4f-8562-550d2deae903"), 0, "7877d411-ae18-4f32-8ad2-aca0ce3e29ce", "deneme@gmail.com", false, "Çağatay", new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"), "Bayraktar", false, null, "DENEME@GMAİL.COM", "CANERBOB ", "AQAAAAIAAYagAAAAENKIlopouKrvsWfXnxuc38/U3e+Lyj7ZQFUNxDXdmrD64VBL5FTi5N8Tq71Z/lQx5A==", "0555 555 55 11", false, null, false, "CanerBob" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eeb3a51f-5450-4c4f-8562-550d2deae903"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 12, 39, 25, 186, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f90267ab-e120-46a2-a235-3cad215e7953"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 12, 39, 25, 186, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("17e138ba-5416-47de-bb0d-39fa981697f1"),
                column: "ConcurrencyStamp",
                value: "2016ce4c-af71-4f8e-a7b6-2e66578fd9d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bcb92afc-a26c-4e9c-bfa8-802dfcaf9de7"),
                column: "ConcurrencyStamp",
                value: "84d4c67c-2e9c-43f7-95fc-d64be4ea52f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a860501-de39-474c-9fa0-91d8d7dbde05"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1573ebc6-4373-47e3-ae4f-07f72e1352bc", "AQAAAAIAAYagAAAAEDdfvBt/XPqGS+zmtlwRBgZmWf2UTH7Wxx918jP0FMiXN4Cg4fIZ40HZL/FpGbIoUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8bbd8f46-95c1-4e5f-bf8b-dc5a1a8630dd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6890191-f65b-4451-a902-c920830b682c", "AQAAAAIAAYagAAAAEBsfTO8NdI/pHkpCszYK94h8sR5v7jr7p4EMc12SXYgvUfZFCR0rAaKN82ig9EMOkg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0eb19997-5c94-4fcd-a327-fdd99e7b807c"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 12, 39, 25, 187, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af5fdfe2-a680-4eb9-929e-8270f1ae2849"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 12, 39, 25, 187, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f406068b-ec45-4d22-b22e-084b4705d8b5"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 12, 39, 25, 187, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5a4aab2-01f0-407b-a20f-6cbd053efd76"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 4, 12, 39, 25, 187, DateTimeKind.Local).AddTicks(1980));
        }
    }
}
