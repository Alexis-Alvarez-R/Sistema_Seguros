using Sistema_Emision_Seguros.Data;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Emision_Seguros.Repository
{
    public class PolizaRepository : IPolizaRepository
    {

        private readonly ApplicationDbContext _db;

        public PolizaRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task<bool> CreatePoliza(Poliza poliza)
        {
           await _db.Polizas.AddAsync(poliza);

            return await Save();
        }


        public async Task<Poliza?> GetPoliza(int idPoliza)
        {
            return await _db.Polizas.Include(poliza => poliza.Cliente)
                                    .Include(poliza => poliza.Vehiculo)
                                    .Include(poliza => poliza.PolizasCoberturas)
                                    .ThenInclude(pc => pc.Cobertura)
                                    .FirstOrDefaultAsync(poliza => poliza.IdPoliza == idPoliza);
        }

        public async Task<IEnumerable<Poliza>> GetPolizas()
        {
            return await _db.Polizas.Include(poliza => poliza.Cliente)
                                    .Include(poliza => poliza.Vehiculo)
                                    .OrderByDescending(poliza => poliza.FechaEmision)
                                    .ToListAsync();
        }

        public async Task<bool> PolizaExiste(string numeroPoliza)
        {
            return await _db.Polizas.AnyAsync(poliza => poliza.NumeroPoliza.ToLower().Trim() == numeroPoliza.ToLower().Trim());
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

        //---
        public Task<bool> DeletePoliza(Poliza poliza)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePoliza(Poliza poliza)
        {
            throw new NotImplementedException();
        }
    }
}
