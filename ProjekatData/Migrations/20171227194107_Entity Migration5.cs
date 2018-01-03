using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjekatData.Migrations
{
    public partial class EntityMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Godina",
                table: "VideoKlubAsset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumIzlaska",
                table: "VideoKlubAsset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumIzlaska",
                table: "VideoKlubAsset",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "Godina",
                table: "VideoKlubAsset",
                nullable: false,
                defaultValue: 0);
        }
    }
}
