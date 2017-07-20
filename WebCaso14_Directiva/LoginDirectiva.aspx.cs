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

namespace WebCaso14_Directiva
{
    public partial class LoginDirectiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

            /* Utiliza el modelo de autenticación con las credenciales del Web.config*/
            if (servicio.ValidarLogin(Login1.UserName, Login1.Password))
            {
                string valor = servicio.CargoEnDirectiva(Login1.UserName);
                if (valor.Equals("Directivo"))
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                    Response.Redirect("InformacionResidente.aspx");
                }
            }
        }
    }

}