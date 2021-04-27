using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzabox.Storing.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Thin", 1.00m },
                    { 2L, "Thick", 2.00m },
                    { 3L, "Stuffed", 4.00m }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "EntityId",
                keyValue: 1L,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { "100 Uncle John Street", "888-888-JOHN" });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Small", 15.00m },
                    { 2L, "Medium", 20.00m },
                    { 3L, "Large", 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "EntityId", "APizzaEntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, null, "Pepperoni", 4.00m },
                    { 2L, null, "Peppers", 2.00m },
                    { 3L, null, "Spinach", 4.00m },
                    { 4L, null, "Anchovies", 3.00m },
                    { 5L, null, "Pineapple", 3.00m },
                    { 6L, null, "Pineapple", 3.00m },
                    { 7L, null, "Ham", 5.00m },
                    { 8L, null, "Mushrooms", 2.00m },
                    { 9L, null, "Sausage", 5.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Crust",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "EntityId",
                keyValue: 9L);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "EntityId",
                keyValue: 1L,
                columns: new[] { "Address", "PhoneNumber" },
                values: new object[] { null, null });
        }
    }
}
