using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.IdCliente);

          
            builder.HasData(
                new Cliente { IdCliente = 1, Nombre = "Alexis Alvarez", Identificacion = "001-151202-1013T", Email = "ramirez151202@gmail.com" },
                new Cliente { IdCliente = 2, Nombre = "Maria Ramirez", Identificacion = "001-120365-1014T", Email = "maria@gmail.com" },
                new Cliente { IdCliente = 3, Nombre = "Yaser Perez", Identificacion = "001-020606-1015T", Email = "ysp67@gmail.com" },
                new Cliente { IdCliente = 4, Nombre = "Jose Noguera", Identificacion = "001-100504-1016T", Email = "noguera10@gmail.com" },
                new Cliente { IdCliente = 5, Nombre = "Tayson Ramirez", Identificacion = "001-151206-1017T", Email = "tayson15@gmail.com" },
                new Cliente { IdCliente = 6, Nombre = "Kevin Spacey", Identificacion = "001-010213-1018T", Email = "underwood@gmail.com" },
                new Cliente { IdCliente = 7, Nombre = "Walter White", Identificacion = "001-200108-1019T", Email = "saymyname@gmail.com" }

            );
        }
    }
}
