using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using SoftGreenDoc;
using BLL;
using System.Net;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

    protected void LogIn(object sender, EventArgs e)
    {
        if (UserName.Text.Length > 0 && Password.Text.Length > 0)
        {
            USUARIOS user = new USUARIOS(UserName.Text, Password.Text);
            if (user.ID_USUARIO > 0)
            {
                Session.Add("User", user);
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                HISTORICO_LOGIN.HISTORICO_LOGINRegistrar(user.ID_USUARIO, host.AddressList[host.AddressList.Length - 1].ToString(), "", DateTime.Now);
                Session.Timeout = 20;
                Char.IsNumber(Convert.ToChar("1pe".Substring(0, 1)));
                //prueba de login

                //var manager = new UserManager();
                //ApplicationUser user2 = new ApplicationUser();
                //user2.UserName = user.LOGIN;
                //user2.PasswordHash = user.CONTRASENIA;
                ////IdentityHelper.SignIn(manager, user2, RememberMe.Checked);
                ////IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                //fin de la prueba
                Response.Redirect("/Default.aspx");
            }
            else
            {
                Alerta.notiffy("Datos Incorrectos", "El nombre de ususario o la contraseña son incorrectos, verifique", "warning", this, GetType());
            }

        }
        //if (IsValid)
        //{
        //    // Validate the user password
        //    var manager = new UserManager();
        //    ApplicationUser user = manager.Find(UserName.Text, Password.Text);
        //    if (user != null)
        //    {
        //        IdentityHelper.SignIn(manager, user, RememberMe.Checked);
        //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //    }
        //    else
        //    {
        //        FailureText.Text = "Invalid username or password.";
        //        ErrorMessage.Visible = true;
        //    }
        //}

    }
}