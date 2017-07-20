using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using Oracle.DataAccess.Client;

namespace Caso14.Negocio
{
    public class Pago_Offline
    {

        public int     id_pago_offline   { get; set; }  
        public string  nombre_archivo    { get; set; }
        public string  fecha             { get; set; }
        public string  tipo              { get; set; }
        public string  rut_resitente     { get; set; }


        public Pago_Offline()
        {
            this.Init();
        }

        private void Init()
        {
            id_pago_offline   = 0;
            nombre_archivo    = " ";
            fecha             = " ";
            tipo              = " ";
            rut_resitente     = " ";
        }

    }
}
