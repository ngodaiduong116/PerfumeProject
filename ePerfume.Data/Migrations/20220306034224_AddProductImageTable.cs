using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePerfume.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 5, 17, 55, 13, 557, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.CreateTable(
                name: "ProductIamge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoftOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIamge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductIamge_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductIamge_ProductId",
                table: "ProductIamge",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductIamge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 5, 17, 55, 13, 557, DateTimeKind.Local).AddTicks(6423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 5, 17, 55, 13, 574, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("24973248-499c-4855-9d60-d56bd75b3ba5"),
                column: "ConcurrencyStamp",
                value: "8d1dd22b-d44b-40e8-a469-d57bf2eeba80");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("888584d2-49cd-4d36-88a2-170751c7dca5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf03ecd2-ef0c-413d-91e4-29a29954e241", "AQAAAAEAACcQAAAAEBNyLaI9RN7IDlS3gYO4h9UjCntC1Q8EtbYsen6JIujfllG7FkKCEbSE2tZWXp3g3A==" });
        }
    }
}
