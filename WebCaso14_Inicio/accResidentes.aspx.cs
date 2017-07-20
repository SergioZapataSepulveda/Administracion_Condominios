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


namespace WebCaso14_Inicio
{
    public partial class accResidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void LoginAccRes_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

            


            /* Utiliza el modelo de autenticación con las credenciales del Web.config*/
            if (servicio.ValidarLogin(LoginAccRes.UserName, LoginAccRes.Password))
            {
                string valor = servicio.CargoEnDirectiva(LoginAccRes.UserName);
                if (valor.Equals("Directivo"))
                {
                    FormsAuthentication.RedirectFromLoginPage(LoginAccRes.UserName, LoginAccRes.RememberMeSet);
                    Response.Redirect("http://localhost:17502/InformacionResidente.aspx");
                }
                if (valor.Equals("Ninguno"))
                {
                    if (servicio.Residente_Nivel_Acceso(LoginAccRes.UserName) == 1)
                    {
                        FormsAuthentication.RedirectFromLoginPage(LoginAccRes.UserName, LoginAccRes.RememberMeSet);
                        Response.Redirect("http://localhost:17501/ConsultarGastosComunes.aspx");
                    }
                }
            }
        }
    }
}



