using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using System.Globalization;
using Oracle.DataAccess.Client;
using System.Data;


namespace Caso14.Negocio
{
    public class Administracion
    {

        public int    Id_Administracion { get; set; }
        public string Fecha             { get; set; }
        public string Tipo              { get; set; }
        public int    Monto             { get; set; }
        public string Descripcion       { get; set; }
        public int    Condominio_id     { get; set; }


        public Administracion()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Administracion  = 0;
            Fecha              = " ";
            Tipo               = " ";
            Monto              = 0;
            Descripcion        = " ";
            Condominio_id      = 0;
        }







        public string listar_Correos_Residentes(int idCondominio)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format(" select RESIDENTE.CORREO from RESIDENTE join VIVIENDA on RESIDENTE.RUT_RESIDENTE = VIVIENDA.RESIDENTE_RUT_RESIDENTE "
                + " join CONDOMINIO on CONDOMINIO.ID_CONDOMINIO = VIVIENDA.CONDOMINIO_ID_CONDOMINIO where CONDOMINIO.ID_CONDOMINIO = {0}", idCondominio);
                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                int count = dr.FieldCount;
                string final = string.Empty;
                while (dr.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        final += dr.GetValue(i) + ", ";
                    }
                }
                return final;
            }
            catch (Exception)
            {
                return "No Se encontraron Registros de Correo";
            }
        }






        public string listar_Registros_GC_Mensuales(string seleccionado, int idCondominio, int mes, int anio, string categoria)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("SELECT to_char({0}) FROM ADMINISTRACION_CONTABLE where CONDOMINIO_ID_CONDOMINIO  = {1} and "
                + " to_char(FECHA , 'MM') = {2} and to_char(FECHA , 'YYYY') = {3} and CATEGORIA = '{4}'", seleccionado, idCondominio, mes, anio, categoria);
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














        public string datos(string rut, string pass)
        {





            OracleConnection _connection = new OracleConnection();
            _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
            _connection.Open();

            OracleCommand cmd = _connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "VALIDARUSUARIO";

            cmd.Parameters.Add("p_rut", OracleDbType.Int32).Value = rut;
            cmd.Parameters.Add("p_pass", OracleDbType.Varchar2).Value = pass;
            cmd.Parameters.Add("p_dv", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_nombres", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_apellido1", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_apellido2", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_fecha_nacimiento", OracleDbType.Date).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_direccion", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_telefono", OracleDbType.Int32, 200).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_sede_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_sede_nombre", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_rol_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_practica_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_carrera_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_carrera_nombre", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("p_foto_perfil", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            cmd.Parameters["p_dv"].Value = "";
            cmd.ExecuteNonQuery();


            var Dv = cmd.Parameters["p_dv"].Value.ToString();
            var Nombres = cmd.Parameters["p_nombres"].Value.ToString();
            var Telefono = int.Parse(cmd.Parameters["p_telefono"].Value.ToString());

            Console.WriteLine("este es el DV: " + Dv + " " + Nombres + " " + Telefono);

            return "este es el DV: " + Dv + " " + Nombres + " " + Telefono;
        
        }









        public string Calcular_Total_Mensual_Registros_GC(int idCondominio, int mes, int anio, string entradaSalida)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("SELECT NVL(sum(monto),0) FROM ADMINISTRACION_CONTABLE where CONDOMINIO_ID_CONDOMINIO  = {0} and to_char(FECHA , 'MM') = {1} and to_char(FECHA , 'YYYY') = {2} and tipo = '{3}'", idCondominio, mes, anio, entradaSalida);
                
                cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();

                string final = string.Empty;
                while (dr.Read())
                {
                    final = dr.GetValue(0).ToString();
                }
                return final;
            }
            catch (Exception)
            {
                return "";
            }
        }







        public string listar_Morosos_Totales(string seleccionado, int idCondominio)
        {
            
                OracleCommand cmd = new OracleCommand();
                OracleDataReader dr;

                cmd.CommandText = string.Format("SELECT {0} from CUOTA_GASTO_RESIDENTES inner JOIN residente " +
                                                " on CUOTA_GASTO_RESIDENTES.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE " +
                                                " inner JOIN vivienda on vivienda.RESIDENTE_RUT_RESIDENTE = residente.RUT_RESIDENTE " +
                                                " inner JOIN CONDOMINIO on vivienda.CONDOMINIO_ID_CONDOMINIO = CONDOMINIO.ID_CONDOMINIO " +
                                                " where CONDOMINIO.ID_CONDOMINIO = {1} and CUOTA_GASTO_RESIDENTES.ESTADO = 'EN MORA' ", seleccionado, idCondominio);

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








        public string SP_Revisar_Multas(int id_condominio)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Revisar_Multas";
                cmd.Parameters.Add("sp_id_condominio", id_condominio);
                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Multas Atomaticas Actualizadas Correctamente";
            }
            catch (Exception e)
            {
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }

























        public string SP_Crear_Ingreso_Gasto_Comun(string _tipo, string _categoria, string _descripcion, int _monto, int _id_condominio)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Ingreso_Gasto_comun";
                cmd.Parameters.Add("tipo", _tipo);
                cmd.Parameters.Add("categoria", _categoria);
                cmd.Parameters.Add("descripcion", _descripcion);
                cmd.Parameters.Add("monto", _monto);
                cmd.Parameters.Add("id_condominio", _id_condominio);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Registro Incertado Correctamente";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }



        public string SP_Modificar_Ingreso_Gasto_Comun(int _idadministrar, string _tipo, string _categoria, string _descripcion, int _monto)
        {
            try
            {
                
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Modificar_Gasto_comun";
                cmd.Parameters.Add("SP_idadministrar", _idadministrar);
                cmd.Parameters.Add("SP_tipo", _tipo);
                cmd.Parameters.Add("SP_categoria", _categoria);
                cmd.Parameters.Add("SP_descripcion", _descripcion);
                cmd.Parameters.Add("SP_monto", _monto);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Registro Actualizado Correctamente";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }




        public string SP_Crear_Cuota_Gasto_Comun(int _id_condominio)
        {
            try
            {

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Cuota_Gasto_Comun";
                cmd.Parameters.Add("SP_idadministrar", _id_condominio);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Cuota Creado Correctamente";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }


        public string SP_Actualizar_Cuota_G_C(int _id_condominio)
        {
            try
            {

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Actualizar_Cuota_G_C";
                cmd.Parameters.Add("SP_idadministrar", _id_condominio);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Cuota Actualizada Correctamente";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }








        public string SP_Crear_Reportes(string Tipo, string DESCRIPCION, string RUT_REPORTADO, int id_condominio)
        {
            try
            {

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Reportes";
                cmd.Parameters.Add("SP_Tipo", Tipo);
                cmd.Parameters.Add("SP_DESCRIPCION", DESCRIPCION);
                cmd.Parameters.Add("SP_RUT_REPORTADO", RUT_REPORTADO);
                cmd.Parameters.Add("SP_id_Condominio", id_condominio);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Reporte Creado Correctamente";
            }
            catch (Exception e)
            {
                //return "La de descripcion no puede estar vacia, complete ese campo para generar reporte valido";
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }












        public bool Create_Ingreso_Administracion()
        {
            try
            {
                Caso14.Datos.ADMINISTRACION_CONTABLE aux = new Caso14.Datos.ADMINISTRACION_CONTABLE();

                aux.ID_ADMISTRACION            = this.Id_Administracion ;
                aux.FECHA                      = Convert.ToDateTime(this.Fecha)           ;
                aux.TIPO                       = this.Tipo              ;
                aux.MONTO                      = this.Monto             ;
                aux.DESCRIPCION                = this.Descripcion       ;
                aux.CONDOMINIO_ID_CONDOMINIO   = (Int16)this.Condominio_id;


                ModeloBD.Instanciar.AddToADMINISTRACION_CONTABLE(aux);
                ModeloBD.Instanciar.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
          







        private Caso14.Datos.ADMINISTRACION_CONTABLE buscarIngreso()
        {
            return ModeloBD.Instanciar.ADMINISTRACION_CONTABLE.First(a => a.ID_ADMISTRACION == this.Id_Administracion);
        }


        public bool Update_Ingreso_Administracion()
        {
            try
            {
                Caso14.Datos.ADMINISTRACION_CONTABLE aux = buscarIngreso();
                aux.ID_ADMISTRACION            = this.Id_Administracion             ;   
                aux.FECHA                      = Convert.ToDateTime(this.Fecha)     ;
                aux.TIPO                       = this.Tipo                          ;
                aux.MONTO                      = this.Monto                         ;
                aux.DESCRIPCION                = this.Descripcion                   ;
                aux.CONDOMINIO_ID_CONDOMINIO   = (Int16)this.Condominio_id          ;

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






