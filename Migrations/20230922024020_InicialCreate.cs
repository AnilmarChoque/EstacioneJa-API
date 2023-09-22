using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Email", "Foto", "Latitude", "Longitude", "Nome", "Preferencia", "Senha_hash", "Senha_salt", "TipoUsuario" },
                values: new object[,]
                {
                    { 1L, 12345678910L, "anilmar@gmail.com", null, null, null, "anilmar", 0, new byte[] { 163, 185, 216, 39, 164, 98, 20, 101, 5, 89, 16, 224, 132, 108, 207, 160, 26, 42, 247, 29, 50, 206, 64, 125, 8, 146, 227, 132, 181, 223, 63, 38, 92, 196, 248, 100, 90, 103, 37, 92, 117, 180, 151, 240, 66, 157, 214, 178, 29, 148, 215, 31, 29, 87, 193, 51, 32, 191, 230, 110, 77, 167, 122, 232 }, new byte[] { 218, 40, 215, 209, 153, 249, 251, 239, 157, 194, 154, 52, 62, 89, 163, 126, 90, 53, 227, 35, 194, 249, 135, 208, 1, 176, 243, 244, 71, 249, 77, 177, 13, 100, 53, 155, 226, 134, 75, 67, 230, 146, 105, 230, 206, 58, 192, 248, 168, 176, 125, 10, 29, 38, 173, 134, 124, 236, 16, 190, 157, 65, 11, 16, 47, 97, 187, 60, 189, 84, 21, 232, 230, 231, 165, 20, 31, 209, 236, 100, 213, 148, 114, 39, 91, 162, 68, 250, 169, 20, 209, 243, 94, 44, 244, 248, 208, 2, 110, 119, 216, 28, 209, 227, 80, 63, 144, 222, 106, 194, 160, 81, 14, 149, 222, 224, 154, 189, 241, 54, 141, 230, 122, 230, 84, 232, 248, 2 }, 1 },
                    { 2L, 12345678911L, "natanael@outlook.com", null, null, null, "natanael", 0, new byte[] { 179, 3, 50, 93, 8, 101, 95, 86, 122, 75, 131, 182, 156, 92, 39, 227, 39, 228, 102, 247, 115, 120, 20, 225, 225, 70, 48, 205, 238, 188, 171, 23, 234, 44, 183, 162, 71, 155, 111, 115, 254, 24, 156, 54, 22, 44, 173, 1, 38, 37, 228, 58, 39, 141, 146, 0, 60, 118, 150, 254, 241, 8, 4, 195 }, new byte[] { 193, 174, 205, 111, 102, 95, 12, 138, 48, 145, 70, 19, 167, 182, 106, 220, 90, 250, 200, 46, 212, 133, 197, 123, 159, 133, 95, 138, 168, 190, 241, 75, 170, 232, 244, 233, 169, 208, 102, 87, 100, 217, 27, 7, 38, 79, 67, 101, 152, 214, 20, 121, 178, 110, 197, 195, 253, 209, 56, 161, 232, 207, 16, 70, 58, 231, 157, 45, 17, 177, 220, 221, 139, 148, 237, 67, 115, 69, 229, 49, 81, 189, 47, 116, 16, 239, 143, 140, 93, 125, 180, 227, 249, 69, 52, 120, 118, 245, 43, 212, 25, 120, 40, 40, 152, 128, 21, 181, 135, 83, 122, 31, 23, 17, 99, 27, 181, 89, 107, 182, 107, 173, 140, 109, 118, 170, 195, 31 }, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
