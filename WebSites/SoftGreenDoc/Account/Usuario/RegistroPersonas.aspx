 <%@ Page Title="Registro PERSONAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="RegistroPERSONAS.aspx.cs" Inherits="RegistroPERSONAS" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="/Scripts/jquery.growl.js" type="text/javascript"></script>
    <h2>PERSONAS.</h2>
    <%--<p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
    
    <div class="form-inline centrado" role="form">
        <div class="row">
            <div class="col-md-2">
                <a ><img class="img-responsive" src="imagenes/loMagdalena.jpg" style="height: 160px;width: 160px;"></a>
            </div>
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="txt_nombres">Nombres:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox  CssClass="form-control" id="txt_nombres" placeholder="Nombres de la persona"  runat="server" required/>
                </div>
            </div>
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="txt_apellidos">Apellidos:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox type="text" CssClass="form-control" id="txt_apellidos" placeholder="Apellidos de la persona" runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="txt_NumeroId">Numero de Identificacion:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox type="number" CssClass="form-control" id="txt_NumeroId" placeholder="Numero Identificacion" runat="server" required />
                </div>
            </div>
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="cbo_tipoId">Tipo Identificacion:</label></div>
                <div class="col-lg-10">
                    <asp:DropDownList CssClass="form-control" ID="cbo_tipoId" placeholder="Seleccione Tipo ID" runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="dtpFechaExpedicion">Fecha Expedición:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox type="date" CssClass="form-control" ID="dtpFechaExpedicion" placeholder="mm/dd/aaaa" runat="server" required/>
                </div>
            </div>

            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="dtpFechaNacimiento">Fecha Nacimiento:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox type="date" CssClass="form-control" ID="dtpFechaNacimiento" placeholder="mm/dd/aaaa" runat="server" required/>
                </div>
            </div>
    
        </div>
        <div class="row">
            <div class="col-lg-6 row control">

                <div class="col-lg-10">
                    <label class="control-label" for="txtDireccion">Direccion de correspondencia:</label>
                </div>
                <div class="col-lg-11 col-md-9">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtDireccion" placeholder="Seleccione Tipo ID" runat="server" required/>
                </div>

            </div>
            <div class="col-lg-4 row control">
                <div class="col-lg-10">
                    <label class="control-label" for="cboGenero">Genero:</label>
                </div>
                <div class="col-lg-10 col-md-9">
                    <asp:DropDownList CssClass="form-control" ID="cboGenero" placeholder="seleccione Genero" runat="server" required/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 row">
                <div class="col-lg-6 row control">

                    <div class="col-lg-10">
                        <label class="control-label" for="cboPais">País:</label>
                    </div>
                    <div class="col-lg-11 col-md-9" style="padding-right: 0px;">
                        <asp:DropDownList CssClass="form-control" ID="cboPais" placeholder="Seleccione País" runat="server" required/>
                    </div>

                </div>
                <div class="col-lg-7 row control">
                    <div class="col-lg-10">
                        <label class="control-label" for="cboDepto">Departamento:</label>
                    </div>
                    <div class="col-lg-10 col-md-9" style="padding-right: 0px;">
                        <asp:DropDownList CssClass="form-control" ID="cboDepto" placeholder="Seleccione Departamento" runat="server" required/>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 row control">
                <div class="col-lg-10">
                    <label class="control-label" for="cboCiudad">Ciudad:</label>
                </div>
                <div class="col-lg-10 col-md-9">
                    <asp:DropDownList CssClass="form-control" ID="cboCiudad" placeholder="Seleccione ciudad" runat="server" required/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 row control">

                <div class="col-lg-10">
                    <label class="control-label" for="TextCorreoElectronico">Correo electronico:</label>
                </div>
                <div class="col-lg-11 col-md-9">
                    <asp:TextBox type="email" CssClass="form-control" ID="TextCorreoElectronico" placeholder="registre el correo electronico" runat="server" required/>
                </div>

            </div>
            <div class="col-lg-4 row control">
                <div class="col-lg-10">
                    <label class="control-label" for="dtpFechaNacimiento"></label>
                </div>
                <div class="col-lg-10 col-md-9">
                    <%--<asp:TextBox type="date" CssClass="form-control" ID="dtpFechaNacimiento" placeholder="dd/mm/aaaa" runat="server" />--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 row">
                <div class="col-lg-6 row control">

                    <div class="col-lg-10">
                        <label class="control-label" for="txtTelefono">Numero Telefonico:</label>
                    </div>
                    <div class="col-lg-11 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="number" CssClass="form-control" ID="txtTelefono" placeholder="Numero telefono fijo" runat="server" required/>
                    </div>

                </div>
                <div class="col-lg-7 row control">
                    <div class="col-lg-10">
                        <label class="control-label" for="txtCelular">Numero Celular:</label>
                    </div>
                    <div class="col-lg-10 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="number" CssClass="form-control" ID="txtCelular" placeholder="Numero celular" runat="server" required/>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 row control">
                <div class="col-lg-3 ">
                <asp:Button ID="BtnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
            </div>
            <div class="col-lg-3 ">
                <asp:Button CssClass="btn btn-default" runat="server" Text="Cancelar" />
            </div>
            </div>
        </div>
    </div>
</asp:Content>

