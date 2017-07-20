using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace WebCaso14_Administrador
{
    public partial class GenerarReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos(); 
            if (!IsPostBack)
            {
                
                ListItemCollection llenarDDL_tipo = new ListItemCollection();
                llenarDDL_tipo.Add("Espacios");
                llenarDDL_tipo.Add("Gastos Comunes");
                llenarDDL_tipo.Add("Morosidad");
                ddl_Tipo.DataSource = llenarDDL_tipo;
                ddl_Tipo.DataBind();
            }
        }





       

        protected void btn_Crear_Reporte_Click1(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
                
                string Tipo = ddl_Tipo.SelectedValue;
                string descripcion = txt_Descripcion.Text;
                string rutReporte = txt_Rut_Reportar.Text;
                int idCondominio = servicio.id_Condominio_desde_Funcionario(auxUserName);

                lbl_Estado_Creacion_Multa.Text = servicio.SP_Crear_Reportes(Tipo, descripcion, rutReporte, idCondominio);
                txt_Descripcion.Text = string.Empty;
                txt_Rut_Reportar.Text = string.Empty;
            }
            catch (Exception)
            {
                lbl_Estado_Creacion_Multa.Text = "Ingrese todos los datos";
            }
        }



        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Reportes>));
            StringReader lector = new StringReader(servicio.ListarReportes());
            GridView2.DataSource = (List<Caso14.Negocio.Reportes>)aux.Deserialize(lector);
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
                e.Row.Cells[0].Text = "Id Reporte";
                e.Row.Cells[1].Text = "Fecha";
                e.Row.Cells[2].Text = "Tipo";
                e.Row.Cells[3].Text = "Descripción";
                e.Row.Cells[4].Text = "Rut Reportado";
            }
        }
    }
}