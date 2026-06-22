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
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteRepository.GetClientes();
            var clientesDto = _mapper.Map<List<ClienteDto>>(clientes);



            return Ok(clientesDto);
        }

        [HttpGet("{idCliente:int}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCliente(int idCliente)
        {

            var cliente = await _clienteRepository.GetCliente(idCliente);

            if (cliente == null) {

                return NotFound($"El cliente con el id {idCliente} no existe");
            }

            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            return Ok(clienteDto);


        }



    }
}
