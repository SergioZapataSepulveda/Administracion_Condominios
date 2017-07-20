using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Xml.Serialization;
using System.IO;
using Caso14.Negocio;


namespace WebCaso14.Residentes
{
    public partial class PaginaDaniel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos();
            if (!IsPostBack)
            {
                for (int mes = DateTime.MinValue.Month; mes <= DateTime.MaxValue.Month; mes++)
                {
                    ListItem lstmes = new ListItem();
                    string[] mesinyear = { "seleccione", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
                    lstmes.Value = mes.ToString();
                    lstmes.Text = mesinyear[mes];
                    ddl_mes.Items.Add(lstmes);
                    ddl_mes.DataBind();
                    ddl_mes.SelectedIndex = DateTime.Today.Month-1;
                }
                for (int i = DateTime.Now.Year - 7; i <= (DateTime.Now.Year + 1); i++)
                {
                    ListItem lst = new ListItem();
                    lst.Value = i.ToString();
                    lst.Text = i.ToString();
                    ddl_anio.Items.Add(lst);
                    ddl_anio.DataBind();
                    ddl_anio.SelectedIndex = 7;
                }
            }
        }


        // cargar datos automaticamente para el mes dado en la variables 
        private void CargarDatos()
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;

                int idCondominio = servicio.Id_Condominio_desde_rut("CONDOMINIO.ID_CONDOMINIO", auxUserName);
                int var2 = 06;
                int var3 = 2017;

                lbl_Mantencion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Mantencion");
                lbl_Mantencion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Mantencion");
                lbl_Mantencion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Mantencion");
                lbl_Mantencion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Mantencion");

                lbl_Sueldos_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Sueldos");
                lbl_Sueldos_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Sueldos");
                lbl_Sueldos_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Sueldos");
                lbl_Sueldos_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Sueldos");

                lbl_Servicios_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Servicios");
                lbl_Servicios_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Servicios");
                lbl_Servicios_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Servicios");
                lbl_Servicios_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Servicios");

                lbl_Otros_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Otros");
                lbl_Otros_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Otros");
                lbl_Otros_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Otros");
                lbl_Otros_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", idCondominio, var2, var3, "Otros");

                lbl_Recaudacion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Recaudacion");
                lbl_Recaudacion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Recaudacion");
                lbl_Recaudacion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Recaudacion");
                lbl_Recaudacion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", idCondominio, var2, var3, "Recaudacion");

                lbl_num_Casas.Text = servicio.Id_Condominio_desde_rut("CONDOMINIO.CANTIDAD_CASAS", auxUserName).ToString();
                var totalEgreso = servicio.Calcular_Total_Mensual_Registros_GC(idCondominio, var2, var3, "Egreso");
                var totalIngreso = servicio.Calcular_Total_Mensual_Registros_GC(idCondominio, var2, var3, "Ingreso");
                lbl_total.Text = (Convert.ToInt32(totalEgreso) - Convert.ToInt32(totalIngreso)).ToString();

                lbl_Creacion_Obseracion.Text = "Test de respuesta a los cambios OKOKOK";


                servicio.Close();
            }
            catch (Exception)
            {
                Response.Redirect("GastosComunes.aspx");
            }
        }




        // cargar datos para el mes dado en la variables seleccionado en segun los campos mes y año 
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;

                int idCondominio = servicio.Id_Condominio_desde_rut("CONDOMINIO.ID_CONDOMINIO", auxUserName);
                int var2 = Convert.ToInt32(ddl_mes.SelectedValue);
                int var3 = Convert.ToInt32(ddl_anio.SelectedValue);

                lbl_Mantencion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Mantencion");
                lbl_Mantencion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Mantencion");
                lbl_Mantencion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Mantencion");
                lbl_Mantencion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Mantencion");

                lbl_Sueldos_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Sueldos");
                lbl_Sueldos_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Sueldos");
                lbl_Sueldos_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Sueldos");
                lbl_Sueldos_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Sueldos");

                lbl_Servicios_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Servicios");
                lbl_Servicios_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Servicios");
                lbl_Servicios_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Servicios");
                lbl_Servicios_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Servicios");

                lbl_Otros_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Otros");
                lbl_Otros_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Otros");
                lbl_Otros_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Otros");
                lbl_Otros_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", idCondominio, var2, var3, "Otros");

                lbl_Recaudacion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", idCondominio, var2, var3, "Recaudacion");
                lbl_Recaudacion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", idCondominio, var2, var3, "Recaudacion");
                lbl_Recaudacion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", idCondominio, var2, var3, "Recaudacion");
                lbl_Recaudacion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", idCondominio, var2, var3, "Recaudacion");

                lbl_num_Casas.Text = servicio.Id_Condominio_desde_rut("CONDOMINIO.CANTIDAD_CASAS", auxUserName).ToString();
                var totalEgreso = servicio.Calcular_Total_Mensual_Registros_GC(idCondominio, var2, var3, "Egreso");
                var totalIngreso = servicio.Calcular_Total_Mensual_Registros_GC(idCondominio, var2, var3, "Ingreso");
                lbl_total.Text = (Convert.ToInt32(totalEgreso) - Convert.ToInt32(totalIngreso)).ToString();

                servicio.Close();
            }
            catch (Exception)
            {
                Response.Redirect("GastosComunes.aspx");
            }
        }

        protected void btn_ingresar_observacion_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                int id_Gasto = Convert.ToInt32(txt_id_gasto.Text);
                string observacion = txt_observacion.Text;

                lbl_Creacion_Obseracion.Text = servicio.Ingresar_Observaciones(observacion, id_Gasto);

                txt_id_gasto.Text = string.Empty;
                txt_observacion.Text = string.Empty;
                servicio.Close();
            }
            catch (Exception)
            {
                lbl_Creacion_Obseracion.Text = "Ingrese un Id Valido";
            }
        }


    }
}