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


namespace WebCaso14.Residentes
{
    public partial class LoginResidente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

   

        protected void LoginResidente_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();


            

            /* Utiliza el modelo de autenticación con las credenciales del Web.config*/
            if (servicio.ValidarLogin(LoginR.UserName, LoginR.Password))
            {
                string valor = servicio.CargoEnDirectiva(LoginR.UserName);
                if (valor.Equals("Ninguno"))
                {
                    if (servicio.Residente_Nivel_Acceso(LoginR.UserName) == 1)
                    {
                        FormsAuthentication.RedirectFromLoginPage(LoginR.UserName, LoginR.RememberMeSet);
                        Response.Redirect("Anuncios.aspx"); 
                    }
                }
            }
        }
    }
}
