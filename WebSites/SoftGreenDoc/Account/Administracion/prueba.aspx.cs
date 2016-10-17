using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Administracion_prueba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //row_modulos_accesos.InnerHtml= row_modulos_accesos.InnerHtml + @"";
    }

    private void agregarNuevomodulo_adminRol( int nRol )
    {
        //String codigoInsert = "<div data-toggle=\"collapse\" data-target=\"#"+
        //    nRol.ID_ROLL+ "\" title=\""+nRol.DESCRIPCION+"\">" + nRol.NOMBRE+"</div> <div class=\"collapse\" id=\"modulo1\" runat=\"server\"></div>";

        string idModulo="idmodulo1", descripcion="esta puede ser la descripcion del modulo", moduloNombre = "Modulo 1";
   
        String codigoInsert = "<div data-toggle=\"collapse\" data-target=\"#" +
           idModulo + "\" title=\"" + descripcion + "\">" + moduloNombre + "</div> <div class=\"collapse\" id=\""+idModulo+"\" runat=\"server\"></div>";
        row_modulos_accesos.InnerHtml = row_modulos_accesos.InnerHtml +codigoInsert;
    }
    int numer_modulo = 1;
    public void clickAgregarModulo(object sender, EventArgs e) {
        agregarNuevomodulo_adminRol(numer_modulo);
        numer_modulo++;
    }
}