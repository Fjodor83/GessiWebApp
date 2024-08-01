using GessiWebApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GessiWebApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<PickingMission> PickingMissions { get; set; }

        // Configurazioni aggiuntive del modello
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aggiungi configurazioni specifiche se necessarie
        }
    }
}