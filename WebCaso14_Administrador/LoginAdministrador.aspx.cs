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

namespace WebCaso14_Administrador
{
    public partial class LoginAdministrador : System.Web.UI.Page
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
            if (servicio.ValidarLoginFuncionario(Login1.UserName, Login1.Password))
            {
                string valor = servicio.CargoEnCondominio(Login1.UserName);
                if (valor.Equals("Administrador"))
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                    Response.Redirect("GastosComunes.aspx");
                }
            }

            servicio.Close();
        }
    }

}