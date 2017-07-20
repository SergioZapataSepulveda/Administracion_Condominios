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
    public partial class IngresarNuevoResidente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItemCollection llenarDDL_tipo = new ListItemCollection();
                llenarDDL_tipo.Add("Propietario no Directivo");
                llenarDDL_tipo.Add("Arrendatario no Directivo");
                llenarDDL_tipo.Add("Propietario Directivo");
                llenarDDL_tipo.Add("Arrendatario Directivo");
                ddl_ID_TIPO_RESIDENTE.DataSource = llenarDDL_tipo;
                ddl_ID_TIPO_RESIDENTE.DataBind();
            }
        }




 
        protected void btn_Ingresar_residente_Click1(object sender, EventArgs e)
        {
            try
            {
                lbl_estado_rectificacion.Text = string.Empty; 

                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

                string Rut_Residente = txt_Rut_Residente.Text;
                string Pass_Residente = txt_Pass_Residente.Text;
                string Nombre_Residente = txt_Nombre_Residente.Text;
                string Direccion = txt_Direccion.Text;
                string Correo = txt_Correo.Text;
                int id_Tipo_Residente = ddl_ID_TIPO_RESIDENTE.SelectedIndex + 1;

                lbl_estado_rectificacion.Text = servicio.SP_Crear_Residentes(Rut_Residente, Pass_Residente, Nombre_Residente, Direccion, Correo, id_Tipo_Residente);

                txt_Rut_Residente.Text =string.Empty;
                txt_Pass_Residente.Text =string.Empty;
                txt_Nombre_Residente.Text =string.Empty;
                txt_Direccion.Text =string.Empty;
                txt_Correo.Text = string.Empty;

            }
            catch (Exception)
            {
                lbl_estado_rectificacion.Text = "Complete todos los campos con datos reales";
            }
        }


       

       

        





    }
}