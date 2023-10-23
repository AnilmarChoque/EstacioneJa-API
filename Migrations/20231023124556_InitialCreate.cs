using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastro.Migrations
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferencia = table.Column<int>(type: "int", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Senha_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Senha_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estacionamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Secao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponibilidade = table.Column<int>(type: "int", nullable: false),
                    Andar = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<double>(type: "float", nullable: false),
                    Preferencia = table.Column<int>(type: "int", nullable: false),
                    EstacionamentoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagas_Estacionamentos_EstacionamentoId",
                        column: x => x.EstacionamentoId,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VagaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensores_Vagas_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioVagas",
                columns: table => new
                {
                    CodData = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forma_pagamento = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Receptor_pagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emissor_pagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocupacao_inicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocupacao_final = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VagaId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioVagas", x => x.CodData);
                    table.ForeignKey(
                        name: "FK_UsuarioVagas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioVagas_Vagas_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Email", "Foto", "Latitude", "Longitude", "Nome", "Preferencia", "Senha_hash", "Senha_salt", "TipoUsuario" },
                values: new object[] { 1L, "12345678910", "anilmar@gmail.com", null, null, null, "anilmar", 1, new byte[] { 178, 50, 158, 196, 98, 116, 196, 126, 13, 172, 216, 43, 83, 215, 206, 161, 57, 101, 225, 153, 216, 234, 86, 177, 36, 220, 3, 125, 246, 142, 62, 73, 22, 64, 103, 59, 30, 188, 10, 117, 103, 76, 186, 218, 91, 76, 124, 15, 139, 55, 107, 173, 191, 171, 108, 101, 197, 28, 39, 11, 145, 191, 118, 244 }, new byte[] { 184, 32, 149, 40, 161, 20, 78, 70, 46, 59, 117, 12, 192, 115, 20, 159, 19, 243, 40, 94, 150, 74, 144, 227, 143, 161, 102, 46, 9, 226, 146, 170, 214, 85, 245, 190, 66, 145, 164, 210, 69, 37, 105, 136, 25, 153, 100, 71, 159, 57, 234, 202, 160, 26, 159, 161, 133, 130, 184, 167, 35, 211, 175, 4, 208, 131, 155, 55, 9, 232, 16, 182, 174, 214, 12, 235, 134, 185, 76, 39, 40, 201, 12, 153, 86, 145, 111, 46, 10, 136, 56, 152, 66, 87, 103, 76, 138, 155, 121, 231, 83, 156, 40, 7, 180, 58, 164, 150, 95, 124, 122, 176, 226, 139, 219, 190, 93, 16, 120, 138, 58, 64, 60, 220, 211, 60, 25, 129 }, 2 });

            migrationBuilder.InsertData(
                table: "Estacionamentos",
                columns: new[] { "Id", "Nome", "Url", "UsuarioId" },
                values: new object[] { 1L, "Auto Park", null, 1L });

            migrationBuilder.InsertData(
                table: "Vagas",
                columns: new[] { "Id", "Andar", "Disponibilidade", "EstacionamentoId", "Latitude", "Longitude", "Numero", "Preferencia", "Secao" },
                values: new object[] { 1L, 1, 1, 1L, "68.4908", "-61.2506", 1.0, 1, "A1" });

            migrationBuilder.InsertData(
                table: "Sensores",
                columns: new[] { "Id", "Latitude", "Longitude", "VagaId" },
                values: new object[] { 1L, "68.4908", "-61.2506", 1L });

            migrationBuilder.InsertData(
                table: "UsuarioVagas",
                columns: new[] { "CodData", "Data", "Emissor_pagamento", "Forma_pagamento", "Ocupacao_final", "Ocupacao_inicial", "Receptor_pagamento", "UsuarioId", "VagaId" },
                values: new object[] { 1L, new DateTime(2023, 10, 23, 9, 45, 56, 899, DateTimeKind.Local).AddTicks(4665), "Anilmar", 1, new DateTime(2023, 10, 23, 9, 45, 56, 899, DateTimeKind.Local).AddTicks(4676), new DateTime(2023, 10, 23, 9, 45, 56, 899, DateTimeKind.Local).AddTicks(4675), "Auto Park", 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_UsuarioId",
                table: "Estacionamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensores_VagaId",
                table: "Sensores",
                column: "VagaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVagas_UsuarioId",
                table: "UsuarioVagas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVagas_VagaId",
                table: "UsuarioVagas",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EstacionamentoId",
                table: "Vagas",
                column: "EstacionamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensores");

            migrationBuilder.DropTable(
                name: "UsuarioVagas");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
