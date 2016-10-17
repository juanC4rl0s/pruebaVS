using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        USUARIOS user = (Session["user"] == null ? new USUARIOS() : Session["user"]) as USUARIOS;
        if (user.ID_USUARIO > 0)
        {
            Alerta.notiffy("Bienvenido", "Muy buen dia " + (Session["user"] as USUARIOS).LOGIN == null ? "Invitado" : (Session["user"] as USUARIOS).LOGIN, "normal", this, GetType());
        }
    }
    protected void Nottify(object sender, EventArgs e)
    {

        Alerta.notiffy("Sitio en construccion", "Muy pronto tendras mas informacion sobre nosotros, no desesperes", "sucessful", this, GetType());
    }
}