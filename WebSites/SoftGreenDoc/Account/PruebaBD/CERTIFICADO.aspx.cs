using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.OleDb;
using System.Runtime.Serialization;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media;
using System.ServiceModel;
using System.Threading;
using System.Net.Sockets;
using System.Security.Cryptography;
using SoftGreenDoc;
using SQLCLASS;
using BLL;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using SDC = Spire.Doc;
using OfficeOpenXml;
using Spire.Pdf;
using Spire.Pdf.Graphics;

public partial class CERTIFICADO : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void CreateUser_Click(object sender, EventArgs e)
    {
        List<DCPERSONASCER> lstPERSONASCER = new List<DCPERSONASCER>();
        //DataTable DTPERSONASCER = new DataTable();
        //DTPERSONASCER = PERSONASCER.PERSONASCERObtenerbyCriterio(txtIdentificacion.Text, 0);
        lstPERSONASCER = PERSONASCER.PERSONASCERObtenerbyCriterio(txtIdentificacion.Text, 0);

        if (lstPERSONASCER.Count > 0)
        {
            //mensajeBUG("" + obtenerFecha(txtFechaDeExpedicion.Text).ToString()+" =="+obtenerFecha(DTPERSONASCER.Rows[0]["FECHANACIMIENTO"].ToString()).ToString()+" &&" +DTPERSONASCER.Rows[0]["EMAIL"].ToString()+"=="+ txtEmai.Text,"1");
          
            DateTime fechaconsulta = Convert.ToDateTime(lstPERSONASCER[0].FECHANACIMIENTO);
            DateTime fechaconsultaformateada = new DateTime(fechaconsulta.Year, fechaconsulta.Month, fechaconsulta.Day);

            DateTime fechacalendar = Convert.ToDateTime(txtFechaDeExpedicion.Text);
            DateTime fechacalendarformateada = new DateTime(fechacalendar.Year, fechacalendar.Month, fechacalendar.Day);

            mensajeBUG("FECHA1BASE" + fechaconsultaformateada + " FECHA2CALENDAR" + fechacalendarformateada, "2comparaciondefechas");

            if (fechaconsultaformateada == fechacalendarformateada && lstPERSONASCER[0].EMAIL.ToString().Equals(txtEmai.Text))
                //if (Convert.ToDateTime(txtFechaDeExpedicion.Text) == Convert.ToDateTime(DTPERSONASCER.Rows[0]["FECHANACIMIENTO"]) && DTPERSONASCER.Rows[0]["EMAIL"].ToString() == txtEmai.Text)            
            {
                String nombresinencriptar = DateTime.Now.Millisecond.ToString() +
                    DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() +
                    DateTime.Now.ToString() + txtNombres.Text;

                String nuevonombre = Encriptar(nombresinencriptar) + ".docx";
                String nuevonombrepdf = Encriptar(nombresinencriptar) + ".pdf";
                mensajeBUG("pdf" + nuevonombrepdf, "3encriptacion");
                GeneradorPdf.generarCertificado(txtIdentificacion.Text, "SI", nuevonombre, "PLANTILLACERTIFICACION.docx", "CERTIFICADO", 0);
                mensajeBUG("ok generacion", "4generado");
                String url = ConfigurationManager.AppSettings["Rutaserver"] + ConfigurationManager.AppSettings["RutaDescargas"] + nuevonombrepdf;
                Uri pruebapdfuri = new Uri(url);
                mensajeBUG("url", "5url");
                HttpContext.Current.Response.Write("<script>window.open ('" + pruebapdfuri + "','" + pruebapdfuri + "')</script>");
                mensajeBUG("urlventana", "6urlventana");

                HttpContext.Current.Response.Write("<script>alert('Se ha generado el Certificado satisfactoriamente y fue enviado a su correo!');</script>");
                //MessageBox.Show("Se ha generado el Certificado satisfactoriamente!");
             
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Los valores no concuerdan!');</script>");
                //MessageBox.Show("Los valores no concuerdan!");
            }
        }
        else
        {

        }
    }

    public void mensajeBUG( string texto, string nombre)
    {
        String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\" + nombre + ".txt";
        //String NobredelDocumentoError = @"c:\\tmp\\" + nombre + ".txt";
        System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
        sw.WriteLine(texto);
        sw.Close();
    }

    public DateTime obtenerFecha(String fecha)
    {
        string[] datos = fecha.Split('/');
        int dia = Convert.ToInt32 (datos[0]);
        int mes = Convert.ToInt32(datos[1]);
        int anio = Convert.ToInt32(datos[2].Substring(0,4));
        return new DateTime(anio,mes,dia);
    }

    public static string Encriptar(string str)
    {
        
        MD5 md5 = MD5CryptoServiceProvider.Create();
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] stream = null;
        StringBuilder sb = new StringBuilder();
        stream = md5.ComputeHash(encoding.GetBytes(str));
        for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
        return sb.ToString();
    }

}