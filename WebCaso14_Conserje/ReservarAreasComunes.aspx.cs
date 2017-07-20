using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCaso14_Conserje
{
    public partial class ReservarAreasComunes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
        }






        // validaciones dinamicas para cada tramo de los Quinchos
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(1);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 1));
        }
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(1);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 1));
        }
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(1);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 1));
        }

        // validaciones dinamicas para cada tramo de la Multicancha
        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(2);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 2));
        }
        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(2);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 2));
        }
        protected void CustomValidator6_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(2);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 2));
        }

        // validaciones dinamicas para cada tramo del Salon Eventos
        protected void CustomValidator7_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(3);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 3));
        }
        protected void CustomValidator8_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(3);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 3));
        }
        protected void CustomValidator9_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(3);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 3));
        }

        // validaciones dinamicas para cada tramo de los Estacionamientos
        protected void CustomValidator10_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(4);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 4));
        }
        protected void CustomValidator11_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(4);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 4));
        }
        protected void CustomValidator12_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            int capacidad = servicio.M_Capacidad_Servicio_porID(4);
            args.IsValid = Convert.ToInt32(args.Value) <= (capacidad - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 4));
            servicio.Close();
        }



        protected void btn_calcular_costo_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

                int Precio_S1 = servicio.M_Precio_Servicio_porID(1);
                int Precio_S2 = servicio.M_Precio_Servicio_porID(2);
                int Precio_S3 = servicio.M_Precio_Servicio_porID(3);
                int Precio_S4 = servicio.M_Precio_Servicio_porID(4);

                int valor_S1_T1 = Convert.ToInt32(txt_Quincho_T1.Text);
                int valor_S1_T2 = Convert.ToInt32(txt_Quincho_T2.Text);
                int valor_S1_T3 = Convert.ToInt32(txt_Quincho_T3.Text);

                int valor_S2_T1 = Convert.ToInt32(txt_Multicancha_T1.Text);
                int valor_S2_T2 = Convert.ToInt32(txt_Multicancha_T2.Text);
                int valor_S2_T3 = Convert.ToInt32(txt_Multicancha_T3.Text);

                int valor_S3_T1 = Convert.ToInt32(txt_SalonEventos_T1.Text);
                int valor_S3_T2 = Convert.ToInt32(txt_SalonEventos_T2.Text);
                int valor_S3_T3 = Convert.ToInt32(txt_SalonEventos_T3.Text);

                int valor_S4_T1 = Convert.ToInt32(txt_Estacionamientos_T1.Text);
                int valor_S4_T2 = Convert.ToInt32(txt_Estacionamientos_T2.Text);
                int valor_S4_T3 = Convert.ToInt32(txt_Estacionamientos_T3.Text);

                int calculo_S1 = Precio_S1 * (valor_S1_T1 + valor_S1_T2 + valor_S1_T3);
                int calculo_S2 = Precio_S2 * (valor_S2_T1 + valor_S2_T2 + valor_S2_T3);
                int calculo_S3 = Precio_S3 * (valor_S3_T1 + valor_S3_T2 + valor_S3_T3);
                int calculo_S4 = Precio_S4 * (valor_S4_T1 + valor_S4_T2 + valor_S4_T3);

                lbl_Costo_Reserva_S1.Text = String.Format("Costo Quincho: ${0}", (calculo_S1));
                lbl_Costo_Reserva_S2.Text = String.Format("Costo Multicancha: ${0}", (calculo_S2));
                lbl_Costo_Reserva_S3.Text = String.Format("Costo Salon Eventos: ${0}", (calculo_S3));
                lbl_Costo_Reserva_S4.Text = String.Format("Costo Estacionamientos: ${0}", (calculo_S4));
                lbl_Costo_Reserva_ST.Text = String.Format("Total a Pagar: ${0}", (calculo_S1 + calculo_S2 + calculo_S3 + calculo_S4));

                servicio.Close();
            }
            catch (Exception)
            {
                ;
            }
        }




        // validaciones dinamicas para Servicios y Tramos registro de id Reserva y Detalle Reserva
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
                ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
                string rutResidente = txt_rutReserva.Text;
                string rutFuncionario = System.Web.HttpContext.Current.User.Identity.Name;

                int capacidad1 = servicio.M_Capacidad_Servicio_porID(1);
                int capacidad2 = servicio.M_Capacidad_Servicio_porID(2);
                int capacidad3 = servicio.M_Capacidad_Servicio_porID(3);
                int capacidad4 = servicio.M_Capacidad_Servicio_porID(4);

                int valor_S1_T1 = Convert.ToInt32(txt_Quincho_T1.Text);
                int valor_S1_T2 = Convert.ToInt32(txt_Quincho_T2.Text);
                int valor_S1_T3 = Convert.ToInt32(txt_Quincho_T3.Text);

                int valor_S2_T1 = Convert.ToInt32(txt_Multicancha_T1.Text);
                int valor_S2_T2 = Convert.ToInt32(txt_Multicancha_T2.Text);
                int valor_S2_T3 = Convert.ToInt32(txt_Multicancha_T3.Text);

                int valor_S3_T1 = Convert.ToInt32(txt_SalonEventos_T1.Text);
                int valor_S3_T2 = Convert.ToInt32(txt_SalonEventos_T2.Text);
                int valor_S3_T3 = Convert.ToInt32(txt_SalonEventos_T3.Text);

                int valor_S4_T1 = Convert.ToInt32(txt_Estacionamientos_T1.Text);
                int valor_S4_T2 = Convert.ToInt32(txt_Estacionamientos_T2.Text);
                int valor_S4_T3 = Convert.ToInt32(txt_Estacionamientos_T3.Text);


                int UsoDeTramo_S1_T1 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 1));
                int UsoDeTramo_S1_T2 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 1));
                int UsoDeTramo_S1_T3 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 1));

                int UsoDeTramo_S2_T1 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 2));
                int UsoDeTramo_S2_T2 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 2));
                int UsoDeTramo_S2_T3 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 2));

                int UsoDeTramo_S3_T1 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 3));
                int UsoDeTramo_S3_T2 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 3));
                int UsoDeTramo_S3_T3 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 3));

                int UsoDeTramo_S4_T1 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 4));
                int UsoDeTramo_S4_T2 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 4));
                int UsoDeTramo_S4_T3 = Convert.ToInt32(servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 4));


                int calculo_S1 = (valor_S1_T1 + valor_S1_T2 + valor_S1_T3);
                int calculo_S2 = (valor_S2_T1 + valor_S2_T2 + valor_S2_T3);
                int calculo_S3 = (valor_S3_T1 + valor_S3_T2 + valor_S3_T3);
                int calculo_S4 = (valor_S4_T1 + valor_S4_T2 + valor_S4_T3);


                if (valor_S1_T1 <= (capacidad1 - UsoDeTramo_S1_T1) &&
                    valor_S1_T2 <= (capacidad1 - UsoDeTramo_S1_T2) &&
                    valor_S1_T3 <= (capacidad1 - UsoDeTramo_S1_T3) &&

                    valor_S2_T1 <= (capacidad2 - UsoDeTramo_S2_T1) &&
                    valor_S2_T2 <= (capacidad2 - UsoDeTramo_S2_T2) &&
                    valor_S2_T3 <= (capacidad2 - UsoDeTramo_S2_T3) &&

                    valor_S3_T1 <= (capacidad3 - UsoDeTramo_S3_T1) &&
                    valor_S3_T2 <= (capacidad3 - UsoDeTramo_S3_T2) &&
                    valor_S3_T3 <= (capacidad3 - UsoDeTramo_S3_T3) &&

                    valor_S4_T1 <= (capacidad4 - UsoDeTramo_S1_T1) &&
                    valor_S4_T2 <= (capacidad4 - UsoDeTramo_S1_T2) &&
                    valor_S4_T3 <= (capacidad4 - UsoDeTramo_S1_T3)
                    )
                {
                    if (servicio.ValidarRut(rutResidente) == true)
                    {
                        servicio.SP_Crear_Reserva_Residente_Desde_Funcionario(rutResidente, rutFuncionario);

                        if (calculo_S1 > 0) { servicio.SP_Crear_Detalle_Reserva(1, valor_S1_T1, valor_S1_T2, valor_S1_T3, fecha, rutResidente); }
                        if (calculo_S2 > 0) { servicio.SP_Crear_Detalle_Reserva(2, valor_S2_T1, valor_S2_T2, valor_S2_T3, fecha, rutResidente); }
                        if (calculo_S3 > 0) { servicio.SP_Crear_Detalle_Reserva(3, valor_S3_T1, valor_S3_T2, valor_S3_T3, fecha, rutResidente); }
                        if (calculo_S4 > 0) { servicio.SP_Crear_Detalle_Reserva(4, valor_S4_T1, valor_S4_T2, valor_S4_T3, fecha, rutResidente); }

                        if ((calculo_S1) >= 1 || (calculo_S2) >= 1 || (calculo_S3) >= 1 || (calculo_S4) >= 1)
                        {

                            int s1 = (calculo_S1 * servicio.M_Precio_Servicio_porID(1));
                            int s2 = (calculo_S2 * servicio.M_Precio_Servicio_porID(2));
                            int s3 = (calculo_S3 * servicio.M_Precio_Servicio_porID(3));
                            int s4 = (calculo_S4 * servicio.M_Precio_Servicio_porID(4));
                            int s5 = s1 + s2 + s3 + s4;



                            Session["Id_Pago"] = "1234";
                            Session["Tipo_Pago"] = "Reserva";
                            Session["Total_Pago"] = s5.ToString();
                            Session["Descripion"] = s5.ToString();
                            Session["RutResidente"] = txt_rutReserva.Text;
                            Server.Transfer("~/ReservarAreasComunes_Pago.aspx?");  // dentro del mismo servidor works ok
                        }
                    }
                }
                lbl_RutValidar.Text = "Rut No Existe en los registros del Condominio, No se pueden registrar las reservas ";
                servicio.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string HolaMundo()
        {
            var X = "HolaMundo y Sus Planetas Cercanos";
            return X;

        }

        public String CurrentCity
        {
            get
            {
                return txt_Quincho_T1.Text;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string fecha = String.Format("{0:dd'/'MM'/'yyyy}", Calendar1.SelectedDate);
            //Fecha = String.Format("{0: dd' de 'MMMM' del 'yyyy '_' }", item.FECHA),
            Resultado_1.Text = string.Format("Fecha Seleccionada: {0}", fecha);


            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            //string fecha, int tramo, int servicio

            int capacidad_Quincho = servicio.M_Capacidad_Servicio_porID(1);
            lbl_Quincho_T1.Text = String.Format("{0} de {1} disponble", (capacidad_Quincho - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 1)), capacidad_Quincho);
            lbl_Quincho_T2.Text = String.Format("{0} de {1} disponble", (capacidad_Quincho - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 1)), capacidad_Quincho);
            lbl_Quincho_T3.Text = String.Format("{0} de {1} disponble", (capacidad_Quincho - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 1)), capacidad_Quincho);

            int capacidad_Multicancha = servicio.M_Capacidad_Servicio_porID(2);
            lbl_Multicancha_T1.Text = String.Format("{0} de {1} disponble", (capacidad_Multicancha - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 2)), capacidad_Multicancha);
            lbl_Multicancha_T2.Text = String.Format("{0} de {1} disponble", (capacidad_Multicancha - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 2)), capacidad_Multicancha);
            lbl_Multicancha_T3.Text = String.Format("{0} de {1} disponble", (capacidad_Multicancha - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 2)), capacidad_Multicancha);

            int capacidad_SalonEventos = servicio.M_Capacidad_Servicio_porID(3);
            lbl_SalonEventos_T1.Text = String.Format("{0} de {1} disponble", (capacidad_SalonEventos - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 3)), capacidad_SalonEventos);
            lbl_SalonEventos_T2.Text = String.Format("{0} de {1} disponble", (capacidad_SalonEventos - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 3)), capacidad_SalonEventos);
            lbl_SalonEventos_T3.Text = String.Format("{0} de {1} disponble", (capacidad_SalonEventos - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 3)), capacidad_SalonEventos);

            int capacidad_Estacionamientos = servicio.M_Capacidad_Servicio_porID(4);
            lbl_Estacionamientos_T1.Text = String.Format("{0} de {1} disponble", (capacidad_Estacionamientos - servicio.UsoDeTramoSegunFechayServicio(fecha, 1, 4)), capacidad_Estacionamientos);
            lbl_Estacionamientos_T2.Text = String.Format("{0} de {1} disponble", (capacidad_Estacionamientos - servicio.UsoDeTramoSegunFechayServicio(fecha, 2, 4)), capacidad_Estacionamientos);
            lbl_Estacionamientos_T3.Text = String.Format("{0} de {1} disponble", (capacidad_Estacionamientos - servicio.UsoDeTramoSegunFechayServicio(fecha, 3, 4)), capacidad_Estacionamientos);

            servicio.Close();
        }

        protected void btn_validarRut_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();


            string rut = txt_rutReserva.Text;

            if (servicio.ValidarRut(rut) == true)
            {
                lbl_RutValidar.Text = "Rut Valido Puede ingresar Reserva";
            }
            if (servicio.ValidarRut(rut) == false)
            {
                lbl_RutValidar.Text = "Rut No Existe en los registros del Condominio";
            }
        }



    }
}