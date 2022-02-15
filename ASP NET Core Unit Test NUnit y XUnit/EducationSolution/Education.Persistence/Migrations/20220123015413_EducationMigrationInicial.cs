using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("9be73948-eb42-4c1b-b622-76db57a8b803"), "Curso de c# basico", new DateTime(2022, 1, 22, 20, 54, 13, 639, DateTimeKind.Local).AddTicks(8168), new DateTime(2024, 1, 22, 20, 54, 13, 640, DateTimeKind.Local).AddTicks(7068), 56m, "C# desde cero hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("5941e611-b68d-49c8-8643-b25ee342750a"), "Curso de java", new DateTime(2022, 1, 22, 20, 54, 13, 640, DateTimeKind.Local).AddTicks(7576), new DateTime(2024, 1, 22, 20, 54, 13, 640, DateTimeKind.Local).AddTicks(7581), 25m, "Master en Java spring desde las raices" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("9bd5c5d1-80e8-4561-b3ea-6c0abdb742a4"), "Curso de unit test para net core", new DateTime(2022, 1, 22, 20, 54, 13, 640, DateTimeKind.Local).AddTicks(7590), new DateTime(2024, 1, 22, 20, 54, 13, 640, DateTimeKind.Local).AddTicks(7591), 1000m, "Master en UNIT Test con CQRS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
