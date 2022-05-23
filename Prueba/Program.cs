using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Datos;

namespace Prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //entidades
            //Cliente cliente = new Cliente("1009", "abc");
            //Cliente cliente1 = new Cliente("1019", "xyz");

            //datos
            //RepositorioClientes clientes = new RepositorioClientes();

            //Console.WriteLine(clientes.Guardar(cliente));
            //Console.WriteLine(clientes.Guardar(cliente1));

            Console.WriteLine("___________________");
            //logica
            Logica.ServicioClientes servicioCliente = new Logica.ServicioClientes();

            //Console.WriteLine(servicioCliente.Modificar("1060", new Cliente("1060", "pedro")));
            //foreach (var item in servicioCliente.)
            //{

            
            Console.ReadKey();
        }
    }
}
