using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia.Models
{
    public class Cliente
    {
        //código, nombre, fecha nacimiento, estado civil, activo
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public int estado { get; set; }


        public sealed class Builder
        {
            private readonly Cliente _cliente;

            public Builder(int  codigo, string nombre, DateTime fecha, string estadoCivil, int estado)
            {
                _cliente = new Cliente
                {
                    codigo = codigo,
                    nombre = nombre,
                    fechaNacimiento = fecha,
                    estadoCivil = estadoCivil,
                    estado =estado
                };
            }          

            public Cliente Constuir()
            {
                return _cliente;
            }
        }
    }
}
