using Microsoft.EntityFrameworkCore.Migrations;

namespace Rehber.Api.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelefonRehberleri_Kullanıcılar_KullanıcıId",
                table: "TelefonRehberleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanıcılar",
                table: "Kullanıcılar");

            migrationBuilder.RenameTable(
                name: "Kullanıcılar",
                newName: "Kullanicilar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanicilar",
                table: "Kullanicilar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TelefonRehberleri_Kullanicilar_KullanıcıId",
                table: "TelefonRehberleri",
                column: "KullanıcıId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelefonRehberleri_Kullanicilar_KullanıcıId",
                table: "TelefonRehberleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanicilar",
                table: "Kullanicilar");

            migrationBuilder.RenameTable(
                name: "Kullanicilar",
                newName: "Kullanıcılar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanıcılar",
                table: "Kullanıcılar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TelefonRehberleri_Kullanıcılar_KullanıcıId",
                table: "TelefonRehberleri",
                column: "KullanıcıId",
                principalTable: "Kullanıcılar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
