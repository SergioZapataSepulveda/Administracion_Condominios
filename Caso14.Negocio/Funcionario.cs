using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using Oracle.DataAccess.Client;

namespace Caso14.Negocio
{
    public class Funcionario
    {

        public bool ValidarLoginFuncionario(string LOGusuario, string LOGpassword)
        {
            try 
            {
                var aux = (from reg in ModeloBD.Instanciar.FUNCIONARIO
                           where reg.RUT_FUNCIONARIO == LOGusuario &&
                                 reg.PASS_FUNCIONARIO == LOGpassword
                           select reg).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }









        public string SP_Crear_Anuncios(string Titulo, string Detalle, int Condominio)
        {
            try
            {
                int auxAntes = (from reg in ModeloBD.Instanciar.ANUNCIO_COMUNIDAD select reg).Count();

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();


                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Anuncios";
                cmd.Parameters.Add("Titulo", Titulo);
                cmd.Parameters.Add("Detalle", Detalle);
                cmd.Parameters.Add("id_Condominio", Condominio);

                cmd.ExecuteNonQuery();
                _connection.Close();

                int auxDespues = (from reg in ModeloBD.Instanciar.ANUNCIO_COMUNIDAD select reg).Count();

                if (auxAntes < auxDespues)
                {
                    return "Anuncio Ingresado Correctamente";
                }
                else
                {
                    return "Revise los datos no se Ingreso ningun anuncio";
                }
            }
            catch (Exception e)
            {
                return string.Format("{0}: {1}", "Error", e.Message);
            }
        }








        public string SP_Crear_Residentes(string Rut_Residente, string Pass_Residente, string Nombre_Residente, string Direccion, string Correo, int ID_TIPO_RESIDENTE)
        {
            try
            {
                int auxAntes = (from reg in ModeloBD.Instanciar.RESIDENTE select reg).Count();

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();


                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Residente";
                cmd.Parameters.Add("Rut_Residente", Rut_Residente);
                cmd.Parameters.Add("Pass_Residente", Pass_Residente);
                cmd.Parameters.Add("Nombre_Residente", Nombre_Residente);
                cmd.Parameters.Add("Direccion", Direccion);
                cmd.Parameters.Add("Correo", Correo);
                cmd.Parameters.Add("ID_TIPO_RESIDENTE", ID_TIPO_RESIDENTE);

                cmd.ExecuteNonQuery();
                _connection.Close();

                int auxDespues = (from reg in ModeloBD.Instanciar.RESIDENTE select reg).Count();

                if (auxAntes < auxDespues)
                {
                    return "Residente Ingresado Correctamente";
                }
                else
                {
                    return "Revise los datos no se Ingreso ningun Residente";
                }
            }
            catch (Exception )
            {
                return "Revise los datos, RUT ya en uso";
            }
        }










        public string SP_Deshabilitar_Residente(string Rut_Residente)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Deshabilitar_Residente";
                cmd.Parameters.Add("Rut_Residente", Rut_Residente);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "RUT Deshabilitado correctamente, ahora el residente no podra entrar a la Plataforma Web";
               
            }
            catch (Exception )
            {
                return "Revise el RUT, no existe en los registros";
            }
        }




        public string SP_Habilitar_Residente(string Rut_Residente)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Habilitar_Residente";
                cmd.Parameters.Add("Rut_Residente", Rut_Residente);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "RUT Habilitado correctamente, ahora el residente puede volver entrar a la Plataforma Web";

            }
            catch (Exception )
            {
                return "Revise el RUT, no existe en los registros";
            }
        }














        public string SP_Crear_Evento_Libro(string SP_Titulo, string SP_Descripcion, string SP_Area_Comun, string SP_Rut_Involucrado, string SP_Rut_Funcionario)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Evento_Libro";
                cmd.Parameters.Add("SP_Titulo", SP_Titulo);
                cmd.Parameters.Add("SP_Descripcion", SP_Descripcion);
                cmd.Parameters.Add("SP_Area_Comun", SP_Area_Comun);
                cmd.Parameters.Add("SP_Rut_Involucrado", SP_Rut_Involucrado);
                cmd.Parameters.Add("SP_Rut_Funcionario", SP_Rut_Funcionario);

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Evento Ingresado Correctamente";

            }
            catch (Exception)
            {
                return "Complete Titulo y Descripción para ingresar Evento al Libro, Rut puede quedar en blanco";
            }
        }

















        public int id_Condominio_desde_Funcionario(string LOGusuario)
        {
            return ModeloBD.Instanciar.FUNCIONARIO.First(a => a.RUT_FUNCIONARIO == LOGusuario).CONDOMINIO_ID_CONDOMINIO;
        }

        public int ID_desde_LogUser_Funcionario(string LOGusuario)
        {
            return Convert.ToInt32(ModeloBD.Instanciar.FUNCIONARIO.First(a => a.RUT_FUNCIONARIO == LOGusuario).TIPO_FUNCIONARIO_ID_T_F);
        }

        public string Nombre_desde_LogUser_Funcionario(string LOGusuario)
        {
            return ModeloBD.Instanciar.FUNCIONARIO.First(a => a.RUT_FUNCIONARIO == LOGusuario).NOMBRE_FUNCIONARIO;
        }

        public string CargoEnCondominio(string LOGusuario) 
        {
            int idTipoFuncionario = Convert.ToInt32(ModeloBD.Instanciar.FUNCIONARIO.First(a => a.RUT_FUNCIONARIO == LOGusuario).TIPO_FUNCIONARIO_ID_T_F);
            return ModeloBD.Instanciar.TIPO_FUNCIONARIO.First(a => a.ID_T_F == idTipoFuncionario).NOMBRE_TIPO_FUNCIONARIO.ToString();
        }


        public string  Rut_Funcionario            { get; set; }  
        public string  Pass_Funcionario           { get; set; }  
        public string  Nivel_Acceso               { get; set; }
        public string  Nombre_Funcionario         { get; set; }
        public int     TIPO_FUNCIONARIO_ID_T_F    { get; set; }
        public int     CONDOMINIO_ID_Condominio   { get; set; }



        public Funcionario()
        {
            this.Init();
        }

        private void Init()
        {
 	        Rut_Funcionario           = " ";
            Pass_Funcionario          = " ";
            Nivel_Acceso              = " ";
            Nombre_Funcionario        = " ";
            TIPO_FUNCIONARIO_ID_T_F   = 0;
            CONDOMINIO_ID_Condominio  = 0;
        }
    }
}
