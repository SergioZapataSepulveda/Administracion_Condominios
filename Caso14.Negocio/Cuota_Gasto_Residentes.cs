using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caso14.Negocio
{
    public class Cuota_Gasto_Residentes
    {

        public int    Id_Cuota_Gasto_Mensual    { get; set; }
        public string FECHA_inicio_pago         { get; set; }
        public string FECHA_termino_pago        { get; set; }
        public string FECHA_pago_residente      { get; set; }
        public int    MONTO                     { get; set; }
        public string ESTADO                    { get; set; }
        public string RESIDENTE_Rut_Residente   { get; set; }





        public Cuota_Gasto_Residentes()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Cuota_Gasto_Mensual  = 0;
            FECHA_inicio_pago       = " ";
            FECHA_termino_pago      = " ";
            FECHA_pago_residente    = " ";
            MONTO                   = 0;
            ESTADO                  = " ";
            RESIDENTE_Rut_Residente = " ";
        } 



    }
}
