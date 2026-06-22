using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Repository.IRepository
{
    public interface ICoberturaRepository
    {
        Task<IEnumerable<Cobertura>> GetCoberturas();

        Task<Cobertura?> GetCobertura(int idCobertura);

        Task<bool> CoberturaExiste(int idCobertura);

   
    }
}
