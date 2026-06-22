using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Repository.IRepository
{
    public interface IClienteRepository
    {
        Task <IEnumerable<Cliente>> GetClientes();

        Task <Cliente?> GetCliente(int idCliente);

        Task<bool> ClienteExisteById(int  idCliente);

        Task <bool> ClienteExisteByIdentificacion(string identificacion);

        Task<bool> CreateCliente(Cliente cliente);

        Task<bool> UpdateCliente(Cliente cliente);

        Task<bool> DeleteCliente(Cliente cliente);

        Task<bool> Save();
    }
}
