using Microsoft.EntityFrameworkCore;

namespace Bakery_Homework.Models
{
    public class BakeryDbContext : DbContext
    {
        public BakeryDbContext() : base()
        {
        }

        public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options)
        {
        }

        public DbSet<Produse> Produse { get; set; }
        public DbSet<Comenzi> Comenzi { get; set; }
        public DbSet<Clienti> Clienti { get; set; }
        public DbSet<Angajati> Angajati { get; set; }
        public DbSet<Locatii> Locatii { get; set; }
        public DbSet<FormulareAngajare> FormulareAngajare { get; set; }
        public DbSet<MetodePlata> MetodePlata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormulareAngajare>()
               .HasOne(f => f.Locatie)
               .WithMany()
               .HasForeignKey(f => f.LocatieId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FormulareAngajare>()
                .HasOne(f => f.Angajat)
                .WithMany()
                .HasForeignKey(f => f.AngajatId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
