using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Oracle.DataAccess.Client; // 2010
using System.Data.EntityClient;
using System.Data;
using System.Globalization;
using Caso14.Negocio;


namespace ConsoleApplication1 
{
    class Program
    {
        static void Main(string[] args)
        {





            string Select = "CUOTA_GASTO_RESIDENTES.FECHA_INICIO_PAGO"; 



            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;

            cmd.CommandText = string.Format("SELECT  to_char({0}) from CUOTA_GASTO_RESIDENTES inner JOIN RESIDENTE " +
                                            " on CUOTA_GASTO_RESIDENTES.RESIDENTE_RUT_RESIDENTE = RESIDENTE.RUT_RESIDENTE " +
                                            " INNER JOIN VIVIENDA on RESIDENTE.RUT_RESIDENTE = VIVIENDA.RESIDENTE_RUT_RESIDENTE " +
                                            " INNER JOIN CONDOMINIO ON VIVIENDA.CONDOMINIO_ID_CONDOMINIO = CONDOMINIO.ID_CONDOMINIO " +
                                            " WHERE CONDOMINIO.ID_CONDOMINIO = {1} AND  RESIDENTE.RUT_RESIDENTE = '{2}' ", Select, 1, "1690");

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




            Console.WriteLine("Resultado: {0}", final);
            Console.ReadLine();




















/*

            OracleConnection _connection = new OracleConnection();
            _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
            _connection.Open();

            OracleCommand cmd = _connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "CASO14.SP_Crear_Ingreso_Gasto_comun";
            cmd.Parameters.Add("tipo", "Egreso");
            cmd.Parameters.Add("categoria", "Sueldos");
            cmd.Parameters.Add("descripcion", "Flavia");
            cmd.Parameters.Add("monto", 1233);
            cmd.Parameters.Add("id_condominio", 1);

            cmd.ExecuteNonQuery();
            _connection.Close();

  

 
            Console.WriteLine("gdfsf");
            Console.ReadLine();








            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;

            cmd.CommandText = string.Format("SELECT sum(monto)FROM ADMINISTRACION_CONTABLE where CONDOMINIO_ID_CONDOMINIO  = 1 and to_char(FECHA , 'MM') = 06 and to_char(FECHA , 'YYYY') = 2017 and tipo = 'Egreso'");
            cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();

            int final = 0; 
            while (dr.Read())
            {
                final = Convert.ToInt32(dr.GetValue(0));
            }

            Console.WriteLine("Resultado: {0}", final);
            Console.ReadLine();












            OracleCommand cmd = new OracleCommand();
            OracleDataReader dr;

            string var0 = "DESCRIPCION";
            int var1 = 1 ; 
            int var2 = 02; 
            int var3 = 2017;
            string var4 = "Mantencion";




            cmd.CommandText = string.Format("SELECT to_char(DESCRIPCION) FROM ADMINISTRACION_CONTABLE " + 
            "where CONDOMINIO_ID_CONDOMINIO  = {1} and to_char(FECHA , 'MM') = {2} and to_char(FECHA , 'YYYY') = {3} and CATEGORIA = '{4}'",var0, var1, var2, var3, var4);
            cmd.Connection = new OracleConnection("DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14");
            cmd.Connection.Open(); 
            dr = cmd.ExecuteReader();

            int count = dr.FieldCount; 
            string final = string.Empty; 
            while (dr.Read())
            {

                for (int i = 0; i < count; i++)
                {
                    final += dr.GetValue(i) + " <br> ";
                    //Console.WriteLine(dr.GetValue(i));
                }
                
              
            }

            Console.WriteLine("Resultado: {0}", final);
            Console.ReadLine();



              



            



        

            OracleConnection _connection = new OracleConnection();
            _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
            _connection.Open();

            var _tramo = 2; 
            var _servicio = 1; 
            var _fecha = "02/01/39";

            string sql = String.Format("select NVL(sum(CAP_USADA_TRAMO_{0}),0) " + 
                         "from DETALLE_RESERVA "+
                         "where FECHA_ARESERVAR = TO_DATE('{1}', 'DD/MM/YYYY') and SERVICIO_ID_SERVICIO = {2}", _tramo, _fecha, _servicio);

            OracleCommand command = new OracleCommand(sql, _connection);
            var ejecuacion = command.ExecuteNonQuery();

            var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

            int parseoResultado = Convert.ToInt32(resultadoConsulta);

            Console.WriteLine("Resultado: {0}", parseoResultado);
            Console.ReadLine();

            _connection.Close();


            return;


            
            var connectionString = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
               OracleConnection _connection = new OracleConnection();

      
               _connection.ConnectionString = connectionString;
               _connection.Open();

               string sql = "call registrarareasportramos(3, 1,0,0, '02/01/39')";

               OracleCommand command = new OracleCommand(sql, _connection);

               var x = command.ExecuteNonQuery();


               Console.WriteLine("{0}: {1}", "", command);
               Console.ReadLine();

              _connection.Close();
            

               return ;



               
             var connectionString = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;

               OracleConnection _connection = new OracleConnection();
               _connection.ConnectionString = connectionString;
               _connection.Open();

               var fecha = "11/11/2111";

               OracleCommand cmd = _connection.CreateCommand();
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
               cmd.CommandText = "CASO14.REGISTRARAREASPORTRAMOS";
               cmd.Parameters.Add("servicio_Seleccionado", OracleDbType.Int32).Value = 4;
               cmd.Parameters.Add("Requerido_para_tramo_1", OracleDbType.Int32).Value = 1;
               cmd.Parameters.Add("requerido_para_tramo_2", OracleDbType.Int32).Value = 1;
               cmd.Parameters.Add("requerido_para_tramo_3", OracleDbType.Int32).Value = 1;
               cmd.Parameters.Add("fechaSeleccionada", fecha);

               cmd.ExecuteNonQuery();
               _connection.Close();

               return ;

             */



            



                
            

        }
    }
}
