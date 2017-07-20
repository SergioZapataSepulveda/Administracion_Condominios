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

namespace WebCaso14_Conserje
{
    public partial class ConsultarPagoGasoComun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
               
            }
        }



        protected void btn_rut_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string rutResidente = txt_rut_Buscar.Text;

                string nombreResidenteBuscado = servicio.Nombre_desde_LogUser(rutResidente);

                XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Cuota_Gasto_Residentes>));
                StringReader lector = new StringReader(servicio.Listar_Pagos_Residente(rutResidente));
                GridView2.DataSource = (List<Caso14.Negocio.Cuota_Gasto_Residentes>)aux.Deserialize(lector);
                GridView2.DataBind();

                lbl_nombre_Rut_buscado.Text = nombreResidenteBuscado.ToString();

                servicio.Close();
            }
            catch (Exception)
            {
                lbl_nombre_Rut_buscado.Text = "Residente No Existe, revise el rut ingresado";
            }
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


        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 1;
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3;
        }





    }
}