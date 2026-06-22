using Sistema_Emision_Seguros.Models.Dtos;

namespace Sistema_Emision_Seguros.Service.IService
{
    public interface IPolizaService
    {
        Task<PolizaDto?> CreatePoliza(CreatePolizaDto createPolizaDto);

        Task<PolizaDto?> UpdatePoliza(int idPoliza, UpdatePolizaDto updatePolizaDto);

        Task<bool> DeletePoliza(int idPoliza);
    }
}
