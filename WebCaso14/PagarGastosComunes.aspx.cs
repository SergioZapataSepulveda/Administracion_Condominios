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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                 CargarDatos2();
            }
        }





        protected void Pagar_Cuota_Click(object sender, EventArgs e)
        {
            try 
	            {	        
		            GridViewRow fila = GridView2.SelectedRow;

                        if (fila.Cells[6].Text.Equals("ACTIVA") || fila.Cells[6].Text.Equals("EN MORA"))
                        {
                            Session["Id_Pago"] = fila.Cells[1].Text;
                            Session["Total_Pago"] = fila.Cells[5].Text;
                            Session["Tipo_Pago"] = "Gasto Comun";
                            Session["Descripion"] = "Cuota mensual de Gasto Comun " + fila.Cells[2].Text;
                            Server.Transfer("~/Pago_Central.aspx?");  // dentro del mismo servidor works ok
                        }
                        lbl_Mensaje_boton.Text = "Seleccione una cuota de la lista, Recuerda que para ir al portal de pago debes seleccionar solo 1 cuota ACTIVA o EN MORA"; 
	            }
	            catch (Exception)
	            {
                    lbl_Mensaje_boton.Text = "Seleccione una cuota de la lista, Recuerda que para ir al portal de pago debes seleccionar solo 1 cuota ACTIVA o EN MORA"; 
	            }

            
        }

        

        private void CargarDatos2() 
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Cuota_Gasto_Residentes>));
            StringReader lector = new StringReader(servicio.Listar_Pagos_Residente(auxUserName));
            GridView2.DataSource = (List<Caso14.Negocio.Cuota_Gasto_Residentes>)aux.Deserialize(lector);
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
                e.Row.Cells[1].Text = "Id de Cuota";
                e.Row.Cells[2].Text = "Inicio de Pago";
                e.Row.Cells[3].Text = "Termino de Pago";
                e.Row.Cells[4].Text = "Fecha de Pago ";
                e.Row.Cells[5].Text = "Monto";
                e.Row.Cells[6].Text = "Estado";
                e.Row.Cells[7].Text = "";
                e.Row.Cells[0].Width = 80;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GridView2.SelectedRow;
            lbl_selccion_ID.Text = fila.Cells[1].Text;
            lbl_selccion_Monto.Text = "$"+fila.Cells[5].Text;
            lbl_selccion_fecha.Text = fila.Cells[3].Text;
            lbl_selccion_estado.Text = fila.Cells[6].Text;
            lbl_Mensaje_boton.Text = "";
        }

    







    }
}


