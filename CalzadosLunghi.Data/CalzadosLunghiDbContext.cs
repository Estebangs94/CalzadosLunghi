using CalzadosLunghi.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalzadosLunghi.Data
{
    public class CalzadosLunghiDbContext : DbContext
    {
        public CalzadosLunghiDbContext(DbContextOptions<CalzadosLunghiDbContext> options)
            :base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Zapato> Zapatos { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<TipoMaterial> TipoMateriales { get; set; }
        public DbSet<PrecioMaterial> PrecioMateriales { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Color> Colores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZapatoMaterial>().HasKey(s => new { s.ZapatoId, s.MaterialId });
        }
    }
}
