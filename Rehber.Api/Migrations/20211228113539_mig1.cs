using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.Api.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNumarası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonRehberleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonNumarası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıId = table.Column<int>(type: "int", nullable: false),
                    OluşturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonRehberleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonRehberleri_Kullanıcılar_KullanıcıId",
                        column: x => x.KullanıcıId,
                        principalTable: "Kullanıcılar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelefonRehberleri_KullanıcıId",
                table: "TelefonRehberleri",
                column: "KullanıcıId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelefonRehberleri");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");
        }
    }
}
