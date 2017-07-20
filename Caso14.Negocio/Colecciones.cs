using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using Oracle.DataAccess.Client;

namespace Caso14.Negocio
{
    public class Colecciones
    {
        private List<Residente> ListarResidente(List<Caso14.Datos.RESIDENTE> aux)
        {
            List<Residente> salida = new List<Residente>();
            foreach (Caso14.Datos.RESIDENTE item in aux)
            {
                salida.Add(new Residente()
                {
                    Rut_Residente           = item.RUT_RESIDENTE,
                    Nombre_Residente        = item.NOMBRE_RESIDENTE,
                    Nivel_Acceso            = Convert.ToInt32(item.NIVEL_ACCESO),
                    Direccion               = item.DIRECCION,
                    Correo                  = item.CORREO,
                    TIPO_RESIDENTE_ID_T_R   = Convert.ToInt32(item.TIPO_RESIDENTE_ID_T_R)
                });
            }
            return salida;
        }


        public List<Residente> ListarResidente()
        {
            return ListarResidente(ModeloBD.Instanciar.RESIDENTE.ToList());
        }

        public List<Residente> ListarResidentesTotales() 
        {
            return ListarResidente(ModeloBD.Instanciar.RESIDENTE.Where(a => a.RUT_RESIDENTE == "1690").ToList());
        }








        // DETALLE_RESERVA

        private List<Detalle_Reserva> ListarDetalleReserva(List<Caso14.Datos.DETALLE_RESERVA> aux)
        {
            List<Detalle_Reserva> salida = new List<Detalle_Reserva>();
            foreach (Caso14.Datos.DETALLE_RESERVA item in aux)
            {
                salida.Add(new Detalle_Reserva()
                {
                    id_d_r                = item.ID_D_R                     ,
                    estado                = item.ESTADO                     ,
                    Cap_Usada_Tramo_1     = item.CAP_USADA_TRAMO_1          ,
                    Cap_Usada_Tramo_2     = item.CAP_USADA_TRAMO_2          ,
                    Cap_Usada_Tramo_3     = item.CAP_USADA_TRAMO_3          ,
                    fecha_areservar       = item.FECHA_ARESERVAR.ToString() ,
                    Costo_Reserva         = item.COSTO_RESERVA              ,
                    reporte               = item.REPORTE                    ,
                    reserva_id_reserva    = (Int32)item.RESERVA_ID_RESERVA  ,
                    servicio_id_servicio  = item.SERVICIO_ID_SERVICIO       ,

                });
            }
            return salida;
        }


        public List<Detalle_Reserva> ListarDetalleReserva()
        {
            return ListarDetalleReserva(ModeloBD.Instanciar.DETALLE_RESERVA.ToList());
        }

        public List<Detalle_Reserva> ListarDetalleReserva(string _fecha_areservar)
        {
            DateTime auxFecha = DateTime.Parse(_fecha_areservar);
            return ListarDetalleReserva(ModeloBD.Instanciar.DETALLE_RESERVA.Where(v => v.FECHA_ARESERVAR >= auxFecha).ToList());
        }





        private List<Administracion> ListarIngresoAdministracion(List<Caso14.Datos.ADMINISTRACION_CONTABLE> aux)
        {
            List<Administracion> salida = new List<Administracion>();
            foreach (Caso14.Datos.ADMINISTRACION_CONTABLE item in aux)
            {
                salida.Add(new Administracion()
                {
                    Id_Administracion = item.ID_ADMISTRACION,
                    Fecha             = (String.Format("{0:MM'/'yyyy }", item.FECHA)),
                    Tipo              = item.TIPO, 
                    Monto             = item.MONTO,
                    Descripcion       = item.DESCRIPCION,
                    Condominio_id     = item.CONDOMINIO_ID_CONDOMINIO
                });
            }
            return salida;
        }

        public List<Administracion> ListarIngresoAdministracion(int id_Condominio)
        {
            return ListarIngresoAdministracion(ModeloBD.Instanciar.ADMINISTRACION_CONTABLE.Where(t => t.CONDOMINIO_ID_CONDOMINIO == id_Condominio).ToList());
        }



        public List<Administracion> ListarIngresoAdministracion(string filtroFecha, string fechaMax, int id_Condominio)
        {
            var aux = DateTime.Parse(filtroFecha);
            var _fechaMax = DateTime.Parse(fechaMax);
            return ListarIngresoAdministracion(ModeloBD.Instanciar.ADMINISTRACION_CONTABLE.Where(v => v.FECHA >= aux).Where(t => t.FECHA <= _fechaMax).Where(u => u.CONDOMINIO_ID_CONDOMINIO == id_Condominio).ToList());
            //v => v.FECHA.ToString().Equals(aux)  Convert.ToInt32(String.Format("{0:MM}", v.FECHA))
        }











        // listar reportes

        private List<Reportes> ListarReportes(List<Caso14.Datos.REPORTES> aux)
        {
            List<Reportes> salida = new List<Reportes>();
            foreach (Caso14.Datos.REPORTES item in aux)
            {
                salida.Add(new Reportes()
                {
                    Id_Reportes   = (Int32)item.ID_REPORTES ,
                    Fecha         = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA)),
                    Tipo          = item.TIPO ,
                    Descripcion   = item.DESCRIPCION ,
                    Rut_Reportado = item.RUT_REPORTADO

                });
            }
            return salida;
        }


        public List<Reportes> ListarReportes()
        {
            return ListarReportes(ModeloBD.Instanciar.REPORTES.OrderBy(a => a.FECHA).ToList());
        }










        // listar MULTAS

        private List<Multa> ListarMultas(List<Caso14.Datos.MULTA> aux)
        {
            List<Multa> salida = new List<Multa>();
            foreach (Caso14.Datos.MULTA item in aux)
            {
                salida.Add(new Multa()
                {
                    ID_Multa                = item.ID_MULTA,
                    Fecha_Creacion_Multa    = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_CREACION_MULTA)),
                    Fecha_Pago_Multa        = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_PAGO_MULTA)),
                    Monto                   = item.MONTO,
                    Descripcion             = item.DESCRIPCION,
                    ESTADO                  = item.ESTADO,
                    RESIDENTE_Rut_Residente = item.RESIDENTE_RUT_RESIDENTE

                });
            }
            return salida;
        }


        public List<Multa> ListarMultas2(int idCondominio)
        {

            var aux = (from multa in ModeloBD.Instanciar.MULTA
                       join residente in ModeloBD.Instanciar.RESIDENTE
                       on multa.RESIDENTE_RUT_RESIDENTE equals residente.RUT_RESIDENTE

                       join vivienda in ModeloBD.Instanciar.VIVIENDA
                       on residente.RUT_RESIDENTE equals vivienda.RESIDENTE_RUT_RESIDENTE

                       join condominio in ModeloBD.Instanciar.CONDOMINIO
                       on vivienda.CONDOMINIO_ID_CONDOMINIO equals condominio.ID_CONDOMINIO

                       where condominio.ID_CONDOMINIO == idCondominio

                       select multa).ToList();

            return ListarMultas(aux);
        }


        public List<Multa> ListarMultas(int idCondominio) 
        {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("SELECT MULTA.ID_Multa,  MULTA.Monto,   MULTA.Descripcion,  MULTA.ESTADO, MULTA.RESIDENTE_Rut_Residente, MULTA.Fecha_Creacion_Multa, to_DATE(MULTA.Fecha_Pago_Multa, 'dd/mm/yyyy')            FROM multa inner join residente on multa.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE " +
                                                " inner join vivienda on vivienda.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE  inner join condominio " +
                                                " on vivienda.CONDOMINIO_ID_CONDOMINIO = condominio.ID_CONDOMINIO where condominio.ID_CONDOMINIO =  {0} ",  idCondominio);

                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                List<Multa> results = new List<Multa>();
                int count = dr.FieldCount;
                string final = string.Empty;
                while (dr.Read())
                {
                    Multa listar = new Multa();
                    listar.ID_Multa                 = dr.GetInt32(0);
                    listar.Monto                    = dr.GetInt32(1);
                    listar.Descripcion              = dr.GetString(2);
                    listar.ESTADO                   = dr.GetString(3);
                    listar.RESIDENTE_Rut_Residente  = dr.GetString(4);
                    listar.Fecha_Creacion_Multa     = String.Format("{0:dd'-'MM'-20'yy }", dr.GetDateTime(5));
                    try
                    {
                        listar.Fecha_Pago_Multa = String.Format("{0:dd'-'MM'-20'yy }", dr.GetDateTime(6));
                    }
                    catch (Exception)
                    {
                        listar.Fecha_Pago_Multa = "";
                    }
                    results.Add(listar);
                }
                return results;
        }





        public List<Multa> ListarMultasPorResidnte(int idCondominio, string rut)
        {

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;

            cmd.CommandText = string.Format("SELECT MULTA.ID_Multa,  MULTA.Monto,   MULTA.Descripcion,  MULTA.ESTADO, MULTA.RESIDENTE_Rut_Residente, MULTA.Fecha_Creacion_Multa, to_DATE(MULTA.Fecha_Pago_Multa, 'dd/mm/yyyy')            FROM multa inner join residente on multa.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE " +
                                            " inner join vivienda on vivienda.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE  inner join condominio " +
                                            " on vivienda.CONDOMINIO_ID_CONDOMINIO = condominio.ID_CONDOMINIO where condominio.ID_CONDOMINIO =  {0} and  residente.RUT_RESIDENTE = '{1}' ", idCondominio, rut);

            cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();

            List<Multa> results = new List<Multa>();
            int count = dr.FieldCount;
            string final = string.Empty;
            while (dr.Read())
            {
                Multa listar = new Multa();
                listar.ID_Multa = dr.GetInt32(0);
                listar.Monto = dr.GetInt32(1);
                listar.Descripcion = dr.GetString(2);
                listar.ESTADO = dr.GetString(3);
                listar.RESIDENTE_Rut_Residente = dr.GetString(4);
                listar.Fecha_Creacion_Multa = String.Format("{0:dd'-'MM'-20'yy }", dr.GetDateTime(5));
                try
                {
                    listar.Fecha_Pago_Multa = String.Format("{0:dd'-'MM'-20'yy }", dr.GetDateTime(6));
                }
                catch (Exception)
                {
                    listar.Fecha_Pago_Multa = "";
                }
                results.Add(listar);
            }
            return results;
        }



       

        // Listar nombre de copones de pago por rut de residente

        private List<Pago_Offline> Listar_Pago_Offline(List<Caso14.Datos.PAGO_OFFLINE> aux)
        {
            List<Pago_Offline> salida = new List<Pago_Offline>();
            foreach (Caso14.Datos.PAGO_OFFLINE item in aux)
            {
                salida.Add(new Pago_Offline()
                {
                    id_pago_offline  = item.ID_PAGO_OFFLINE,
                    nombre_archivo   = item.NOMBRE_ARCHIVO,
                    fecha            = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA)),
                    tipo             = item.TIPO,
                    rut_resitente    = item.RUT_RESIDENTE
                });
            }
            return salida;
        }


        public List<Pago_Offline> Listar_Pago_Offline(string rutResidente) 
        {

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.CommandText = string.Format("SELECT ID_PAGO_OFFLINE, NOMBRE_ARCHIVO, FECHA, TIPO, RUT_RESIDENTE FROM PAGO_OFFLINE WHERE RUT_RESIDENTE = '{0}' ", rutResidente);

            cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();


            List<Pago_Offline> results = new List<Pago_Offline>();

            int count = dr.FieldCount;
            string final = string.Empty;
            while (dr.Read())
            {
                Pago_Offline listar = new Pago_Offline();
                listar.id_pago_offline = dr.GetInt32(0);
                listar.nombre_archivo = dr.GetString(1);

                try{listar.fecha = String.Format("{0:dd'/'MM'/'yyyy }", dr.GetDateTime(2));}
                catch (Exception){listar.fecha = "";}

                listar.tipo = dr.GetString(3);
                listar.rut_resitente = dr.GetString(4);
                
                results.Add(listar);
            }
            return results;
        }







        private List<Cuota_Gasto_Residentes> Listar_Pagos_Residente(List<Caso14.Datos.CUOTA_GASTO_RESIDENTES> aux)
        {
            List<Cuota_Gasto_Residentes> salida = new List<Cuota_Gasto_Residentes>();
            foreach (Caso14.Datos.CUOTA_GASTO_RESIDENTES item in aux)
            {
                salida.Add(new Cuota_Gasto_Residentes()
                {
                    Id_Cuota_Gasto_Mensual  = item.ID_CUOTA_GASTO_MENSUAL,
                    FECHA_inicio_pago       = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_INICIO_PAGO)),
                    FECHA_termino_pago      = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_TERMINO_PAGO)),
                    FECHA_pago_residente    = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_PAGO_RESIDENTE)),
                    MONTO                   = item.MONTO,
                    ESTADO                  = item.ESTADO,
                    RESIDENTE_Rut_Residente = item.RESIDENTE_RUT_RESIDENTE
                });
            }
            return salida;
        }




        public List<Cuota_Gasto_Residentes> Listar_Pagos_Residente(string rutResidente)
        {

            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;
            cmd.CommandText = string.Format("SELECT ID_CUOTA_GASTO_MENSUAL, FECHA_INICIO_PAGO, FECHA_TERMINO_PAGO, FECHA_PAGO_RESIDENTE, MONTO, ESTADO FROM CUOTA_GASTO_RESIDENTES WHERE RESIDENTE_RUT_RESIDENTE = '{0}' ORDER BY FECHA_INICIO_PAGO DESC ", rutResidente);

            cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();


            List<Cuota_Gasto_Residentes> results = new List<Cuota_Gasto_Residentes>();

            int count = dr.FieldCount;
            string final = string.Empty;
            while (dr.Read())
            {
                Cuota_Gasto_Residentes listar = new Cuota_Gasto_Residentes();
                listar.Id_Cuota_Gasto_Mensual = dr.GetInt32(0);
                try { listar.FECHA_inicio_pago = String.Format("{0:dd'/'MM'/'yyyy }", dr.GetDateTime(1)); }catch (Exception) { listar.FECHA_inicio_pago = ""; }
                try { listar.FECHA_termino_pago = String.Format("{0:dd'/'MM'/'yyyy }", dr.GetDateTime(2)); }catch (Exception) { listar.FECHA_termino_pago = ""; }
                try { listar.FECHA_pago_residente = String.Format("{0:dd'/'MM'/'yyyy }", dr.GetDateTime(3)); }catch (Exception) { listar.FECHA_pago_residente = ""; }
                listar.MONTO = dr.GetInt32(4);
                listar.ESTADO = dr.GetString(5);

                results.Add(listar);
            }
            return results;
        }
















        // listar EVENTO_LIBRO

        private List<Evento_Libro> ListarEventoLibro(List<Caso14.Datos.EVENTO_LIBRO> aux)
        {
            List<Evento_Libro> salida = new List<Evento_Libro>();
            foreach (Caso14.Datos.EVENTO_LIBRO item in aux)
            {
                salida.Add(new Evento_Libro()
                {
                    Id_Evento_Libro = Convert.ToInt32(item.ID_EVENTO_LIBRO),
                    Titulo          = item.TITULO,
                    Descripcion     = item.DESCRIPCION,
                    Fecha           = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA)),
                    Area_Comun      = item.AREA_COMUN,
                    Rut_Involucrado = item.RUT_INVOLUCRADO,
                    Rut_Funcionario = item.RUT_FUNCIONARIO
                });
            }
            return salida;
        }



        public List<Evento_Libro> ListarEventoLibro(int id_Condominio)
        {
            var aux = (from eventoLibro in ModeloBD.Instanciar.EVENTO_LIBRO
                       join funcionario in ModeloBD.Instanciar.FUNCIONARIO
                       on eventoLibro.RUT_FUNCIONARIO equals funcionario.RUT_FUNCIONARIO

                       join condominio in ModeloBD.Instanciar.CONDOMINIO
                       on funcionario.CONDOMINIO_ID_CONDOMINIO equals condominio.ID_CONDOMINIO

                       where condominio.ID_CONDOMINIO == id_Condominio

                       select eventoLibro).ToList();

            return ListarEventoLibro(aux);
        }












        // listar Cuota_Gasto_Residentes

        private List<Cuota_Gasto_Residentes> Listar_Cuota_Gasto_Residentes(List<Caso14.Datos.CUOTA_GASTO_RESIDENTES> aux)
        {
            List<Cuota_Gasto_Residentes> salida = new List<Cuota_Gasto_Residentes>();
            foreach (Caso14.Datos.CUOTA_GASTO_RESIDENTES item in aux)
            {
                salida.Add(new Cuota_Gasto_Residentes()
                {
                    Id_Cuota_Gasto_Mensual     = item.ID_CUOTA_GASTO_MENSUAL,          
                    FECHA_inicio_pago          = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_INICIO_PAGO)),      
                    FECHA_termino_pago         = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_TERMINO_PAGO)),       
                    FECHA_pago_residente       = (String.Format("{0:dd'-'MM'-'yyyy }", item.FECHA_PAGO_RESIDENTE)),         
                    MONTO                      = item.MONTO,          
                    ESTADO                     = item.ESTADO,          
                    RESIDENTE_Rut_Residente    = item.RESIDENTE_RUT_RESIDENTE

                });
            }
            return salida;
        }


        public List<Cuota_Gasto_Residentes> Listar_Cuota_Gasto_Residentes(int idCondominio)
        {


            var aux = (from cuota in ModeloBD.Instanciar.CUOTA_GASTO_RESIDENTES
                       join residente in ModeloBD.Instanciar.RESIDENTE 
                       on cuota.RESIDENTE_RUT_RESIDENTE equals residente.RUT_RESIDENTE

                       join vivienda in ModeloBD.Instanciar.VIVIENDA
                       on  residente.RUT_RESIDENTE equals vivienda.RESIDENTE_RUT_RESIDENTE

                       join condominio in ModeloBD.Instanciar.CONDOMINIO
                       on vivienda.CONDOMINIO_ID_CONDOMINIO equals condominio.ID_CONDOMINIO

                       where cuota.ESTADO == "EN MORA"
                       where condominio.ID_CONDOMINIO == idCondominio

                       select cuota).ToList();

            return Listar_Cuota_Gasto_Residentes(aux);
        }

    }
}
