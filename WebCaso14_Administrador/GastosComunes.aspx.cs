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
using System.Web.Mail;
using System.Net.Mail;
using System.Net;

namespace WebCaso14_Administrador
{
    public partial class GastosComunes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDatos();
            if (!IsPostBack)
            {
                for (int mes = DateTime.MinValue.Month; mes < DateTime.MaxValue.Month; mes++)
                {
                    ListItem lstmes = new ListItem();
                    string[] mesinyear = { "seleccione", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
                    lstmes.Value = mes.ToString();
                    lstmes.Text = mesinyear[mes];
                    ddl_mes.Items.Add(lstmes);
                    ddl_mes.DataBind();
                    ddl_mes.SelectedIndex = 5;
                }
                for (int i = DateTime.Now.Year - 7; i <= (DateTime.Now.Year + 1); i++)
                {
                    ListItem lst = new ListItem();
                    lst.Value = i.ToString();
                    lst.Text = i.ToString();
                    ddl_anio.Items.Add(lst);
                    ddl_anio.DataBind();
                    ddl_anio.SelectedIndex = 7;
                }

                ListItemCollection llenarDDL_tipo = new ListItemCollection();
                llenarDDL_tipo.Add("Egreso");
                llenarDDL_tipo.Add("Ingreso");
                ddlTipo.DataSource = llenarDDL_tipo;
                ddlTipo2.DataSource = llenarDDL_tipo;
                ddlTipo.DataBind();
                ddlTipo2.DataBind();




                ListItemCollection llenarDDL_Categoria = new ListItemCollection();
                llenarDDL_Categoria.Add("Mantencion");
                llenarDDL_Categoria.Add("Sueldos");
                llenarDDL_Categoria.Add("Servicios");
                llenarDDL_Categoria.Add("Otros");
                llenarDDL_Categoria.Add("Recaudacion");
                ddl_Categoria.DataSource = llenarDDL_Categoria;
                ddl_Categoria2.DataSource = llenarDDL_Categoria;
                ddl_Categoria.DataBind();
                ddl_Categoria2.DataBind();

            }


        }


        // cargar datos automaticamente para el mes dado en la variables 
        private void CargarDatos()
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;


                int var1 = servicio.id_Condominio_desde_Funcionario(auxUserName);
                int var2 = 06;
                int var3 = 2017;

                lbl_Mantencion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Mantencion");
                lbl_Mantencion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Mantencion");
                lbl_Mantencion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Mantencion");
                lbl_Mantencion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Mantencion");

                lbl_Sueldos_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Sueldos");
                lbl_Sueldos_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Sueldos");
                lbl_Sueldos_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Sueldos");
                lbl_Sueldos_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Sueldos");

                lbl_Servicios_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Servicios");
                lbl_Servicios_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Servicios");
                lbl_Servicios_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Servicios");
                lbl_Servicios_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Servicios");

                lbl_Otros_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Otros");
                lbl_Otros_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Otros");
                lbl_Otros_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Otros");
                lbl_Otros_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Otros");

                lbl_Recaudacion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Recaudacion");
                lbl_Recaudacion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Recaudacion");
                lbl_Recaudacion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Recaudacion");
                lbl_Recaudacion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Recaudacion");


                var totalEgreso = servicio.Calcular_Total_Mensual_Registros_GC(var1, var2, var3, "Egreso");
                var totalIngreso = servicio.Calcular_Total_Mensual_Registros_GC(var1, var2, var3, "Ingreso");
                lbl_total.Text = (Convert.ToInt32(totalEgreso) - Convert.ToInt32(totalIngreso)).ToString();

                servicio.Close();
            }
            catch (Exception)
            {
                Response.Redirect("GastosComunes.aspx");
            }
        }




        // cargar datos para el mes dado en la variables seleccionado en segun los campos mes y año 
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;


                int var1 = servicio.id_Condominio_desde_Funcionario(auxUserName);
                int var2 = Convert.ToInt32(ddl_mes.SelectedValue);
                int var3 = Convert.ToInt32(ddl_anio.SelectedValue);

                lbl_Mantencion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Mantencion");
                lbl_Mantencion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Mantencion");
                lbl_Mantencion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Mantencion");
                lbl_Mantencion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Mantencion");

                lbl_Sueldos_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Sueldos");
                lbl_Sueldos_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Sueldos");
                lbl_Sueldos_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Sueldos");
                lbl_Sueldos_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Sueldos");

                lbl_Servicios_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Servicios");
                lbl_Servicios_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Servicios");
                lbl_Servicios_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Servicios");
                lbl_Servicios_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Servicios");

                lbl_Otros_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Otros");
                lbl_Otros_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Otros");
                lbl_Otros_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Otros");
                lbl_Otros_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Otros");

                lbl_Recaudacion_id.Text = servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Recaudacion");
                lbl_Recaudacion_Detalle.Text = servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Recaudacion");
                lbl_Recaudacion_Monto.Text = servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Recaudacion");
                lbl_Recaudacion_Observacion.Text = servicio.listar_Registros_GC_Mensuales("Observaciones", 1, var2, var3, "Recaudacion");


                var totalEgreso = servicio.Calcular_Total_Mensual_Registros_GC(var1, var2, var3, "Egreso");
                var totalIngreso = servicio.Calcular_Total_Mensual_Registros_GC(var1, var2, var3, "Ingreso");
                lbl_total.Text = (Convert.ToInt32(totalEgreso) - Convert.ToInt32(totalIngreso)).ToString();

                servicio.Close();
            }
            catch (Exception)
            {
                Response.Redirect("GastosComunes.aspx");
            }
        }

        protected void Crear_Registro_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;

                string var1 = ddlTipo.SelectedValue.ToString();
                string var2 = ddl_Categoria.SelectedValue.ToString();
                string var3 = txt_Descripcion.Text.ToString();
                int var4 = Convert.ToInt32(txt_Monto.Text);
                int var5 = servicio.id_Condominio_desde_Funcionario(auxUserName);

                if (txt_Descripcion.Text.Length >= 3 && txt_Monto.Text.Length >= 3)
                {
                    lbl_crear_registro.Text = servicio.SP_Crear_Ingreso_Gasto_Comun(var1, var2, var3, var4, var5);
                    txt_Descripcion.Text = string.Empty;
                    txt_Monto.Text = string.Empty;

                    Response.Redirect("GastosComunes.aspx");
                }
                servicio.Close();
            }
            catch (Exception)
            {
                lbl_crear_registro.Text = "* Complete todos los datos";
            }
        }


        // Opcion desactivada al dar sobre atribuciones al administrador 
        protected void Modificar_Registro_Click(object sender, EventArgs e)
        {

            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;

                string var1 = ddlTipo2.SelectedValue.ToString();
                string var2 = ddl_Categoria2.SelectedValue.ToString();
                string var3 = txt_Descripcion_2.Text.ToString();
                int var4 = Convert.ToInt32(txt_monto_2.Text);
                int var5 = Convert.ToInt32(txt_id_a_Modificar.Text);


                if (txt_Descripcion_2.Text.Length >= 3 && txt_monto_2.Text.Length >= 3 && txt_id_a_Modificar.Text.Length >= 1)
                {
                    lbl_actualizar_registro.Text = servicio.SP_Modificar_Ingreso_Gasto_Comun(var5, var1, var2, var3, var4);
                    txt_Descripcion.Text = string.Empty;
                    txt_Monto.Text = string.Empty;
                    txt_id_a_Modificar.Text = string.Empty;

                    Response.Redirect("GastosComunes.aspx");
                }
                servicio.Close();
            }
            catch (Exception)
            {
                lbl_actualizar_registro.Text = "* Complete todos los datos";
            }
            
        }

        protected void btn_Crear_Cuota_Proximo_Mes_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int id_condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);
            var estado = servicio.SP_Crear_Cuota_Gasto_Comun(id_condominio);
            lbl_estado_cuota_proximo_mes.Text = estado.ToString(); 
        }

        protected void btn_Actualizar_Cuota_Proximo_Mes_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;
            int id_condominio = servicio.id_Condominio_desde_Funcionario(auxUserName);
            var estado = servicio.SP_Actualizar_Cuota_G_C(id_condominio);
            lbl_estado_cuota_proximo_mes.Text = estado.ToString(); 
        }





        protected void btn_Notificacion_Correo_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string auxUserName = System.Web.HttpContext.Current.User.Identity.Name;

                int var1 = servicio.id_Condominio_desde_Funcionario(auxUserName);
                int var2 = 06;
                int var3 = 2017;
               
                string smtpAddress = "smtp-mail.outlook.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFrom = "sociedad.condomios.s.a@outlook.com"; //servicio.CorreoCondominio_desde_Funcionario(auxUserName)
                string password = "S8)Ods/S(76";           //servicio.PassCorreoCondominio_desde_Funcionario(auxUserName)

                string correosPara = "ser.zapata@alumnos.duoc.cl, xxx@alumnos.duoc.cl";
                string asunto = "Detalle Gastos Comunes";
                lbl_Lista_Correos.Text = "Listado de Correos con Notificacion GC: <br>" + servicio.listar_Correos_Residentes(var1);

                var totalEgreso = servicio.Calcular_Total_Mensual_Registros_GC(var1, var2, var3, "Egreso");
                var totalIngreso = servicio.Calcular_Total_Mensual_Registros_GC(var1, var2, var3, "Ingreso");
                string totalMes = (Convert.ToInt32(totalEgreso) - Convert.ToInt32(totalIngreso)).ToString();

                string body = "<div style='border: 1px; width: 500px; font-family: arial,sans-serif; font-size: 11px; color: #000'>";
                body += "<h3 style='background-color: #1c7793; color: #ffffff; margin-top:0px; padding: 5px;'>Gastos Comunes " + (String.Format("{0:MMMM' 'yyyy }", DateTime.Today.AddMonths(1))) + "</h3>";
                body += "<br/>";
                body += "<br/>";
                body += "<b>Mantencion</b><br/><table style='color: #000000'><tr><td style='width: 50px;'>";
                body += "<b>Id</b><br/>" + servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Mantencion");
                body += "</td><td style='width: 250px;'>";
                body += "<b>Descripcion</b><br/>" + servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Mantencion");
                body += "</td><td style='width: 100px;'>";
                body += "<b>Monto</b><br/>" + servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Mantencion");
                body += "</td></tr></table><br />";

                body += "<b>Sueldos</b><br/><table style='color: #000000'><tr><td style='width: 50px;'>";
                body += "<b>Id</b><br/>" + servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Sueldos");
                body += "</td><td style='width: 250px;'>";
                body += "<b>Descripcion</b><br/>" + servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Sueldos");
                body += "</td><td style='width: 100px;'>";
                body += "<b>Monto</b><br/>" + servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Sueldos");
                body += "</td></tr></table><br />";

                body += "<b>Servicios</b><br/><table style='color: #000000'><tr><td style='width: 50px;'>";
                body += "<b>Id</b><br/>" + servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Servicios");
                body += "</td><td style='width: 250px;'>";
                body += "<b>Descripcion</b><br/>" + servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Servicios");
                body += "</td><td style='width: 100px;'>";
                body += "<b>Monto</b><br/>" + servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Servicios");
                body += "</td></tr></table><br />";

                body += "<b>Otros</b><br/><table style='color: #000000'><tr><td style='width: 50px;'>";
                body += "<b>Id</b><br/>" + servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Otros");
                body += "</td><td style='width: 250px;'>";
                body += "<b>Descripcion</b><br/>" + servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Otros");
                body += "</td><td style='width: 100px;'>";
                body += "<b>Monto</b><br/>" + servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Otros");
                body += "</td></tr></table><br />";

                body += "<b>Recaudacion</b><br/><table style='color: #000000'><tr><td style='width: 50px;'>";
                body += "<b>Id</b><br/>" + servicio.listar_Registros_GC_Mensuales("ID_ADMISTRACION", var1, var2, var3, "Recaudacion");
                body += "</td><td style='width: 250px;'>";
                body += "<b>Descripcion</b><br/>" + servicio.listar_Registros_GC_Mensuales("DESCRIPCION", var1, var2, var3, "Recaudacion");
                body += "</td><td style='width: 100px;'>";
                body += "<b>Monto</b><br/>" + servicio.listar_Registros_GC_Mensuales("MONTO", 1, var2, var3, "Recaudacion");
                body += "</td></tr></table><br />";

                body += "Total a Prorratear entre todos los Residentes: <b>$" + totalMes + "</b>";
                body += "<br />";
                body += "<b>Saluda atentamente la Administracion.</b>";
                body += "</div>";

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(correosPara);
                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
            catch (Exception)
            {
                lbl_Lista_Correos.Text= "Servidor de correos en mantencion Programada, vuelva a intentarlo en unos minutos ";
            }
        }


























        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3; 
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3; 
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3;
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 3;
        }
        
        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Length >= 1;
        }

        

       

        
    }
}