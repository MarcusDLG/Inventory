using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class FixedOrderAndItemOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Items_ItemId",
                table: "ItemOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrder_Order_OrderId",
                table: "ItemOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ItemOrder",
                newName: "ItemOrders");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ItemOrders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_OrderId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrder_ItemId",
                table: "ItemOrders",
                newName: "IX_ItemOrders_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "ItemOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Items_ItemId",
                table: "ItemOrders",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Orders_OrderId",
                table: "ItemOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_LocationId",
                table: "Orders",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Items_ItemId",
                table: "ItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Orders_OrderId",
                table: "ItemOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_LocationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LocationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemOrders",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "ItemOrders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "ItemOrders",
                newName: "ItemOrder");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemOrder",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_OrderId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrders_ItemId",
                table: "ItemOrder",
                newName: "IX_ItemOrder_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemOrder",
                table: "ItemOrder",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Items_ItemId",
                table: "ItemOrder",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrder_Order_OrderId",
                table: "ItemOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
