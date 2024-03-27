using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Items",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Code = table.Column<int>(type: "int", nullable: false),
                Value = table.Column<string>(type: "nvarchar(255)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("Item_PK", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Items");
    }
}
