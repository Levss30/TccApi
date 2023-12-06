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
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<int>(type: "int", nullable: false),
                    Senha_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Numero_est = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
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
                values: new object[] { 1L, "500.230.222-32", "Agatha.linhares@gmail.com", null, "Agatha", new byte[] { 184, 225, 243, 1, 89, 22, 122, 86, 209, 97, 148, 145, 198, 240, 225, 152, 36, 25, 220, 160, 50, 37, 192, 72, 77, 79, 9, 92, 187, 222, 96, 5, 231, 81, 74, 28, 62, 172, 168, 112, 209, 193, 189, 152, 68, 152, 117, 250, 158, 21, 178, 126, 168, 140, 79, 166, 8, 165, 178, 221, 36, 155, 2, 76 }, new byte[] { 37, 255, 62, 248, 42, 159, 72, 49, 165, 203, 2, 195, 161, 230, 177, 163, 167, 217, 60, 173, 7, 254, 48, 124, 104, 176, 48, 133, 172, 206, 34, 252, 48, 74, 11, 193, 124, 236, 56, 188, 48, 222, 251, 225, 9, 23, 130, 223, 100, 156, 237, 156, 186, 21, 159, 119, 103, 65, 199, 83, 200, 194, 167, 216, 247, 171, 182, 156, 14, 123, 183, 147, 24, 142, 171, 99, 30, 69, 193, 123, 32, 19, 96, 9, 152, 242, 12, 224, 48, 143, 187, 129, 40, 20, 216, 47, 163, 7, 68, 253, 32, 3, 10, 99, 189, 102, 138, 43, 5, 146, 199, 173, 114, 74, 16, 232, 54, 54, 244, 236, 80, 186, 110, 148, 157, 136, 231, 145 }, 0 });

            migrationBuilder.InsertData(
                table: "Estabelecimentos",
                columns: new[] { "Id", "CEP", "Cnpj", "Complemento", "Email", "Endereco", "Nome_est", "Numero_est", "Senha_hash", "Senha_salt", "Telefone", "UsuarioId" },
                values: new object[] { 1L, "02223001", "12123456/0001-12", 4, null, "Av. Ramiz Galvão", "CutsCuts", 1082, null, null, 934958271, 1L });

            migrationBuilder.InsertData(
                table: "Agendamentos",
                columns: new[] { "Id", "EstabelecimentoId", "FormasDePagamento", "Hora_ag", "Local_ag", "UsuarioId", "data_ag" },
                values: new object[] { 1L, 1L, 0, new DateTime(2023, 12, 6, 3, 27, 28, 459, DateTimeKind.Local).AddTicks(7530), "Av. Ramiz Galvão", 1L, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) });

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
