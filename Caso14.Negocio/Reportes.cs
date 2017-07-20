using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using Oracle.DataAccess.Client;


namespace Caso14.Negocio
{
    public class Reportes
    {

        public int    Id_Reportes       { get; set; }
        public string Fecha             { get; set; }
        public string Tipo              { get; set; }
        public string Descripcion       { get; set; }
        public string Rut_Reportado     { get; set; }


        public Reportes()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Reportes   = 0;
            Fecha         = " ";
            Tipo          = " ";
            Descripcion   = " ";
            Rut_Reportado = " ";
        }





    }
}
