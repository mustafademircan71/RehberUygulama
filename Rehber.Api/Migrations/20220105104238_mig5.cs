using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.Api.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefonNumarası",
                table: "TelefonRehberleri",
                newName: "TelefonNumarasi");

            migrationBuilder.RenameColumn(
                name: "ResimDosyası",
                table: "TelefonRehberleri",
                newName: "ResimDosyasi");

            migrationBuilder.RenameColumn(
                name: "TelefonNumarası",
                table: "Kullanicilar",
                newName: "TelefonNumarasi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefonNumarasi",
                table: "TelefonRehberleri",
                newName: "TelefonNumarası");

            migrationBuilder.RenameColumn(
                name: "ResimDosyasi",
                table: "TelefonRehberleri",
                newName: "ResimDosyası");

            migrationBuilder.RenameColumn(
                name: "TelefonNumarasi",
                table: "Kullanicilar",
                newName: "TelefonNumarası");
        }
    }
}
