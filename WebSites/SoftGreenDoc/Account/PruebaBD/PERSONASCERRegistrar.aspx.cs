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
using System.Xml;
using System.Net;
using System.Windows;
using System.Windows.Input;
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

public partial class PERSONASCERRegistrar : Page
{
    #region VARIABLES
    public List<DCPERSONASCER> PERSONACERSELECCIONADA = new List<DCPERSONASCER>();
    #endregion

    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CARGARGRILLA();
            CARGARGRILLA2();
            CARGARGRILLA3();
        }
    }

    #region metodos

    public void CARGARGRILLA()
    {
        List<DCPERSONASCER> dt = new List<DCPERSONASCER>();
        dt = PERSONASCER.PERSONASCERObtener(0);
        grdLista.Visible = false;
        if (dt.Count > 0)
        {
            grdLista.Visible = true;
            grdLista.DataSource = null;
            grdLista.DataBind();
            grdLista.DataSource = dt;
            grdLista.DataBind();
        }
        else
        {
            grdLista.Visible = false;
            grdLista.DataSource = null;
            grdLista.DataBind();
        }
    }

    #endregion

    #region eventos viejos
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        StatusLabel.Text = "Cargando...";
        //if (FileUploadControl.HasFile)
        //{
        //    try
        //    {
        //        string filename = Path.GetFileName(FileUploadControl.FileName);
        //        FileUploadControl.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["RutaWebSoftDoc"] + ConfigurationManager.AppSettings["RutaFotos"]) + filename);
        //        StatusLabel.Text = "Upload status: File uploaded!";
        //    }
        //    catch (Exception ex)
        //    {
        //        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        //    }
        //}
        if (FileUploadControl.HasFile)
        {
            try
            {
                if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                {
                    if (FileUploadControl.PostedFile.ContentLength < 1024000)
                    {
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["RutaFotos"]) + filename);
                        StatusLabel.Text = "Status de Carga: Carga Exitosa!";
                        //Uri URLIMAGEN = new Uri(ConfigurationManager.AppSettings["RutaFotos"].ToString() + filename);
                        Image2.ImageUrl = ConfigurationManager.AppSettings["RutaFotos"].ToString() + filename;
                        //Image1.ImageUrl = ConfigurationManager.AppSettings["RutaFotos"].ToString() + filename;
                    }
                    else
                        StatusLabel.Text = "Status de Carga: ha exedido los 1000 kb!";
                }
                else
                    StatusLabel.Text = "Status de Carga: Solo puede subir archivos de tipo jpeg!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Status de Carga: No se ha cargado el archivo pues se presento el siguiente error: " + ex.Message;
            }
        }
    }
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        List<DCPERSONASCER> lstPERSONASCER = new List<DCPERSONASCER>();
        List<DCPERSONASCER> DTPERSONASCER = new List<DCPERSONASCER>();
        DTPERSONASCER = PERSONASCER.PERSONASCERObtenerbyCriterio(txtIdentificacion.Text, 0);
        if (DTPERSONASCER.Count == 0)
        {
            PERSONASCER.PERSONASCERRegistrar(0, txtIdentificacion.Text.ToUpper(), txtNombres.Text.ToUpper(), txtApellidos.Text.ToUpper(), new DateTime(2002, 11, 3), txtEmail.Text, txtTelefono.Text.ToUpper(), txtMovil.Text.ToUpper(), "EMPLEADO", "SOLTERO", 0, DateTime.Now, 0, DateTime.Now, txtCargo.Text.ToUpper(), txtDependencia.Text.ToUpper(), txtFunciones.Text.ToUpper(), txtSueldo.Text.ToUpper(), "SI");
            CARGARGRILLA();

            Alerta.notiffy("Registro Exitoso", "Se ha registrado correctamenta en la BD, los datos de la persona", "sucessful", this, GetType());
        }
        else
        {
            CARGARGRILLA();
            Alerta.notiffy("Operacion incompleta", "No se ha podido agregar la persona, el numero de identificación ya existe!", "warning", this, GetType());
        }
    }

    #region EVENTOS GRILLA1
    public void grdLista_RowDataBound(object sender, GridViewRowEventArgs e)
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
    public void grdLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdLista.Rows[index];
            //decimal IDUSUARIOSELECCIONADODELAGRILLA = Convert.ToDecimal(grdLista.Rows[index].Cells[2].Text);
            var idpersona = grdLista.DataKeys[index].Value;
            decimal IDUSUARIOSELECCIONADODELAGRILLA = Convert.ToDecimal(idpersona);
            bool _actualizado;
            _actualizado = PERSONASCER.PERSONASCEREliminarbyIDPERSONA(IDUSUARIOSELECCIONADODELAGRILLA, 0, DateTime.Now);
         
            if (_actualizado == true)
            {
                CARGARGRILLA();
                Alerta.notiffy("Registro Exitoso", "Se ha eliminado correctamente la persona", "sucessful", this, GetType());
            }
            else
            {
                Alerta.notiffy("Registro Exitoso", "Se ha eliminado correctamente la persona", "warning", this, GetType());
            }
        }
    }
    protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdLista.PageIndex = e.NewPageIndex;
        CARGARGRILLA();
    }
    protected void grdLista_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdLista.EditIndex = -1;
        CARGARGRILLA();
    }
    protected void grdLista_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdLista.EditIndex = e.NewEditIndex;
        CARGARGRILLA();
    }
    protected void grdLista_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var idpersona = grdLista.DataKeys[e.RowIndex].Value;
        TextBox txtnombres = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtNOMBRES");
        TextBox txtapellidos = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtAPELLIDOS");
        TextBox txtidentificacion = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtIDENTIFICACION");
        TextBox txtemail = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtEMAIL");
        TextBox txtcargo = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtCARGO");
        TextBox txtdependencia = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtDEPENDENCIA");
        TextBox txtfunciones = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtFUNCIONES");
        TextBox txtsueldo = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtSUELDO");
        //TextBox txtactivo = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtACTIVO");
        DropDownList Drpactivo = (DropDownList)grdLista.Rows[e.RowIndex].FindControl("DrpACTIVO");

        //String txtnombres = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtNOMBRES");
        //String txtapellidos = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtAPELLIDOS");
        //String txtidentificacion = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtIDENTIFICACION");
        //String txtemail = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtEMAIL");
        //String txtcargo = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtCARGO");
        //String txtdependencia = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtDEPENDENCIA");
        //String txtfunciones = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtFUNCIONES");
        //String txtsueldo = (TextBox)grdLista.Rows[e.RowIndex].FindControl("txtSUELDO");
        
        if (txtnombres.Text != "" && txtapellidos.Text != "" && txtidentificacion.Text != "" && txtemail.Text != "" && txtcargo.Text != "" && txtdependencia.Text != ""
            && txtfunciones.Text != "" && txtsueldo.Text != "" && Drpactivo.SelectedItem.ToString() != "")
        {
            if (PERSONASCER.PERSONASCERActualizarbyIDPERSONA(Convert.ToDecimal(idpersona), txtidentificacion.Text, txtnombres.Text, txtapellidos.Text, DateTime.Now,
                txtemail.Text, "", "", "", "", 0, DateTime.Now, 0, DateTime.Now, txtcargo.Text, txtdependencia.Text, txtfunciones.Text, txtsueldo.Text, Drpactivo.SelectedItem.ToString()))
            {
                grdLista.EditIndex = -1;
                CARGARGRILLA();
                Alerta.notiffy("Registro Exitoso", "Se ha registrado correctamenta la actualización de los datos", "sucessful", this, GetType());
            }
            else
            {
                Alerta.notiffy("Operacion incompleta", "No se han podido actualizar los cambios!", "warning", this, GetType());
                return;
            }
        }
    }
    protected void grdLista_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CARGARGRILLA();
    }
    protected void DrpACTIVO_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    #endregion

    #endregion

    #region EVENTOS GRILLA2

    public void CARGARGRILLA2()
    {
        List<DCPERSONASCER> dt = new List<DCPERSONASCER>();
        dt = PERSONASCER.PERSONASCERObtener(0);
        grdLista2.Visible = false;
        if (dt.Count > 0)
        {
            grdLista2.Visible = true;
            grdLista2.DataSource = null;
            grdLista2.DataBind();
            grdLista2.DataSource = dt;
            grdLista2.DataBind();
        }
        else
        {
            grdLista2.Visible = false;
            grdLista2.DataSource = null;
            grdLista2.DataBind();
        }
    }

    protected void grdLista2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Decimal _USUARIO_TMP_ID = 0;
            //Int32 x = e.Row.RowIndex;

            //e.Row.Cells[1].ForeColor = System.Drawing.Color.Blue;
            //e.Row.Cells[1].Font.Underline = true;
            //HyperLinkField hlink = new HyperLinkField();
            //hlink = grdLista.Columns[3] as HyperLinkField;

            //String textLink = String.Empty;
            //_USUARIO_TMP_ID = (Decimal)DataBinder.Eval(e.Row.DataItem, "USUARIO_TMP_ID");

            //textLink = "../PDF/" + _USUARIO_TMP_ID + ".pdf";

            //HyperLink myHL = (HyperLink)e.Row.FindControl("EditHyperLink1");
            //myHL.NavigateUrl = textLink;
        }
    }

    protected void grdLista2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdnameEliminar")
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = grdLista2.Rows[index];
            //decimal IDUSUARIOSELECCIONADODELAGRILLA = Convert.ToDecimal(grdLista2.Rows[index].Cells[0].Text);

            //bool _actualizado;

            //_actualizado = PERSONAS.PERSONASEliminarbyIDPERSONA(IDUSUARIOSELECCIONADODELAGRILLA, 0, DateTime.Now);

            //if (_actualizado == true)
            //{
            //    CARGARGRILLA();
            //    string script = "alert(\"Se ha eliminado el usuario satisfactoriamente!\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
            //else
            //{
            //    string script = "alert(\"No se ha podido eliminar el usuario!\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
        }
    }

    #endregion

    #region EVENTOS GRILLA3
    public void CARGARGRILLA3()
    {
        List<DCPERSONASCER> dt = new List<DCPERSONASCER>();
        dt = PERSONASCER.PERSONASCERObtener(0);
        GridView1.Visible = false;
        if (dt.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Editar"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string code = GridView1.DataKeys[index].Value.ToString();

            PERSONACERSELECCIONADA = PERSONASCER.PERSONASCERObtenerbyIDPERSONA(Convert.ToDecimal(code), 0);
            Session["PERSONACERSELECCIONADA"] = PERSONACERSELECCIONADA;
            txt_APELLIDOS.Text = PERSONACERSELECCIONADA[0].APELLIDOS;
            txt_CARGO.Text = PERSONACERSELECCIONADA[0].CARGO;
            txt_DEPENDENCIA.Text = PERSONACERSELECCIONADA[0].DEPENDENCIA;
            txt_EMAIL.Text = PERSONACERSELECCIONADA[0].EMAIL;
            txt_FUNCIONES.Text = PERSONACERSELECCIONADA[0].FUNCIONES;
            txt_IDENTIFICACION.Text = PERSONACERSELECCIONADA[0].IDENTIFICACION;
            txt_MOVIL.Text = PERSONACERSELECCIONADA[0].MOVIL;
            txt_NOMBRES.Text = PERSONACERSELECCIONADA[0].NOMBRE;
            txt_SUELDO.Text = PERSONACERSELECCIONADA[0].SUELDO;
            txt_TELEFONO.Text = PERSONACERSELECCIONADA[0].TELEFONO;
           
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#myModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
            "ModalScript", sb.ToString(), false);
        }
        else if(e.CommandName.Equals("Eliminar"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            Decimal code = Convert.ToDecimal(GridView1.DataKeys[index].Value);

            bool _actualizado;
            _actualizado = PERSONASCER.PERSONASCEREliminarbyIDPERSONA(code, 0, DateTime.Now);

            if (_actualizado == true)
            {
                CARGARGRILLA();
                CARGARGRILLA2();
                CARGARGRILLA3();
                Alerta.notiffy("Eliminación Exitosa", "Se ha Eliminado correctamente la persona", "sucessful", this, GetType());
            }
            else
            {
                Alerta.notiffy("Operacion incompleta", "No se ha podido Eliminar la persona!", "warning", this, GetType());
            }
            //DataTable dt = new DataTable();
            //dt = PERSONASCER.PERSONASCERObtener(0);
            //DetailsView1.Visible = false;
            //if (dt.Rows.Count > 0)
            //{
            //    DetailsView1.Visible = true;
            //    DetailsView1.DataSource = null;
            //    DetailsView1.DataBind();
            //    DetailsView1.DataSource = dt;
            //    DetailsView1.DataBind();
            //}
            //else
            //{
            //    DetailsView1.Visible = false;
            //    DetailsView1.DataSource = null;
            //    DetailsView1.DataBind();
            //}
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        CARGARGRILLA3();
    }
    public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void BTNMODALGUARDAR_Click(object sender, EventArgs e)
    {
        PERSONACERSELECCIONADA = (List<DCPERSONASCER>)Session["PERSONACERSELECCIONADA"];
        if (PERSONASCER.PERSONASCERActualizarbyIDPERSONA(PERSONACERSELECCIONADA[0].IDPERSONA, txt_IDENTIFICACION.Text, txt_NOMBRES.Text,
            txt_APELLIDOS.Text, DateTime.Now, txt_EMAIL.Text, txt_TELEFONO.Text, txt_MOVIL.Text, "PRUEBA", "SOLTERO", 0, DateTime.Now, 0, DateTime.Now,
            txt_CARGO.Text, txt_DEPENDENCIA.Text, txt_FUNCIONES.Text, txt_SUELDO.Text, "SI"))
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
        //List<DCPERSONAS> lstPERSONAS = new List<DCPERSONAS>();
        //DataTable DTPERSONAS = new DataTable();
        //DTPERSONAS = PERSONAS.PERSONASObtenerbyCriterio(txt_NumeroId.Text, 0);
        //if (DTPERSONAS.Rows.Count == 0)
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
    }

    #endregion

}