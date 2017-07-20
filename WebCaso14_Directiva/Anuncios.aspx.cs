using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCaso14_Directiva
{
    public partial class Anuncios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int idCondominio = servicio.Id_Condominio_desde_rut("CONDOMINIO.ID_CONDOMINIO", auxUserName);

            lbl_detalle_Anuncio.Text = servicio.listar_Anuncios(idCondominio, 0);

            servicio.Close();
        }

        protected void btn_Crear_Anuncio_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
                int idCondominio = servicio.Id_Condominio_desde_rut("CONDOMINIO.ID_CONDOMINIO", auxUserName);


                string titulo = txt_Titulo.Text;
                string descripcion = txt_Descripcion.Text;


                lbl_estado.Text = servicio.SP_Crear_Anuncios(titulo, descripcion, idCondominio);

                lbl_detalle_Anuncio.Text = servicio.listar_Anuncios(idCondominio, 0);

                txt_Titulo.Text = string.Empty;
                txt_Descripcion.Text = string.Empty;

                servicio.Close();
            }
            catch (Exception)
            {
                lbl_estado.Text = "Largo Maximo de Caracteres para titulo sobrepasado";
            }
        }
    }
}


