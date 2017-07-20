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
    public partial class ConsultarMultas : System.Web.UI.Page
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
            }
        }







        // cargar datos automaticamente para el mes dado en la variables 





        protected void btn_rut_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
                int id_Condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);

                string rut = txt_rut_Buscar.Text;
                lbl_nombre_Rut_buscado.Text = servicio.Nombre_desde_LogUser(rut);

                XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Multa>));
                StringReader lector = new StringReader(servicio.ListarMultasPorResidnte(id_Condominio, rut));
                GridView2.DataSource = (List<Caso14.Negocio.Multa>)aux.Deserialize(lector);
                GridView2.DataBind();



                servicio.Close();
            }
            catch (Exception)
            {
                lbl_nombre_Rut_buscado.Text = "Residente No Existe, revise el rut ingresado";
            }
        }






        // Listar_Cuota_Gasto_Residentes(int idCondominio)
        private void CargarDatos2()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int id_Condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Multa>));
            StringReader lector = new StringReader(servicio.ListarMultas(id_Condominio));
            GridView2.DataSource = (List<Caso14.Negocio.Multa>)aux.Deserialize(lector);
            GridView2.DataBind();

            servicio.Close();
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
                e.Row.Cells[0].Text = "id";
                e.Row.Cells[1].Text = "Creación";
                e.Row.Cells[2].Text = "Pago";
                e.Row.Cells[3].Text = "Moto";
                e.Row.Cells[4].Text = "Descripción";
                e.Row.Cells[5].Text = "Estado";
                e.Row.Cells[6].Text = "Rut";
            }
        }

        protected void btn_mostrarTodos_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int id_Condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Multa>));
            StringReader lector = new StringReader(servicio.ListarMultas(id_Condominio));
            GridView2.DataSource = (List<Caso14.Negocio.Multa>)aux.Deserialize(lector);
            GridView2.DataBind();

            servicio.Close();
        }

    }
}
