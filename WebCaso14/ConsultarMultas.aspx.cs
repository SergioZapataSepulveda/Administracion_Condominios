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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WebCaso14
{
    public partial class ConsultarMultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos2();
            if (!IsPostBack)
            {

            }
        }





        protected void Pagar_Cuota_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow fila = GridView2.SelectedRow;


                if (fila.Cells[6].Text.Equals("ACTIVA"))
                {
                    Session["Id_Pago"] = fila.Cells[1].Text;
                    Session["Total_Pago"] = fila.Cells[4].Text;
                    Session["Tipo_Pago"] = "Multa";
                    Session["Descripion"] = fila.Cells[5].Text;
                    Server.Transfer("~/Pago_Central.aspx?");  // dentro del mismo servidor works ok
                }
                lbl_Mensaje_boton.Text = "Seleccione una Multa de la lista, Recuerda que para ir al portal de pago debes seleccionar solo 1 Multa ACTIVA";
            }
            catch (Exception)
            {
                lbl_Mensaje_boton.Text = "Seleccione una Multa de la lista, Recuerda que para ir al portal de pago debes seleccionar solo 1 Multa ACTIVA";
            }
        }









        private void CargarDatos2()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int idCondominio = servicio.Id_Condominio_desde_rut("CONDOMINIO.ID_Condominio", auxUserName);

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Multa>));
            StringReader lector = new StringReader(servicio.ListarMultasPorResidnte(idCondominio, auxUserName));
            GridView2.DataSource = (List<Caso14.Negocio.Multa>)aux.Deserialize(lector);
            GridView2.DataBind();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            CargarDatos2();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Seleccione";
                e.Row.Cells[1].Text = "id";
                e.Row.Cells[2].Text = "Fecha Creación";
                e.Row.Cells[3].Text = "Fecha Pago";
                e.Row.Cells[4].Text = "Moto";
                e.Row.Cells[5].Text = "Descripción";
                e.Row.Cells[6].Text = "Estado";
                e.Row.Cells[7].Text = "Rut";
                e.Row.Cells[0].Width = 80;
                e.Row.Cells[5].Width = 150;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GridView2.SelectedRow;
            lbl_selccion_ID.Text = fila.Cells[1].Text;
            lbl_selccion_Monto.Text = "$" + fila.Cells[4].Text;
            lbl_selccion_fecha.Text = fila.Cells[2].Text;
            lbl_selccion_estado.Text = fila.Cells[6].Text;
            lbl_Mensaje_boton.Text = "";
        }








    }
}


