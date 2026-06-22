using System.ComponentModel.DataAnnotations;

namespace Sistema_Emision_Seguros.Models.Dtos
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Identificacion { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
