using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;


namespace WebCaso14
{
    public partial class ingresoResidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
            if (!IsPostBack)
            {
                
                ListItemCollection llenarDDL_tipo = new ListItemCollection();
                llenarDDL_tipo.Add("Gasto_Comun");
                llenarDDL_tipo.Add("Multa");
                llenarDDL_tipo.Add("Reserva");
                ddl_tipo.DataSource = llenarDDL_tipo;
                ddl_tipo.DataBind();
            }
        }


        protected void btn_mostrar_ruta_Click(object sender, EventArgs e)
        {

            string[] arr = Server.MapPath(FileUpload1.ToString()).Split(new string[] { "Desktop\u005c" }, StringSplitOptions.None);
            string var = arr[0] + "Desktop\u005c";

        }



        protected void btn_subir_archivo_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            //lblDato.Text = servicio.Nombre_desde_LogUser(auxUserName).ToString();

            //string mes = (ddl_mes.SelectedIndex + 1).ToString();
            //string anio = ddl_anio.SelectedValue;
            string tipo = ddl_tipo.SelectedValue;

            //FileUpload1.SaveAs(Server.MapPath("imgPagos\\" + FileUpload1.FileName + ".555"));
 

            if (FileUpload1.FileName == String.Empty)
            {
                lbl_mensaje.Text = "No hay ningo archivo seleccionado, busque uno mediante el boton selccionar archivo 1232132321";
            }

            if (FileUpload1.FileName != String.Empty)
            {
                servicio.SP_PAGO_OFFLINE(auxUserName, tipo);

                FileUpload1.SaveAs(Server.MapPath("imgPagos\\" + servicio.NOMBRE_ARCHIVO_PAGO_OFFLINE_2()));
                //lbl_mensaje.Text = "Archivo cargado";
                lbl_mensaje.Text = "archivo guardado con el nombre de: " + servicio.NOMBRE_ARCHIVO_PAGO_OFFLINE_2(); 
            }
            //lbl_mensaje.Text = FileUpload1.FileName.ToString();
        } 



        


       // Listar_Cuota_Gasto_Residentes(int idCondominio)
        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;

            XmlSerializer aux = new XmlSerializer(typeof(List<Caso14.Negocio.Pago_Offline>));
            StringReader lector = new StringReader(servicio.Listar_Pago_Offline(auxUserName));
            GridView2.DataSource = (List<Caso14.Negocio.Pago_Offline>)aux.Deserialize(lector);
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
                e.Row.Cells[0].Text = "Ver archivo";
                e.Row.Cells[1].Text = "id";
                e.Row.Cells[2].Text = "Nombre Archivo";
                e.Row.Cells[3].Text = "Fecha";
                e.Row.Cells[4].Text = "Tipo";
                e.Row.Cells[5].Text = "Rut Residente";
                e.Row.Cells[0].Width = 80;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow fila = GridView2.SelectedRow;
            //lbl_nombre_lista.Text = fila.Cells[2].Text;

            img_nombre_archivo.ImageUrl = string.Format("~/imgPagos/{0}", fila.Cells[2].Text);
        }







    }

}