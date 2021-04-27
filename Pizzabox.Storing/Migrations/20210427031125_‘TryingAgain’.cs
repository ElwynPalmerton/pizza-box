using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzabox.Storing.Migrations
{
    public partial class TryingAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderEntityId1",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderEntityId1",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderEntityId1",
                table: "Pizzas");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "OrderEntityId1",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityId1",
                table: "Pizzas",
                column: "OrderEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderEntityId1",
                table: "Pizzas",
                column: "OrderEntityId1",
                principalTable: "Orders",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
