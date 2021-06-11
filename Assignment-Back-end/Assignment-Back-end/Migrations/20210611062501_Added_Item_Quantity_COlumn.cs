using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_Back_end.Migrations
{
    public partial class Added_Item_Quantity_COlumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemQuantity",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemQuantity",
                table: "Items");
        }
    }
}
