using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using Oracle.DataAccess.Client;

namespace Caso14.Negocio
{
    public class Residente
    {

        public bool ValidarLogin(string LOGusuario, string LOGpassword)
        {
            try
            {
                var aux = (from reg in ModeloBD.Instanciar.RESIDENTE
                           where reg.RUT_RESIDENTE == LOGusuario &&
                                 reg.PASS_RESIDENTE == LOGpassword
                           select reg).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool ValidarTarjeta(string RutIngresado, long numeroTarjeta, int codigoSeg, string FechaV)
        {
            try
            {
                var aux = (from reg in ModeloBD.Instanciar.TARJETA_CREDITO
                           where reg.RUT_PERSONA       == RutIngresado &&
                                 reg.NUMERO_TARJETA    == numeroTarjeta &&
                                 reg.COD_SEGURIDAD     == codigoSeg &&
                                 reg.FECHA_VENCIMIENTO == FechaV
                           select reg).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }





        public bool ValidarRut(string RutIngresado)
        {
            try
            {
                var aux = (from reg in ModeloBD.Instanciar.RESIDENTE
                           where reg.RUT_RESIDENTE == RutIngresado 
                           select reg).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public int GenerarAlertasMora(string RutIngresado) 
        {
            try
            {
                var aux = (from reg in ModeloBD.Instanciar.CUOTA_GASTO_RESIDENTES
                           where reg.RESIDENTE_RUT_RESIDENTE == RutIngresado &&
                                 reg.ESTADO == "EN MORA"
                           select reg).Count();
                return aux;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public int GenerarAlertasMulta(string RutIngresado)
        {
            try
            {
                var aux = (from reg in ModeloBD.Instanciar.MULTA
                           where reg.RESIDENTE_RUT_RESIDENTE == RutIngresado &&
                                 reg.ESTADO == "ACTIVA"
                           select reg).Count();
                return aux;
            }
            catch (Exception)
            {
                return 0;
            }
        }





        public string SP_PAGO_OFFLINE(string RUTResidente, string Tipo)
        {
            try
            {
                
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_PAGO_OFFLINE";
                cmd.Parameters.Add("SP_TIPO", Tipo);
                cmd.Parameters.Add("SP_RUT_RESIDENTE", RUTResidente);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

           




        public string NOMBRE_ARCHIVO_PAGO_OFFLINE_2() 
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = String.Format("SELECT NOMBRE_ARCHIVO FROM  PAGO_OFFLINE WHERE ID_PAGO_OFFLINE = (SELECT MAX(ID_PAGO_OFFLINE)  FROM PAGO_OFFLINE)");
                OracleCommand command = new OracleCommand(sql, _connection);
                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 
                _connection.Close();

                return resultadoConsulta.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }




















        public int Id_Condominio_desde_rut(string select, string rutBuscar)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = string.Format("SELECT {0} FROM RESIDENTE INNER JOIN VIVIENDA on RESIDENTE.RUT_RESIDENTE = VIVIENDA.RESIDENTE_RUT_RESIDENTE " +
                                                " INNER JOIN CONDOMINIO on VIVIENDA.CONDOMINIO_ID_CONDOMINIO = CONDOMINIO.ID_CONDOMINIO WHERE RESIDENTE.RUT_RESIDENTE = '{1}'", select, rutBuscar);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                _connection.Close();
                return Convert.ToInt32(resultadoConsulta);
            }
            catch (Exception)
            {
                return 0;
            }
        }







        public string Crear_Multa(int monto, string descripcion, string rutMultar)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = string.Format("insert INTO MULTA VALUES (SEQ_MULTA_RESIDENTE.NEXTVAL, SYSDATE, null, {0}, '{1}', 'ACTIVA', '{2}')", monto, descripcion, rutMultar);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                _connection.Close();
                return string.Format("Multa Ingresada correctamente para el Rut {0}, Actualize la pagina para ver registro ingresado", rutMultar);
            }
            catch (Exception)
            {
                return "Rut no existe en los registros, solo se puede asignar una multa a un residente valido del condominio";
            }
        }





        public string Modificar_Multa(string fechapago, int monto, string descripcion, string estado, int idMulta)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = string.Format("UPDATE MULTA SET FECHA_PAGO_MULTA = TO_DATE('{0}', 'DD/MM/YY'), MONTO = {1} , DESCRIPCION = '{2}' , ESTADO = '{3}' where ID_MULTA = {4}", fechapago, monto, descripcion, estado, idMulta);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                _connection.Close();
                return "Multa Actualizada correctamente, Actualize la pagina para ver registro ingresado";
            }
            catch (Exception e)
            {
                return e.ToString();
                //return "Rut no existe en los registros, solo se puede asignar una multa a un residente valido del condominio";
            }
        }





        public string Ingresar_Observaciones(string observacion, int idGastoComun)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = string.Format("UPDATE ADMINISTRACION_CONTABLE SET OBSERVACIONES = '{0}' where ID_ADMISTRACION = {1}", observacion, idGastoComun);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                _connection.Close();
                return "Observacion ingresada Correctamente, Recargue la pagina para ver el registro asignado";
            }
            catch (Exception)
            {
                return "Id ";
            }
        }












        public string listar_Anuncios(int idCondominio, int lugar)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = string.Format("select ANUNCIO_COMUNIDAD.DETALLE from ANUNCIO_COMUNIDAD inner join Condominio on ANUNCIO_COMUNIDAD.ID_CONDOMINIO = {0} " +
                                                " where ID_ANUNCIO_COMUNIDAD = (SELECT max(ID_ANUNCIO_COMUNIDAD) FROM ANUNCIO_COMUNIDAD)- {1}", idCondominio, lugar);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                _connection.Close();
                return resultadoConsulta.ToString();
            }
            catch (Exception)
            {
                return "Sin Anuncios";
            }
        }








        public string Metodo_listar_Anuncios_Test(int idCondominio, int lugar)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                string sql = string.Format("select ANUNCIO_COMUNIDAD.DETALLE from ANUNCIO_COMUNIDAD inner join Condominio on ANUNCIO_COMUNIDAD.ID_CONDOMINIO = {0} " +
                                                " where ID_ANUNCIO_COMUNIDAD = (SELECT max(ID_ANUNCIO_COMUNIDAD) FROM ANUNCIO_COMUNIDAD)- {1}", idCondominio, lugar);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                _connection.Close();
                return resultadoConsulta.ToString();
            }
            catch (Exception)
            {
                return "Sin Anuncios";
            }
        }











        public string listar_Multas_Residentes(string select, int idCondominio, string rutBuscar)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("SELECT {0} FROM multa inner join residente on multa.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE " +
                                                " inner join vivienda on vivienda.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE  inner join condominio " +
                                                " on vivienda.CONDOMINIO_ID_CONDOMINIO = condominio.ID_CONDOMINIO where condominio.ID_CONDOMINIO =  {1} " +
                                                " and multa.RESIDENTE_RUT_RESIDENTE = '{2}'", select, idCondominio, rutBuscar);

                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                int count = dr.FieldCount;
                string final = string.Empty;
                while (dr.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        final += dr.GetValue(i) + "<br>";
                    }
                }
                return final;
            }
            catch (Exception )
            {
                return "No Se encontraron Registros ";
            }
        }



        public string Met_Pagar_Reservas()
        {
            try
            {
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


          
         
         
        public string Met_Ver_Detalle_Reservas(string select, string rutResidente) 
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format(" SELECT {0} FROM DETALLE_RESERVA inner join RESERVA " +
                                                " on RESERVA.id_reserva = DETALLE_RESERVA.RESERVA_ID_RESERVA " +
                                                " inner join SERVICIO on SERVICIO.ID_SERVICIO = DETALLE_RESERVA.SERVICIO_ID_SERVICIO " +
                                                " where RESERVA.ID_RESERVA = (SELECT max(RESERVA_ID_RESERVA) FROM DETALLE_RESERVA) " +
                                                " and RESERVA.RESIDENTE_RUT_RESIDENTE = '{1}' ORDER by DETALLE_RESERVA.ID_D_R", select, rutResidente);
                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                int count = dr.FieldCount;
                string final = string.Empty;
                while (dr.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        final += dr.GetValue(i) + "<br>";
                    }
                }
                return final;
            }
            catch (Exception e)
            {
                return "No Se encontraron Registros " + e.Message;
            }
        }
























        public string listar_Registros_GC_Residentes(string seleccionado, int idCondominio, string rutBuscar)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("SELECT  to_char({0}) from CUOTA_GASTO_RESIDENTES inner JOIN RESIDENTE " +
                                                " on CUOTA_GASTO_RESIDENTES.RESIDENTE_RUT_RESIDENTE = RESIDENTE.RUT_RESIDENTE " +
                                                " INNER JOIN VIVIENDA on RESIDENTE.RUT_RESIDENTE = VIVIENDA.RESIDENTE_RUT_RESIDENTE " +
                                                " INNER JOIN CONDOMINIO ON VIVIENDA.CONDOMINIO_ID_CONDOMINIO = CONDOMINIO.ID_CONDOMINIO " +
                                                " WHERE CONDOMINIO.ID_CONDOMINIO = {1} AND  RESIDENTE.RUT_RESIDENTE = '{2}' " + 
                                                " ORDER BY CUOTA_GASTO_RESIDENTES.FECHA_INICIO_PAGO", seleccionado, idCondominio, rutBuscar); 
                
                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                int count = dr.FieldCount;
                string final = string.Empty;
                while (dr.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        final += dr.GetValue(i) + "<br>";
                    }
                }
                return final;
            }
            catch (Exception)
            {
                return "No Se encontraron Registros ";
            }
        }






        public string rectificar_Registros_GC_Residentes(string fechaPago, string estado, int monto, int idCuota)
        {

            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("update Cuota_Gasto_Residentes set FECHA_PAGO_RESIDENTE = TO_DATE('{0}', 'DD/MM/YYYY'), ESTADO = '{1}', MONTO = {2} where ID_CUOTA_GASTO_MENSUAL = {3}", fechaPago, estado, monto, idCuota);

                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                return "Pago Registrado Correctamente";
            }
            catch (Exception )
            {
                return "Id de Cuota no existe"; ;
            }
        }









        public int Residente_Nivel_Acceso(string LOGusuario)
        {
            return Convert.ToInt32(ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).NIVEL_ACCESO);
        }


        public int ID_desde_LogUser(string LOGusuario)
        {
            return Convert.ToInt32(ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).TIPO_RESIDENTE_ID_T_R);
        }


        public string Nombre_desde_LogUser(string LOGusuario)
        {
            try
            {
                return string.Format("{0}", (ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).NOMBRE_RESIDENTE));
            }
            catch (Exception)
            {
                return "Residente No Existe, revise el rut ingresado";
            }
        }


        public string CargoEnDirectiva(string LOGusuario)
        {
            try
            {
                int idTipoResidente = Convert.ToInt32(ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).TIPO_RESIDENTE_ID_T_R);
                return ModeloBD.Instanciar.TIPO_RESIDENTE.First(a => a.ID_T_R == idTipoResidente).CARGO_JUNTA_VECINOS.ToString();
            }
            catch (Exception)
            {
                
                return "No se encontro Inforacion";
            }
        }



        

























        public string  Rut_Residente            { get; set; }  
        public string  Pass_Residente           { get; set; }
        public string  Nombre_Residente         { get; set; }
        public int     Nivel_Acceso             { get; set; }
        public string  Direccion                { get; set; }
        public string  Correo                   { get; set; }
        public int     TIPO_RESIDENTE_ID_T_R    { get; set; }


        public Residente()
        {
            this.Init();
        }

        private void Init()
        {
            Rut_Residente          = " ";
            Pass_Residente         = " ";
            Nombre_Residente       = " ";
            Nivel_Acceso           = 0;
            Direccion              = " ";
            Correo                 = " ";
            TIPO_RESIDENTE_ID_T_R  = 0;
        }



        private Caso14.Datos.RESIDENTE buscarUsuario()
        {
            return ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == this.Rut_Residente);
        }


        public bool CreateResidente()
        {
            try
            {
                Caso14.Datos.RESIDENTE aux = new Caso14.Datos.RESIDENTE();

                aux.RUT_RESIDENTE = this.Rut_Residente;
                aux.PASS_RESIDENTE    = this.Pass_Residente;
                aux.NOMBRE_RESIDENTE    = this.Nombre_Residente;
                aux.NIVEL_ACCESO = (Int16)this.Nivel_Acceso;
                aux.DIRECCION    = this.Direccion;
                aux.CORREO    = this.Correo;
                aux.TIPO_RESIDENTE_ID_T_R = (Int16)this.TIPO_RESIDENTE_ID_T_R;   

                ModeloBD.Instanciar.AddToRESIDENTE(aux);
                ModeloBD.Instanciar.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteResidente()
        {
            try
            {
                Caso14.Datos.RESIDENTE aux = buscarUsuario();

                ModeloBD.Instanciar.DeleteObject(aux);

                ModeloBD.Instanciar.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }








    }
}
