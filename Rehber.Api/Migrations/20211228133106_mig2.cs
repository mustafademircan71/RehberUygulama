using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.Api.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OluşturmaTarihi",
                table: "TelefonRehberleri",
                newName: "OlusturmaTarihi");

            migrationBuilder.RenameColumn(
                name: "GüncellemeTarihi",
                table: "TelefonRehberleri",
                newName: "GuncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "OluşturmaTarihi",
                table: "Kullanıcılar",
                newName: "OlusturmaTarihi");

            migrationBuilder.RenameColumn(
                name: "GüncellemeTarihi",
                table: "Kullanıcılar",
                newName: "GuncellemeTarihi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OlusturmaTarihi",
                table: "TelefonRehberleri",
                newName: "OluşturmaTarihi");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "TelefonRehberleri",
                newName: "GüncellemeTarihi");

            migrationBuilder.RenameColumn(
                name: "OlusturmaTarihi",
                table: "Kullanıcılar",
                newName: "OluşturmaTarihi");

            migrationBuilder.RenameColumn(
                name: "GuncellemeTarihi",
                table: "Kullanıcılar",
                newName: "GüncellemeTarihi");
        }
    }
}
