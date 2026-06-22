using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Sistema_Emision_Seguros.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int AnioFabricacion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorComercial { get; set; }
    }


}
