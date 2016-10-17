 <%@ Page Title="Administrar PERSONAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AdministrarPersonas.aspx.cs" Inherits="AdministrarPersonas" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="/Scripts/jquery.growl.js" type="text/javascript"></script>
  <%--  <script src="/Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/modal.js" type="text/javascript"></script>
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/jquery.growl.css" rel="stylesheet" />--%>

  <%--<link href="/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="/Scripts/bootstrap.js" type="text/javascript"></script>--%>
    
  <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">--%>

  <%--<meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
 
     <!-- Latest compiled and minified CSS -->
<%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">--%>

<!-- Optional theme -->
<%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">--%>

<!-- Latest compiled and minified JavaScript -->
<%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>--%>
     
    <h2>Administrar Personas</h2>
    <%--<p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>
    
    <br />
    <br />
    <br />
    
    <div class="form-inline centrado" role="form">
    <div class="row">
        <div class="col-md-10">
        </div>
        <div class="row col-md-2">
            <div class="col-lg-12">
                <asp:Button ID="btnNUEVO" CssClass="btn btn-primary" runat="server" Text="Nuevo" OnClientClick="$('#myModal').modal('show');"/>
            </div> 
        </div>
    </div>
    </div>

    <div id="DivTablas3" >
        <span style="text-align: center">
            <span style="align-content:center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server"> 
                    <ContentTemplate>
                        <div class="table-responsive" style="overflow-x:auto">
                            <asp:GridView ID="GrdVw_Personas" runat="server" Width="940px"  HorizontalAlign="Center" OnRowCommand="GrdVw_Personas_RowCommand"
                        AutoGenerateColumns="false" DataKeyNames="IDPERSONA" CssClass="table table-hover table-striped" CellPadding="4" 
                        Font-Names="Segoe UI" ForeColor="#333333" GridLines="Vertical" style="text-align: left" PageSize="2" AllowPaging="true"
                        OnPageIndexChanging="GrdVw_Personas_PageIndexChanging" EnableModelValidation="true" OnRowDataBound="GrdVw_Personas_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                               <%-- <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle forecolor="Red" CssClass="table table-bordered" />
                                <emptydatatemplate> ¡No hay clientes con los �metros seleccionados!
                                </emptydatatemplate>  --%>       
                        <Columns>
                            <asp:ButtonField CommandName="Detalle" ControlStyle-CssClass="btn btn-info" ButtonType="Button" Text="Detalle" 
                                HeaderText="DETALLE" />
                            <asp:ButtonField CommandName="Editar" ControlStyle-CssClass="btn btn-primary" ButtonType="Button" Text="Editar" 
                                HeaderText="EDITAR" />
                            <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-default" ButtonType="Button" Text="Eliminar" 
                                HeaderText="ELIMINAR" />
                            <asp:BoundField DataField="IDPERSONA" HeaderText="IDPERSONA" />
                            <asp:BoundField DataField="IDENTIFICACION" HeaderText="IDENTIFICACION" />
                            <asp:BoundField DataField="TIPOIDENTIFICACION" HeaderText="TIPOIDENTIFICACION" />
                            <asp:BoundField DataField="FECHAEXPEDICION" HeaderText="FECHAEXPEDICION" />
                            <asp:BoundField DataField="FECHANACIMIENTO" HeaderText="FECHANACIMIENTO" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="APELLIDOS" HeaderText="APELLIDOS" />
                            <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" />
                            <asp:BoundField DataField="PAIS" HeaderText="PAIS" />
                            <asp:BoundField DataField="DEPTO" HeaderText="DEPTO" />
                            <asp:BoundField DataField="CIUDAD" HeaderText="CIUDAD" />
                            <asp:BoundField DataField="CORREO" HeaderText="CORREO" />
                            <asp:BoundField DataField="GENERO" HeaderText="GENERO" />
                            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" />
                            <asp:BoundField DataField="MOVIL" HeaderText="MOVIL" />
                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                            <asp:BoundField DataField="ACTIVO" HeaderText="ACTIVO" />
                            <asp:BoundField DataField="IDUSUARIOCREO" HeaderText="IDUSUARIOCREO" />
                            <asp:BoundField DataField="FECHACREO" HeaderText="FECHACREO" />
                            <asp:BoundField DataField="IDUSUARIOMODIFICO" HeaderText="IDUSUARIOMODIFICO" />
                            <asp:BoundField DataField="FECHAMODIFICO" HeaderText="FECHAMODIFICO" />
                        </Columns>
                        <%--<EditRowStyle BackColor="#2461BF" />--%>
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" /> 
                        <headerstyle BackColor="LightBlue" Font-Bold="True" ForeColor="Black" />
                        <pagerstyle BackColor="LightBlue" ForeColor="Black" HorizontalAlign="Center" />  
                        <RowStyle BackColor="#EFF3FB" ForeColor="#333333" Width="100%" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView> 
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </span>
        </span>
    </div>
    
    <div class="form-inline" role="form">
        <span style="text-align:start">
            <span style="align-content: flex-start">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal fade bs-example-modal-lg" role="dialog" id="myModal" tabindex="-1" aria-labelledby="myLargeModalLabel" style="display: none;"> 
        <div class="modal-dialog modal-lg" role="document" style=" width: initial;"> 
            <div class="modal-content" >
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button> 
                    <h4 class="modal-title" id="myModalLabel">Editar Persona</h4> 
                </div> 
                <div class="modal-body">
                     <div class="form-inline centrado" role="form">
        
        <div class="row">
            
            <div class="col-md-2">
                <a ><img class="img-responsive" src="imagenes/loMagdalena.jpg" style="height: 160px;width: 160px;"></a>
            </div>
            
            <div class="row col-md-5">
                <div class=""><label class="control-label" for="txt_nombres">Nombres:</label></div>
                <div class="col-lg-12">
                    <asp:TextBox  CssClass="form-control" id="txt_nombres" placeholder="Nombres de la persona"  runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-5">
                <div class="col-lg-12"><label class="control-label" for="txt_apellidos">Apellidos:</label></div>
                <div class="col-lg-12">
                    <asp:TextBox type="text" CssClass="form-control" id="txt_apellidos" placeholder="Apellidos de la persona" runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-5">
                <div class="col-lg-12"><label class="control-label" for="txt_NumeroId">Identificacion:</label></div>
                <div class="col-lg-12">
                    <asp:TextBox type="number" CssClass="form-control" id="txt_NumeroId" placeholder="Numero Identificacion" runat="server" required />
                </div>
            </div>
            
            <div class="row col-md-5">
                <div class="col-lg-12"><label class="control-label" for="cbo_tipoId">Tipo Identificacion:</label></div>
                <div class="col-lg-12">
                    <asp:DropDownList CssClass="form-control" ID="cbo_tipoId" placeholder="Seleccione Tipo ID" runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-5">
                <div class="col-lg-12"><label class="control-label" for="dtpFechaExpedicion">Fecha Expedición:</label></div>
                <div class="col-lg-12">
                    <asp:TextBox type="date" CssClass="form-control" ID="dtpFechaExpedicion" placeholder="mm/dd/aaaa" runat="server" required/>
                </div>
            </div>

            <div class="row col-md-5">
                <div class="col-lg-12"><label class="control-label" for="dtpFechaNacimiento">Fecha Nacimiento:</label></div>
                <div class="col-lg-12">
                    <asp:TextBox type="date" CssClass="form-control" ID="dtpFechaNacimiento" placeholder="mm/dd/aaaa" runat="server" required/>
                </div>
            </div>
    
        </div>
        
        <div class="row">
            
            <div class="col-lg-7 row control">

                <div class="col-lg-12">
                    <label class="control-label" for="txtDireccion">Correspondencia:</label>
                </div>
                <div class="col-lg-12 col-md-9">
                    <asp:TextBox type="text" CssClass="form-control" ID="txtDireccion" placeholder="Seleccione Tipo ID" runat="server" required/>
                </div>

            </div>
            
            <div class="col-lg-5 row control">
                <div class="col-lg-12">
                    <label class="control-label" for="cboGenero">Genero:</label>
                </div>
                <div class="col-lg-12 col-md-9">
                    <asp:DropDownList CssClass="form-control" ID="cboGenero" placeholder="seleccione Genero" runat="server" required/>
                </div>
            </div>
        
        </div>
        
        <div class="row">
            
            <div class="col-lg-12 row">
                <div class="col-lg-4 row control">

                    <div class="col-lg-12">
                        <label class="control-label" for="cboPais">País:</label>
                    </div>
                    <div class="col-lg-12 col-md-9" style="padding-right: 0px;">
                        <asp:DropDownList CssClass="form-control" ID="cboPais" placeholder="Seleccione País" runat="server" required/>
                    </div>

                </div>
                <div class="col-lg-4 row control">
                    <div class="col-lg-12">
                        <label class="control-label" for="cboDepto">Departamento:</label>
                    </div>
                    <div class="col-lg-12 col-md-9" style="padding-right: 0px;">
                        <asp:DropDownList CssClass="form-control" ID="cboDepto" placeholder="Seleccione Departamento" runat="server" required/>
                    </div>
                </div>
                <div class="col-lg-4 row control">
                    <div class="col-lg-12">
                        <label class="control-label" for="cboCiudad">Ciudad:</label>
                    </div>
                    <div class="col-lg-12 col-md-9">
                        <asp:DropDownList CssClass="form-control" ID="cboCiudad" placeholder="Seleccione ciudad" runat="server" required/>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="row">
            
            <div class="col-lg-10 row control">

                <div class="col-lg-12">
                    <label class="control-label" for="TextCorreoElectronico">Correo electronico:</label>
                </div>
                <div class="col-lg-12 col-md-9">
                    <asp:TextBox type="email" CssClass="form-control" ID="TextCorreoElectronico" placeholder="registre el correo electronico" runat="server" required/>
                </div>
            </div>
        
        </div>
        
        <div class="row">
            
            <div class="col-lg-10 row">
                <div class="col-lg-6 row control">

                    <div class="col-lg-12">
                        <label class="control-label" for="txtTelefono">Telefono:</label>
                    </div>
                    <div class="col-lg-12 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="number" CssClass="form-control" ID="txtTelefono" placeholder="Numero telefono fijo" runat="server" required/>
                    </div>

                </div>
                <div class="col-lg-6 row control">
                    <div class="col-lg-12">
                        <label class="control-label" for="txtCelular">Celular:</label>
                    </div>
                    <div class="col-lg-12 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="number" CssClass="form-control" ID="txtCelular" placeholder="Numero celular" runat="server" required/>
                    </div>
                </div>
            </div>

<%--            <div class="col-lg-4 row control" >
                <div class="col-lg-3 col-md-9">
                <asp:Button ID="BtnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
            </div>
            <div class="col-lg-3 col-md-9">
                <asp:Button CssClass="btn btn-default" runat="server" Text="Cancelar" />
            </div>
            </div>
        --%>
        </div>
        
    </div>
                </div> 
                <div class="modal-footer"> 
                    <button type="button" class="btn btn-default" data-dismiss="modal">calcelar</button> 
                    <asp:Button ID="BTNMODALGUARDAR" OnClientClick="$('#myModal').modal('hide');" OnClick="BtnGuardar_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                   <%-- <button id="BTNMODALGUARDAR" type="button" class="btn btn-primary" onclick="BTNMODALGUARDAR_Click">Guardar</button>--%>
                </div> 
            </div> 
        </div> 
    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </span>
        </span>
    </div>
    
    <div class="form-inline" role="form">
        <span style="text-align:start">
            <span style="align-content: flex-start">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="modal fade bs-example-modal-lg" role="dialog" id="myModalDetail" tabindex="-1" aria-labelledby="myLargeModalLabel" style="display: none;">
                            <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                        <h4 class="modal-title" id="myModalDetailLabel">Detalle Persona</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-inline centrado" role="form">
                                            <div class="row">
                                                <div class="row col-md-12">
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblIDPERSONA"><strong> IdPersona:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblIDPERSONA" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblIDENTIFICACION"><strong> Identificación:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblIDENTIFICACION" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblTIPOIDENTIFICACION"><strong> TipoIdentificación:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblTIPOIDENTIFICACION" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblFECHAEXPEDICION"><strong> FechaDeExpedición:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblFECHAEXPEDICION" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblFECHANACIMIENTO"><strong> FechaDeNacimiento:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblFECHANACIMIENTO" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblNOMBRE"><strong> Nonmbre:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblNOMBRE" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblApellidos"><strong> Apellidos:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblApellidos" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblDIRECCION"><strong> Dirección:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblDIRECCION" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblPAIS"><strong> País:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblPAIS" class="control-label" runat="server">-</label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblDEPTO"><strong> Depto:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblDEPTO" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblCIUDAD"><strong> Ciudad:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblCIUDAD" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblCORREO"><strong> Correo:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblCORREO" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblGENERO"><strong> Genero:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblGENERO" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblTELEFONO"><strong> Telefono:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblTELEFONO" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblMOVIL"><strong> Móvil:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblMOVIL" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblIDUSUARIOCREO"><strong> IdUsuario:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblIDUSUARIOCREO" class="control-label" runat="server">-</label>
                                                    </div>  
                                                    <div class="col-lg-6">
                                                        <label class="control-label" for="LblFECHACREO"><strong> FechaCreo:</strong></label>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <label id="LblFECHACREO" class="control-label" runat="server">-</label>
                                                    </div>  
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </span>
        </span>
    </div>
    
 </asp:Content>

