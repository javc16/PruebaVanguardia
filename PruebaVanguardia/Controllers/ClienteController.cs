using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaVanguardia.AppService;
using PruebaVanguardia.Helpers;
using PruebaVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> GetAll()
        {
            var result = _clienteAppService.GetAll();
            return Ok(result);
        }


        [HttpGet("{codigo}")]
        public async Task<ActionResult<Response>> GetById(long codigo)
        {
            return Ok(await _clienteAppService.GetById(codigo));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Cliente item)
        {
            return Ok(await _clienteAppService.PostCliente(item));
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<Response>> PutCiudadano(long codigo, Cliente cliente)
        {
            return Ok(await _clienteAppService.PutCliente(codigo,cliente));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteById(int id)
        {
            return Ok(await _clienteAppService.DeleteCliente(id));
        }
    }
}
