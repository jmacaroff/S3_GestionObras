using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObras.Migrations
{
    public partial class AddProveedoresToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "varchar(100)", nullable: false),
                    NRCUIT = table.Column<string>(type: "nchar(11)", maxLength: 11, nullable: false),
                    NRCBU = table.Column<string>(type: "nchar(22)", maxLength: 22, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
