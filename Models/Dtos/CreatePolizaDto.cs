using System.ComponentModel.DataAnnotations;

namespace Sistema_Emision_Seguros.Models.Dtos
{
    public class CreatePolizaDto
    {
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Los datos del vehículo son obligatorios.")]
        public CreateVehiculoDto Vehiculo { get; set; } = null!;

        [Required(ErrorMessage = "Debe seleccionar al menos una cobertura.")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos el ID de una cobertura.")]
        public List<int> CoberturasIds { get; set; } = [];

        [Required(ErrorMessage = "La suma asegurada es obligatoria.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La suma asegurada debe ser un monto mayor a cero.")]
        public decimal SumaAsegurada { get; set; }
    }
}
