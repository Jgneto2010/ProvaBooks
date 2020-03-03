using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class testes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoryes",
                columns: table => new
                {
                    ID_CATEGORY = table.Column<Guid>(nullable: false),
                    Name_CATEGORY = table.Column<string>(type: "varchar(40)", nullable: false),
                    IdProduct = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoryes", x => x.ID_CATEGORY);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID_PRODUCT = table.Column<Guid>(nullable: false),
                    Name_Product = table.Column<string>(type: "varchar(40)", nullable: false),
                    Price = table.Column<string>(type: "varchar(40)", nullable: false),
                    IdCategory = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID_PRODUCT);
                    table.ForeignKey(
                        name: "FK_Products_Categoryes_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categoryes",
                        principalColumn: "ID_CATEGORY",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categoryes");
        }
    }
}
