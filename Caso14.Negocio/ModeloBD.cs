using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;

namespace Caso14.Negocio
{
    class ModeloBD
    {
        private static Entities _instanciar;

        public static Entities Instanciar
        {
            get
            {
                if (_instanciar == null)
                {
                    _instanciar = new Entities();
                }
                return _instanciar;
            }
            set { _instanciar = value; }
        }
    }
}
          
