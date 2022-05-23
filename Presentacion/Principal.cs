using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Entidad;


namespace Presentacion
{
    public class Principal
    {
        public void MenuPrincipal()
        {
            int opcion;
           do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(18, 2); Console.WriteLine("----- K S A - B A N K -----");
                Console.SetCursorPosition(21, 3); Console.WriteLine("----- M E N U -----");
                Console.SetCursorPosition(15, 6); Console.WriteLine("1. OPCIONES CLIENTES");
                Console.SetCursorPosition(15, 8); Console.WriteLine("2. OPCIONES CUENTAS");
                Console.SetCursorPosition(15, 10); Console.WriteLine("3. SALIR");
                Console.SetCursorPosition(15, 12); Console.WriteLine("Seleccione una opcion >  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        new PresentacionClientes().MenuClientes(); 
                        break;
                    case 2:
                        new PresentacionCuenta().MenuCuentas();
                        break;
                    case 3:
                        Environment.Exit(3);
                        break;
                }
            } while (opcion != 3);

        }
    }
}

