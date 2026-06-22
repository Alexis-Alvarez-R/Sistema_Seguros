using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Emision_Seguros.Models
{
    public class PolizaCobertura
    {
        public int IdPoliza { get; set; }
        public  Poliza? Poliza { get; set; }

        public int IdCobertura { get; set; }
        public  Cobertura? Cobertura { get; set; }
    }
}
