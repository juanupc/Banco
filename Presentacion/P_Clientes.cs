using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Pstn_Clientes
    {
        public void MenuClientes()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(18, 2); Console.Write("----- K S A - B A N K -----");
                Console.SetCursorPosition(21, 3); Console.Write("----- M E N U -----");
                Console.SetCursorPosition(18, 4); Console.Write("----- C L I E N T E S -----");
                Console.SetCursorPosition(15, 6); Console.Write("  1. Agregar ");
                Console.SetCursorPosition(30, 6); Console.Write("  2. Consultar ");
                Console.SetCursorPosition(15, 8); Console.Write("  3. Modificar ");
                Console.SetCursorPosition(30, 8); Console.Write("  4. Eliminar ");
                Console.SetCursorPosition(16, 10); Console.Write(" 5. Atras ");
                Console.SetCursorPosition(15, 14); Console.Write("Seleccione una opcion >  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        MenuAgregar();
                        break;
                    case 2:
                        MenuConsultar();
                        break;
                    case 3:
                        MenuModificar();
                        break;
                    case 4:
                        MenuEliminar();
                        break;
                    case 5:

                        break;
                }
            } while (opcion != 5);

        }

        public void MenuAgregar()
        {
            Entidad.Cliente cliente = new Entidad.Cliente();
            Logica.S_Clientes servico = new Logica.S_Clientes();
            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("-- INGRESE LAS CREDENCIALES DEL CLIENTE -- ");
            Console.SetCursorPosition(20, 8); Console.Write("-- Identificacion del cliente > "); cliente.IdCliente = Console.ReadLine();
            Console.SetCursorPosition(20, 10); Console.Write("NOMBRE CLIENTE : "); cliente.Nombre = Console.ReadLine();
            Console.SetCursorPosition(20, 13); Console.WriteLine(servico.Guardar(cliente));
            Console.ReadKey();
        }
        public void MenuConsultar()
        {
            Entidad.Cliente cliente = new Entidad.Cliente();
            Logica.S_Clientes servico = new Logica.S_Clientes();
            int i = 0;
            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("LISTA DE CLIENTES");
            Console.SetCursorPosition(20, 9); Console.Write("IDENTIFICACION");
            Console.SetCursorPosition(35, 9); Console.Write("NOMBRE CLIENTE");
            foreach (var item in servico.Consultar())
            {
                i = i + 2;
                Console.SetCursorPosition(20, 10 + i); Console.Write(item.IdCliente);
                Console.SetCursorPosition(35, 10 + i); Console.Write(item.Nombre);
            }

            Console.ReadKey();
        }
        public void MenuEliminar()
        {
            Entidad.Cliente cliente;
            string id_cliente;
            Logica.S_Clientes servico = new Logica.S_Clientes();
            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("INGRESE LA IDENTIFICACION ");
            Console.SetCursorPosition(20, 8); Console.Write("IDENTIFICACION > ");
            Console.SetCursorPosition(20, 10); Console.Write("NOMBRE CLIENTE > ");

            Console.SetCursorPosition(38, 8); id_cliente = Console.ReadLine();

            cliente = servico.BuscarID(id_cliente);
            if (cliente == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 10); Console.WriteLine("EL CLIENTE NO SE ENCUENTRA REGISTRADO");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(38, 10); Console.WriteLine(cliente.Nombre);

            Console.SetCursorPosition(20, 13); Console.Write(servico.Eliminar(id_cliente));

            Console.ReadKey();
        }

        public void MenuModificar()
        {
            Entidad.Cliente cliente;
            string id_cliente;
            Logica.S_Clientes servico = new Logica.S_Clientes();
            Console.Clear();

            Console.SetCursorPosition(20, 6); Console.Write("INGRESE EL ID DEL CLIENTE QUE DESEA MODIFICAR");
            Console.SetCursorPosition(20, 8); Console.Write("IDENTIFICACION > ");
            Console.SetCursorPosition(20, 10); Console.Write("NOMBRE CLIENTE >  ");

            Console.SetCursorPosition(37, 8); id_cliente = Console.ReadLine();

            cliente = servico.BuscarID(id_cliente);
            if (cliente == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 10); Console.WriteLine("EL CLIENTE NO SE ENCUENTRA REGISTRADO");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(38, 10); Console.WriteLine(cliente.Nombre);

            Console.SetCursorPosition(20, 13); Console.WriteLine("INGRESE LOS NUEVOS DATOS");
            Console.SetCursorPosition(20, 15); Console.Write("IDENTIFICACION >"); cliente.IdCliente = Console.ReadLine();
            Console.SetCursorPosition(20, 17); Console.Write("NOMBRE CLIENTE > "); cliente.Nombre = Console.ReadLine();

            Console.SetCursorPosition(20, 21); Console.WriteLine(servico.Modificar(cliente));

            Console.ReadKey();
        }
    }


}

