using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public Cliente(string idCliente, string nombre)
        {
            IdCliente = idCliente;
            Nombre = nombre;
        }
        public Cliente()
        {

        }
        public Cliente(string linea)
        {
            if (linea != null)
            {
                Mapear(linea);
            } 
           
        }
        public string Linea()
        {
            return IdCliente + ";" + Nombre;    
        }
        private void Mapear(string linea)
        {            
            IdCliente = linea.Split(';')[0];
            Nombre = linea.Split(';')[1];
        }
    }
}
