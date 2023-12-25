using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital2.Migrations
{
    public partial class anabilimdali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polikliniks_AnaBilimDali_AnaBilimDaliId",
                table: "Polikliniks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnaBilimDali",
                table: "AnaBilimDali");

            migrationBuilder.RenameTable(
                name: "AnaBilimDali",
                newName: "AnaBilimDalis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnaBilimDalis",
                table: "AnaBilimDalis",
                column: "AnaBilimDaliId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polikliniks_AnaBilimDalis_AnaBilimDaliId",
                table: "Polikliniks",
                column: "AnaBilimDaliId",
                principalTable: "AnaBilimDalis",
                principalColumn: "AnaBilimDaliId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polikliniks_AnaBilimDalis_AnaBilimDaliId",
                table: "Polikliniks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnaBilimDalis",
                table: "AnaBilimDalis");

            migrationBuilder.RenameTable(
                name: "AnaBilimDalis",
                newName: "AnaBilimDali");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnaBilimDali",
                table: "AnaBilimDali",
                column: "AnaBilimDaliId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polikliniks_AnaBilimDali_AnaBilimDaliId",
                table: "Polikliniks",
                column: "AnaBilimDaliId",
                principalTable: "AnaBilimDali",
                principalColumn: "AnaBilimDaliId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
