using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundoParcial2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registros",
                columns: table => new
                {
                    RegistroId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: false),
                    Problema = table.Column<string>(nullable: false),
                    Solucion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros", x => x.RegistroId);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistroId = table.Column<int>(nullable: false),
                    Problema = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroDetalle_registros_RegistroId",
                        column: x => x.RegistroId,
                        principalTable: "registros",
                        principalColumn: "RegistroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDetalle_RegistroId",
                table: "RegistroDetalle",
                column: "RegistroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroDetalle");

            migrationBuilder.DropTable(
                name: "registros");
        }
    }
}
