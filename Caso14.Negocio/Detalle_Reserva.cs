using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caso14.Datos;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
//using Oracle.ManagedDataAccess.Client; // 2015
using System.Threading.Tasks;
using Oracle.DataAccess.Client; // 2010





namespace Caso14.Negocio
{
    public class Detalle_Reserva
    { 



        public int ID_desde_LogUser(string LOGusuario)
        {
            return Convert.ToInt32(ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).TIPO_RESIDENTE_ID_T_R);
        }

        public string Nombre_desde_LogUser(string LOGusuario)
        {
            return string.Format("{0}", (ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).NOMBRE_RESIDENTE));
        }

        public string CargoEnDirectiva(string LOGusuario)
        {
            int idTipoResidente = Convert.ToInt32(ModeloBD.Instanciar.RESIDENTE.First(a => a.RUT_RESIDENTE == LOGusuario).TIPO_RESIDENTE_ID_T_R);
            return ModeloBD.Instanciar.TIPO_RESIDENTE.First(a => a.ID_T_R == idTipoResidente).CARGO_JUNTA_VECINOS.ToString();
        }


        public int ContarFilas()
        {
            return ModeloBD.Instanciar.DETALLE_RESERVA.Count(); 
        }











        









        
        









        public int UsoDeTramoSegunFechayServicio(string fecha, int tramo, int servicio)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                var _tramo = tramo;
                var _servicio = servicio;
                var _fecha = fecha;

                string sql = String.Format("select NVL(sum(CAP_USADA_TRAMO_{0}),0) " +
                             "from DETALLE_RESERVA " +
                             "where FECHA_ARESERVAR = TO_DATE('{1}', 'DD/MM/YYYY') and SERVICIO_ID_SERVICIO = {2}", _tramo, _fecha, _servicio);

                OracleCommand command = new OracleCommand(sql, _connection);

                var resultadoConsulta = command.ExecuteScalar(); // recupera el primer valor de la consulta 

                Console.WriteLine("Resultado: {0}", resultadoConsulta);
                Console.ReadLine();

                _connection.Close();


                return Convert.ToInt32(resultadoConsulta);
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public string SP_Pagar_Reservas_Tarjetas(string RUTResidente)
        {
            try
            {
                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Pagar_Reservas_Tarjetas";
                cmd.Parameters.Add("sp_rut", "1690");

                cmd.ExecuteNonQuery();
                _connection.Close();

                return "Proceso Correcto, sus reservas estan Pagadas";
            }
            catch (Exception e)
            {
                return "Tarjeta son Saldo Suficiente, Contactese con su banco";
            }
        }


        public bool SP_Crear_Reserva_Residente(string RUTResidente)
        {
            try
            {
                //var connectionString = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
                int auxAntes = (from reg in ModeloBD.Instanciar.DETALLE_RESERVA select reg).Count();

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                //var fecha = "11/11/2111";

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Reserva_Residente";
                cmd.Parameters.Add("RUT_Residente", RUTResidente);

                cmd.ExecuteNonQuery();
                _connection.Close();

                int auxDespues = (from reg in ModeloBD.Instanciar.DETALLE_RESERVA select reg).Count();

                if (auxAntes < auxDespues)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return false;
            }
        }





        public bool SP_Crear_Reserva_Residente_Desde_Funcionario(string RUTResidente, string RUT_Funcionario)
        {
            try
            {
                //var connectionString = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
                int auxAntes = (from reg in ModeloBD.Instanciar.DETALLE_RESERVA select reg).Count();

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                //var fecha = "11/11/2111";

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Reserva_Funcionario";
                cmd.Parameters.Add("RUT_Residente", RUTResidente);
                cmd.Parameters.Add("RUT_Funcionario", RUT_Funcionario);

                cmd.ExecuteNonQuery();
                _connection.Close();

                int auxDespues = (from reg in ModeloBD.Instanciar.DETALLE_RESERVA select reg).Count();

                if (auxAntes < auxDespues)
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return false;
            }
        }








        public bool SP_Crear_Detalle_Reserva(int idServicio, int tramo1, int tramo2, int tramo3, string fechaASeleccionar, string RUTResidente) 
        {
            try
            {
                //var connectionString = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
                int auxAntes = (from reg in ModeloBD.Instanciar.DETALLE_RESERVA select reg).Count();

                OracleConnection _connection = new OracleConnection();
                _connection.ConnectionString = "DATA SOURCE=127.0.0.1;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=CASO14";
                _connection.Open();

                //var fecha = "11/11/2111";

                OracleCommand cmd = _connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CASO14.SP_Crear_Detalle_Reserva";
                cmd.Parameters.Add("servicio_Seleccionado",  idServicio  );
                cmd.Parameters.Add("Requerido_para_tramo_1", tramo1     );
                cmd.Parameters.Add("requerido_para_tramo_2", tramo2     );
                cmd.Parameters.Add("requerido_para_tramo_3", tramo3     );
                cmd.Parameters.Add("fechaSeleccionada", fechaASeleccionar);
                cmd.Parameters.Add("RUT_Residente", RUTResidente);

                cmd.ExecuteNonQuery();
                _connection.Close();

                int auxDespues = (from reg in ModeloBD.Instanciar.DETALLE_RESERVA select reg).Count();

                if (auxAntes < auxDespues)
	            {
		         return true;
	            }
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: {1}", "Error", e.Message);
                Console.ReadLine();
                return false;
            }
        }





        public int          id_d_r                 { get; set; }  
        public string       estado                 { get; set; }
        public int          Cap_Usada_Tramo_1      { get; set; }
        public int          Cap_Usada_Tramo_2      { get; set; }
        public int          Cap_Usada_Tramo_3      { get; set; } 
        public string       fecha_areservar        { get; set; } 
        public int          Costo_Reserva          { get; set; }  
        public string       reporte                { get; set; }
        public int          reserva_id_reserva     { get; set; }
        public int          servicio_id_servicio   { get; set; } 

        public Detalle_Reserva()
        {
            this.Init();
        }

        private void Init()
        {
            id_d_r                = 0;
            estado                = " ";
            Cap_Usada_Tramo_1     = 0;
            Cap_Usada_Tramo_2     = 0;
            Cap_Usada_Tramo_3     = 0;
            
            fecha_areservar       = " ";
            Costo_Reserva         = 0;
            reporte               = " ";
            reserva_id_reserva    = 0;
            servicio_id_servicio  = 0;
        }



        private Caso14.Datos.DETALLE_RESERVA buscarIdDetalle() 
        {
            return ModeloBD.Instanciar.DETALLE_RESERVA.First(a => a.ID_D_R == this.id_d_r);
        }

        private Caso14.Datos.DETALLE_RESERVA buscarIdDetalle_IdServicio()
        {
            return ModeloBD.Instanciar.DETALLE_RESERVA.First(a => a.SERVICIO_ID_SERVICIO == this.servicio_id_servicio);
        }

        private Caso14.Datos.DETALLE_RESERVA buscarIdDetalle_Fecha() 
        {
            return ModeloBD.Instanciar.DETALLE_RESERVA.First(a => a.FECHA_ARESERVAR.ToString() == this.fecha_areservar);
        }


        public bool CreateDetalleReserva()
        {
            try
            {
                Caso14.Datos.DETALLE_RESERVA aux = new Caso14.Datos.DETALLE_RESERVA();

                aux.ID_D_R                  = this.id_d_r                          ;
                aux.ESTADO                  = this.estado                          ;
                aux.CAP_USADA_TRAMO_1       = (Int16)this.Cap_Usada_Tramo_1        ;
                aux.CAP_USADA_TRAMO_2       = (Int16)this.Cap_Usada_Tramo_2        ;
                aux.CAP_USADA_TRAMO_3       = (Int16)this.Cap_Usada_Tramo_3        ;
                
                aux.FECHA_ARESERVAR         = DateTime.Parse(this.fecha_areservar) ;
                aux.COSTO_RESERVA           = this.Costo_Reserva                   ;
                aux.REPORTE                 = this.reporte                         ;
                aux.RESERVA_ID_RESERVA      = this.reserva_id_reserva              ;
                aux.SERVICIO_ID_SERVICIO    = this.servicio_id_servicio            ;


                ModeloBD.Instanciar.AddToDETALLE_RESERVA(aux);
                ModeloBD.Instanciar.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool ReadDetalleReserva()
        {
            try
            {
                Caso14.Datos.DETALLE_RESERVA aux = buscarIdDetalle(); 

                this.id_d_r                = aux.ID_D_R                      ;
                this.estado                = aux.ESTADO                      ;
                this.Cap_Usada_Tramo_1     = aux.CAP_USADA_TRAMO_1           ;
                this.Cap_Usada_Tramo_2     = aux.CAP_USADA_TRAMO_2           ;
                this.Cap_Usada_Tramo_3     = aux.CAP_USADA_TRAMO_3           ;
                this.fecha_areservar       = aux.FECHA_ARESERVAR.ToString()  ;
                this.Costo_Reserva         = aux.COSTO_RESERVA               ;
                this.reporte               = aux.REPORTE                     ;
                this.reserva_id_reserva    = (Int32)aux.RESERVA_ID_RESERVA   ;
                this.servicio_id_servicio  = aux.SERVICIO_ID_SERVICIO        ;


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
