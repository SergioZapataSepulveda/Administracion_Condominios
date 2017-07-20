using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace WebCaso14_Conserje
{
    public partial class VerResidentesMorosos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos();
            if (!IsPostBack)
            {


            }
        }


        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int id_Condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Cuota_Gasto_Residentes>));
            StringReader lector = new StringReader(servicio.Listar_Cuota_Gasto_Residentes(id_Condominio));
            GridView2.DataSource = (List<Caso14.Negocio.Cuota_Gasto_Residentes>)aux.Deserialize(lector);
            GridView2.DataBind();

            servicio.Close();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "id";
                e.Row.Cells[1].Text = "Fecha Inicio Pago";
                e.Row.Cells[2].Text = "Fecha Termino Pago";
                e.Row.Cells[3].Text = "Fecha Pago";
                e.Row.Cells[4].Text = "Moto";
                e.Row.Cells[5].Text = "Estado";
                e.Row.Cells[6].Text = "Rut Residente";
            }
        }
    }
}