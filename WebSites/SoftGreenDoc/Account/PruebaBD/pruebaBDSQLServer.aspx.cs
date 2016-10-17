using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftGreenDoc;
using SQLCLASS;
using BLL;

public partial class Account_PruebaBD_pruebaBDSQLServer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        decimal idregistrado = PERSONASCER.PERSONASCERRegistrar(0,"1095808196", "gabriel", "ortega", DateTime.Now, "gabo25_12@hotmail.com", "6381746",
            "300777777", "per", "soltero", 0, DateTime.Now, 0, DateTime.Now, "EMPLEADO","ADMINISTRACION", "CONTROL", "2000000", "SI");
        GeneradorPdf.generarCertificado("1095808196", "", "PRUEBA1.docx", "PLANTILLACERTIFICACION.docx", "CERTIFICADO", 0);
    }
}