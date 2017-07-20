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


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

               

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

            

        }
    }
}
