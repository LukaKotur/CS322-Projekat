using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjekatData.Migrations
{
    public partial class Changedposlovnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_VideoKlubOgranak_ClanOgrankaId",
                table: "Clanovi");

            migrationBuilder.DropForeignKey(
                name: "FK_RadnoVreme_VideoKlubOgranak_OgranakId",
                table: "RadnoVreme");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoKlubAsset_VideoKlubOgranak_LokacijaId",
                table: "VideoKlubAsset");

            migrationBuilder.DropTable(
                name: "VideoKlubOgranak");

            migrationBuilder.DropTable(
                name: "Zaposleni");

            migrationBuilder.CreateTable(
                name: "VideoKlubPoslovnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: false),
                    VremeKadaJeOtvoreno = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoKlubPoslovnica", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_VideoKlubPoslovnica_ClanOgrankaId",
                table: "Clanovi",
                column: "ClanOgrankaId",
                principalTable: "VideoKlubPoslovnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RadnoVreme_VideoKlubPoslovnica_OgranakId",
                table: "RadnoVreme",
                column: "OgranakId",
                principalTable: "VideoKlubPoslovnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoKlubAsset_VideoKlubPoslovnica_LokacijaId",
                table: "VideoKlubAsset",
                column: "LokacijaId",
                principalTable: "VideoKlubPoslovnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_VideoKlubPoslovnica_ClanOgrankaId",
                table: "Clanovi");

            migrationBuilder.DropForeignKey(
                name: "FK_RadnoVreme_VideoKlubPoslovnica_OgranakId",
                table: "RadnoVreme");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoKlubAsset_VideoKlubPoslovnica_LokacijaId",
                table: "VideoKlubAsset");

            migrationBuilder.DropTable(
                name: "VideoKlubPoslovnica");

            migrationBuilder.CreateTable(
                name: "VideoKlubOgranak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: false),
                    VremeKadaJeOtvoreno = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoKlubOgranak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaposleni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Sifra = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposleni", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_VideoKlubOgranak_ClanOgrankaId",
                table: "Clanovi",
                column: "ClanOgrankaId",
                principalTable: "VideoKlubOgranak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RadnoVreme_VideoKlubOgranak_OgranakId",
                table: "RadnoVreme",
                column: "OgranakId",
                principalTable: "VideoKlubOgranak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoKlubAsset_VideoKlubOgranak_LokacijaId",
                table: "VideoKlubAsset",
                column: "LokacijaId",
                principalTable: "VideoKlubOgranak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
