using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzabox.Storing.Migrations
{
    public partial class RemoveTheExtraPizzaFieldFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pizzas_PizzaEntityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PizzaEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PizzaEntityId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PizzaEntityId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaEntityId",
                table: "Orders",
                column: "PizzaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pizzas_PizzaEntityId",
                table: "Orders",
                column: "PizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
