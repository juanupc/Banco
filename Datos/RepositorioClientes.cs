using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class RepositorioClientes
    {
        string ruta = "Clientes.txt";
        public string Guardar(Cliente cliente)
        {
            try
            {
                
                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(cliente.Linea());
                escritor.Close();
                return "Se han guardado los datos";
            }
            catch (Exception)
            {
                return "ERROR...No se han guardado los datos";
            }
            
        }

        public string Modificar(List<Entidad.Cliente> clientes)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.Linea());
                   
                }
                            
                escritor.Close();
               
                return "Se han modificado los datos";

              
            }
            catch (Exception)
            {

                return "ERROR...NO Se han modificado los datos";
            }

        }

        public string Modificar2(List<Entidad.Cliente> clientes) 
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt");// sobreescribe
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.Linea());
                    //close
                }

                escritor.Close();

                File.Delete(ruta); 

                File.Move("tmp.txt", ruta);

                return "Los Datos se modificaron exitosamente";

            }
            catch (Exception)
            {

                return "ERROR...NO Se han modificado los datos";
            }

        }

        public Cliente Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultaGeneral();
            foreach (var item in clientes)
            {
                if (Encontrado(item.IdCliente, identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        private bool Encontrado(string IdClienteRegistrado, string IdClienteBuscado)
        {
            return IdClienteRegistrado == IdClienteBuscado;
        }

        public List<Cliente> ConsultaGeneral()
        {
            List<Cliente> clientes = new List<Cliente>();
           
            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea =lector.ReadLine();
                Cliente cliente = new Cliente(linea);       
                clientes.Add(cliente);
            }
            lector.Close();
           
            return clientes;
        }
        

        public void Eliminar(String identificacion)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = ConsultaGeneral();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in clientes)
            {
                if (!Encontrado(item.IdCliente, identificacion))
                {
                    Guardar(item);
                }
            }
        }
       
        public List<Cliente> FiltrarIdentificacion(string identificacion)
        {
            return ConsultaGeneral().Where(p => p.IdCliente.Equals(identificacion)).ToList();
        }

    }
}

