<%@ Page Title="PERSONASCERRegistrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PERSONASCERRegistrar.aspx.cs" Inherits="PERSONASCERRegistrar" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="/Scripts/jquery.growl.js" type="text/javascript"></script>
     <link href="/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="/Scripts/bootstrap.js" type="text/javascript"></script>
   
      <h2>GESTION DE PERSONAS</h2>
    
    <div class="form-inline centrado" role="form">
        <div class="row">
            <div class="col-md-2">
                <a><asp:Image ID="Image2" runat="server" ImageUrl="" class="img-responsive" style="height: 160px;width: 160px;" /> </a>
                <%--<a><asp:Image ID="Image1" runat="server" ImageUrl="~/Img/logo.png"class="img-responsive" src="imagenes/loMagdalena.jpg" style="height: 160px;width: 160px;" /></a>--%>
            </div>
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="txtNombres">Nombres:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox  CssClass="form-control" id="txtNombres" placeholder="Nombres de la persona"  runat="server" required/>
                </div>
            </div>
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="txtApellidos">Apellidos:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox type="text" CssClass="form-control" id="txtApellidos" placeholder="Apellidos de la persona" runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="txtIdentificacion">Numero de Identificacion:</label></div>
                <div class="col-lg-10">
                    <asp:TextBox type="number" CssClass="form-control" id="txtIdentificacion" placeholder="Numero Identificacion" runat="server" required />
                </div>
            </div>
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="cbo_tipoId">Cargo:</label></div>
                <div class="col-lg-10">
                  <asp:TextBox type="text" CssClass="form-control" id="txtCargo" placeholder="Cargo" runat="server" required/>
                </div>
            </div>
            
            <div class="row col-md-4">
                <div class="col-lg-10"><label class="control-label" for="cbo_tipoId">Subir Foto:</label></div>
                <div class="col-lg-10">
                    <asp:FileUpload id="FileUploadControl" runat="server" CssClass="form-control" />
                </div>
                <div class="col-lg-10">
                    <asp:Label runat="server" id="StatusLabel" text="Status de Carga: " type="text" CssClass="form-control" />
                </div>
                <div class="col-lg-10">
                    <asp:Button runat="server" id="UploadButton" text="Subir" onclick="UploadButton_Click" CssClass="btn btn-primary"/>
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
                    <asp:TextBox type="text" CssClass="form-control" ID="txtDireccion" placeholder="Direccion" runat="server" required/>
                </div>

            </div>

        </div>
        <div class="row">
            <div class="col-lg-6 row">
                <div class="col-lg-6 row control">

                    <div class="col-lg-10">
                        <label class="control-label" for="txtDependencia">Dependencia:</label>
                    </div>
                    <div class="col-lg-11 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="text" CssClass="form-control" ID="txtDependencia" placeholder="Funciones" runat="server" required/>
                    </div>

                </div>
                <div class="col-lg-7 row control">
                    <div class="col-lg-10">
                        <label class="control-label" for="txtFunciones">Funciones:</label>
                    </div>
                    <div class="col-lg-10 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="text" CssClass="form-control" ID="txtFunciones" placeholder="Funciones" runat="server" required/>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 row control">
                <div class="col-lg-10">
                    <label class="control-label" for="txtSueldo">sueldo:</label>
                </div>
                <div class="col-lg-10 col-md-9">
                    <asp:TextBox type="number" CssClass="form-control" ID="txtSueldo" placeholder="Sueldo" runat="server" required/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 row control">

                <div class="col-lg-10">
                    <label class="control-label" for="txtEmail">Correo electronico:</label>
                </div>
                <div class="col-lg-11 col-md-9">
                    <asp:TextBox type="email" CssClass="form-control" ID="txtEmail" placeholder="registre el correo electronico" runat="server" required/>
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
                        <label class="control-label" for="txtMovil">Numero Celular:</label>
                    </div>
                    <div class="col-lg-10 col-md-9" style="padding-right: 0px;">
                        <asp:TextBox type="number" CssClass="form-control" ID="txtMovil" placeholder="Numero celular" runat="server" required/>
                    </div>
                </div>
            </div>
            
         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
            </div>
        </div>
            <div class="col-lg-4 row control">
                <div class="col-lg-3 ">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Guardar" CssClass="btn btn-primary" />
            </div>
            <div class="col-lg-3 ">
                <asp:Button CssClass="btn btn-default" runat="server" Text="Cancelar" data-toggle="modal" data-target="#myModal"/>
            </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div id="DivTablas" class="table-responsive" >
        <span style="text-align: center">
            <span style="align-content:center">
                  <asp:UpdatePanel ID="udpMantUsuario" runat="server">
                       <ContentTemplate>
                 <asp:GridView ID="grdLista" HorizontalAlign="Center" runat="server" AutoGenerateColumns="false" CellPadding="4" 
                     Font-Names="Segoe UI" ForeColor="#333333" GridLines="None" style="text-align: left" PageSize="5" AllowPaging="true" 
                     DataKeyNames="IDPERSONA" OnPageIndexChanging="grdLista_PageIndexChanging" OnRowCancelingEdit="grdLista_RowCancelingEdit"
                     OnRowEditing="grdLista_RowEditing" OnRowUpdating="grdLista_RowUpdating" OnRowCommand="grdLista_RowCommand" 
                     EnableModelValidation="true" OnRowDeleting="grdLista_RowDeleting" Width="100%" OnRowDataBound="grdLista_RowDataBound">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <columns>
                      <asp:CommandField ShowEditButton="True" />
                
                     <asp:TemplateField HeaderText="Id Persona">
                        <EditItemTemplate> 
                            <asp:TextBox ReadOnly="true" type="number" CssClass="form-control" ID="txtIDPERSONA" runat="server" Text='<%# Bind("IDPERSONA") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ReadOnly="true" type="number" runat="server" Text='<%# Bind("IDPERSONA") %>' ID="Label1"  Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Nombres">
                        <EditItemTemplate> 
                            <asp:TextBox type="text" CssClass="form-control" ID="txtNOMBRES"  runat="server" Text='<%# Bind("NOMBRE") %>'  Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label type="text" runat="server" Text='<%# Bind("NOMBRE") %>' ID="Label2" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellidos">
                        <EditItemTemplate> 
                            <asp:TextBox type="text" CssClass="form-control" ID="txtAPELLIDOS" runat="server" Text='<%# Bind("APELLIDOS") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label type="text" runat="server" Text='<%# Bind("APELLIDOS") %>' ID="Label3" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Identificación">
                        <EditItemTemplate> 
                            <asp:TextBox  type="number" CssClass="form-control" ID="txtIDENTIFICACION" runat="server" Text='<%# Bind("IDENTIFICACION") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label  type="number" runat="server" Text='<%# Bind("IDENTIFICACION") %>' ID="Label4" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="FECHA DE NACIMIENTO">
                        <EditItemTemplate> 
                            <asp:TextBox type="date" CssClass="form-control" ID="dtpFechaNacimiento" placeholder="mm/dd/aaaa" runat="server" Text='<%# Bind("FECHANACIMIENTO") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label  type="number" runat="server" Text='<%# Bind("FECHANACIMIENTO") %>' ID="Label5" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
     
                    <asp:TemplateField HeaderText="Email">
                        <EditItemTemplate> 
                            <asp:TextBox type="email" CssClass="form-control" ID="txtEMAIL" runat="server" Text='<%# Bind("EMAIL") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label  type="email" runat="server" Text='<%# Bind("EMAIL") %>' ID="Label6" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cargo">
                        <EditItemTemplate> 
                            <asp:TextBox type="text" CssClass="form-control" ID="txtCARGO" runat="server" Text='<%# Bind("CARGO") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label type="text" runat="server" Text='<%# Bind("CARGO") %>' ID="Label7" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dependencia">
                        <EditItemTemplate> 
                            <asp:TextBox type="text" CssClass="form-control" ID="txtDEPENDENCIA" runat="server" Text='<%# Bind("DEPENDENCIA") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label type="text" runat="server" Text='<%# Bind("DEPENDENCIA") %>' ID="Label8" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Funciones">
                        <EditItemTemplate> 
                            <asp:TextBox type="text" CssClass="form-control" ID="txtFUNCIONES" runat="server" Text='<%# Bind("FUNCIONES") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label type="text" runat="server" Text='<%# Bind("FUNCIONES") %>' ID="Label9" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="Sueldo">
                        <EditItemTemplate> 
                            <asp:TextBox type="number" CssClass="form-control" ID="txtSUELDO" runat="server" Text='<%# Bind("SUELDO") %>' Width="100%"/>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label type="number" runat="server" Text='<%# Bind("SUELDO") %>' ID="Label10" Width="100%"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ACTIVO">
                            <EditItemTemplate> 
                                 <asp:DropDownList ID="DrpACTIVO" CssClass="form-control" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="DrpACTIVO_SelectedIndexChanged" 
                                        SelectedValue='<%# Bind("ACTIVO") %>' Width="100%">
                                    <asp:ListItem>SI</asp:ListItem>
                                    <asp:ListItem>NO</asp:ListItem>
                                </asp:DropDownList>
                        </EditItemTemplate>
                                <ItemTemplate>
                            <asp:Label type="text" runat="server" Text='<%# Bind("ACTIVO") %>' ID="Label11" Width="100%"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                
                </columns>
                <EditRowStyle BackColor="#2461BF" />
                <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />              
                <headerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />              
                <pagerstyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />              
                <RowStyle BackColor="#EFF3FB" ForeColor="#333333" Width="100%" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
              </asp:GridView>
                       </ContentTemplate>
                </asp:UpdatePanel>
            </span>
        </span>
    </div>

    <br />
    <br />
    
    <div id="DivTablas2">
        <span style="text-align: center">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdLista2" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" Font-Names="Segoe UI" ForeColor="#333333" GridLines="None" style="text-align: left" 
                        OnRowDataBound="grdLista2_RowDataBound" OnRowCommand="grdLista2_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <columns>

                            <asp:BoundField HeaderText="IdPersona" DataField="IDPERSONA" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />   
                            </asp:BoundField>
                            
                            <asp:BoundField HeaderText="NOMBRES" DataField="NOMBRE" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                    
                            <asp:BoundField HeaderText="Apellidos" DataField="APELLIDOS" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />       
                            </asp:BoundField>
                            
                            <asp:BoundField HeaderText="Identificación" DataField="IDENTIFICACION">
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />  
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="Email" HeaderText="EMAIL" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />  
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" /> 
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="Cargo" HeaderText="CARGO" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                    
                            <asp:BoundField DataField="Dependencia" HeaderText="DEPENDENCIA" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" /> 
                            </asp:BoundField> 
                    
                            <asp:BoundField DataField="Funciones" HeaderText="FUNCIONES" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" /> 
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" /> 
                            </asp:BoundField>
                    
                            <asp:BoundField DataField="Sueldo" HeaderText="SUELDO" >
                                <headerstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <itemstyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" /> 
                            </asp:BoundField>
                
                          <%--  <asp:TemplateField HeaderText="Eliminar" >
                                 <itemtemplate>
                                     <asp:Button CssClass="btn btn-default" ID="BTNEliminar" runat="server" CommandName="cmdnameEliminar"
                                          CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar"
                                          type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal" > 
                                     </asp:Button>
                                 </itemtemplate>
                            </asp:TemplateField>--%>
                    
                    <%-- <asp:TemplateField HeaderText="Ver Información" >
                  <itemtemplate>
                    <asp:HyperLink ID="EditHyperLink1" runat="server" Target="_blank" 
                                      NavigateUrl=''
                                      Text="&lt;img src='IMAGES/imgUsuarioReg.png' alt='Clic para información detallada del usuario a crear o denegar' title='Clic para información detallada del usuario a crear o denegar' border='0'  /&gt;" style="margin-left:40%"> </asp:HyperLink>
                  </itemtemplate>
                    <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>--%>

                        </columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <footerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />   
                        <headerstyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />    
                        <pagerstyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />    
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </span>
    </div>
    
    <br />
    <br />

    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="imagenes/loMagdalena.jpg" alt="Loading.. Please wait!"/>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <div id="DivTablas3">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div>
                    <asp:GridView ID="GridView1" runat="server" Width="940px"  HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand"
                        AutoGenerateColumns="false" DataKeyNames="IDPERSONA" CssClass="table table-hover table-striped" CellPadding="4" 
                        Font-Names="Segoe UI" ForeColor="#333333" GridLines="Vertical" style="text-align: left" PageSize="2" AllowPaging="true"
                        OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="true" OnRowDataBound="GridView1_RowDataBound">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:ButtonField CommandName="Editar" ControlStyle-CssClass="btn btn-info" ButtonType="Button" Text="Editar" 
                                HeaderText="EDITAR" />
                            <asp:ButtonField CommandName="Eliminar" ControlStyle-CssClass="btn btn-default" ButtonType="Button" Text="Eliminar" 
                                HeaderText="ELIMINAR" />
                            <asp:BoundField DataField="IDPERSONA" HeaderText="IDPERSONA" />
                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="APELLIDOS" HeaderText="APELLIDOS" />
                            <asp:BoundField DataField="FECHANACIMIENTO" HeaderText="FECHANACIMIENTO" />
                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" />
                            <asp:BoundField DataField="MOVIL" HeaderText="MOVIL" />
                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                            <asp:BoundField DataField="ESTADOCIVIL" HeaderText="ESTADOCIVIL" />
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
                     
    <div class="modal fade" role="dialog" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" style="display: none;"> 
        <div class="modal-dialog" role="document"> 
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button> 
                    <h4 class="modal-title" id="myModalLabel">Modal title</h4> 
                </div> 
                <div class="modal-body">
                     <div class="form-horizontal">
                         <h3>Gestion de PERSONAS.</h3>
                         <hr />
                         <div class="form-group" id="DivNombresEDITAR">
                              <asp:Label runat="server" AssociatedControlID="txt_NOMBRES" CssClass="col-md-2 control-label">Nombres</asp:Label>
                              <div class="col-md-10">
                                   <asp:TextBox  CssClass="form-control" id="txt_NOMBRES" placeholder="Nombres de la persona"  runat="server" />
                              </div>
                              </div>
                          <div class="form-group" id="DivApellidosEDITAR">
                              <asp:Label runat="server" AssociatedControlID="txt_APELLIDOS" CssClass="col-md-2 control-label">Apellidos</asp:Label>
                              <div class="col-md-10">
                                  <asp:TextBox type="text" CssClass="form-control" id="txt_APELLIDOS" placeholder="Apellidos de la persona" runat="server" />
                              </div>
                          </div>
       
                         <div class="form-group" id="DivIdentificacionEDITAR">
                             <asp:Label runat="server" AssociatedControlID="txt_IDENTIFICACION" CssClass="col-md-2 control-label">Identificación</asp:Label>
                             <div class="col-md-10">
                                 <asp:TextBox type="number" CssClass="form-control" id="txt_IDENTIFICACION" placeholder="Numero Identificacion" runat="server"  />
                             </div>
                         </div>
                         <div class="form-group" id="DivEmailEDITAR">
                             <asp:Label runat="server" AssociatedControlID="txt_EMAIL" CssClass="col-md-2 control-label">Email</asp:Label>
                             <div class="col-md-10">
                                 <asp:TextBox type="email" CssClass="form-control" ID="txt_EMAIL" placeholder="registre el correo electronico" runat="server" />
                             </div>
                         </div>
                         <div class="form-group" id="DivTelefonoEDITAR">
                             <asp:Label runat="server" AssociatedControlID="txt_TELEFONO" CssClass="col-md-2 control-label">Telefono</asp:Label>
                             <div class="col-md-10">
                                 <asp:TextBox type="number" CssClass="form-control" ID="txt_TELEFONO" placeholder="Numero telefono fijo" runat="server" />
                             </div>
                         </div>
       
                         <div class="form-group" id="DivMovilEDITAR">
                            <asp:Label runat="server" AssociatedControlID="txt_MOVIL" CssClass="col-md-2 control-label">Móvil</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox type="number" CssClass="form-control" ID="txt_MOVIL" placeholder="Numero celular" runat="server" />
                            </div>
                        </div>

                         <div class="form-group" id="DivCargoEDITAR">
                            <asp:Label runat="server" AssociatedControlID="txt_CARGO" CssClass="col-md-2 control-label">Cargo</asp:Label>
                            <div class="col-md-10">
                                  <asp:TextBox type="text" CssClass="form-control" id="txt_CARGO" placeholder="Apellidos de la persona" runat="server" />
                            </div>
                        </div>
        
                         <div class="form-group" id="DivDependenciaEDITAR">
                            <asp:Label runat="server" AssociatedControlID="txt_DEPENDENCIA" CssClass="col-md-2 control-label">Dependencia</asp:Label>
                            <div class="col-md-10">
                                  <asp:TextBox type="text" CssClass="form-control" id="txt_DEPENDENCIA" placeholder="Apellidos de la persona" runat="server" />
                            </div>
                        </div>
        
                         <div class="form-group" id="DivFuncionesEDITAR">
                            <asp:Label runat="server" AssociatedControlID="txt_FUNCIONES" CssClass="col-md-2 control-label">Funciones</asp:Label>
                            <div class="col-md-10">
                                  <asp:TextBox type="text" CssClass="form-control" id="txt_FUNCIONES" placeholder="Apellidos de la persona" runat="server" />
                            </div>
                        </div>
        
                         <div class="form-group" id="DivSueldoEDITAR">
                            <asp:Label runat="server" AssociatedControlID="txt_SUELDO" CssClass="col-md-2 control-label">Sueldo</asp:Label>
                            <div class="col-md-10">
                                  <asp:TextBox type="text" CssClass="form-control" id="txt_SUELDO" placeholder="Apellidos de la persona" runat="server" />
                            </div> 
                         </div>
                     </div>
                </div> 
                <div class="modal-footer"> 
                    <button type="button" class="btn btn-default" data-dismiss="modal">calcelar</button> 
                    <asp:Button ID="BTNMODALGUARDAR" OnClientClick="$('#myModal').modal('hide');" OnClick="BTNMODALGUARDAR_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                   <%-- <button id="BTNMODALGUARDAR" type="button" class="btn btn-primary" onclick="BTNMODALGUARDAR_Click">Guardar</button>--%>
                </div> 
            </div> 
        </div> 
    </div>
    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </div>

</asp:Content>