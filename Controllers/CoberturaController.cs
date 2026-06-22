using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Emision_Seguros.Models;
using Sistema_Emision_Seguros.Models.Dtos;
using Sistema_Emision_Seguros.Repository.IRepository;

namespace Sistema_Emision_Seguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoberturaController : ControllerBase
    {
        private readonly ICoberturaRepository _coberturaRepository;
        private readonly IMapper _mapper;


        public CoberturaController(ICoberturaRepository coberturaRepository, IMapper mapper)
        {
            _coberturaRepository = coberturaRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCoberturas()
        {
            var coberturas = await _coberturaRepository.GetCoberturas();
            var coberturasDto = _mapper.Map<List<CoberturaDto>>(coberturas);

            return Ok(coberturasDto);
        }

        [HttpGet("{idCobertura:int}", Name = "GetCobertura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCobertura(int idCobertura)
        {
            var cobertura = await _coberturaRepository.GetCobertura(idCobertura);

            if (cobertura == null) { 
            
                return NotFound($"La cobertura con el id{idCobertura} No existe");
            }

            var coberturasDto = _mapper.Map<CoberturaDto>(cobertura);

            return Ok(coberturasDto);
        }
    }
}
