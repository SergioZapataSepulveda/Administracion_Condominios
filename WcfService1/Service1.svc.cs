using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Caso14.Negocio;
using System.Xml.Serialization;
using System.IO;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }




        #region  Reportes

        public string ListarReportes()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Reportes>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarReportes());
            return salida.ToString();
        }


        #endregion






        #region  Colecciones

        public string Listar_Pagos_Residente(string rutResidente)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Cuota_Gasto_Residentes>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.Listar_Pagos_Residente(rutResidente));
            return salida.ToString();
        }



        public string Listar_Pago_Offline(string rut)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Pago_Offline>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.Listar_Pago_Offline(rut));
            return salida.ToString();
        }

        public string Listar_Cuota_Gasto_Residentes(int idCondominio)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Cuota_Gasto_Residentes>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.Listar_Cuota_Gasto_Residentes(idCondominio));
            return salida.ToString();
        }



        public string ListarMultas(int idCondominio)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Multa>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarMultas(idCondominio));
            return salida.ToString();
        }



        public string ListarMultasPorResidnte(int idCondominio, string rut)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Multa>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarMultasPorResidnte(idCondominio, rut));
            return salida.ToString();
        }



        public string ListarEventoLibro(int id_Condominio)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Evento_Libro>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarEventoLibro(id_Condominio));
            return salida.ToString();
        }

        #endregion




        #region  Administracion

        public string ListarIngresoAdministracion(string filtroFecha, string fechaMax, int id_Condominio)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Administracion>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarIngresoAdministracion(filtroFecha, fechaMax, id_Condominio));
            return salida.ToString();
        }

        public string ListarIngresoAdministracionTodo(int id_Condominio)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Administracion>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarIngresoAdministracion(id_Condominio));
            return salida.ToString();
        }

        public string SP_Crear_Ingreso_Gasto_Comun(string _tipo, string _categoria, string _descripcion, int _monto, int _id_condominio)
        {
            Administracion aux = new Administracion();
            return aux.SP_Crear_Ingreso_Gasto_Comun(_tipo, _categoria, _descripcion, _monto, _id_condominio);
        }

        public string SP_Modificar_Ingreso_Gasto_Comun(int _idadministrar, string _tipo, string _categoria, string _descripcion, int _monto)
        {
            Administracion aux = new Administracion();
            return aux.SP_Modificar_Ingreso_Gasto_Comun(_idadministrar, _tipo, _categoria, _descripcion, _monto);
        }

        public string listar_Registros_GC_Mensuales(string seleccionado, int idCondominio, int mes, int anio, string categoria)
        {
            Administracion aux = new Administracion();
            return aux.listar_Registros_GC_Mensuales(seleccionado, idCondominio, mes, anio, categoria);
        }

        public string Calcular_Total_Mensual_Registros_GC(int idCondominio, int mes, int anio, string entradaSalida)
        {
            Administracion aux = new Administracion();
            return aux.Calcular_Total_Mensual_Registros_GC(idCondominio, mes, anio, entradaSalida);
        }

        public string SP_Crear_Cuota_Gasto_Comun(int _id_condominio)
        {
            Administracion aux = new Administracion();
            return aux.SP_Crear_Cuota_Gasto_Comun(_id_condominio);
        }

        public string SP_Actualizar_Cuota_G_C(int _id_condominio)
        {
            Administracion aux = new Administracion();
            return aux.SP_Actualizar_Cuota_G_C(_id_condominio);
        }


        public string listar_Morosos_Totales(string seleccionado, int idCondominio)
        {
            Administracion aux = new Administracion();
            return aux.listar_Morosos_Totales(seleccionado, idCondominio);
        }


        public string SP_Crear_Reportes(string Tipo, string DESCRIPCION, string RUT_REPORTADO, int id_condominio)
        {
            Administracion aux = new Administracion();
            return aux.SP_Crear_Reportes(Tipo, DESCRIPCION, RUT_REPORTADO, id_condominio);
        }


        public string listar_Correos_Residentes(int idCondominio)
        {
            Administracion aux = new Administracion();
            return aux.listar_Correos_Residentes(idCondominio);
        }


        public string SP_Revisar_Multas(int id_condominio)
        {
            Administracion aux = new Administracion();
            return aux.SP_Revisar_Multas(id_condominio);
        }


        #endregion





        #region  Residente

        public string ListarResidente()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Residente>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarResidente());
            return salida.ToString();
        }






        public string NOMBRE_ARCHIVO_PAGO_OFFLINE_2()
        {
            Residente aux = new Residente();
            return aux.NOMBRE_ARCHIVO_PAGO_OFFLINE_2();
        }


        public string SP_PAGO_OFFLINE(string RUTResidente, string Tipo)
        {
            Residente aux = new Residente();
            return aux.SP_PAGO_OFFLINE(RUTResidente, Tipo);
        }


        public int GenerarAlertasMora(string RutIngresado)
        {
            Residente aux = new Residente();
            return aux.GenerarAlertasMora(RutIngresado);
        }

        public int GenerarAlertasMulta(string RutIngresado)
        {
            Residente aux = new Residente();
            return aux.GenerarAlertasMulta(RutIngresado);
        }

        public bool ValidarLogin(string LOGusuario, string LOGpassword)
        {
            Residente aux = new Residente();
            return aux.ValidarLogin(LOGusuario, LOGpassword);
        }


        public bool ValidarRut(string RutIngresado)
        {
            Residente aux = new Residente();
            return aux.ValidarRut(RutIngresado);
        }


        public int ID_desde_LogUser(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.ID_desde_LogUser(LOGusuario);
        }

        public string Nombre_desde_LogUser(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.Nombre_desde_LogUser(LOGusuario);
        }

        public string CargoEnDirectiva(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.CargoEnDirectiva(LOGusuario);
        }


        public bool CreateResidente(string Rut)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Residente));
            StringReader lector = new StringReader(Rut);
            Residente nuevoUsuario = (Residente)serializador.Deserialize(lector);
            return nuevoUsuario.CreateResidente();

        }

        public bool DeleteResidente(string Rut)
        {
            Residente user = new Residente() { Rut_Residente = Rut };
            return user.DeleteResidente();
        }


        public string listar_Registros_GC_Residentes(string seleccionado, int idCondominio, string rutBuscar)
        {
            Residente user = new Residente();
            return user.listar_Registros_GC_Residentes(seleccionado, idCondominio, rutBuscar);
        }


        public string rectificar_Registros_GC_Residentes(string fechaPago, string estado, int monto, int idCuota)
        {
            Residente user = new Residente();
            return user.rectificar_Registros_GC_Residentes(fechaPago, estado, monto, idCuota);
        }


        public int Id_Condominio_desde_rut(string select, string rutBuscar)
        {
            Residente user = new Residente();
            return user.Id_Condominio_desde_rut(select, rutBuscar);
        }


        public string listar_Multas_Residentes(string select, int idCondominio, string rutBuscar)
        {
            Residente user = new Residente();
            return user.listar_Multas_Residentes(select, idCondominio, rutBuscar);
        }




        public string Crear_Multa(int monto, string descripcion, string rutMultar)
        {
            Residente user = new Residente();
            return user.Crear_Multa(monto, descripcion, rutMultar);
        }




        public string Met_Ver_Detalle_Reservas(string select, string rutResidente)
        {
            Residente user = new Residente();
            return user.Met_Ver_Detalle_Reservas(select, rutResidente);
        }





        public string Modificar_Multa(string fechapago, int monto, string descripcion, string estado, int idMulta)
        {
            Residente user = new Residente();
            return user.Modificar_Multa(fechapago, monto, descripcion, estado, idMulta);
        }

        public string Ingresar_Observaciones(string observacion, int idGastoComun)
        {
            Residente user = new Residente();
            return user.Ingresar_Observaciones(observacion, idGastoComun);
        }


        public string listar_Anuncios(int idCondominio, int lugar)
        {
            Residente user = new Residente();
            return user.listar_Anuncios(idCondominio, lugar);
        }

        public int Residente_Nivel_Acceso(string LOGusuario)
        {
            Residente aux = new Residente();
            return aux.Residente_Nivel_Acceso(LOGusuario);
        }



        public string Met_Pagar_Reservas()
        {
            Residente aux = new Residente();
            return aux.Met_Pagar_Reservas();
        }


        public bool ValidarTarjeta(string RutIngresado, long numeroTarjeta, int codigoSeg, string FechaV)
        {
            Residente aux = new Residente();
            return aux.ValidarTarjeta(RutIngresado, numeroTarjeta, codigoSeg, FechaV);
        }

        #endregion





        #region  Funcionario
        public bool ValidarLoginFuncionario(string LOGusuario, string LOGpassword)
        {
            Funcionario aux = new Funcionario();
            return aux.ValidarLoginFuncionario(LOGusuario, LOGpassword);
        }

        public int ID_desde_LogUser_Funcionario(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.ID_desde_LogUser_Funcionario(LOGusuario);
        }

        public string Nombre_desde_LogUser_Funcionario(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.Nombre_desde_LogUser_Funcionario(LOGusuario);
        }

        public string CargoEnCondominio(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.CargoEnCondominio(LOGusuario);
        }

        public int id_Condominio_desde_Funcionario(string LOGusuario)
        {
            Funcionario aux = new Funcionario();
            return aux.id_Condominio_desde_Funcionario(LOGusuario);
        }

        public string SP_Crear_Anuncios(string Titulo, string Detalle, int Condominio)
        {
            Funcionario aux = new Funcionario();
            return aux.SP_Crear_Anuncios(Titulo, Detalle, Condominio);
        }

        public string SP_Crear_Residentes(string Rut_Residente, string Pass_Residente, string Nombre_Residente, string Direccion, string Correo, int ID_TIPO_RESIDENTE)
        {
            Funcionario aux = new Funcionario();
            return aux.SP_Crear_Residentes(Rut_Residente, Pass_Residente, Nombre_Residente, Direccion, Correo, ID_TIPO_RESIDENTE);
        }

        public string SP_Deshabilitar_Residente(string Rut_Residente)
        {
            Funcionario aux = new Funcionario();
            return aux.SP_Deshabilitar_Residente(Rut_Residente);
        }

        public string SP_Habilitar_Residente(string Rut_Residente)
        {
            Funcionario aux = new Funcionario();
            return aux.SP_Habilitar_Residente(Rut_Residente);
        }


        public string SP_Crear_Evento_Libro(string SP_Titulo, string SP_Descripcion, string SP_Area_Comun, string SP_Rut_Involucrado, string SP_Rut_Funcionario)
        {
            Funcionario aux = new Funcionario();
            return aux.SP_Crear_Evento_Libro(SP_Titulo, SP_Descripcion, SP_Area_Comun, SP_Rut_Involucrado, SP_Rut_Funcionario);
        }







        #endregion





        #region  Detalle Reserva


        public string ListarDetalleReserva()
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Detalle_Reserva>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarDetalleReserva());
            return salida.ToString();
        }

        public string ListarDetalleReservaPorFecha(string _fecha_areservar)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Detalle_Reserva>));
            Colecciones colns = new Colecciones();
            StringWriter salida = new StringWriter();
            serializador.Serialize(salida, colns.ListarDetalleReserva(_fecha_areservar));
            return salida.ToString();
        }

        public bool CreateDetalleReserva(string id)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(Detalle_Reserva));
            StringReader lector = new StringReader(id);
            Detalle_Reserva nuevoUsuario = (Detalle_Reserva)serializador.Deserialize(lector);
            return nuevoUsuario.CreateDetalleReserva();
        }

        public string ReadDetalleReserva(int fechaSeleccionada)
        {
            XmlSerializer serialziador = new XmlSerializer(typeof(Detalle_Reserva));
            Detalle_Reserva user = new Detalle_Reserva() { id_d_r = fechaSeleccionada };
            StringWriter salida = new StringWriter();
            user.ReadDetalleReserva();
            serialziador.Serialize(salida, user);
            return salida.ToString();
        }

        public bool SP_Crear_Detalle_Reserva(int idServicio, int tramo1, int tramo2, int tramo3, string fechaASeleccionar, string RUTResidente)
        {
            Detalle_Reserva aux = new Detalle_Reserva();
            return aux.SP_Crear_Detalle_Reserva(idServicio, tramo1, tramo2, tramo3, fechaASeleccionar, RUTResidente);
        }

        public bool SP_Crear_Reserva_Residente(string RUTResidente)
        {
            Detalle_Reserva aux = new Detalle_Reserva();
            return aux.SP_Crear_Reserva_Residente(RUTResidente);
        }

        public bool SP_Crear_Reserva_Residente_Desde_Funcionario(string RUTResidente, string RUT_Funcionario)
        {
            Detalle_Reserva aux = new Detalle_Reserva();
            return aux.SP_Crear_Reserva_Residente_Desde_Funcionario(RUTResidente, RUT_Funcionario);
        }

        public int UsoDeTramoSegunFechayServicio(string fecha, int tramo, int servicio)
        {
            Detalle_Reserva aux = new Detalle_Reserva();
            return aux.UsoDeTramoSegunFechayServicio(fecha, tramo, servicio);
        }

        public int M_Capacidad_Servicio_porID(int Id_Busqueda)
        {
            Servicio aux = new Servicio();
            return aux.M_Capacidad_Servicio_porID(Id_Busqueda);
        }

        public int M_Precio_Servicio_porID(int Id_Busqueda)
        {
            Servicio aux = new Servicio();
            return aux.M_Precio_Servicio_porID(Id_Busqueda);
        }

        public int ContarFilas()
        {
            Detalle_Reserva aux = new Detalle_Reserva();
            return aux.ContarFilas();
        }


        public string SP_Pagar_Reservas_Tarjetas(string RUTResidente)
        {
            Detalle_Reserva aux = new Detalle_Reserva();
            return aux.SP_Pagar_Reservas_Tarjetas(RUTResidente);
        }


        #endregion



    }
}
