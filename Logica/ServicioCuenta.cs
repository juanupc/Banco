using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Logica
{
    public class ServicioCuenta
    {
        Datos.RepositorioCuenta repositorioCuenta = new Datos.RepositorioCuenta();
        List<Cuenta> Cuentas;
        public ServicioCuenta()
        {
            Cuentas = repositorioCuenta.Consultar();
        }
        public string Guardar(Cuenta cuenta)
        {
            string mensaje = string.Empty;
           

            mensaje = repositorioCuenta.Guardar(cuenta);
            Actualizar();
            return mensaje;
        }

        private void Actualizar()
        {
            Cuentas = repositorioCuenta.Consultar();
        }

        public List<Cuenta> Consultar()
        {
            Actualizar();
            return Cuentas;
        }

        public Cuenta BuscarNumCuenta(double NumCuenta)
        {
            foreach (var item in Cuentas)
            {
                if (item.NumeroCuenta == NumCuenta)
                {
                    return item;
                }

            }
            return null;

        }

        public string Eliminar(double NumCuenta)
        {
            Cuenta cuenta = BuscarNumCuenta(NumCuenta);
            if (cuenta == null)
            {
                return "La cuenta ingresada, no ha sido encontrada";
            }
            else
            {
                Cuentas.Remove(cuenta);

                repositorioCuenta.Modificar2(Cuentas);
                return "la cuenta ha sido eliminada";
            }
        }

        public string Modificar(Cuenta cuenta_New)
        {
            Cuenta cuenta_actual = BuscarNumCuenta(cuenta_New.NumeroCuenta);
            if (cuenta_actual == null)
            {
                return Guardar(cuenta_New);

            }
            else
            {
                cuenta_actual.Cliente = cuenta_New.Cliente;
                return repositorioCuenta.Modificar2(Cuentas);
            }

        }

        public class CuentaConsultaResponse
        {
            public List<Cuenta> Cuentas { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool CuentaEncontrada { get; set; }
            public CuentaConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                CuentaEncontrada = false;
            }
            public CuentaConsultaResponse(List<Cuenta> cuentas)
            {
                Cuentas = cuentas;
                Error = false;
                CuentaEncontrada = true;
            }
        }



    }
}
