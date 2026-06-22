namespace Sistema_Emision_Seguros.Models.Dtos
{
    public class UpdatePolizaDto
    {
        public decimal SumaAsegurada { get; set; }

        public List<int> CoberturasIds { get; set; } = [];
    }
}
