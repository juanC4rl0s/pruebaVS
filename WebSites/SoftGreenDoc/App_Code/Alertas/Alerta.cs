using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for Alerta
/// </summary>
public class Alerta
{
    public Alerta()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Genera una notificacion (String titulo, string Mensaje, string tipoNotify,Control ctn)  tipoNotify:('error','sucessful','warning','normal')
    /// </summary>
    /// <param name="titulo"></param>
    /// <param name="Mensaje"></param>
    /// <param name="tipoNotify"> </param>
    public static void notiffy(String titulo, string Mensaje, string tipoNotify,Control ctn, Type tipo)
    {
        string script = " ";
        switch (tipoNotify)
        {
            case "error": script = " $.growl.error({ title: '" + titulo+ "',message: '" + Mensaje + "' });"; break;
            case "sucessful": script = " $.growl.notice({ title: '" + titulo + "',message: '" + Mensaje + "' });"; break;
            case "warning": script = " $.growl.warning({ title: '" + titulo + "',message: '" + Mensaje + "' });"; break;
            case "normal": script = " $.growl({ title: '" + titulo + "',message: '" + Mensaje + "' });"; break;
            default: break;
        }
        ScriptManager.RegisterStartupScript(ctn,tipo , "ServerControlScript", script, true);
    }
}