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
    public partial class accFuncionarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void LoginAccFun_Authenticate(object sender, AuthenticateEventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();




            /* Utiliza el modelo de autenticación con las credenciales del Web.config*/
            if (servicio.ValidarLoginFuncionario(LoginAccFun.UserName, LoginAccFun.Password))
            {
                string valor = servicio.CargoEnCondominio(LoginAccFun.UserName).ToString();
                lblDato.Text = servicio.Nombre_desde_LogUser_Funcionario(LoginAccFun.UserName).ToString();
                if (valor.Equals("Administrador"))
                {
                    FormsAuthentication.RedirectFromLoginPage(LoginAccFun.UserName, LoginAccFun.RememberMeSet);
                    Response.Redirect("http://localhost:17504/InformacionResidentes.aspx");
                }
                if (valor.Equals("Conserje"))
                {
                    FormsAuthentication.RedirectFromLoginPage(LoginAccFun.UserName, LoginAccFun.RememberMeSet);
                    Response.Redirect("http://localhost:17503/InformacionResidente.aspx");
                }


            }
        }
    }
}

