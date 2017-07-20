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

namespace WebCaso14_Directiva
{
    public partial class ReportarMorosidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos2();
            if (!IsPostBack)
            {
                for (int mes = DateTime.MinValue.Month; mes < DateTime.MaxValue.Month; mes++)
                {
                    ListItem lstmes = new ListItem();
                    string[] mesinyear = { "seleccione", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
                    lstmes.Value = mes.ToString();
                    lstmes.Text = mesinyear[mes];
                }
                for (int i = DateTime.Now.Year - 7; i <= (DateTime.Now.Year + 1); i++)
                {
                    ListItem lst = new ListItem();
                    lst.Value = i.ToString();
                    lst.Text = i.ToString();
                }

                ListItemCollection llenarDDL_tipo = new ListItemCollection();
                llenarDDL_tipo.Add("EN MORA");
                llenarDDL_tipo.Add("ACTIVA");
                ddl_Estado.DataSource = llenarDDL_tipo;
                ddl_Estado.DataBind();
            }
        }




        protected void Modificar_Registro_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id_a_Modificar.Text.Length >= 1 && txt_Monto.Text.Length >= 3)
                {
                    int idCuota = Convert.ToInt32(txt_id_a_Modificar.Text);
                    string estado = ddl_Estado.SelectedValue;
                    int monto = Convert.ToInt32(txt_Monto.Text);
                    string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);

                    ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                    lbl_estado_rectificacion.Text = servicio.rectificar_Registros_GC_Residentes(fecha, estado, monto, idCuota);
                    Response.Redirect("ReportarMorosidad.aspx");

                    servicio.Close();
                }
                lbl_estado_rectificacion1.Text = "Complete ID con datos reales";
                lbl_estado_rectificacion2.Text = "Complete Monto con datos reales";
            }
            catch (Exception)
            {
                lbl_estado_rectificacion.Text = "Complete todos los campos con datos reales";
            }
        }


        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 1;
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3;
        }



        private void CargarDatos2()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = "1690";
            string nombreRut = servicio.Nombre_desde_LogUser(auxUserName);
            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Cuota_Gasto_Residentes>));
            StringReader lector = new StringReader(servicio.Listar_Pagos_Residente(auxUserName));
            GridView2.DataSource = (List<Caso14.Negocio.Cuota_Gasto_Residentes>)aux.Deserialize(lector);
            GridView2.DataBind();
            lbl_nombre_Rut_buscado.Text = nombreRut;
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            btn_rut_Buscar_Click(sender, e);
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Id de Cuota";
                e.Row.Cells[1].Text = "Inicio de Pago";
                e.Row.Cells[2].Text = "Termino de Pago";
                e.Row.Cells[3].Text = "Fecha de Pago ";
                e.Row.Cells[4].Text = "Monto";
                e.Row.Cells[5].Text = "Estado";
                e.Row.Cells[6].Text = "";
            }
        }

        protected void btn_rut_Buscar_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = txt_rut_Buscar.Text;
            string nombreRut = servicio.Nombre_desde_LogUser(auxUserName);
            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Cuota_Gasto_Residentes>));
            StringReader lector = new StringReader(servicio.Listar_Pagos_Residente(auxUserName));
            GridView2.DataSource = (List<Caso14.Negocio.Cuota_Gasto_Residentes>)aux.Deserialize(lector);
            GridView2.DataBind();
            lbl_nombre_Rut_buscado.Text = nombreRut;
        }



    }
}