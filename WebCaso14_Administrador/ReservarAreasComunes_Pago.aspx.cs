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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WebCaso14_Administrador
{
    public partial class ReservarAreasComunes_Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void cargardatos()
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();
            string RutResidente = Session["RutResidente"].ToString();
            string tipoPago = Session["Tipo_Pago"].ToString();
            string total_Pago = Session["Total_Pago"].ToString();
            string id_Pago = Session["Id_Pago"].ToString();
            string descripion = Session["Descripion"].ToString();


            string select1 = "DETALLE_RESERVA.ID_D_R";  // Los ID solo los conosco despues de llamar al procedimiento... tengo que llamarlos desde la base de datos 
            string select2 = "SERVICIO.NOMBRE_SERVICIO"; // este valor lo puedo traer desde la pagina anterior por Session
            string select3 = "DETALLE_RESERVA.COSTO_RESERVA";       // este valor lo puedo traer desde la pagina anterior por Session


            //Met_Ver_Detalle_Reservas(string select, string rutResidente) 


            lbl_total_Pagar.Text = total_Pago;
            lbl_tipo_pago.Text = tipoPago;
            lbl_total_pago_info.Text = total_Pago;

            lbl_id.Text = servicio.Met_Ver_Detalle_Reservas(select1, RutResidente);
            lbl_detalle.Text = servicio.Met_Ver_Detalle_Reservas(select2, RutResidente);
            lbl_costo.Text = servicio.Met_Ver_Detalle_Reservas(select3, RutResidente);

        }


        protected void btn_guardar_cupon_pago_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client servicio = new ServiceReference1.Service1Client();

            string tipoPago = Session["Tipo_Pago"].ToString();
            string total_Pago = Session["Total_Pago"].ToString();
            string id_Pago = Session["Id_Pago"].ToString();
            string descripion = Session["Descripion"].ToString();
            string RutResidente = Session["RutResidente"].ToString();
            string Nombre = servicio.Nombre_desde_LogUser(RutResidente).ToString();

            string select1 = "DETALLE_RESERVA.ID_D_R";  // Los 
            string select2 = "SERVICIO.NOMBRE_SERVICIO"; // est
            string select3 = "DETALLE_RESERVA.COSTO_RESERVA";
            string select1Id = servicio.Met_Ver_Detalle_Reservas(select1, RutResidente);
            string select2Dc = servicio.Met_Ver_Detalle_Reservas(select2, RutResidente);
            string select3Mt = servicio.Met_Ver_Detalle_Reservas(select3, RutResidente);
            string[] select1Ids = select1Id.Split(new string[] { "<br>" }, StringSplitOptions.None);
            string[] select2Dcs = select2Dc.Split(new string[] { "<br>" }, StringSplitOptions.None);
            string[] select3Mts = select3Mt.Split(new string[] { "<br>" }, StringSplitOptions.None);

            Document doc = new Document(PageSize.LETTER);// Creamos el documento con el tamaño de página: carta
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\Sergio\Desktop\Cupon " + tipoPago + ".pdf", FileMode.Create));// Indicamos donde vamos a guardar el documento

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Cupon de Pago");
            doc.AddCreator("Sergio Zapata");

            // Abrimos el archivo
            doc.Open();

            // Estilos para los textos 
            var Color_Verde = new BaseColor(33, 138, 94);
            var Color_Blanco = new BaseColor(255, 255, 255);
            var Color_VerdeAgua = new BaseColor(235, 241, 241);
            iTextSharp.text.Font _estilo_Titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _estilo_Titulo_Italic = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.ITALIC, Color_Verde);
            iTextSharp.text.Font _estilo_Sub_Titulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _estilo_Sub_Titulo_der = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
            iTextSharp.text.Font _standardFont10 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY);
            iTextSharp.text.Font _standardFont12 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Cupon de Pago de " + tipoPago, _estilo_Titulo));
            doc.Add(new Paragraph("Residente " + Nombre, _estilo_Titulo_Italic));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("RUT Comercial: 17.355.434-2", _estilo_Sub_Titulo));
            doc.Add(new Paragraph("GIROS DE ACTIVIDADES EN ASESORAMIENTO COMUNITARIO,", _estilo_Sub_Titulo));
            doc.Add(new Paragraph("GESTION COMERCIAL, SERVICIOS SOCIALES Y PROFESIONALES", _estilo_Sub_Titulo));
            doc.Add(new Paragraph("Sociedad de Condomios S.A.", _estilo_Sub_Titulo));
            doc.Add(new Paragraph("Oficinas Central Alamenda n° 12354", _estilo_Sub_Titulo));
            doc.Add(Chunk.NEWLINE);



            Paragraph p1 = new Paragraph("Detalle de pago emitido", _standardFont10);
            p1.SpacingAfter = Element.CHUNK;
            doc.Add(p1);

            PdfPTable tblPrueba = new PdfPTable(3); // numero de columnas
            tblPrueba.WidthPercentage = 100;
            float[] widths = new float[] { 15, 65, 20 };
            tblPrueba.SetWidths(widths);


            // Configurar el título de las columnas de la tabla
            PdfPCell clLEFT = new PdfPCell(new Phrase("Id", _standardFont12)); clLEFT.BorderColor = Color_Blanco; clLEFT.BorderWidth = 1.5f;
            PdfPCell clCENTER = new PdfPCell(new Phrase("Descripcion", _standardFont12)); clCENTER.BorderColor = Color_Blanco; clCENTER.BorderWidth = 1.5f;
            PdfPCell clRIGHT = new PdfPCell(new Phrase("Monto", _standardFont12)); clRIGHT.BorderColor = Color_Blanco; clRIGHT.BorderWidth = 1.5f;
            //clRIGHT.BorderWidth = 0.5f; clRIGHT.BorderColor = Color_Verde;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clLEFT).BackgroundColor = Color_VerdeAgua;
            tblPrueba.AddCell(clCENTER).BackgroundColor = Color_VerdeAgua;
            tblPrueba.AddCell(clRIGHT).BackgroundColor = Color_VerdeAgua;

            // Llenamos la tabla con información // Añadimos las celdas a la tabla


            for (int i = 0; i < select1Ids.Length; i++)
            {
                tblPrueba.AddCell(new PdfPCell(new Phrase(select1Ids[i], _standardFont10))).BorderWidth = 0;
                tblPrueba.AddCell(new PdfPCell(new Phrase(select2Dcs[i], _standardFont10))).BorderWidth = 0;
                tblPrueba.AddCell(new PdfPCell(new Phrase(select3Mts[i], _standardFont10))).BorderWidth = 0;
            }

           

            doc.Add(tblPrueba);


            doc.Add(Chunk.NEWLINE); // salto de linea 
            Paragraph p = new Paragraph("Total a Pagar $" + total_Pago, _standardFont12);
            p.Alignment = Element.ALIGN_RIGHT;
            doc.Add(p);

            doc.Add(Chunk.NEWLINE); // salto de linea 
            doc.Add(Chunk.NEWLINE); // salto de linea 

            doc.Add(new Paragraph("Fecha / Hora de Emision: " + DateTime.Now.ToString()));
            iTextSharp.text.Image imageQR = iTextSharp.text.Image.GetInstance(Server.MapPath("~/img/qrcode.jpeg"));
            imageQR.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            doc.Add(imageQR);
            doc.Add(new Paragraph("Codigo de Seguridad:"));
            doc.Add(new Paragraph("CA-237867828797080754035877420"));



            doc.Close();
            writer.Close();
        }
    }
}