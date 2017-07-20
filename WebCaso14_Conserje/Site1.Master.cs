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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            lblDato.Text = servicio.Nombre_desde_LogUser_Funcionario(auxUserName).ToString();

            string aux = servicio.CargoEnCondominio(auxUserName).ToString();
            if (aux.Equals("Conserje"))
            {
                lblDatoNombreDirectiva.Text = "Conserje Condominio";
            }
        }





        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {

        }
    }
}