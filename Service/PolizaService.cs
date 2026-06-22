using AutoMapper;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Models.Dtos;
using Sistema_Emision_Seguros.Repository.IRepository;
using Sistema_Emision_Seguros.Service.IService;

namespace Sistema_Emision_Seguros.Service
{
    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository _polizaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ICoberturaRepository _coberturaRepository;
        private readonly IMapper _mapper;

        public PolizaService(IPolizaRepository polizaRepository, IClienteRepository clienteRepository, ICoberturaRepository coberturaRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _polizaRepository = polizaRepository;
            _coberturaRepository = coberturaRepository;
            _mapper = mapper;
            
        }


        public async Task<PolizaDto?> CreatePoliza(CreatePolizaDto createPolizaDto)
        {
         
            bool existeCliente = await _clienteRepository.ClienteExisteById(createPolizaDto.IdCliente);
            if (!existeCliente) throw new ArgumentException($"El cliente con ID {createPolizaDto.IdCliente} no existe.");

            bool placaYaRegistrada = await _polizaRepository.ExisteVehiculoConPlaca(createPolizaDto.Vehiculo.Placa);

            if (placaYaRegistrada)
            {
                throw new ArgumentException($"El vehiculo con la placa '{createPolizaDto.Vehiculo.Placa}' ya tiene una poliza vigente en el sistema.");
            }

            var poliza = _mapper.Map<Poliza>(createPolizaDto);
            poliza.NumeroPoliza = $"POL-{DateTime.Now:yyyyMMddHHmmss}";
            poliza.FechaEmision = DateTime.Now;
            poliza.Vehiculo = _mapper.Map<Vehiculo>(createPolizaDto.Vehiculo);

            
            decimal acumuladorPrima = 0;
            foreach (int idCobertura in createPolizaDto.CoberturasIds)
            {
                var cobertura = await _coberturaRepository.GetCobertura(idCobertura);
                if (cobertura == null) throw new ArgumentException($"La cobertura con ID {idCobertura} no existe.");

                acumuladorPrima += cobertura.MontoCobertura;
                poliza.PolizasCoberturas.Add(new PolizaCobertura { IdCobertura = idCobertura });
            }
            poliza.PrimaTotal = acumuladorPrima;

           
            if (!await _polizaRepository.CreatePoliza(poliza)) return null;

          
            var polizaDetalle = await _polizaRepository.GetPoliza(poliza.IdPoliza);
            return _mapper.Map<PolizaDto>(polizaDetalle);

        }


      
        public async Task<PolizaDto?> UpdatePoliza(int idPoliza, UpdatePolizaDto updatePolizaDto)
        {

            if (updatePolizaDto.CoberturasIds == null || !updatePolizaDto.CoberturasIds.Any())
            {
                throw new ArgumentException("La poliza debe incluir al menos una cobertura valida. No se permite dejar la lista vacia.");
            }

            var polizaExistente = await _polizaRepository.GetPoliza(idPoliza);
            if (polizaExistente == null) return null;

           
            polizaExistente.SumaAsegurada = updatePolizaDto.SumaAsegurada;

            
            await _polizaRepository.LimpiarCoberturasPoliza(idPoliza);
            polizaExistente.PolizasCoberturas.Clear();

          
            decimal acumuladorPrima = 0;
            foreach (int idCobertura in updatePolizaDto.CoberturasIds)
            {
                var cobertura = await _coberturaRepository.GetCobertura(idCobertura);
                if (cobertura == null) throw new ArgumentException($"La cobertura con ID {idCobertura} no existe.");

                acumuladorPrima += cobertura.MontoCobertura;
                polizaExistente.PolizasCoberturas.Add(new PolizaCobertura { IdPoliza = idPoliza, IdCobertura = idCobertura });
            }
            polizaExistente.PrimaTotal = acumuladorPrima;

            
            if (!await _polizaRepository.UpdatePoliza(polizaExistente)) return null;

           
            var polizaActualizada = await _polizaRepository.GetPoliza(idPoliza);
            return _mapper.Map<PolizaDto>(polizaActualizada);
        }

        public async Task<bool> DeletePoliza(int idPoliza)
        {
            var poliza = await _polizaRepository.GetPoliza(idPoliza);
            if (poliza == null) return false;

            return await _polizaRepository.DeletePoliza(poliza);
        }
    }
}
