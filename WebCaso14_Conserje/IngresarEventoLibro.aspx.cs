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
    public partial class IngresarEventoLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos();
            if (!IsPostBack)
            {

                ListItemCollection llenarDDL_tipo = new ListItemCollection();
                llenarDDL_tipo.Add("Quincho");
                llenarDDL_tipo.Add("Multicancha");
                llenarDDL_tipo.Add("Salon Eventos");
                llenarDDL_tipo.Add("Estacionamientos");
                llenarDDL_tipo.Add("Ninguna");
                ddl_areaComun.DataSource = llenarDDL_tipo;
                ddl_areaComun.DataBind();
            }
        }










        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int id_Condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Evento_Libro>));
            StringReader lector = new StringReader(servicio.ListarEventoLibro(id_Condominio));
            GridView2.DataSource = (List<Caso14.Negocio.Evento_Libro>)aux.Deserialize(lector);
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
                e.Row.Cells[0].Text = "Id";
                e.Row.Cells[1].Text = "Titulo";
                e.Row.Cells[2].Text = "Descripcion";
                e.Row.Cells[3].Text = "Fecha";
                e.Row.Cells[4].Text = "Area Comun";
                e.Row.Cells[5].Text = "Rut Involucrado";
                e.Row.Cells[6].Text = "Rut Funcionario";
            }
        }

        protected void btn_Crear_Evento_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();


                string titulo = txt_Titulo.Text;
                string descripcion = txt_Descripcion.Text;
                string areaComun = ddl_areaComun.SelectedValue; 
                string rutInvolucrado = txt_Rut_Involucrado.Text;
                string rutFuncionario = System.Web.HttpContext.Current.User.Identity.Name;

                lbl_Estado_Creacion.Text = servicio.SP_Crear_Evento_Libro(titulo, descripcion, areaComun, rutInvolucrado, rutFuncionario);
                txt_Titulo.Text = string.Empty;
                txt_Descripcion.Text = string.Empty;
                txt_Rut_Involucrado.Text = string.Empty;
            }
            catch (Exception)
            {
                lbl_Estado_Creacion.Text = "Ingrese todos los datos";
            }
        }
    }
}