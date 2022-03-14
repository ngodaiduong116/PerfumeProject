using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePerfume.Data.Migrations
{
    public partial class ChangeFileLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "ProductIamge",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductIamge",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 6, 15, 27, 54, 572, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"),
                column: "ConcurrencyStamp",
                value: "e9163743-8f45-4eab-bfa1-8a2b20d5ea79");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("888584d2-49cd-4d36-88a2-170751c7dca5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d32c0002-8fbc-482a-8502-e498e46a9187", "AQAAAAEAACcQAAAAEDeAWl83GYZmNOm2RCPHl0L84ED6yTKAUq0UcNeJFLArABFOgRqIvMc6qlmEmYtU+A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "ProductIamge",
                newName: "Created");

            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductIamge",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 6, 10, 42, 23, 205, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"),
                column: "ConcurrencyStamp",
                value: "f85120c9-a89f-4e3b-9a32-8343bb68b2f4");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("888584d2-49cd-4d36-88a2-170751c7dca5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f78e9fc-fc96-4a3a-acd7-5a62f175bf85", "AQAAAAEAACcQAAAAEBpD8lNmeKp6X93fKPk0SQR2tVta96+noARcyFYKSbZPBhvcPN73NAyD8yvHJ4lMig==" });
        }
    }
}
