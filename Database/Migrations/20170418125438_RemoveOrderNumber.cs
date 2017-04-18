using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RemoveOrderNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "TableId",
                table: "Order",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order");

            migrationBuilder.AlterColumn<long>(
                name: "TableId",
                table: "Order",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Table_TableId",
                table: "Order",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
