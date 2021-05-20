using PruebaVanguardia.Helpers;
using PruebaVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia.AppService
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteDTO> GetAll();
        Task<Response> GetById(long id);
        Task<Response> PostCliente(Cliente cliente);
        Task<Response> PutCliente(long codigo, Cliente cliente);
        Task<Response> DeleteCliente(int id);
    }
}
