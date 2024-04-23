﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Squadron.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changedarmoredvehiclemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ArmoredVehicle",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ArmoredVehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "ArmoredVehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ArmoredVehicle");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "ArmoredVehicle");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "ArmoredVehicle",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
