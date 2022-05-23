using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Entidad;
namespace Datos
{
    public class RepositorioCuenta
    {
        string ruta = "Cuentas.txt";
        public string Guardar(Entidad.Cuenta cuenta)
        {
            try
            {
               
                
                StreamWriter escritor = new StreamWriter(ruta, true); 
                escritor.WriteLine(cuenta.ToString());
                escritor.Close(); 

                return "Se han guardaron los datos";
            }
            catch (Exception)
            {
                return "ERROR... No Se guardaron los datos";
            }

        }
        public string Modificar(List<Entidad.Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                   
                }

                escritor.Close();

                return "Se han modificado los datos";

                
            }
            catch (Exception)
            {

                return "ERROR... No Se modificar los datos";
            }

        }
        public string Modificar2(List<Entidad.Cuenta> cuentas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt", true);
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    
                }

                escritor.Close();

                File.Delete(ruta); 
                File.Move("tmp.txt", ruta);

                return "Se han modificado  los datos";

            }
            catch (Exception)
            {

                return "ERROR... No Se modificar los datos";
            }

        }
        public Cuenta Buscar(double numeroCuenta)
        {
            List<Cuenta> cuentas = Consultar();
            foreach (var item in cuentas)
            {
                if (Encontrado(item.NumeroCuenta, numeroCuenta))
                {
                    return item;
                }
            }
            return null;
        }        

           

        private bool Encontrado(double NumCuentaRegistrado, double NumCuentaBuscado)
        {
            return NumCuentaRegistrado == NumCuentaBuscado;
        }

        public void Eliminar(double numerocuenta)
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            cuentas = Consultar();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in cuentas)
            {
                if (!Encontrado(item.NumeroCuenta, numerocuenta))
                {
                    Guardar(item);
                }
            }
        }
        public List<Cuenta> Consultar()
        {
            try
            {
                List<Cuenta> cuentas = new List<Cuenta>();
                StreamReader lector = new StreamReader(ruta);
               
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();

                    double numCuenta = double.Parse(linea.Split(';')[0]);
                    Entidad.Cliente cliente = new RepositorioClientes().Buscar(linea.Split(';')[1]);
                    double saldo = double.Parse(linea.Split(';')[2]);

                    Entidad.Cuenta cuenta = new Entidad.Cuenta(numCuenta,cliente, saldo);
                    cuentas.Add(cuenta);

                 
                }

               
                lector.Close();

                return cuentas;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
