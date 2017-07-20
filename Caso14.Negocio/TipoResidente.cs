using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;

namespace Caso14.Negocio
{
    class TipoResidente
    {
        public int     ID_T_R                   { get; set; }
        public string  Nombre_Tipo_Residente    { get; set; }
        public string  Cargo_Junta_Vecinos      { get; set; }


        public TipoResidente()
        {
            this.Init();
        }

        private void Init()
        {
            ID_T_R                 = 0;
            Nombre_Tipo_Residente  = " ";
            Cargo_Junta_Vecinos    = " ";
        }



    }
}
