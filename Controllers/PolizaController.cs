using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Emision_Seguros.Models.Dtos;
using Sistema_Emision_Seguros.Repository.IRepository;
using Sistema_Emision_Seguros.Service.IService;

namespace Sistema_Emision_Seguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {

        private readonly IPolizaService _polizaService;
        private readonly IPolizaRepository _polizaRepository;
        private readonly IMapper _mapper;

        public PolizaController(IPolizaService polizaService, IPolizaRepository polizaRepository, IMapper mapper)
        {

           _polizaService = polizaService;
            _polizaRepository = polizaRepository;
            _mapper = mapper;

        }

        [HttpPost("emitir")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EmitirPoliza([FromBody] CreatePolizaDto polizaCreateDto)
        {
            if (polizaCreateDto == null)
            {
                ModelState.AddModelError("ValidationError", "El cuerpo de la solicitud no puede estar vacio.");
                return BadRequest(ModelState);
            }

            try
            {
                var polizaDto = await _polizaService.CreatePoliza(polizaCreateDto);

                if (polizaDto == null)
                {
                    return StatusCode(500, "Error interno al procesar la emision.");
                }

                return CreatedAtRoute("GetPoliza", new { idPoliza = polizaDto.IdPoliza }, polizaDto);
            }
            catch (ArgumentException ex)
            {

                ModelState.AddModelError("BusinessError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPolizas()
        {
            var listaPolizas = await _polizaRepository.GetPolizas();

           
            var listaPolizasDto = _mapper.Map<IEnumerable<PolizaDto>>(listaPolizas);

            return Ok(listaPolizasDto);
        }

     
        [HttpGet("{idPoliza:int}", Name = "GetPoliza")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPoliza(int idPoliza)
        {
            var poliza = await _polizaRepository.GetPoliza(idPoliza);

            if (poliza == null)
            {
         
                return NotFound($"La poliza con ID {idPoliza} no fue encontrada.");
            }

            var polizaDto = _mapper.Map<PolizaDto>(poliza);

            return Ok(polizaDto);
        }


        [HttpPut("{idPoliza:int}", Name = "UpdatePoliza")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePoliza(int idPoliza, [FromBody] UpdatePolizaDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var polizaActualizada = await _polizaService.UpdatePoliza(idPoliza, updateDto);

                if (polizaActualizada == null)
                {
                    return NotFound($"No se encontro ninguna poliza con el ID {idPoliza}");
                } 
                

                return Ok(polizaActualizada); 
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("ErrorValidacion", ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor al actualizar la poliza.");
            }
        }

 
        [HttpDelete("{idPoliza:int}", Name = "DeletePoliza")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePoliza(int idPoliza)
        {
            try
            {
                bool eliminado = await _polizaService.DeletePoliza(idPoliza);
                if (!eliminado) return NotFound($"No se pudo encontrar o eliminar la poliza con ID {idPoliza}");

                return NoContent(); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor al intentar borrar la poliza.");
            }
        }
    }
}
