using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
