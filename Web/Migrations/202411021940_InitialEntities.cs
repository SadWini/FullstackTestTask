using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations;

public partial class InitialEntities : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false),
                SenderSity = table.Column<string>(nullable: false),
                SenderAddress = table.Column<string>(nullable: false),
                RecipientSity = table.Column<string>(nullable: false),
                RecipientAddress = table.Column<string>(nullable: false),
                PickupDate = table.Column<DateTimeOffset>(nullable: false),
                Weight = table.Column<decimal>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Students");
    }
}