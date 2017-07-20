using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCaso14
{
    public partial class Anuncios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos(); 
            if (IsPostBack)
            {
               
            }
        }

        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int idCondominio = servicio.Id_Condominio_desde_rut("CONDOMINIO.ID_CONDOMINIO", auxUserName);

            int lugar_0 = 0;
            int lugar_1 = 1;
            int lugar_2 = 2;
            int lugar_3 = 3;
            int lugar_4 = 4;
            int lugar_5 = 5;

            lbl_detalle_1.Text = servicio.listar_Anuncios(idCondominio, lugar_0);
            lbl_detalle_2.Text = servicio.listar_Anuncios(idCondominio, lugar_1);
            lbl_detalle_3.Text = servicio.listar_Anuncios(idCondominio, lugar_2);

            lbl_detalle_4.Text = servicio.listar_Anuncios(idCondominio, lugar_3);
            lbl_detalle_5.Text = servicio.listar_Anuncios(idCondominio, lugar_4);
            lbl_detalle_6.Text = servicio.listar_Anuncios(idCondominio, lugar_5);
        }
    }
}