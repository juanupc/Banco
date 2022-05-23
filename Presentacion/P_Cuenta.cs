using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;
namespace Presentacion
{
    internal class Pstn_Cuenta
    {
        public void MenuCuentas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(18, 2); Console.Write("----- K S A - B A N K -----");
                Console.SetCursorPosition(21, 3); Console.Write("----- M E N U -----");
                Console.SetCursorPosition(18, 4); Console.Write("----- C U E N T A S -----");
                Console.SetCursorPosition(15, 6); Console.Write("  1. Agregar             ");
                Console.SetCursorPosition(30, 6); Console.Write("  2. Consultar           ");
                Console.SetCursorPosition(15, 8); Console.Write("  3. Modificar          ");
                Console.SetCursorPosition(30, 8); Console.Write("  4. Eliminar           ");
                Console.SetCursorPosition(15, 10); Console.Write("  5. Consignar          ");
                Console.SetCursorPosition(30, 10); Console.Write("  6. Retirar            ");
                Console.SetCursorPosition(15, 12); Console.Write("  7. Atras              ");

                Console.SetCursorPosition(15, 16); Console.Write("Seleccione una opcion >  ");
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
            Logica.S_Cuenta servico = new Logica.S_Cuenta();

            Console.Clear();
            Console.SetCursorPosition(15, 8); Console.Write("-- INGRESE LAS CREDENCIALES DEL CLIENTE -- ");
            Console.SetCursorPosition(15, 10); Console.Write("-- Identificacion del cliente > "); id = Console.ReadLine();

            cliente = new S_Clientes().BuscarID(id);

            if (cliente == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 6); Console.WriteLine("EL CLIENTE INGRESADO NO SE ENCUENTRA EN NUESTRO SISTEMA");
                Console.SetCursorPosition(25, 7); Console.WriteLine("--POR FAVOR CREAR EL CLIENTE--");
                Console.SetCursorPosition(25, 15); Console.WriteLine("--PULSE CUALQUIER TECLA PARA SALIR--");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(15, 12); Console.Write("NUMERO DE CUENTA > "); numCuenta = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(15, 14); Console.Write("DEPOSITO INICIAL > "); saldo = double.Parse(Console.ReadLine());
            Cuenta cuenta = new Cuenta(numCuenta, cliente, saldo);

            Console.SetCursorPosition(15, 18); Console.WriteLine(servico.Guardar(cuenta));
            Console.ReadKey();
        }


        void MenuConsultar()
        {

            Logica.S_Cuenta servico = new Logica.S_Cuenta();
            int i = 0;
            Console.Clear();
            Console.SetCursorPosition(20, 6); Console.Write("--LISTA DE CLIENTES--");
            Console.SetCursorPosition(22, 7); Console.Write("--CREDENCIALES--");
            Console.SetCursorPosition(20, 9); Console.Write("NUMERO DE CUENTA");
            Console.SetCursorPosition(40, 9); Console.Write("NOMBRE CLIENTE");
            Console.SetCursorPosition(65, 9); Console.Write("SALDO DISPONIBLE");


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
            Logica.S_Cuenta servico = new Logica.S_Cuenta();
            Console.Clear();
            Console.SetCursorPosition(15, 8); Console.Write("INGRESE EL NUMERO DE CUENTA > ");
            Console.SetCursorPosition(15, 10); Console.Write("NUMERO DE CUENTA > ");
            Console.SetCursorPosition(15, 12); Console.Write("NOMBRE CLIENTE > ");
            Console.SetCursorPosition(15, 14); Console.Write("SALDO > ");

            Console.SetCursorPosition(45, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("LA CUENTA INGRESADA NO EXISTE");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(32, 12); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(23, 14); Console.WriteLine(cuenta.getSaldo());

            Console.SetCursorPosition(20, 20); Console.Write(servico.Eliminar(numero_cuenta));

            Console.ReadKey();
        }


        public void MenuModificar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            Logica.S_Cuenta servico = new Logica.S_Cuenta();
            Console.Clear();

            Console.SetCursorPosition(15, 6); Console.Write("INGRESE EL NUMERO DE CUENTA");
            Console.SetCursorPosition(15, 8); Console.Write("NUMERO CUENTA > ");
            Console.SetCursorPosition(15, 10); Console.Write("NOMBRE CLIENTE > ");
            Console.SetCursorPosition(15, 12); Console.Write("SALDO > ");

            Console.SetCursorPosition(31, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("LA CUENTA NO SE ENCUENTRA REGISTRADA");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(32, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(23, 12); Console.WriteLine(cuenta.getSaldo());

            Console.SetCursorPosition(15, 15); Console.WriteLine("INGRESE LOS NUEVOS DATOS DE LA CUENTA QUE DESEA MODICAR");
            Console.SetCursorPosition(15, 17); Console.Write("NUMERO CUENTA > "); cuenta.NumeroCuenta = double.Parse(Console.ReadLine());

            Console.SetCursorPosition(20, 19); Console.WriteLine(servico.Modificar(cuenta));

            Console.ReadKey();
        }


        public void MenuConsignar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            double valor;
            Logica.S_Cuenta servico = new Logica.S_Cuenta();
            Console.Clear();

            Console.SetCursorPosition(15, 6); Console.Write("INGRESE EL NUMERO DE CUENTA");
            Console.SetCursorPosition(15, 8); Console.Write("NUMERO CUENTA > ");
            Console.SetCursorPosition(15, 10); Console.Write("NOMBRE CLIENTE > ");
            Console.SetCursorPosition(15, 12); Console.Write("SALDO > ");

            Console.SetCursorPosition(32, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("LA CUENTA NO SE ENCUENTRA REGISTRADA");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(32, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(23, 12); Console.WriteLine(cuenta.getSaldo());
            Console.SetCursorPosition(55, 8); Console.WriteLine("¿ CUANTO DESEA INGRESAR ?");
            Console.SetCursorPosition(55, 10); Console.Write("DINERO > "); valor = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(32, 14); Console.WriteLine(cuenta.Consignar(valor));
            Console.SetCursorPosition(32, 15); Console.WriteLine(servico.Modificar(cuenta));
            Console.ReadKey();
        }


        public void MenuRetirar()
        {
            Entidad.Cuenta cuenta;
            double numero_cuenta;
            double valor;
            Logica.S_Cuenta servico = new Logica.S_Cuenta();
            Console.Clear();

            Console.SetCursorPosition(15, 6); Console.Write("INGRESE EL NUMERO DE CUENTA");
            Console.SetCursorPosition(15, 8); Console.Write("NUMERO CUENTA > ");
            Console.SetCursorPosition(15, 10); Console.Write("NOMBRE CLIENTE > ");
            Console.SetCursorPosition(15, 12); Console.Write("SALDO > ");

            Console.SetCursorPosition(32, 8); numero_cuenta = Convert.ToDouble(Console.ReadLine());

            cuenta = servico.BuscarNumCuenta(numero_cuenta);
            if (cuenta == null)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 8); Console.WriteLine("LA CUENTA NO SE ENCUENTRA REGISTRADA");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(32, 10); Console.WriteLine(cuenta.Cliente.Nombre);
            Console.SetCursorPosition(23, 12); Console.WriteLine(cuenta.getSaldo());
            Console.SetCursorPosition(55, 8); Console.WriteLine("¿ CUANTO DESEA SOLICITAR ?");
            Console.SetCursorPosition(55, 10); Console.Write("DINERO > "); valor = double.Parse(Console.ReadLine());
            Console.SetCursorPosition(32, 14); Console.WriteLine(cuenta.Retirar(valor));
            Console.SetCursorPosition(32, 15); Console.WriteLine(servico.Modificar(cuenta));

            Console.ReadKey();
        }
    }
}
