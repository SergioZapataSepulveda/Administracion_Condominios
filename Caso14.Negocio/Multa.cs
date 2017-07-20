using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caso14.Negocio
{
    public class Multa
    {

      

        public int        ID_Multa                  { get; set; }
        public string     Fecha_Creacion_Multa      { get; set; }
        public string     Fecha_Pago_Multa          { get; set; }
        public int        Monto                     { get; set; }
        public string     Descripcion               { get; set; }
        public string     ESTADO                    { get; set; }
        public string     RESIDENTE_Rut_Residente   { get; set; }




        public Multa()
        {
            this.Init();
        }

        private void Init()
        {
            ID_Multa    			  = 0;
            Fecha_Creacion_Multa      = " ";
            Fecha_Pago_Multa          = " ";
            Monto       			  = 0;
            Descripcion 			  = " ";
            ESTADO                    = " ";
            RESIDENTE_Rut_Residente   = " ";
        }
    }
}
