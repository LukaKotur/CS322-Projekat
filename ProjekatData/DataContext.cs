using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjekatData.Models;

namespace ProjekatData
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSet (migrations)

        // command to add migration to queue: add-migration "Ime Migracije" 

        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Iznajmljivanje> Iznajmljivanje { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<RadnoVreme> RadnoVreme { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<IstorijaIznajmljivanja> IstorijaIznajmljivanja { get; set; }
        public DbSet<VideoKlubAsset> VideoKlubAsset { get; set; }
        public DbSet<VideoKlubOgranak> VideoKlubOgranak { get; set; }
        public DbSet<ClanskaKarta> ClanskaKarta { get; set; }
        public DbSet<Zaposleni> Zaposleni { get; set; }

        // command to execute update to db: update-database

        #endregion
    }
}