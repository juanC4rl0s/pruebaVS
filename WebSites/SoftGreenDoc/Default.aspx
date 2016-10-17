<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/jquery.growl.js" type="text/javascript"></script>

    <div class="jumbotron">
         <img class="img-responsive" src="imagenes/loMagdalena.jpg" />&nbsp;<h1>
            SOFGREENDOC</h1>
       <p class="lead">Es un desarrollo pensado en facilitar y mejorar la gestión documental en múltiples procesos cotidianOS de las organizaciones, realizando los diferentes tramites de forma digital y manteniendo un control del estado actual de cada tramite, permitiendo de esta forma mejorar y facilitar la toma de decisiones para optimizar los procesos.</p>
        <asp:Button runat="server" CssClass="btn btn-primary btn-lg" Text="Conoce mas" OnClick="Nottify"/>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Desarrollo</h2>
            <p>
                Las tecnologías aplicadas en el desarrollo de esta aplicación son lo suficientemente robusta y agiles para permitir un funcionamiento fluido y con altos estándares de seguridad, brindándole la tranquilidad a nuestros clientes de que su información y procesos siempre estarán respaldados y seguros.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
