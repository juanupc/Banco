using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Entidad;
namespace Datos
{
    public class R_Cuenta
    {
        string ruta = "Cuentas.txt";// ruta donde se guarda el archivo
        public string Guardar(Entidad.Cuenta cuenta)
        {
            try
            {
                //FileStream archivo = new FileStream(ruta, FileMode.Append);
                
                StreamWriter escritor = new StreamWriter(ruta, true);  //1. instanciar - abre en modo append -  adiciona datos
                escritor.WriteLine(cuenta.ToString()); // 2. operaciones 
                escritor.Close();  //3.  guardar

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
                StreamWriter escritor = new StreamWriter(ruta, false);// sobreescribe
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                return "Se han modificado los datos";

                //File.Delete(ruta);  // elimina
                //File.Move("tmp", ruta);// renombrar
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
                StreamWriter escritor = new StreamWriter("tmp.txt", true);// sobreescribe
                foreach (var item in cuentas)
                {
                    escritor.WriteLine(item.ToString());
                    //close
                }

                escritor.Close();

                File.Delete(ruta);  // elimina
                File.Move("tmp.txt", ruta);// renombrar

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
                // 2. operaciones
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();

                    double numCuenta = double.Parse(linea.Split(';')[0]);
                    Entidad.Cliente cliente = new R_Clientes().Buscar(linea.Split(';')[1]);
                    double saldo = double.Parse(linea.Split(';')[2]);

                    Entidad.Cuenta cuenta = new Entidad.Cuenta(numCuenta,cliente, saldo);
                    cuentas.Add(cuenta);

                    //clientes.Add(new Entidad.Cliente(linea.Split(';')[0], linea.Split(';')[1]));
                }

                //3.  guardar
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
