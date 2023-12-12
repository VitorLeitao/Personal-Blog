using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDAPI.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Textos_Usuarios_UserModelId",
                table: "Textos");

            migrationBuilder.DropIndex(
                name: "IX_Textos_UserModelId",
                table: "Textos");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Textos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Textos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Textos_UserModelId",
                table: "Textos",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Textos_Usuarios_UserModelId",
                table: "Textos",
                column: "UserModelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
