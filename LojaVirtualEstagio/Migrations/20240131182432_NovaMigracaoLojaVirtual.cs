using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVirtualEstagio.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigracaoLojaVirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId1",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_UsuarioId1",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Pedidos");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId1",
                table: "Pedidos",
                column: "UsuarioId1",
                unique: true,
                filter: "[UsuarioId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId1",
                table: "Pedidos",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
