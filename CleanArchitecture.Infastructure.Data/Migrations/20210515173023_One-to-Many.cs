using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CleanArchitecture.Infra.Data.Migrations
{
    public partial class OnetoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Markets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MarketId",
                table: "Companies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_MarketId",
                table: "Companies",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Markets_MarketId",
                table: "Companies",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Markets_MarketId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_MarketId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "MarketId",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: true),
                    CompanyPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    MarketId = table.Column<int>(type: "integer", nullable: true),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CompanyId",
                table: "Prices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_MarketId",
                table: "Prices",
                column: "MarketId");
        }
    }
}
