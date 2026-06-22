using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Repository.IRepository
{
    public interface ICoberturaRepository
    {
        Task<IEnumerable<Cobertura>> GetCoberturas();

        Task<Cobertura?> GetCobertura(int idCobertura);

        Task<bool> CoberturaExiste(int idCobertura);

        Task<bool> CreateCobertura(Cobertura cobertura);

        Task<bool> UpdateCobertura(Cobertura cobertura);

        Task<bool> DeleteCobertura(Cobertura cobertura);

        Task<bool> Save();
    }
}
