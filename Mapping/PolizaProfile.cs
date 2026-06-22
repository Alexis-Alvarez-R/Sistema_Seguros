using AutoMapper;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Models.Dtos;

namespace Sistema_Emision_Seguros.Mapping
{
    public class PolizaProfile : Profile
    {
        public PolizaProfile()
        {
            CreateMap<Poliza, CreatePolizaDto>().ReverseMap();

            CreateMap<Poliza, PolizaDto>().ForMember(destino => destino.NombreCliente, option => option.MapFrom(src => src.Cliente.Nombre))
                .ForMember(destino => destino.IdentificacionCliente, option => option.MapFrom(src => src.Cliente.Identificacion))
                .ForMember(destino => destino.EmailCliente, option => option.MapFrom(src => src.Cliente.Email))

                .ForMember(destino => destino.PlacaVehiculo, option => option.MapFrom(src => src.Vehiculo.Placa))
                .ForMember(destino => destino.MarcaVehiculo, option => option.MapFrom(src => src.Vehiculo.Marca))
                .ForMember(destino => destino.ModeloVehiculo, option => option.MapFrom(src => src.Vehiculo.Modelo))

                .ForMember(destino => destino.CoberturasNombres, option => option.MapFrom(src => 
                    src.PolizasCoberturas.Select(pc => pc.Cobertura!.NombreCobertura).ToList())).ReverseMap();;    
        }
    }
}
