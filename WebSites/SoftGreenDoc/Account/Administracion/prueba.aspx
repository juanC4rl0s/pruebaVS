<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prueba.aspx.cs" Inherits="Account_Administracion_prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <h3>PERSONAS.</h3>
    <%--<p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
   

            <div class="form-inline centrado" role="form" runat="server">

                <%-- Row del encabezado para buscar y mostrar la informacion del rol a administrar --%>
                <div class="row" id="row_busqueda_informacion">
                    <div class="col-lg-6 row" id="info_user">
                        <p>Busque el rol para el cual desea administrar los accesos</p>

                        <%--<asp:TextBox type="text" CssClass="form-control " ID="busqueda_Rol" PlaceHolder="Ingrese una busqueda" runat="server" />--%>
                        <%--<asp:LinkButton type="button" CssClass="btn btn-default btn-sm" runat="server">
                        <span class="glyphicon  glyphicon-search"></span>
                        </asp:LinkButton>--%>
                        <button type="button" class="btn btn-default btn-sm">
                        <span class="glyphicon  glyphicon-search"></span>
                        </button>
                    </div>
                    <div class="col-lg-6  row" id="Datos_user">
                        <b>Nombre del ROL</b>
                        <i>: descripcion asignada al rol escogico como elemento a administar, para definirle los accesos permitido a ese rol</i>
                    </div>
                </div>
                <%-- Fin del Row encabezado --%>

                <%-- Row para mostrar los Modulos actuales del sistema y ls accesos permitidos en cada modulo --%>
                <div class="row" id="row_modulos_accesos" runat="server">

                    <div data-toggle="collapse" data-target="#modulo1" title="">Modulo 1</div>
                    <div class="collapse" id="modulo1" runat="server">
                    </div>

                    <div class="row">
                        <%-- titulo de la seccion --%>
                        <div class=" col-lg-3 row">
                            <b class="col-lg-3">seccion 1.1</b>
                        </div>
                        <%-- cuerpo seccion con los accesos --%>
                        <div class="col-lg-9 row">
                            <div class="col-lg-4 col-sm-4 col-xs-6 columna-delgada">
                                <span class="row">
                                    <input type="checkbox" id="idAcceso" />
                                    <span>columna 1</span>
                                </span>
                            </div>

                        </div>
                    </div>




                    <div data-toggle="collapse" data-target="#modulo2">Modulo 2</div>
                    <div class="collapse" id="modulo2">
                        <div class="row">
                            <div class=" col-lg-3 row">
                                <b class="col-lg-3">seccion 2.1</b>
                            </div>
                            <div class="col-lg-9 row">
                                <div class="col-lg-4">
                                    columna 1
                                <span class="row">
                                    <input type="checkbox" id="idAcceso" />
                                    <span>columna 1</span>
                                </span>
                                </div>
                                <div class="col-lg-4">columna 2.2</div>
                                <div class="col-lg-4">columna 2.3</div>
                            </div>

                        </div>
                    </div>

                </div>
                <%-- Fin row modulos --%>

                <asp:Button runat="server" Text="agregarModulo" OnClick="clickAgregarModulo"/>
            </div>
        
</body>
</html>
