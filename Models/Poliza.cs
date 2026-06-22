using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sistema_Emision_Seguros.Models
{
    public class Poliza
    {
        [Key]
        public int IdPoliza { get; set; }

        [Required]
        [MaxLength(50)]
        public string NumeroPoliza { get; set; } = string.Empty;

        public DateTime FechaEmision  { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SumaAsegurada { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrimaTotal { get; set; }


        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public required Cliente Cliente { get; set; }

        public int IdVehiculo { get; set; }
        [ForeignKey("IdVehiculo")]
        public required Vehiculo Vehiculo { get; set; }

        public ICollection<PolizaCobertura> PolizasCoberturas { get; set; } = [];
    }
}
