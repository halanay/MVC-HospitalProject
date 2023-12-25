using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital2.Migrations
{
    public partial class profilgüncelle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Boy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cinsiyet",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DogumTarihi",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kilo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Boy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Kilo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Users");
        }
    }
}
