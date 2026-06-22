using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Repository.IRepository
{
    public interface IPolizaRepository
    {
        Task<IEnumerable<Poliza>> GetPolizas();

        Task<Poliza?> GetPoliza(int idPoliza);

        Task<bool> PolizaExiste(string numeroPoliza);


        Task<bool> CreatePoliza(Poliza poliza);

        Task<bool> UpdatePoliza(Poliza poliza);

        Task<bool> DeletePoliza(Poliza poliza);

        Task LimpiarCoberturasPoliza(int idPoliza);

        Task<bool> ExisteVehiculoConPlaca(string placa);

        Task<bool> Save();
    }
}
