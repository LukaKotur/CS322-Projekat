﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProjekatData;
using System;

namespace ProjekatData.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20171227181413_Entity Migration")]
    partial class EntityMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjekatData.Models.Clan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int?>("ClanOgrankaId");

                    b.Property<int?>("ClanskaKartaId");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("ClanOgrankaId");

                    b.HasIndex("ClanskaKartaId");

                    b.ToTable("Clanovi");
                });

            modelBuilder.Entity("ProjekatData.Models.ClanskaKarta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Dug");

                    b.Property<DateTime>("VremePravljenja");

                    b.HasKey("Id");

                    b.ToTable("ClanskaKarta");
                });

            modelBuilder.Entity("ProjekatData.Models.IstorijaIznajmljivanja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClanskaKartaId");

                    b.Property<DateTime>("DatumIznajmljivanja");

                    b.Property<DateTime?>("DatumVracanja");

                    b.Property<int>("VideoKlubAssetId");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaKartaId");

                    b.HasIndex("VideoKlubAssetId");

                    b.ToTable("IstorijaIznajmljivanja");
                });

            modelBuilder.Entity("ProjekatData.Models.Iznajmljivanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClanskaKartaId");

                    b.Property<DateTime>("DatumKraja");

                    b.Property<DateTime>("DatumPocetka");

                    b.Property<int>("VideoKlubAssetId");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaKartaId");

                    b.HasIndex("VideoKlubAssetId");

                    b.ToTable("Iznajmljivanje");
                });

            modelBuilder.Entity("ProjekatData.Models.RadnoVreme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DanUNedelji");

                    b.Property<int?>("OgranakId");

                    b.Property<int>("VremeKadaJeOtvoreno");

                    b.Property<int>("VremeKadaJeZatvoreno");

                    b.HasKey("Id");

                    b.HasIndex("OgranakId");

                    b.ToTable("RadnoVreme");
                });

            modelBuilder.Entity("ProjekatData.Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClanskaKartaId");

                    b.Property<DateTime>("StavljenaRezervacija");

                    b.Property<int?>("VideoKlubAssetId");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaKartaId");

                    b.HasIndex("VideoKlubAssetId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("ProjekatData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<string>("Opis")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("ProjekatData.Models.VideoKlubAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojKopija");

                    b.Property<decimal>("Cena");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Godina");

                    b.Property<string>("ImgUrl");

                    b.Property<int?>("LokacijaId");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("LokacijaId");

                    b.HasIndex("StatusId");

                    b.ToTable("VideoKlubAsset");

                    b.HasDiscriminator<string>("Discriminator").HasValue("VideoKlubAsset");
                });

            modelBuilder.Entity("ProjekatData.Models.VideoKlubOgranak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa")
                        .IsRequired();

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Opis");

                    b.Property<string>("Telefon")
                        .IsRequired();

                    b.Property<DateTime>("VremeKadaJeOtvoreno");

                    b.HasKey("Id");

                    b.ToTable("VideoKlubOgranak");
                });

            modelBuilder.Entity("ProjekatData.Models.Film", b =>
                {
                    b.HasBaseType("ProjekatData.Models.VideoKlubAsset");

                    b.Property<DateTime>("DatumIzlaska");

                    b.Property<string>("GlavniGlumci")
                        .IsRequired();

                    b.ToTable("Film");

                    b.HasDiscriminator().HasValue("Film");
                });

            modelBuilder.Entity("ProjekatData.Models.Clan", b =>
                {
                    b.HasOne("ProjekatData.Models.VideoKlubOgranak", "ClanOgranka")
                        .WithMany("Clanovi")
                        .HasForeignKey("ClanOgrankaId");

                    b.HasOne("ProjekatData.Models.ClanskaKarta", "ClanskaKarta")
                        .WithMany()
                        .HasForeignKey("ClanskaKartaId");
                });

            modelBuilder.Entity("ProjekatData.Models.IstorijaIznajmljivanja", b =>
                {
                    b.HasOne("ProjekatData.Models.ClanskaKarta", "ClanskaKarta")
                        .WithMany()
                        .HasForeignKey("ClanskaKartaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjekatData.Models.VideoKlubAsset", "VideoKlubAsset")
                        .WithMany()
                        .HasForeignKey("VideoKlubAssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjekatData.Models.Iznajmljivanje", b =>
                {
                    b.HasOne("ProjekatData.Models.ClanskaKarta", "ClanskaKarta")
                        .WithMany("SvaIznajmljivanja")
                        .HasForeignKey("ClanskaKartaId");

                    b.HasOne("ProjekatData.Models.VideoKlubAsset", "VideoKlubAsset")
                        .WithMany()
                        .HasForeignKey("VideoKlubAssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjekatData.Models.RadnoVreme", b =>
                {
                    b.HasOne("ProjekatData.Models.VideoKlubOgranak", "Ogranak")
                        .WithMany()
                        .HasForeignKey("OgranakId");
                });

            modelBuilder.Entity("ProjekatData.Models.Rezervacija", b =>
                {
                    b.HasOne("ProjekatData.Models.ClanskaKarta", "ClanskaKarta")
                        .WithMany()
                        .HasForeignKey("ClanskaKartaId");

                    b.HasOne("ProjekatData.Models.VideoKlubAsset", "VideoKlubAsset")
                        .WithMany()
                        .HasForeignKey("VideoKlubAssetId");
                });

            modelBuilder.Entity("ProjekatData.Models.VideoKlubAsset", b =>
                {
                    b.HasOne("ProjekatData.Models.VideoKlubOgranak", "Lokacija")
                        .WithMany("VideoKlubAssets")
                        .HasForeignKey("LokacijaId");

                    b.HasOne("ProjekatData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
