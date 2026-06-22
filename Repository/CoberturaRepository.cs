using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Sistema_Emision_Seguros.Data;

namespace Sistema_Emision_Seguros.Repository
{
    public class CoberturaRepository : ICoberturaRepository
    {
        private readonly ApplicationDbContext _db;

        public CoberturaRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }


        public async Task<IEnumerable<Cobertura>> GetCoberturas()
        {
            return await _db.Coberturas.OrderBy(cobertura => cobertura.NombreCobertura).ToListAsync();
        }

        public async Task<Cobertura?> GetCobertura(int idCobertura)
        {
            return await _db.Coberturas.FirstOrDefaultAsync(c => c.IdCobertura == idCobertura);
        }

        //------

        public Task<bool> CoberturaExiste(int idCobertura)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCobertura(Cobertura cobertura)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCobertura(Cobertura cobertura)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCobertura(Cobertura cobertura)
        {
            throw new NotImplementedException();
        }
    }
}
