using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;

namespace Caso14.Negocio
{
    public class Servicio
    {

        public int M_Capacidad_Servicio_porID(int Id_Busqueda)
        {
            try
            {
                return ModeloBD.Instanciar.SERVICIO.First(a => a.ID_SERVICIO == Id_Busqueda).CANTIDAD_TOTAL;
            }
            catch (Exception)
            {
                return 1;
            }
        }


        public int M_Precio_Servicio_porID(int Id_Busqueda)
        {
            try
            {
                return ModeloBD.Instanciar.SERVICIO.FirstOrDefault(a => a.ID_SERVICIO == Id_Busqueda).VALOR_TRAMO;
            }
            catch (Exception)
            {
                return 500;
            }
        }
      




    }
}
