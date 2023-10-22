using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Email", "Foto", "Latitude", "Longitude", "Nome", "Preferencia", "Senha_hash", "Senha_salt", "TipoUsuario" },
                values: new object[] { 1L, "12345678910", "anilmar@gmail.com", null, null, null, "anilmar", 1, new byte[] { 225, 55, 160, 126, 242, 104, 10, 55, 151, 16, 135, 57, 55, 11, 180, 194, 249, 229, 202, 168, 137, 214, 220, 252, 51, 109, 39, 35, 82, 158, 201, 160, 18, 49, 204, 252, 236, 71, 24, 244, 203, 40, 223, 27, 211, 184, 168, 161, 161, 45, 183, 6, 106, 113, 197, 196, 15, 49, 79, 213, 107, 129, 208, 151 }, new byte[] { 232, 158, 12, 73, 176, 192, 199, 208, 180, 211, 173, 30, 64, 222, 152, 157, 50, 229, 242, 190, 198, 232, 113, 223, 104, 183, 39, 194, 91, 249, 54, 225, 118, 158, 19, 8, 151, 30, 133, 167, 158, 39, 35, 39, 79, 110, 0, 102, 138, 33, 238, 9, 62, 251, 42, 10, 157, 74, 41, 100, 243, 47, 180, 254, 140, 156, 234, 37, 25, 129, 4, 207, 71, 89, 251, 253, 67, 125, 161, 163, 16, 220, 16, 100, 191, 140, 165, 3, 236, 214, 48, 170, 47, 169, 117, 249, 109, 73, 187, 85, 246, 52, 161, 4, 211, 247, 138, 88, 81, 244, 175, 244, 44, 163, 241, 211, 164, 216, 189, 13, 201, 7, 186, 40, 90, 54, 39, 13 }, 2 });

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
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
