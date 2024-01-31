using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaVirtualEstagio.Migrations
{
    /// <inheritdoc />
    public partial class LojaVirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ChaveVerificacao = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    LastToken = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    IsVerificado = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItems_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItems_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Ativo", "Excluido", "Nome", "Url" },
                values: new object[,]
                {
                    { 1, true, false, "Sapato", "url_sapato" },
                    { 2, true, false, "Sandalia", "url_sandalia" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "ChaveVerificacao", "Email", "Excluido", "IsDeleted", "IsVerificado", "LastToken", "Login", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, true, "chave-unico-para-verificacao", "Gustavo@example.com", false, false, true, "token-unico", "Guga123", "Gustavo", "senha123" },
                    { 2, true, "outra-chave-unico", "Henrique@example.com", false, false, true, "outro-token-unico", "Henrique123", "Henrique", "senha12345" }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "DataPedido", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 12, 7, 53, 646, DateTimeKind.Local).AddTicks(4758), 1 },
                    { 2, new DateTime(2024, 1, 31, 12, 7, 53, 646, DateTimeKind.Local).AddTicks(4784), 2 }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "CategoriaId", "Excluido", "Nome", "Quantidade", "Url" },
                values: new object[,]
                {
                    { 1, true, 2, false, "Sandalia1", 100, "url_sandalia" },
                    { 2, true, 2, false, "Sandalia2", 80, "url_sandalia" },
                    { 3, true, 2, false, "Sandalia3", 50, "url_sandalia" },
                    { 4, false, 2, true, "Sandalia4", 50, "url_sandalia" },
                    { 5, true, 1, false, "Sapato1", 45, "url_sapato" },
                    { 6, true, 1, false, "Sapato2", 10, "url_sapato" },
                    { 7, true, 1, false, "Sapato3", 30, "url_sapato" },
                    { 8, false, 1, true, "Sapato4", 10, "url_sapato" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "PedidoItems",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItems_ProdutoId",
                table: "PedidoItems",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItems");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
