using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Emision_Seguros.Models.Dtos
{
    public class CoberturaDto
    {
      
        public int IdCobertura { get; set; }

        public string NombreCobertura { get; set; } = string.Empty;
   
        public decimal MontoCobertura { get; set; }


    }
}

