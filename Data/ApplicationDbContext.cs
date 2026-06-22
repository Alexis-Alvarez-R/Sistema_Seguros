using Microsoft.EntityFrameworkCore;
using Sistema_Emision_Seguros.Models;
using System.Reflection;


namespace Sistema_Emision_Seguros.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cobertura> Coberturas { get; set; }

        public DbSet<Poliza> Polizas { get; set; }

        public DbSet<PolizaCobertura> PolizasCoberturas { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<PolizaCobertura>()
                .HasKey(pc => new { pc.IdPoliza, pc.IdCobertura });

           
            modelBuilder.Entity<PolizaCobertura>()
                .HasOne(pc => pc.Poliza)
                .WithMany(p => p.PolizasCoberturas)
                .HasForeignKey(pc => pc.IdPoliza)
                .OnDelete(DeleteBehavior.Cascade); 

        
            modelBuilder.Entity<PolizaCobertura>()
                .HasOne(pc => pc.Cobertura)
                .WithMany(c => c.PolizasCoberturas)
                .HasForeignKey(pc => pc.IdCobertura)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
