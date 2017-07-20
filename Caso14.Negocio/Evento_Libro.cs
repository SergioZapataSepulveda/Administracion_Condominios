using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caso14.Negocio
{
    public class Evento_Libro
    {
        public int    Id_Evento_Libro      { get; set; }
        public string Titulo               { get; set; }
        public string Descripcion          { get; set; }
        public string Fecha                { get; set; }
        public string Area_Comun           { get; set; }
        public string Rut_Involucrado      { get; set; }
        public string Rut_Funcionario      { get; set; }


        public Evento_Libro()
        {
            this.Init();
        }


        private void Init()
        {
            Id_Evento_Libro  = 0;
            Titulo           = " ";
            Descripcion      = " ";
            Fecha            = " ";
            Area_Comun       = " ";
            Rut_Involucrado  = " ";
            Rut_Funcionario  = " ";
        }





    }
}