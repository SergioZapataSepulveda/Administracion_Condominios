using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Caso14.Negocio;

namespace WebCaso14_Administrador
{
    public partial class InformacionResidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos(); 
        }


        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();




            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Residente>));
            StringReader lector = new StringReader(servicio.ListarResidente());
            GridView2.DataSource = (List<Caso14.Negocio.Residente>)aux.Deserialize(lector);
            GridView2.DataBind();
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
                e.Row.Cells[0].Text = "Rut";
                e.Row.Cells[1].Text = "";
                e.Row.Cells[2].Text = "Nombre";
                e.Row.Cells[3].Text = "Niv. Acceso";
                e.Row.Cells[4].Text = "Direccion";
                e.Row.Cells[5].Text = "Correo";
                e.Row.Cells[6].Text = "Tipo Residente";
                e.Row.Cells[1].Width = 0;
            }
        }
    }
}