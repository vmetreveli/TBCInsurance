using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infra.Data.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CompanyPrice",
                table: "Prices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyPrice",
                table: "Prices");
        }
    }
}
