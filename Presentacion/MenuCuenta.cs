using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;
namespace Presentacion
{
    internal class MenuCuenta
    {
        public void MenuCuentas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(18, 2); Console.WriteLine("----- K S A - B A N K -----");
                Console.SetCursorPosition(21, 3); Console.WriteLine("----- M E N U -----");
                Console.SetCursorPosition(18, 4); Console.WriteLine("----- C U E N T A S -----");
                Console.SetCursorPosition(15, 6); Console.WriteLine("  1. Agregar             ");
                Console.SetCursorPosition(30, 6); Console.WriteLine("  2. Consultar           ");
                Console.SetCursorPosition(15, 8); Console.WriteLine("  3. Modificar          ");
                Console.SetCursorPosition(30, 8); Console.WriteLine("  4. Eliminar           ");
                Console.SetCursorPosition(15, 10); Console.WriteLine("  5. Consignar          ");
                Console.SetCursorPosition(30, 10); Console.WriteLine("  6. Retirar            ");
                Console.SetCursorPosition(15, 12); Console.WriteLine("  7. Atras              ");
                Console.SetCursorPosition(15, 16); Console.Write("Seleccione una opcion : ");
                Console.SetCursorPosition(15, 25); Console.Write("CRISTIAN FABIAN BAQUERO BASTIDAS");
                Console.SetCursorPosition(15, 26); Console.Write("JUAN ANDRES SALCEDO BERMUDEZ");
                Console.SetCursorPosition(38, 16); opcion = Convert.ToInt32(Console.ReadLine());
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
                        MenuConsignar();
                        break;
                    case 6:
                        MenuRetirar();
                        break;
                    case 7:

                        break;
                }
            } while (opcion != 7);
        }
        void MenuAgregar()
        {
            Cliente cliente;
            double numCuenta, saldo;
            string id;
            Logica.ServicioCuenta servico = new Logica.ServicioCuenta();

            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("INGRESE EL ID DEL CLIENTE ");
            Console.SetCursorPosition(20, 8); Console.Write("Id Cliente : "); id = Console.ReadLine();

            cliente = new ServicioClientes().BuscarID(id);

            if (cliente == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 6); Console.WriteLine("El cliente ingresado no existe, nesecita crearlo primero");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(20, 10); Console.Write("Numero de cuenta : "); numCuenta = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(20, 12); Console.Write("Saldo inicial : "); saldo = double.Parse(Console.ReadLine());
            Cuenta cuenta = new Cuenta(numCuenta, cliente, saldo);
            Console.SetCursorPosition(20, 14); Console.WriteLine(servico.Guardar(cuenta));
            Console.ReadKey();
        }

        void MenuConsultar()
        {

            Logica.ServicioCuenta servico = new Logica.ServicioCuenta();
            int i = 0;
            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("LISTA DE CLIENTES");
            Console.SetCursorPosition(20, 9); Console.Write("Numero Cuenta");
            Console.SetCursorPosition(40, 9); Console.Write("Nombre Cliente");
            Console.SetCursorPosition(65, 9); Console.Write("Saldo");


            foreach (var item in servico.Consultar())
            {
                i = i + 2;
                Console.SetCursorPosition(20, 10 + i); Console.Write(item.NumeroCuenta);
                Console.SetCursorPosition(40, 10 + i); Console.Write(item.Cliente.Nombre);
                Console.SetCursorPosition(65, 10 + i); Console.Write(item.getSaldo());

            }
            Console.ReadKey();
        }

        public void MenuEliminar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            Logica.ServicioCuenta servico = new Logica.ServicioCuenta();
            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("INGRESE EL NUEMRO DE CUENTA QUE DESEA ELIMINAR");
            Console.SetCursorPosition(20, 8); Console.Write("Numero Cuenta : ");
            Console.SetCursorPosition(20, 10); Console.Write("Nombre Cliente : ");
            Console.SetCursorPosition(20, 12); Console.Write("Saldo : ");

            Console.SetCursorPosition(37, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("La cuenta no existe");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(39, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(30, 12); Console.WriteLine(cuenta.getSaldo());
            Console.SetCursorPosition(20, 15); Console.Write(servico.Eliminar(numero_cuenta));

            Console.ReadKey();
        }

        public void MenuModificar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            Logica.ServicioCuenta servico = new Logica.ServicioCuenta();
            Console.Clear();

            Console.SetCursorPosition(20, 6); Console.Write("INGRESE EL NUEMRO DE CUENTA QUE DESEA MODIFICAR");
            Console.SetCursorPosition(20, 8); Console.Write("Numero Cuenta : ");
            Console.SetCursorPosition(20, 10); Console.Write("Nombre Cliente : ");
            Console.SetCursorPosition(20, 12); Console.Write("Saldo : ");

            Console.SetCursorPosition(37, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("La cuenta no existe");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(39, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(30, 12); Console.WriteLine(cuenta.getSaldo());
            Console.SetCursorPosition(20, 15); Console.WriteLine("INGRESE LOS NUEVOS DATOS DE LA CUENTA QUE DESEA MODICAR");
            Console.SetCursorPosition(20, 17); Console.Write("Numero Cuenta : "); cuenta.NumeroCuenta = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(20, 19); Console.WriteLine(servico.Modificar(cuenta));

            Console.ReadKey();
        }

        public void MenuConsignar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            double valor;
            Logica.ServicioCuenta servico = new Logica.ServicioCuenta();
            Console.Clear();

            Console.SetCursorPosition(20, 6); Console.Write("INGRESE EL NUMERO DE CUENTA A LA QUE DESEA CONSIGNAR");
            Console.SetCursorPosition(20, 8); Console.Write("Numero Cuenta : ");
            Console.SetCursorPosition(20, 10); Console.Write("Nombre Cliente : ");
            Console.SetCursorPosition(20, 12); Console.Write("Saldo : ");

            Console.SetCursorPosition(37, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("La cuenta no existe");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(39, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(30, 12); Console.WriteLine(cuenta.getSaldo());
            Console.SetCursorPosition(20, 15); Console.WriteLine("INGRESE EL MONTO DE DINERO QUE DESEA CONSIGNAR A LA CUENTA");
            Console.SetCursorPosition(20, 17); Console.Write("Valor : "); valor = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(20, 20); Console.WriteLine(cuenta.Consignar(valor));
            Console.SetCursorPosition(20, 21); Console.WriteLine(servico.Modificar(cuenta));

            Console.ReadKey();
        }

        public void MenuRetirar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            double valor;
            Logica.ServicioCuenta servico = new Logica.ServicioCuenta();
            Console.Clear();

            Console.SetCursorPosition(20, 6); Console.Write("INGRESE EL NUMERO DE CUENTA DE LA QUE DESEA RETIRAR");
            Console.SetCursorPosition(20, 8); Console.Write("Numero Cuenta : ");
            Console.SetCursorPosition(20, 10); Console.Write("Nombre Cliente : ");
            Console.SetCursorPosition(20, 12); Console.Write("Saldo : ");

            Console.SetCursorPosition(37, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("La cuenta no existe");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(39, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(30, 12); Console.WriteLine(cuenta.getSaldo());
            Console.SetCursorPosition(20, 15); Console.WriteLine("INGRESE EL MONTO DE DINERO QUE DESEA RETIRAR A LA CUENTA");
            Console.SetCursorPosition(20, 17); Console.Write("Valor : "); valor = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(20, 20); Console.WriteLine(cuenta.Retirar(valor));
            Console.SetCursorPosition(20, 21); Console.WriteLine(servico.Modificar(cuenta));

            Console.ReadKey();
        }
    }
}
