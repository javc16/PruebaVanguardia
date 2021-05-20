using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia.Models
{
    public class ClienteDTO
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public int estado { get; set; }


        public static ClienteDTO DeModeloADTO(Cliente cliente)
        {
            return cliente != null ? new ClienteDTO
            {
                id = cliente.id,
                codigo =cliente.codigo,
                nombre = cliente.nombre,
                fechaNacimiento = cliente.fechaNacimiento,
                estadoCivil = cliente.estadoCivil,
                estado = cliente.estado
            } : null;
        }

        public static IEnumerable<ClienteDTO> DeModeloADTO(IEnumerable<Cliente> cliente)
        {
            if (cliente == null)
            {
                return new List<ClienteDTO>();
            }
            List<ClienteDTO> clientesData = new List<ClienteDTO>();

            foreach (var item in cliente)
            {
                clientesData.Add(DeModeloADTO(item));
            }

            return clientesData;
        }


        public static Cliente DeDTOAModelo(ClienteDTO clienteDTO)
        {
            return clienteDTO != null ? new Cliente.Builder(clienteDTO.codigo,clienteDTO.nombre,clienteDTO.fechaNacimiento,clienteDTO.estadoCivil,clienteDTO.estado).Constuir() : null;
        }
    }
}
