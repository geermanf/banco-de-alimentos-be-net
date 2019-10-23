using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.Entities.Common
{
    public class IncorrectCustomerVariablesException : ArgumentException
    {
        public IncorrectCustomerVariablesException(string msg = null, ArgumentException inner = null) : base("No se han podido procesar las variables de cliente. Verifique que fueron ingresadas correctamente mirando las referencias.", inner)
        {

        }
    }
}
