using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.Api.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelefonRehberleri_Kullanicilar_KullanıcıId",
                table: "TelefonRehberleri");

          

            migrationBuilder.RenameIndex(
                name: "IX_TelefonRehberleri_KullanıcıId",
                table: "TelefonRehberleri",
                newName: "IX_TelefonRehberleri_KullaniciId");

            migrationBuilder.AddColumn<string>(
                name: "ResimDosyası",
                table: "TelefonRehberleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TelefonRehberleri_Kullanicilar_KullaniciId",
                table: "TelefonRehberleri",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelefonRehberleri_Kullanicilar_KullaniciId",
                table: "TelefonRehberleri");

            migrationBuilder.DropColumn(
                name: "ResimDosyası",
                table: "TelefonRehberleri");

           

            migrationBuilder.RenameIndex(
                name: "IX_TelefonRehberleri_KullaniciId",
                table: "TelefonRehberleri",
                newName: "IX_TelefonRehberleri_KullanıcıId");

            migrationBuilder.AddForeignKey(
                name: "FK_TelefonRehberleri_Kullanicilar_KullanıcıId",
                table: "TelefonRehberleri",
                column: "KullanıcıId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
