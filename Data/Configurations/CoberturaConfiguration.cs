using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Data.Configurations
{
    public class CoberturaConfiguration : IEntityTypeConfiguration<Cobertura>
    {
        public void Configure(EntityTypeBuilder<Cobertura> builder)
        {
            builder.HasKey(c => c.IdCobertura);

            builder.HasData(
                new Cobertura { IdCobertura = 1, NombreCobertura = "Responsabilidad Civil", MontoCobertura = 150.00m },
                new Cobertura { IdCobertura = 2, NombreCobertura = "Robo Total", MontoCobertura = 250.50m },
                new Cobertura { IdCobertura = 3, NombreCobertura = "Choque o Colisión", MontoCobertura = 300.00m },
                new Cobertura { IdCobertura = 4, NombreCobertura = "Daños por Fenómenos Naturales", MontoCobertura = 120.25m }
            );
        }
    }
}
