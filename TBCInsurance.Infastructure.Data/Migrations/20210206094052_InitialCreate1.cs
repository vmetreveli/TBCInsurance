using Microsoft.EntityFrameworkCore.Migrations;

namespace TBCInsurance.Infastructure.Data.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SexId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SexId",
                table: "Students",
                column: "SexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Gender_SexId",
                table: "Students",
                column: "SexId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Gender_SexId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_Students_SexId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SexId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }
    }
}
