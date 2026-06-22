using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Emision_Seguros.Models.Dtos
{
    public class PolizaDto
    {
       
        public int IdPoliza { get; set; }

      
        public string NumeroPoliza { get; set; } = string.Empty;

        public DateTime FechaEmision { get; set; } = DateTime.Now;

      
        public decimal SumaAsegurada { get; set; }

      
        public decimal PrimaTotal { get; set; }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string IdentificacionCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;


        public int IdVehiculo { get; set; }
        public string PlacaVehiculo { get; set; } = string.Empty;
        public string MarcaVehiculo { get; set; } = string.Empty;
        public string ModeloVehiculo { get; set; } = string.Empty;

  
        public List<string> CoberturasNombres { get; set; } = [];


    }
}


