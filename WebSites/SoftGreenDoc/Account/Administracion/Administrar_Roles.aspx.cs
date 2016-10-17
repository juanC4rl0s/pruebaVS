using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using BLL;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class Administrar_Roles : Page
{
    DataTable dt = new DataTable();
    DataTable dtusuariocargado = new DataTable();

    #region VARIABLES

    ROLES ROL = new ROLES();
    List<USUARIOS_ROLL> UserRols = new List<USUARIOS_ROLL>();
    List<ACCESO_ROLL> userAccesos = new List<ACCESO_ROLL>();
    #endregion

    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CARGARVALORESINICIALES();
        }
        if (Page.IsPostBack)
        {
            ROL = new ROLES(Convert.ToDecimal( cboRollBuscar.SelectedValue));
            DESCRIPCIONROL.InnerText = ROL.DESCRIPCION;
            NombreRol.InnerText = ROL.NOMBRE;
        }
    }

     

    public void CARGARVALORESINICIALES()
    {
        List<ROLES> listRol = ROLES.ROLESObtenerTodos("SI");
        cboRollBuscar.DataSource = listRol;
        cboRollBuscar.DataTextField = "NOMBRE";
        cboRollBuscar.DataValueField = "ID_ROLL";
        cboRollBuscar.DataBind();
    }

   
    private void agregarNuevomodulo_adminRol(MODULOS modulo)
    {
        //String codigoInsert = "<div data-toggle=\"collapse\" data-target=\"#"+
        //    nRol.ID_ROLL+ "\" title=\""+nRol.DESCRIPCION+"\">" + nRol.NOMBRE+"</div> <div class=\"collapse\" id=\"modulo1\" runat=\"server\"></div>";

        string idModulo = "M"+modulo.ID_MODULO.ToString(), descripcion = modulo.DESCRIPCION, moduloNombre = modulo.NOMBRE ;

        String codigoInsert = "<div data-toggle=\"collapse\" data-target=\"#" +
           idModulo + "\" title=\"" + descripcion + "\" runat=\"server\">" + moduloNombre + "</div> <div class=\"collapse\" id=\"" + idModulo + "\" runat=\"server\">";
        

        //for (int i =0; i<3; i++)
            foreach(SECCIONES sec in modulo.SECCIONES)
        {
            string idSeccion =idModulo+"S"+ sec.ID_SECCION.ToString();
            codigoInsert = codigoInsert + "<div class=\"row\"> <div class=\"col-lg-3 row\"> <b class=\"col-lg-12\" data-toggle=\"collapse\" data-target=\"#" + idSeccion + "\"> " + sec.NOMBRE+ "</b> </div> <div class=\"col-lg-9 row collapse\" id=\"" + idSeccion +  "\"> ";
                //for (int j=0; j < 6; j++)
                foreach(ACCESOS asc in sec.ACCESOS)
            {
                string idAcceso = "A" + asc.ID_ACCESO;
                codigoInsert = codigoInsert + "<div class=\"col-lg-4 col-sm-4 col-xs-6 columna-delgada\" id=\""+idAcceso + "\"> <span class=\"row\" title=\"" + asc.DESCRIPCION + "\" > <input type=\"checkbox\" id=\"" + asc.ID_ACCESO+"\" /> <span>" + asc.NOMBRE+"</span></span> </div>  ";
            }
            codigoInsert = codigoInsert + "</div> </div>";
        }

        //"<div class=\"row\"> <div class=\"col-lg-3 row\"> <b class=\"col-lg-3\">seccion 1.1</b> </div> <div class=\"col-lg-9 row\"> <div class=\"col-lg-4 col-sm-4 col-xs-6 columna-delgada\"> <span class=\"row\"> <input type=\"checkbox\" id=\"idAcceso\" /> <span>columna 1</span></span> </div> </div>   </div>"
        //+
        codigoInsert = codigoInsert + "</div>";
        //row_modulos_accesos.InnerHtml = row_modulos_accesos.InnerHtml + codigoInsert;
        row_modulo_accex.InnerHtml = row_modulo_accex.InnerHtml + codigoInsert;
        

    }

    public void clickAgregarModulo(object sender, EventArgs e)
    {
        List<MODULOS> listModulos = MODULOS.MODULOSObtenerTODOS();
        row_modulo_accex.InnerHtml = "";
        foreach ( MODULOS mod in listModulos)
        {
            agregarNuevomodulo_adminRol(mod);
        }
        string valorSelect = cboRollBuscar.SelectedValue;
        string textoselect = cboRollBuscar.SelectedItem.Text;
        //Alerta.notiffy("Registro Exitoso", "el texto del combo es: "+textoselect+" y el valor es : "+valorSelect, "sucessful", this, GetType());
    }

    public void BuscarRol_click(object sender, EventArgs e)
    {
        List<ROLES> listRol = ROLES.ROLESObtenerTodos("SI");
    }

   
    private void cargarDatosdeUsuario()
    {
        // obteniendo los roles asociados al usuario deberia realizarse en el login como variable de session
        List<USUARIOS_ROLL> UserRols = USUARIOS_ROLL.USUARIOS_ROLLObtenerbyIdUsuario(1);
        // obteneiendo los accesos para el usuario se deberian cargar en el login como varible de session
        
        foreach(USUARIOS_ROLL user_rol in UserRols)
        {
            userAccesos.AddRange(ACCESO_ROLL.ACCESO_ROLLObtenerbyID_ROLL(user_rol.ID_ROLL));
        }
    }

}