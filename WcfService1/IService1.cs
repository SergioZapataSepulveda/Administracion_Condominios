using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio
         

        // RESIDENTE
        [OperationContract]
        string ListarResidente();

        [OperationContract]
        string NOMBRE_ARCHIVO_PAGO_OFFLINE_2();

        [OperationContract]
        string SP_PAGO_OFFLINE(string RUTResidente, string Tipo);

        [OperationContract]
        bool ValidarLogin(string LOGusuario, string LOGpassword);

        [OperationContract]
        bool ValidarRut(string RutIngresado);

        [OperationContract]
        int ID_desde_LogUser(string LOGusuario);

        [OperationContract]
        string Nombre_desde_LogUser(string LOGusuario);

        [OperationContract]
        string CargoEnDirectiva(string LOGusuario);

        [OperationContract]
        bool CreateResidente(string Rut);

        [OperationContract]
        bool DeleteResidente(string Rut);

        [OperationContract]
        string listar_Registros_GC_Residentes(string seleccionado, int idCondominio, string rutBuscar);

        [OperationContract]
        string rectificar_Registros_GC_Residentes(string fechaPago, string estado, int monto, int idCuota);

        [OperationContract]
        int Id_Condominio_desde_rut(string select, string rutBuscar);

        [OperationContract]
        string listar_Multas_Residentes(string select, int idCondominio, string rutBuscar);

        [OperationContract]
        string Crear_Multa(int monto, string descripcion, string rutMultar);

        [OperationContract]
        string Met_Ver_Detalle_Reservas(string select, string rutResidente);

        [OperationContract]
        string Modificar_Multa(string fechapago, int monto, string descripcion, string estado, int idMulta);

        [OperationContract]
        string Ingresar_Observaciones(string observacion, int idGastoComun);

        [OperationContract]
        string listar_Anuncios(int idCondominio, int lugar);

        [OperationContract]
        int Residente_Nivel_Acceso(string LOGusuario);

        [OperationContract]
        int GenerarAlertasMora(string RutIngresado);

        [OperationContract]
        int GenerarAlertasMulta(string RutIngresado);

        [OperationContract]
        string Listar_Pago_Offline(string rut);

        [OperationContract]
        bool ValidarTarjeta(string RutIngresado, long numeroTarjeta, int codigoSeg, string FechaV);



        [OperationContract]
        string Met_Pagar_Reservas();



        [OperationContract]
        string Listar_Pagos_Residente(string rutResidente);





        // REPORTES
        [OperationContract]
        string ListarReportes();


        // Cuota_Gasto_Residentes
        [OperationContract]
        string Listar_Cuota_Gasto_Residentes(int idCondominio);


        // Multas
        [OperationContract]
        string ListarMultas(int idCondominio);

        [OperationContract]
        string ListarMultasPorResidnte(int idCondominio, string rut);


        [OperationContract]
        string ListarEventoLibro(int id_Condominio);



        //ADMINISTRACION
        [OperationContract]
        string ListarIngresoAdministracion(string filtroFecha, string fechaMax, int id_Condominio);

        [OperationContract]
        string ListarIngresoAdministracionTodo(int id_Condominio);

        [OperationContract]
        string SP_Crear_Ingreso_Gasto_Comun(string _tipo, string _categoria, string _descripcion, int _monto, int _id_condominio);

        [OperationContract]
        string SP_Modificar_Ingreso_Gasto_Comun(int _idadministrar, string _tipo, string _categoria, string _descripcion, int _monto);

        [OperationContract]
        string listar_Registros_GC_Mensuales(string seleccionado, int idCondominio, int mes, int anio, string categoria);

        [OperationContract]
        string Calcular_Total_Mensual_Registros_GC(int idCondominio, int mes, int anio, string entradaSalida);

        [OperationContract]
        string SP_Crear_Cuota_Gasto_Comun(int _id_condominio);

        [OperationContract]
        string SP_Actualizar_Cuota_G_C(int _id_condominio);

        [OperationContract]
        string listar_Morosos_Totales(string seleccionado, int idCondominio);

        [OperationContract]
        string SP_Crear_Reportes(string Tipo, string DESCRIPCION, string RUT_REPORTADO, int id_condominio);

        [OperationContract]
        string listar_Correos_Residentes(int idCondominio);

        [OperationContract]
        string SP_Revisar_Multas(int id_condominio);










        // FUNCIONARIO
        [OperationContract]
        bool ValidarLoginFuncionario(string LOGusuario, string LOGpassword);

        [OperationContract]
        int ID_desde_LogUser_Funcionario(string LOGusuario);

        [OperationContract]
        string Nombre_desde_LogUser_Funcionario(string LOGusuario);

        [OperationContract]
        string CargoEnCondominio(string LOGusuario);

        [OperationContract]
        int id_Condominio_desde_Funcionario(string LOGusuario);

        [OperationContract]
        string SP_Crear_Anuncios(string Titulo, string Detalle, int Condominio);

        [OperationContract]
        string SP_Crear_Residentes(string Rut_Residente, string Pass_Residente, string Nombre_Residente, string Direccion, string Correo, int ID_TIPO_RESIDENTE);

        [OperationContract]
        string SP_Deshabilitar_Residente(string Rut_Residente);

        [OperationContract]
        string SP_Habilitar_Residente(string Rut_Residente);

        [OperationContract]
        string SP_Crear_Evento_Libro(string SP_Titulo, string SP_Descripcion, string SP_Area_Comun, string SP_Rut_Involucrado, string SP_Rut_Funcionario);




        // DETALLE_RESERVA

        [OperationContract]
        string ListarDetalleReserva();

        [OperationContract]
        string ListarDetalleReservaPorFecha(string _fecha_areservar);

        [OperationContract]
        bool CreateDetalleReserva(string id);

        [OperationContract]
        string ReadDetalleReserva(int fechaSeleccionada);

        [OperationContract]
        bool SP_Crear_Detalle_Reserva(int idServicio, int tramo1, int tramo2, int tramo3, string fechaASeleccionar, string RUTResidente);

        [OperationContract]
        bool SP_Crear_Reserva_Residente_Desde_Funcionario(string RUTResidente, string RUT_Funcionario);

        [OperationContract]
        bool SP_Crear_Reserva_Residente(string RUTResidente);

        [OperationContract]
        int UsoDeTramoSegunFechayServicio(string fecha, int tramo, int servicio);

        [OperationContract]
        int M_Capacidad_Servicio_porID(int Id_Busqueda);

        [OperationContract]
        int M_Precio_Servicio_porID(int Id_Busqueda);

        [OperationContract]
        int ContarFilas();


        [OperationContract]
        string SP_Pagar_Reservas_Tarjetas(string RUTResidente);











}



    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}





