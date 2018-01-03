using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjekatData.Migrations
{
    public partial class EntityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClanOgrankaId",
                table: "Clanovi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClanskaKartaId",
                table: "Clanovi",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClanskaKarta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dug = table.Column<decimal>(nullable: false),
                    VremePravljenja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanskaKarta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

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
                name: "RadnoVreme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DanUNedelji = table.Column<int>(nullable: false),
                    OgranakId = table.Column<int>(nullable: true),
                    VremeKadaJeOtvoreno = table.Column<int>(nullable: false),
                    VremeKadaJeZatvoreno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnoVreme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadnoVreme_VideoKlubOgranak_OgranakId",
                        column: x => x.OgranakId,
                        principalTable: "VideoKlubOgranak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoKlubAsset",
                columns: table => new
                {
                    DatumIzlaska = table.Column<DateTime>(nullable: true),
                    GlavniGlumci = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojKopija = table.Column<int>(nullable: false),
                    Cena = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Godina = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    LokacijaId = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoKlubAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoKlubAsset_VideoKlubOgranak_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "VideoKlubOgranak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoKlubAsset_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IstorijaIznajmljivanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClanskaKartaId = table.Column<int>(nullable: false),
                    DatumIznajmljivanja = table.Column<DateTime>(nullable: false),
                    DatumVracanja = table.Column<DateTime>(nullable: true),
                    VideoKlubAssetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstorijaIznajmljivanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IstorijaIznajmljivanja_ClanskaKarta_ClanskaKartaId",
                        column: x => x.ClanskaKartaId,
                        principalTable: "ClanskaKarta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IstorijaIznajmljivanja_VideoKlubAsset_VideoKlubAssetId",
                        column: x => x.VideoKlubAssetId,
                        principalTable: "VideoKlubAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iznajmljivanje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClanskaKartaId = table.Column<int>(nullable: true),
                    DatumKraja = table.Column<DateTime>(nullable: false),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    VideoKlubAssetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iznajmljivanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanje_ClanskaKarta_ClanskaKartaId",
                        column: x => x.ClanskaKartaId,
                        principalTable: "ClanskaKarta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanje_VideoKlubAsset_VideoKlubAssetId",
                        column: x => x.VideoKlubAssetId,
                        principalTable: "VideoKlubAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClanskaKartaId = table.Column<int>(nullable: true),
                    StavljenaRezervacija = table.Column<DateTime>(nullable: false),
                    VideoKlubAssetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_ClanskaKarta_ClanskaKartaId",
                        column: x => x.ClanskaKartaId,
                        principalTable: "ClanskaKarta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_VideoKlubAsset_VideoKlubAssetId",
                        column: x => x.VideoKlubAssetId,
                        principalTable: "VideoKlubAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_ClanOgrankaId",
                table: "Clanovi",
                column: "ClanOgrankaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_ClanskaKartaId",
                table: "Clanovi",
                column: "ClanskaKartaId");

            migrationBuilder.CreateIndex(
                name: "IX_IstorijaIznajmljivanja_ClanskaKartaId",
                table: "IstorijaIznajmljivanja",
                column: "ClanskaKartaId");

            migrationBuilder.CreateIndex(
                name: "IX_IstorijaIznajmljivanja_VideoKlubAssetId",
                table: "IstorijaIznajmljivanja",
                column: "VideoKlubAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_ClanskaKartaId",
                table: "Iznajmljivanje",
                column: "ClanskaKartaId");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanje_VideoKlubAssetId",
                table: "Iznajmljivanje",
                column: "VideoKlubAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_RadnoVreme_OgranakId",
                table: "RadnoVreme",
                column: "OgranakId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_ClanskaKartaId",
                table: "Rezervacija",
                column: "ClanskaKartaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VideoKlubAssetId",
                table: "Rezervacija",
                column: "VideoKlubAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoKlubAsset_LokacijaId",
                table: "VideoKlubAsset",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoKlubAsset_StatusId",
                table: "VideoKlubAsset",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_VideoKlubOgranak_ClanOgrankaId",
                table: "Clanovi",
                column: "ClanOgrankaId",
                principalTable: "VideoKlubOgranak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_ClanskaKarta_ClanskaKartaId",
                table: "Clanovi",
                column: "ClanskaKartaId",
                principalTable: "ClanskaKarta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_VideoKlubOgranak_ClanOgrankaId",
                table: "Clanovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_ClanskaKarta_ClanskaKartaId",
                table: "Clanovi");

            migrationBuilder.DropTable(
                name: "IstorijaIznajmljivanja");

            migrationBuilder.DropTable(
                name: "Iznajmljivanje");

            migrationBuilder.DropTable(
                name: "RadnoVreme");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "ClanskaKarta");

            migrationBuilder.DropTable(
                name: "VideoKlubAsset");

            migrationBuilder.DropTable(
                name: "VideoKlubOgranak");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Clanovi_ClanOgrankaId",
                table: "Clanovi");

            migrationBuilder.DropIndex(
                name: "IX_Clanovi_ClanskaKartaId",
                table: "Clanovi");

            migrationBuilder.DropColumn(
                name: "ClanOgrankaId",
                table: "Clanovi");

            migrationBuilder.DropColumn(
                name: "ClanskaKartaId",
                table: "Clanovi");
        }
    }
}
