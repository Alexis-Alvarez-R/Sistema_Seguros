using System.ComponentModel.DataAnnotations;

namespace Sistema_Emision_Seguros.Models.Dtos
{
    public class CreateVehiculoDto
    {
        [Required(ErrorMessage = "La placa es obligatoria.")]
        [MaxLength(50)]
        public string Placa { get; set; } = string.Empty;

        [Required(ErrorMessage = "La marca es obligatoria.")]
        [MaxLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [MaxLength(50)]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de fabricacion es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de fabricacion debe ser un año valido.")]
        public int AnioFabricacion { get; set; }

        [Required(ErrorMessage = "El valor comercial es obligatorio.")]
        [Range(1.0, double.MaxValue, ErrorMessage = "El valor comercial debe ser mayor a cero.")]
        public decimal ValorComercial { get; set; }

    }
}
