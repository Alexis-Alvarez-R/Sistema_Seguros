using Microsoft.EntityFrameworkCore;
using Sistema_Emision_Seguros.Data;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Repository.IRepository;

namespace Sistema_Emision_Seguros.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ApplicationDbContext _db;

        public ClienteRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _db.Clientes.OrderBy(cliente => cliente.Nombre).ToListAsync();
        }

      
        public async Task<bool> ClienteExisteById(int idCliente)
        {
            return await _db.Clientes.AnyAsync(cliente => cliente.IdCliente == idCliente);
        }

        public async Task<bool> ClienteExisteByIdentificacion(string identificacion)
        {
            return await _db.Clientes.AnyAsync(cliente => cliente.Identificacion.ToLower().Trim() == identificacion.ToLower().Trim());
        }


        //------

        public Task<bool> CreateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> GetCliente(int idCliente)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
