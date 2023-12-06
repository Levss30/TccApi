using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Senha_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome_est = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<int>(type: "int", nullable: false),
                    Senha_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Numero_est = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora_ag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local_ag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_ag = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    FormasDePagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Email", "Foto", "Nome", "Senha_hash", "Senha_salt", "TipoUsuario" },
                values: new object[] { 1L, 50023022232L, "Agatha.linhares@gmail.com", null, "Agatha", new byte[] { 99, 19, 197, 131, 175, 169, 231, 57, 78, 116, 111, 119, 253, 36, 139, 75, 12, 110, 191, 58, 81, 183, 11, 127, 210, 194, 221, 226, 101, 171, 81, 173, 203, 112, 131, 94, 135, 56, 26, 25, 138, 95, 55, 136, 172, 239, 183, 213, 178, 37, 136, 111, 35, 33, 167, 63, 176, 43, 213, 115, 112, 126, 190, 224 }, new byte[] { 153, 18, 32, 53, 32, 56, 214, 176, 190, 32, 226, 191, 25, 161, 188, 30, 22, 222, 111, 113, 116, 192, 60, 125, 29, 144, 60, 105, 38, 250, 252, 168, 95, 24, 82, 125, 13, 70, 122, 209, 221, 102, 107, 251, 149, 205, 32, 166, 139, 58, 40, 123, 220, 161, 201, 93, 129, 172, 212, 200, 17, 105, 22, 108, 203, 184, 14, 128, 26, 52, 0, 28, 167, 53, 77, 240, 119, 72, 177, 172, 185, 81, 151, 81, 81, 63, 238, 140, 104, 14, 128, 174, 229, 135, 218, 200, 130, 225, 153, 153, 66, 217, 124, 204, 154, 68, 107, 77, 153, 249, 90, 10, 137, 142, 5, 173, 129, 225, 231, 239, 52, 210, 13, 125, 150, 180, 28, 248 }, 0 });

            migrationBuilder.InsertData(
                table: "Estabelecimentos",
                columns: new[] { "Id", "CEP", "Cnpj", "Complemento", "Email", "Endereco", "Nome_est", "Numero_est", "Senha_hash", "Senha_salt", "TipoUsuario", "UsuarioId" },
                values: new object[] { 1L, 2223001, "12123456/0001-12", 4, null, "Av. Ramiz Galvão", "CutsCuts", 1082, null, null, 1, 1L });

            migrationBuilder.InsertData(
                table: "Agendamentos",
                columns: new[] { "Id", "EstabelecimentoId", "FormasDePagamento", "Hora_ag", "Local_ag", "UsuarioId", "data_ag" },
                values: new object[] { 1L, 1L, 0, new DateTime(2023, 12, 5, 23, 25, 42, 96, DateTimeKind.Local).AddTicks(3410), "Av. Ramiz Galvão", 1L, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EstabelecimentoId",
                table: "Agendamentos",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioId",
                table: "Agendamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_UsuarioId",
                table: "Estabelecimentos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
