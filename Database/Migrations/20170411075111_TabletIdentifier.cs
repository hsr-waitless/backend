using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class TabletIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itemtyp_Submenu_SubmenuId",
                table: "Itemtyp");

            migrationBuilder.DropForeignKey(
                name: "FK_Submenu_Menu_MenuId",
                table: "Submenu");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Tablet");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Tablet",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MenuId",
                table: "Submenu",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SubmenuId",
                table: "Itemtyp",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Itemtyp_Submenu_SubmenuId",
                table: "Itemtyp",
                column: "SubmenuId",
                principalTable: "Submenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submenu_Menu_MenuId",
                table: "Submenu",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itemtyp_Submenu_SubmenuId",
                table: "Itemtyp");

            migrationBuilder.DropForeignKey(
                name: "FK_Submenu_Menu_MenuId",
                table: "Submenu");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Tablet");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Tablet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "MenuId",
                table: "Submenu",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "SubmenuId",
                table: "Itemtyp",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Itemtyp_Submenu_SubmenuId",
                table: "Itemtyp",
                column: "SubmenuId",
                principalTable: "Submenu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Submenu_Menu_MenuId",
                table: "Submenu",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
