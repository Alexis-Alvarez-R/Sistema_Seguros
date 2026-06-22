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
                                    .Include(poliza=> poliza.PolizasCoberturas)
                                    .ThenInclude(pc=> pc.Cobertura)
                                    .OrderByDescending(poliza => poliza.FechaEmision)
                                    .ToListAsync();
        }

        public async Task<bool> PolizaExiste(string numeroPoliza)
        {
            return await _db.Polizas.AnyAsync(poliza => poliza.NumeroPoliza.ToLower().Trim() == numeroPoliza.ToLower().Trim());
        }

        public async Task<bool> DeletePoliza(Poliza poliza)
        {
         
            var coberturasAsociadas = _db.PolizasCoberturas.Where(pc => pc.IdPoliza == poliza.IdPoliza);
            _db.PolizasCoberturas.RemoveRange(coberturasAsociadas);

            _db.Polizas.Remove(poliza);
            return await Save();
        }

        public async Task<bool> UpdatePoliza(Poliza poliza)
        {
             _db.Polizas.Update(poliza);
            return await Save();
        }

        public async Task LimpiarCoberturasPoliza(int idPoliza)
        {
            var coberturasViejas = await _db.PolizasCoberturas.Where(pc => pc.IdPoliza == idPoliza).ToListAsync();
            _db.PolizasCoberturas.RemoveRange(coberturasViejas);
            
        }
        public async Task<bool> ExisteVehiculoConPlaca(string placa)
        {
            
            return await _db.Polizas.AnyAsync(poliza => poliza.Vehiculo.Placa == placa);
        }
        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

    }
}
