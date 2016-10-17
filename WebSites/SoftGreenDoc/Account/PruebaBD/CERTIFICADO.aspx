<%@ Page Title="CERTIFICADO" uiCulture="en-US" culture="en-US" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="CERTIFICADO.aspx.cs" Inherits="CERTIFICADO" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Certificados.</h2>
   <%-- <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
    
    <div class="form-horizontal">
        <h3>Certificados de historia labroal.</h3>
        <h4>Por favor llene los campos para poder generar su certificado.</h4>
        <hr />                                                            
        <%--<asp:ValidationSummary runat="server" CssClass="text-danger" />--%>
        <div class="form-group" id="DivNombres">
            <asp:Label runat="server" AssociatedControlID="txtNombres" CssClass="col-md-2 control-label">Nombres</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtNombres" CssClass="form-control" />
          
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombres"
                    CssClass="text-danger" ErrorMessage="El Nombre no es correcto." />
            </div>
        </div>
        <div class="form-group" id="DivIdentificacion">
            <asp:Label runat="server" AssociatedControlID="txtIdentificacion" CssClass="col-md-2 control-label">Identificación</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control" />
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtIdentificacion" ErrorMessage="Ingrese Valores Numericos"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]*">
</asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIdentificacion"
                    CssClass="text-danger" ErrorMessage="La identificaciòn no es correcta." />
            </div>
        </div>
        <div class="form-group" id="DivFechaDeExpedicion">
            <asp:Label runat="server" AssociatedControlID="txtFechaDeExpedicion" CssClass="col-md-2 control-label">Fecha De Expedición DeCedula</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFechaDeExpedicion" CssClass="form-control" />
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtIdentificacion"
                    CssClass="text-danger" ErrorMessage="La identificaciòn no es correcta." />
                    <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtFechaDeExpedicion"  Format="MM/dd/yyyy" />
           
            </div>
        </div>

        <div class="form-group" id="DivEmail">
            <asp:Label runat="server" AssociatedControlID="txtEmai" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmai" CssClass="form-control" /> 
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="txtEmai" ErrorMessage="El correo no es valido"
                            ForeColor="Red"
                            ValidationExpression="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$">
</asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmai"
                    CssClass="text-danger" ErrorMessage="El Email no es correcto." />
         
             </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Generar" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

