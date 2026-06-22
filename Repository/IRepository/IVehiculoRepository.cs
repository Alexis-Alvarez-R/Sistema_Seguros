using Sistema_Emision_Seguros.Models;

namespace Sistema_Emision_Seguros.Repository.IRepository
{
    public interface IVehiculoRepository
    {
        Task <IEnumerable<Vehiculo>> GetVehiculos();

        Task<IEnumerable<Vehiculo>> GetVehiculosByMarca(string marca);

        Task<Vehiculo?> GetVehiculo(string placa);

        Task<bool> VehiculoExiste(string placa);

        Task<bool> CreateVehiculo(Vehiculo vehiculo);

        Task<bool> UpdateVehiculo(Vehiculo vehiculo);

        Task<bool> DeleteVehiculo(Vehiculo vehiculo);

        Task<bool> Save();
    }
}
