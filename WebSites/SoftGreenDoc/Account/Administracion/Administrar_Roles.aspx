 <%@ Page Title="Administrar Roles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Administrar_Roles.aspx.cs" Inherits="Administrar_Roles" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <style>
  .custom-combobox {
    position: relative;
    display: inline-block;
  }
  .custom-combobox-toggle {
    position: absolute;
    top: 0;
    bottom: 0;
    margin-left: -1px;
    padding: 0;
  }
  .custom-combobox-input {
    margin: 0;
    padding: 5px 10px;
  }
  .custom-combobox-toggle{
      display: none;

  }
  </style>

    <script src="/Scripts/jquery.growl.js" type="text/javascript"></script>
    <script src="/Scripts/FuncionesGlobales.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    
    <h3>PERSONAS.</h3>
    <%--<p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
    <%-- <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>

    <div class="form-inline centrado" role="form">

        <%-- Row del encabezado para buscar y mostrar la informacion del rol a administrar --%>
        <div class="row" id="row_busqueda_informacion">
            <div class="col-lg-6 row" id="info_user">
                <p>Busque el rol para el cual desea administrar los accesos</p>

                <div class="ui-widget">
                    <asp:DropDownList runat="server" ID="cboRollBuscar" Height="21px"  Width="131px"></asp:DropDownList>
                    <asp:LinkButton CssClass="btn btn-default btn-sm" runat="server" OnClick="clickAgregarModulo">
                        <span class="glyphicon  glyphicon-search"></span>
                    </asp:LinkButton>
                </div>
            </div>
            <div class="col-lg-6  row" id="Datos_user">
                <b id="NombreRol" runat="server">Nombre del ROL</b>
                <i id="DESCRIPCIONROL" runat="server">: descripcion asignada al rol escogico como elemento a administar, para definirle los accesos permitido a ese rol</i>
            </div>
        </div>
        

        <div class="row" id="row_modulo_accex" runat="server">
        </div>
        <%-- Fin row modulos --%>
    </div>
    <%-- Inici declaracion de Modal nuevo Rol --%>
    <asp:Button ID="btnNUEVO" CssClass="btn btn-primary" runat="server" Text="Nuevo" OnClientClick="$('#myModalDetail').modal('show');"/>


    <div class="form-inline centrado" role="form">
    <div class="row">
        <div class="col-md-10">
        </div>
        <div class="row col-md-2">
            <div class="col-lg-12">
                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Nuevo" OnClientClick="$('#myModal').modal('show');"/>
            </div> 
        </div>
    </div>
    </div>
    <%-- Fin Modal Nuevo Rol --%>




    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(comboAutocomplete("cboRollBuscar", "toggle", ": no es un nombre de Rol valido"));
    </script>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
 </asp:Content>

