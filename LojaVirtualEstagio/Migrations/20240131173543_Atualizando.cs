using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVirtualEstagio.Migrations
{
    /// <inheritdoc />
    public partial class Atualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataPedido",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataPedido",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataPedido",
                value: new DateTime(2024, 1, 31, 12, 7, 53, 646, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataPedido",
                value: new DateTime(2024, 1, 31, 12, 7, 53, 646, DateTimeKind.Local).AddTicks(4784));
        }
    }
}
