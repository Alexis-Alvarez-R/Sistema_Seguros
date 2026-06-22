using AutoMapper;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Models.Dtos;

namespace Sistema_Emision_Seguros.Mapping
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile()
        {
            CreateMap<Vehiculo,CreateVehiculoDto>().ReverseMap();
        }
    }
}
