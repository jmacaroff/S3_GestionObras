using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObras.Migrations
{
    public partial class AddClientesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NRCUIT = table.Column<string>(type: "nchar(11)", maxLength: 11, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
