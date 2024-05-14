using Bakery_H.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Bakery_Homework.Models
{
    public class BakeryDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
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
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormulareAngajare>()
               .HasOne(f => f.Locatie)
               .WithMany()
               .HasForeignKey(f => f.LocatieId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comenzi>()
                .HasOne(f => f.Client)
                .WithMany()
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
