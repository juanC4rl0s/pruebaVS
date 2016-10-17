using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Windows.Forms;


namespace BLL
{
    public class Correos
    {
        MailMessage correos = new MailMessage();
        SmtpClient envios = new SmtpClient();

        public void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (ruta.Equals("") == false)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(ruta);
                    correos.Attachments.Add(archivo);
                }

                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                //Datos importantes no modificables para tener acceso a las cuentas

                if (emisor.Contains("gmail"))
                {
                    envios.Host = "smtp.gmail.com";
                }
                else if (emisor.Contains("hotmail"))
                {
                    envios.Host = "smtp.live.com";
                }

                //envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                //HttpContext.Current.Response.Write("<script>alert('El mensaje fue enviado correctamente');</script>");
                //MessageBox.Show("El mensaje fue enviado correctamente");
            }
            catch (Exception ex)
            {
                //HttpContext.Current.Response.Write("<script>alert('ha fallado el metodo de generar el documento!');</script>");

                String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\error_enviocorreo.txt";
                String texto = ex.Message + " " + " " + ex.StackTrace + " " + ex.InnerException;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                sw.WriteLine(texto);
                sw.Close();
                //MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}