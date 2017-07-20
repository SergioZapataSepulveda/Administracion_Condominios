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

namespace WebCaso14
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
            lblDato.Text = servicio.Nombre_desde_LogUser(auxUserName).ToString();

            string aux = servicio.CargoEnDirectiva(auxUserName).ToString();
            if (aux.Equals("Ninguno"))
	        {
                lblDatoNombreDirectiva.Text = "Residente Condominio";
	        }


            if (servicio.GenerarAlertasMora(auxUserName) == 0)
            {
                lbl_alertas.Text = "";
            }
            if (servicio.GenerarAlertasMora(auxUserName) == 1)
            {
                lbl_alertas.Text = "<b style='background-color: Red; padding: 5px; color:White'>Alerta :: Tiene 1 Cuota Morosa</b>";
            }
            if (servicio.GenerarAlertasMora(auxUserName) > 1)
            {
                lbl_alertas.Text = "<b style='background-color: Red; padding: 5px; color:White'>Alerta :: Tiene " + servicio.GenerarAlertasMora(auxUserName) + " Cuotas Morosas</b>";
            }
            
            if (servicio.GenerarAlertasMulta(auxUserName) == 0)
            {
                lbl_multas.Text = "";
            }
            if (servicio.GenerarAlertasMulta(auxUserName) == 1)
            {
                lbl_multas.Text = "<b style='background-color: Red; padding: 5px; color:White'>Alerta :: Tiene 1 Multa Activa</b>";
            }
            if (servicio.GenerarAlertasMulta(auxUserName) > 1)
            {
                lbl_multas.Text = "<b style='background-color: Red; padding: 5px; color:White'>Alerta :: Tiene " + servicio.GenerarAlertasMulta(auxUserName) + " Multas Activas</b>";
            }
           

                
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {

        }
    }
}