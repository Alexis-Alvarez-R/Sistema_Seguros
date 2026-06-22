using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Emision_Seguros.Models
{
    public class Cobertura
    {

        [Key]
        public int IdCobertura { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreCobertura { get; set; } = string.Empty;

        [Required]
        [Column (TypeName = "decimal(18,2)")]
        public decimal MontoCobertura { get; set; }

        public ICollection<PolizaCobertura> PolizasCoberturas { get; set; } = [];

    }
}
