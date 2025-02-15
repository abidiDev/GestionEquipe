﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Membres");

            migrationBuilder.AddColumn<int>(
                name: "IsJoueur",
                table: "Membres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsJoueur",
                table: "Membres");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
