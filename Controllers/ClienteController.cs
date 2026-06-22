using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Emision_Seguros.Models.Dtos;
using Sistema_Emision_Seguros.Repository.IRepository;


namespace Sistema_Emision_Seguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;


        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task <IActionResult> GetClientes()
        {
            var clientes = await _clienteRepository.GetClientes();
            var clientesDto =  _mapper.Map<List<ClienteDto>>(clientes);



            return Ok(clientesDto);
        }


    }
}
