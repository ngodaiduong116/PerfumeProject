using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePerfume.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 5, 17, 55, 13, 557, DateTimeKind.Local).AddTicks(6423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 5, 17, 12, 21, 695, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 5, 17, 55, 13, 574, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Desccription", "Name", "NormalizedName" },
                values: new object[] { new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"), "8d1dd22b-d44b-40e8-a469-d57bf2eeba80", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("888584d2-49cd-4d36-88a2-170751c7dca5"), 0, "cf03ecd2-ef0c-413d-91e4-29a29954e241", new DateTime(1999, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ngodaiduong116@gmail.com", true, "Duong", "Ngo Dai", false, null, "ngodaiduong116@gmail.com", "admin", "AQAAAAEAACcQAAAAEBNyLaI9RN7IDlS3gYO4h9UjCntC1Q8EtbYsen6JIujfllG7FkKCEbSE2tZWXp3g3A==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"), new Guid("888584d2-49cd-4d36-88a2-170751c7dca5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("888584d2-49cd-4d36-88a2-170751c7dca5"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"), new Guid("888584d2-49cd-4d36-88a2-170751c7dca5") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 5, 17, 12, 21, 695, DateTimeKind.Local).AddTicks(7769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 5, 17, 55, 13, 557, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 5, 17, 12, 21, 712, DateTimeKind.Local).AddTicks(9519));
        }
    }
}
