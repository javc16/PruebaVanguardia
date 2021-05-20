using Microsoft.EntityFrameworkCore;
using PruebaVanguardia.Context;
using PruebaVanguardia.Helpers;
using PruebaVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia.AppService
{
    public class ClienteAppService: IClienteAppService
    {
        private readonly TestContext _context;
        //private readonly TipoUsuarioDomainService _userTypeDomainService;

        public ClienteAppService(TestContext context)
        {
            _context = context;
            //_userTypeDomainService = userTypeDomainService;
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            var clientes = _context.Cliente.Where(x => x.estado == Constantes.Activo);
            var clientesDTO = ClienteDTO.DeModeloADTO(clientes);
            return clientesDTO;
        }

        public async Task<Response> GetById(long codigo)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(r => r.codigo == codigo);
            if (cliente == null)
            {
                return new Response { Mensaje = "Este cliente no existe" };
            }
            var data = ClienteDTO.DeModeloADTO(cliente);
            return new Response { Datos = data };
        }

        public async Task<Response> PostCliente(Cliente cliente)
        {
            var SavedUser = await _context.Cliente.FirstOrDefaultAsync(r => r.nombre == cliente.nombre || r.codigo == cliente.codigo);
            if (SavedUser != null)
            {
                return new Response { Mensaje = "Este cliente ya existe en el sistema" };
            }

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return new Response { Mensaje = "Cliente agregado correctamente" };
        }

        public async Task<Response> PutCliente(long codigo, Cliente cliente)
        {
               _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"El cliente con codigo {codigo} fue modificado correctamente" };
        }

        public async Task<Response> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return new Response { Mensaje = $"No tenemos un cliente con ese id" }; ;
            }
            cliente.estado = Constantes.Inactivo;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new Response { Mensaje = $"Cliente {cliente.nombre} eliminado correctamente" };
        }
    }
}
