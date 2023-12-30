using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital2.Migrations
{
    public partial class tableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaBilimDalis",
                columns: table => new
                {
                    AnaBilimDaliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaBilimDaliName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaBilimDalis", x => x.AnaBilimDaliId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polikliniks",
                columns: table => new
                {
                    PoliklinikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikIsmi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnaBilimDaliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polikliniks", x => x.PoliklinikId);
                    table.ForeignKey(
                        name: "FK_Polikliniks_AnaBilimDalis_AnaBilimDaliId",
                        column: x => x.AnaBilimDaliId,
                        principalTable: "AnaBilimDalis",
                        principalColumn: "AnaBilimDaliId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doktors",
                columns: table => new
                {
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktarAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoliklinikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktors", x => x.DoktorId);
                    table.ForeignKey(
                        name: "FK_Doktors_Polikliniks_PoliklinikId",
                        column: x => x.PoliklinikId,
                        principalTable: "Polikliniks",
                        principalColumn: "PoliklinikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doktors_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktors",
                        principalColumn: "DoktorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoktorId",
                table: "Appointments",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktors_PoliklinikId",
                table: "Doktors",
                column: "PoliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_Polikliniks_AnaBilimDaliId",
                table: "Polikliniks",
                column: "AnaBilimDaliId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doktors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Polikliniks");

            migrationBuilder.DropTable(
                name: "AnaBilimDalis");
        }
    }
}
