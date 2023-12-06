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
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                values: new object[] { 1L, "500.230.222-32", "Agatha.linhares@gmail.com", null, "Agatha", new byte[] { 5, 94, 115, 78, 188, 245, 73, 29, 23, 179, 226, 25, 163, 49, 221, 232, 219, 47, 112, 1, 122, 29, 196, 227, 62, 134, 62, 41, 172, 222, 104, 146, 121, 116, 177, 123, 153, 188, 200, 223, 168, 183, 55, 207, 25, 140, 81, 17, 207, 183, 176, 127, 186, 5, 110, 101, 203, 224, 235, 221, 140, 35, 191, 93 }, new byte[] { 232, 200, 122, 24, 10, 96, 21, 101, 12, 79, 48, 171, 195, 90, 65, 114, 164, 59, 49, 219, 12, 76, 103, 165, 233, 80, 178, 171, 36, 192, 134, 70, 200, 38, 115, 222, 40, 211, 24, 172, 40, 19, 71, 200, 144, 187, 208, 197, 200, 118, 173, 213, 147, 94, 178, 152, 109, 24, 168, 53, 228, 6, 59, 18, 252, 210, 230, 247, 148, 238, 70, 130, 117, 19, 81, 84, 225, 71, 168, 189, 189, 16, 59, 11, 130, 73, 244, 58, 215, 233, 89, 217, 66, 229, 142, 49, 13, 253, 93, 145, 201, 102, 114, 144, 103, 30, 33, 96, 0, 111, 200, 37, 161, 146, 81, 244, 48, 138, 200, 74, 31, 61, 121, 42, 34, 168, 56, 218 }, 0 });

            migrationBuilder.InsertData(
                table: "Estabelecimentos",
                columns: new[] { "Id", "CEP", "Cnpj", "Complemento", "Email", "Endereco", "Nome_est", "Numero_est", "Senha_hash", "Senha_salt", "TipoUsuario", "UsuarioId" },
                values: new object[] { 1L, 2223001, "12123456/0001-12", 4, null, "Av. Ramiz Galvão", "CutsCuts", 1082, null, null, 1, 1L });

            migrationBuilder.InsertData(
                table: "Agendamentos",
                columns: new[] { "Id", "EstabelecimentoId", "FormasDePagamento", "Hora_ag", "Local_ag", "UsuarioId", "data_ag" },
                values: new object[] { 1L, 1L, 0, new DateTime(2023, 12, 5, 23, 48, 11, 810, DateTimeKind.Local).AddTicks(3767), "Av. Ramiz Galvão", 1L, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Local) });

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
