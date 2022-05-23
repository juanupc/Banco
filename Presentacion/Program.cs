using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Entidad;

using static Logica.ServicioClientes;

namespace Presentacion
{
    static class Program
    {
        
        static void Main(string[] args)
        {
            Menuprincipal vistaPrincipal = new Menuprincipal();
            vistaPrincipal.MenuPrincipal();
            
        }
    }
}

