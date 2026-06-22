using AutoMapper;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Models.Dtos;

namespace Sistema_Emision_Seguros.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() { 
        
        
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
