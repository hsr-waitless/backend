using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Submenu",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    MenuId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itemtyp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Category = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<double>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    SubmenuId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itemtyp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itemtyp_Submenu_SubmenuId",
                        column: x => x.SubmenuId,
                        principalTable: "Submenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    ItemtypId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_Itemtyp_ItemtypId",
                        column: x => x.ItemtypId,
                        principalTable: "Itemtyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationValue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConfigurationId = table.Column<long>(nullable: true),
                    OrderPosId = table.Column<long>(nullable: true),
                    PriceApproximation = table.Column<double>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationValue_Configuration_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ItemtypId = table.Column<long>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: true),
                    PosStatus = table.Column<int>(nullable: false),
                    PricePaidByCustomer = table.Column<double>(nullable: false),
                    PricePos = table.Column<double>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPos_Itemtyp_ItemtypId",
                        column: x => x.ItemtypId,
                        principalTable: "Itemtyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Call",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CallStatus = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<long>(nullable: true),
                    TabletId = table.Column<long>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Call", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tablet",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Mode = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    PriceOrder = table.Column<double>(nullable: false),
                    TableId = table.Column<long>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    WaiterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Tablet_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "Tablet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Call_OrderId",
                table: "Call",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Call_TabletId",
                table: "Call",
                column: "TabletId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_ItemtypId",
                table: "Configuration",
                column: "ItemtypId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationValue_ConfigurationId",
                table: "ConfigurationValue",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationValue_OrderPosId",
                table: "ConfigurationValue",
                column: "OrderPosId");

            migrationBuilder.CreateIndex(
                name: "IX_Itemtyp_SubmenuId",
                table: "Itemtyp",
                column: "SubmenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TableId",
                table: "Order",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_WaiterId",
                table: "Order",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPos_ItemtypId",
                table: "OrderPos",
                column: "ItemtypId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPos_OrderId",
                table: "OrderPos",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Submenu_MenuId",
                table: "Submenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tablet_OrderId",
                table: "Tablet",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationValue_OrderPos_OrderPosId",
                table: "ConfigurationValue",
                column: "OrderPosId",
                principalTable: "OrderPos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPos_Order_OrderId",
                table: "OrderPos",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Order_OrderId",
                table: "Call",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Call_Tablet_TabletId",
                table: "Call",
                column: "TabletId",
                principalTable: "Tablet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tablet_Order_OrderId",
                table: "Tablet",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tablet_Order_OrderId",
                table: "Tablet");

            migrationBuilder.DropTable(
                name: "Call");

            migrationBuilder.DropTable(
                name: "ConfigurationValue");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "OrderPos");

            migrationBuilder.DropTable(
                name: "Itemtyp");

            migrationBuilder.DropTable(
                name: "Submenu");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Tablet");
        }
    }
}
