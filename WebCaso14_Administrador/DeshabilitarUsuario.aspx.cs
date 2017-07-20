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
    public partial class DeshabilitarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
            }
        }




        protected void btn_SP_Deshabilitar_Residente_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

                string Rut_Deshabilitar = txt_Rut_Deshabilitar.Text;

                if (servicio.ValidarRut(Rut_Deshabilitar) == true)
                {
                    lbl_estado_Deshabilitar.Text = servicio.SP_Deshabilitar_Residente(Rut_Deshabilitar);
                }
                if (servicio.ValidarRut(Rut_Deshabilitar) == false)
                {
                    lbl_estado_Deshabilitar.Text = "Rut No Existe en los registros del Condominio";
                }
            }
            catch (Exception)
            {
                lbl_estado_Deshabilitar.Text = "Rut No Existe en los registros del Condominio";
            }
        }

        protected void btn_SP_Habilitar_Residente_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

                string Rut_Habilitar = txt_Rut_Habilitar.Text;

                if (servicio.ValidarRut(Rut_Habilitar) == true)
                {
                    lbl_estado_Habilitar.Text = servicio.SP_Habilitar_Residente(Rut_Habilitar);
                }
                if (servicio.ValidarRut(Rut_Habilitar) == false)
                {
                    lbl_estado_Habilitar.Text = "Rut No Existe en los registros del Condominio";
                }
            }
            catch (Exception)
            {
                lbl_estado_Habilitar.Text = "Rut No Existe en los registros del Condominio";
            }
        }







    }
}