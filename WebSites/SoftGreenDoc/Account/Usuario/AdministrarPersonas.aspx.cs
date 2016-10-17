using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using BLL;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
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
using System.Xml;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.ServiceModel;
using System.Threading;
using System.Net.Sockets;
using SoftGreenDoc;
using SQLCLASS;
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


public partial class AdministrarPersonas : Page
{
    #region VARIABLES
    public List<DCPERSONAS> PERSONASELECCIONADA = new List<DCPERSONAS>();
    DataTable dt = new DataTable();
    DataTable dtusuariocargado = new DataTable();
    #endregion
    
    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CARGARVALORESINICIALES();
        }
    }

    public void CARGARVALORESINICIALES()
    {
        DataTable PAISES = new DataTable("PAISES");

        DataColumn COLUMNAS = PAISES.Columns.Add("IDPAIS", typeof(Int32));
        COLUMNAS.AllowDBNull = false;
        COLUMNAS.Unique = true;
        PAISES.Columns.Add("NOMBRE", typeof(String));
        DataRow nuevafila;
        nuevafila = PAISES.NewRow();
        nuevafila["IDPAIS"] = 1;
        nuevafila["NOMBRE"] = "COLOMBIA";
        PAISES.Rows.Add(nuevafila);
        
        cboPais.DataSource = PAISES;
        cboPais.DataTextField = "NOMBRE";
        cboPais.DataValueField = "NOMBRE";
        cboPais.DataBind();

        DataTable GENEROS = new DataTable("GENEROS");

        DataColumn COLUMNASGENEROS = GENEROS.Columns.Add("IDGENERO", typeof(Int32));
        COLUMNASGENEROS.AllowDBNull = false;
        COLUMNASGENEROS.Unique = true;
        GENEROS.Columns.Add("NOMBRE", typeof(String));
        DataRow nuevafilaGENEROS;
        nuevafilaGENEROS = GENEROS.NewRow();
        nuevafilaGENEROS["IDGENERO"] = 1;
        nuevafilaGENEROS["NOMBRE"] = "HOMBRE";
        GENEROS.Rows.Add(nuevafilaGENEROS);
        nuevafilaGENEROS = GENEROS.NewRow();
        nuevafilaGENEROS["IDGENERO"] = 2;
        nuevafilaGENEROS["NOMBRE"] = "MUJER";
        GENEROS.Rows.Add(nuevafilaGENEROS);

        cboGenero.DataSource = GENEROS;
        cboGenero.DataTextField = "NOMBRE";
        cboGenero.DataValueField = "NOMBRE";
        cboGenero.DataBind();

        DataTable TIPOSIDEN = new DataTable("TIPOSIDEN");

        DataColumn COLUMNASTIPOSIDEN = TIPOSIDEN.Columns.Add("IDTIPOSIDEN", typeof(Int32));
        COLUMNASTIPOSIDEN.AllowDBNull = false;
        COLUMNASTIPOSIDEN.Unique = true;
        TIPOSIDEN.Columns.Add("NOMBRE", typeof(String));
        DataRow nuevafilaTIPOSIDEN;
        nuevafilaTIPOSIDEN = TIPOSIDEN.NewRow();
        nuevafilaTIPOSIDEN["IDTIPOSIDEN"] = 1;
        nuevafilaTIPOSIDEN["NOMBRE"] = "CEDULA DE CIUDADANIA";
        TIPOSIDEN.Rows.Add(nuevafilaTIPOSIDEN);
        nuevafilaTIPOSIDEN = TIPOSIDEN.NewRow();
        nuevafilaTIPOSIDEN["IDTIPOSIDEN"] = 2;
        nuevafilaTIPOSIDEN["NOMBRE"] = "TARJETA DE IDENTIDAD";
        TIPOSIDEN.Rows.Add(nuevafilaTIPOSIDEN);

        cbo_tipoId.DataSource = TIPOSIDEN;
        cbo_tipoId.DataTextField = "NOMBRE";
        cbo_tipoId.DataValueField = "NOMBRE";
        cbo_tipoId.DataBind();

        cboDepto.DataSource = GENERALES.DEPARTAMENTOSObtener(0) ;
        cboDepto.DataTextField = "NOMBRE";
        cboDepto.DataValueField = "NOMBRE";
        cboDepto.DataBind();

        cboCiudad.DataSource = GENERALES.MUNICIPIOSObtenerbyID_DEPTO(1,0);
        cboCiudad.DataTextField = "NOMBRE";
        cboCiudad.DataValueField = "NOMBRE";
        cboCiudad.DataBind();
        CARGARGRILLA3();
    }
    
    #region EVENTOS GRILLA3
    public void CARGARGRILLA3()
    {
        List<DCPERSONAS> dt = new List<DCPERSONAS>();
        dt = PERSONAS.PERSONASObtener(0);
        GrdVw_Personas.Visible = false;
        if (dt.Count > 0)
        {
            GrdVw_Personas.Visible = true;
            GrdVw_Personas.DataSource = null;
            GrdVw_Personas.DataBind();
            GrdVw_Personas.DataSource = dt;
            GrdVw_Personas.DataBind();
        }
        else
        {
            GrdVw_Personas.Visible = false;
            GrdVw_Personas.DataSource = null;
            GrdVw_Personas.DataBind();
        }
    }
    protected void GrdVw_Personas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Editar"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string code = GrdVw_Personas.DataKeys[index].Value.ToString();

            PERSONASELECCIONADA = PERSONAS.PERSONASObtenerbyIDPERSONA(Convert.ToDecimal(code), 0);
            Session["PERSONASELECCIONADA"] = PERSONASELECCIONADA;
            txtCelular.Text = PERSONASELECCIONADA[0].MOVIL;
            txtDireccion.Text = PERSONASELECCIONADA[0].DIRECCION;
            txtTelefono.Text = PERSONASELECCIONADA[0].TELEFONO;
            txt_apellidos.Text = PERSONASELECCIONADA[0].APELLIDOS;
            txt_nombres.Text = PERSONASELECCIONADA[0].NOMBRE;
            txt_NumeroId.Text = PERSONASELECCIONADA[0].IDENTIFICACION;
            TextCorreoElectronico.Text = PERSONASELECCIONADA[0].CORREO;
            cboCiudad.SelectedValue = PERSONASELECCIONADA[0].CIUDAD;
            cboDepto.SelectedValue = PERSONASELECCIONADA[0].DEPTO;
            cboGenero.SelectedValue = PERSONASELECCIONADA[0].GENERO;
            cboPais.SelectedValue = PERSONASELECCIONADA[0].PAIS;
            cbo_tipoId.SelectedValue = PERSONASELECCIONADA[0].TIPOIDENTIFICACION;
            dtpFechaExpedicion.Text = PERSONASELECCIONADA[0].FECHAEXPEDICION.ToShortDateString();
            dtpFechaNacimiento.Text = PERSONASELECCIONADA[0].FECHAEXPEDICION.ToShortDateString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            "ModalScript", sb.ToString(), false);
        }
        else if (e.CommandName.Equals("Eliminar"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Decimal code = Convert.ToDecimal(GrdVw_Personas.DataKeys[index].Value);

            bool _actualizado;
            _actualizado = PERSONAS.PERSONASEliminarbyIDPERSONA(code, 0, DateTime.Now);

            if (_actualizado == true)
            {
                CARGARGRILLA3();
                Alerta.notiffy("Eliminación Exitosa", "Se ha Eliminado correctamente la persona", "sucessful", this, GetType());
            }
            else
            {
                Alerta.notiffy("Operacion incompleta", "No se ha podido Eliminar la persona!", "warning", this, GetType());
            }
        }
        else if (e.CommandName.Equals("Detalle"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string code = GrdVw_Personas.DataKeys[index].Value.ToString();

            PERSONASELECCIONADA = PERSONAS.PERSONASObtenerbyIDPERSONA(Convert.ToDecimal(code), 0);
            Session["PERSONASELECCIONADA"] = PERSONASELECCIONADA;
            LblIDPERSONA.InnerText = PERSONASELECCIONADA[0].IDPERSONA.ToString();
            LblIDENTIFICACION.InnerText = PERSONASELECCIONADA[0].IDENTIFICACION;
            LblTIPOIDENTIFICACION.InnerText = PERSONASELECCIONADA[0].TIPOIDENTIFICACION;
            LblFECHAEXPEDICION.InnerText = PERSONASELECCIONADA[0].FECHAEXPEDICION.ToString();
            LblFECHANACIMIENTO.InnerText = PERSONASELECCIONADA[0].FECHANACIMIENTO.ToString();
            LblNOMBRE.InnerText = PERSONASELECCIONADA[0].NOMBRE;
            LblApellidos.InnerText = PERSONASELECCIONADA[0].APELLIDOS;
            LblDIRECCION.InnerText = PERSONASELECCIONADA[0].DIRECCION;
            LblPAIS.InnerText = PERSONASELECCIONADA[0].PAIS;
            LblDEPTO.InnerText = PERSONASELECCIONADA[0].DEPTO;
            LblCIUDAD.InnerText = PERSONASELECCIONADA[0].CIUDAD;
            LblCORREO.InnerText = PERSONASELECCIONADA[0].CORREO;
            LblGENERO.InnerText = PERSONASELECCIONADA[0].GENERO;
            LblTELEFONO.InnerText = PERSONASELECCIONADA[0].TELEFONO;
            LblMOVIL.InnerText = PERSONASELECCIONADA[0].MOVIL;
            LblIDUSUARIOCREO.InnerText = PERSONASELECCIONADA[0].IDUSUARIOCREO.ToString();
            LblFECHACREO.InnerText = PERSONASELECCIONADA[0].FECHACREO.ToString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModalDetail').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            "ModalScript", sb.ToString(), false);
        }
    }
    protected void GrdVw_Personas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdVw_Personas.PageIndex = e.NewPageIndex;
        CARGARGRILLA3();
    }
    public void GrdVw_Personas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //Decimal _USUARIO_TMP_ID = 0;
        //    //Int32 x = e.Row.RowIndex;

        //    //e.Row.Cells[1].ForeColor = System.Drawing.Color.Blue;
        //    //e.Row.Cells[1].Font.Underline = true;
        //    //HyperLinkField hlink = new HyperLinkField();
        //    //hlink = grdLista.Columns[3] as HyperLinkField;

        //    //String textLink = String.Empty;
        //    //_USUARIO_TMP_ID = (Decimal)DataBinder.Eval(e.Row.DataItem, "USUARIO_TMP_ID");

        //    //textLink = "../PDF/" + _USUARIO_TMP_ID + ".pdf";

        //    //HyperLink myHL = (HyperLink)e.Row.FindControl("EditHyperLink1");
        //    //myHL.NavigateUrl = textLink;
        //}
    }

    #endregion

    #region EVENTOS MODAL

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        //List<DCPERSONAS> lstPERSONAS = new List<DCPERSONAS>();
        //DataTable DTPERSONAS = new DataTable();
        //PERSONASELECCIONADA = PERSONAS.PERSONASObtenerbyCriterio(txt_NumeroId.Text, 0);
        //Session["PERSONASELECCIONADA"] = PERSONASELECCIONADA;
        //if (PERSONASELECCIONADA.Count == 0)
        //{
        //    PERSONAS.PERSONASRegistrar(0, txt_NumeroId.Text,
        //        cbo_tipoId.SelectedItem.Text, Convert.ToDateTime(dtpFechaExpedicion.Text), Convert.ToDateTime(dtpFechaNacimiento.Text),
        //        txt_nombres.Text.ToUpper(), txt_apellidos.Text.ToUpper(), txtDireccion.Text, cboPais.SelectedItem.Text,
        //        cboDepto.SelectedItem.Text, cboCiudad.SelectedItem.Text, TextCorreoElectronico.Text, cboGenero.SelectedItem.Text,
        //        txtTelefono.Text, txtCelular.Text, "PERSONA", "SI", 0, DateTime.Now, 0, DateTime.Now);

        //    //string script = " $.growl.notice({ title: 'Registro Exitoso',message: '' });";
        //    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    Alerta.notiffy("Registro Exitoso", "Se ha registrado correctamenta en la BD, los datos de la persona", "sucessful", this, GetType());
        //}
        //else
        //{
        //    //string script = "alert(\"No se ha podido agregar la persona pues el numero de identificación ya existe!\");";
        //    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    Alerta.notiffy("Operacion incompleta", "No se ha podido agregar la persona, el numero de identificación ya existe!", "warning", this, GetType());
        //}

        PERSONASELECCIONADA = (List<DCPERSONAS>)Session["PERSONASELECCIONADA"];
        if (PERSONAS.PERSONASActualizarbyIDPERSONA(PERSONASELECCIONADA[0].IDPERSONA, txt_NumeroId.Text, cbo_tipoId.SelectedValue.ToString(), Convert.ToDateTime(dtpFechaExpedicion.Text),
            Convert.ToDateTime(dtpFechaNacimiento.Text), txt_nombres.Text, txt_apellidos.Text, txtDireccion.Text, cboPais.SelectedValue.ToString(), cboDepto.SelectedValue.ToString(),
            cboCiudad.SelectedValue.ToString(), TextCorreoElectronico.Text, cboGenero.SelectedValue.ToString(), txtTelefono.Text, txtCelular.Text, "PERSONA", "SI", 0, DateTime.Now, 0, DateTime.Now ))
        {
            //grdLista.EditIndex = -1;
            //CARGARGRILLA();
            Alerta.notiffy("Registro Exitoso", "Se ha registrado correctamenta la actualización de los datos", "sucessful", this, GetType());
        }
        else
        {
            Alerta.notiffy("Operacion incompleta", "No se han podido actualizar los cambios!", "warning", this, GetType());
        }
        CARGARGRILLA3();
    }

    #endregion
    
    protected void btnNUEVO_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('#myModal').modal('show');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
        "ModalScript", sb.ToString(), false);
    }
}