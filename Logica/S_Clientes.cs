using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Logica
{
    public class S_Clientes
    {
        List<Cliente> clientes;
        R_Clientes repositorioClientes = new R_Clientes();//datos
        public S_Clientes()
        {   
            clientes = repositorioClientes.ConsultarTodos();  // trae a los clientes del archivo
        }

        public string Guardar(Cliente cliente)
        {
            string mensaje= string.Empty;
            try
            {
                
                if (repositorioClientes.Buscar(cliente.IdCliente) == null)
                {
                    mensaje= repositorioClientes.Guardar(cliente);
                    Actualizar();
                    return mensaje; //"Se guardaron los datos de manera exitosa";
                    // aqui no pasa nada
                }
                return mensaje; //"No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "ERROR: " + e.Message;
            }
        }

        private void Actualizar()
        {
            clientes = repositorioClientes.ConsultarTodos();
        }
        public List<Cliente> Consultar()
        {
            return clientes;
        }

        public Cliente BuscarID(string IDcliente)
        {
            foreach (var item in clientes)
            {
                if (item.IdCliente==IDcliente)
                {
                    return item;
                }
               
            }
            return null;

        }

        public string Eliminar(string identificacion)
        {
            Cliente cliente = BuscarID(identificacion);
            if (cliente == null)
            {
                return "El cliente ingresado, no ha sido encontrado";
            }
            else
            {
                clientes.Remove(cliente);

                repositorioClientes.Modificar2(clientes);
                return "El cliente ha sido eliminado";
            }
        }

        public string Modificar(Cliente cliente_New)
        {
            Cliente cliente_actual = BuscarID(cliente_New.IdCliente);
            if (cliente_actual == null)
            {
                return Guardar(cliente_New);

            }
            else
            {
                cliente_actual.Nombre = cliente_New.Nombre;
                return repositorioClientes.Modificar2(clientes);
            }
            
        }
        //public void ConsultarIdentificacion(string identificacion)
        //{
        //    try
        //    {
        //        List<Cliente> clientes = repositorioClientes.FiltrarIdentificacion(identificacion);
        //        var response = new ClienteConsultaResponse(clientes);
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        var response = new ClienteConsultaResponse("Error:" + e.Message);
        //        return response;
        //        //}
        //    }

        public class ClienteConsultaResponse
        {
            public List<Cliente> Clientes { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool ClienteEncontrado { get; set; }
            public ClienteConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                ClienteEncontrado = false;
            }
            public ClienteConsultaResponse(List<Cliente> clientes)
            {
                Clientes = clientes;
                Error = false;
                ClienteEncontrado = true;
            }
        }
    }
}

