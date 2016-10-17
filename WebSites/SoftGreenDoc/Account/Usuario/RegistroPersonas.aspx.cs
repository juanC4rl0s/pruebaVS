using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using BLL;
using System.Collections.Generic;


public partial class RegistroPERSONAS : Page
{
    DataTable dt = new DataTable();
    DataTable dtusuariocargado = new DataTable();

    #region VARIABLES
    public List<DCPERSONAS> PERSONASELECCIONADA = new List<DCPERSONAS>();
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
    }

    public void grdLista_RowDataBound(object sender, GridViewRowEventArgs e)
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

    public void grdLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "cmdnameEliminar")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = grdLista.Rows[index];
        //    decimal IDUSUARIOSELECCIONADODELAGRILLA = Convert.ToDecimal(grdLista.Rows[index].Cells[0].Text);

        //    bool _actualizado;

        //    _actualizado = PERSONAS.PERSONASEliminarbyIDPERSONA(IDUSUARIOSELECCIONADODELAGRILLA, 0, DateTime.Now);

        //    if (_actualizado == true)
        //    {
        //        CARGARGRILLA();
        //        string script = "alert(\"Se ha eliminado el usuario satisfactoriamente!\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
        //    }
        //    else
        //    {
        //        string script = "alert(\"No se ha podido eliminar el usuario!\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //    }
        //}
    }
    
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        List<DCPERSONAS> lstPERSONAS = new List<DCPERSONAS>();
        DataTable DTPERSONAS = new DataTable();
        PERSONASELECCIONADA = PERSONAS.PERSONASObtenerbyCriterio(txt_NumeroId.Text, 0);
        Session["PERSONACERSELECCIONADA"] = PERSONASELECCIONADA;
        if (PERSONASELECCIONADA.Count == 0)
        {
            PERSONAS.PERSONASRegistrar(0, txt_NumeroId.Text,
                cbo_tipoId.SelectedItem.Text, Convert.ToDateTime(dtpFechaExpedicion.Text), Convert.ToDateTime(dtpFechaNacimiento.Text),
                txt_nombres.Text.ToUpper(), txt_apellidos.Text.ToUpper(), txtDireccion.Text, cboPais.SelectedItem.Text,
                cboDepto.SelectedItem.Text, cboCiudad.SelectedItem.Text, TextCorreoElectronico.Text, cboGenero.SelectedItem.Text,
                txtTelefono.Text, txtCelular.Text, "PERSONA", "SI", 0, DateTime.Now, 0, DateTime.Now);

            //string script = " $.growl.notice({ title: 'Registro Exitoso',message: '' });";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            Alerta.notiffy("Registro Exitoso","Se ha registrado correctamenta en la BD, los datos de la persona","sucessful",this,GetType());
        }
        else
        {
            //string script = "alert(\"No se ha podido agregar la persona pues el numero de identificación ya existe!\");";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            Alerta.notiffy("Operacion incompleta", "No se ha podido agregar la persona, el numero de identificación ya existe!", "warning", this, GetType());
        }
    }
}