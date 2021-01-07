using Microsoft.EntityFrameworkCore.Migrations;

namespace CICD_API.Migrations
{
    public partial class ChangeBDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Collector",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Editeur",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Game",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Game",
                newName: "summary");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Game",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Game",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "summary",
                table: "Game",
                newName: "Titre");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Game",
                newName: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Collector",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Editeur",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prix",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Game",
                type: "int",
                nullable: true);
        }
    }
}
