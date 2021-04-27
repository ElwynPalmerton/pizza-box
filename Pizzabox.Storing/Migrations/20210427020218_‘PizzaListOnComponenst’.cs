using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzabox.Storing.Migrations
{
    public partial class PizzaListOnComponenst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 6L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "EntityId", "APizzaEntityId", "Name", "Price" },
                values: new object[] { 6L, null, "Pineapple", 3.00m });
        }
    }
}
