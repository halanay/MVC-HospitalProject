using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital2.Migrations
{
    public partial class anabilimdaliString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnaBilimDaliName",
                table: "AnaBilimDali",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnaBilimDaliName",
                table: "AnaBilimDali",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
