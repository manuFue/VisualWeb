<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMCProveedores.aspx.cs" Inherits="ABMCProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <br />
                <h1 style="text-align: center">ABMC - Proveedores</h1>
                <br />
                <br />
            </div>
            <div class="col-md-2"></div>
        </div>

        <div class="row">
            

            </div>
            <div class="col-md-6">


                <%-- groupBox  DatosPersonales --%>
                <fieldset id="altaProveedor">
                    <fieldset id="DatosPersonales">
                        <legend>Datos Personales</legend>
                        <div class="form-group">


                         <div class="row">
                             <div class="col-md-2">
                                <label for="txtNombre">Nombre</label>
                             </div>
                             <div class="col-md-8">
                                <asp:TextBox ID="txtNombre" runat="server"  CssClass="form-control" placeholder="Ingrese el nombre" Columns="50"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvNombre"
                                runat="server"
                                ControlToValidate="txtNombre"
                                ErrorMessage="Ingrese un Nombre"
                                Text="*"
                                ValidationGroup="A">
                            </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2"></div>  

                         </div>

                        </div> 
                    
                            
                        
                        <div class="form-group">
                              <div class="row">
                              <div class="col-md-2">
                                 <label for="txtApellido">Empresa</label>
                              </div>
                              <div class="col-md-8">
                                     <asp:TextBox ID="txtEmpresa" runat="server" CssClass=" form-control" placeholder="Ingrese el Apellido" Columns="50"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfvApellido"
                                      runat="server"
                                      ControlToValidate="txtEmpresa"
                                      ErrorMessage="Ingrese una Empresa"
                                      Text="*"
                                      ValidationGroup="A">
                                      </asp:RequiredFieldValidator>

                              </div>
                            <div class="col-md-2"></div>  

                         </div>

                       </div>


                        <div class="form-group">
                           <div class="row">
                              <div class="col-md-2">
                                   <label for="txtCuit">Cuit</label>
                              </div> 
                              <div class="col-md-8">

                                <asp:TextBox ID="txtCuit" runat="server"  CssClass="form-control" placeholder="00-00000000-0" Columns="50"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rfvCuit"
                                runat="server" 
                                ControlToValidate ="txtCuit" 
                                ErrorMessage="Ingrese un Cuit valido" 
                                Text="*" 
                                ValidationExpression="(\d{2})([-]{1})(\d{8})([-]{1})(\d{1})" 
                                ValidationGroup ="A">
                                </asp:RegularExpressionValidator>

                              </div>
                              <div class="col-md-2">  </div>  
                         </div>
                        </div>
                          <div class="form-group">
                           <div class="row">
                              <div class="col-md-2">
                                   <label for="txtCuit">EMAIL</label>
                              </div> 
                              <div class="col-md-8">

                                <asp:TextBox ID="txtEmail" runat="server"  CssClass="form-control" placeholder="ejemplo@ejemplo.com"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                runat="server" 
                                ControlToValidate ="txtEmail" 
                                ErrorMessage="Ingrese un correo valido" 
                                Text="*" 
                                ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,3}$" 
                                ValidationGroup ="A">
                                </asp:RegularExpressionValidator>

                              </div>
                              <div class="col-md-2">  </div>  
                         </div>
                        </div>


                     
                    </fieldset>
                    <br />
                    <br />

                    <%--groupBox Domicilio--%>
                    <fieldset id="Domicilio">
                        <legend>Domicilio</legend>
                        <div class="form-group">
                            
                         <div class="row">
                             <div class="col-md-2">
                                 <label for="cboLocalidad">Localidad</label>
                             </div>
                             <div class="col-md-8">
                                <asp:DropDownList ID="cboLocalidad" CssClass="form-control" runat="server" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="0">&lt;Selecione una Localidad &gt;</asp:ListItem>
                                </asp:DropDownList>
                            
                                <asp:RequiredFieldValidator ID="rfvLocalidad"
                                runat="server"
                                ControlToValidate="cboLocalidad"
                                ErrorMessage="Seleccione una Localidad"
                                Text="*"
                                ValidationGroup="A">
                                </asp:RequiredFieldValidator>
                             </div>
                             <div class="col-md-2"></div>  
                        </div>
                     </div>

                     <div class="form-group form-inline">
                         <div class="row">
                             <div class="col-md-2">
                                  <label for="txtCalle">Calle</label>
                             </div>
                             <div class="col-md-4">
                                     <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Ingrese nombre de calle" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfvCalle"
                                     runat="server"
                                     ControlToValidate="txtCalle"
                                     ErrorMessage="Ingrese una direccion completa."
                                     Text="*"
                                     ValidationGroup="A">
                                    </asp:RequiredFieldValidator>
                             </div>
                             
                             <div class="col-md-2">       
                                    <label for="txtNroCalle">Nro calle</label>
                             </div>
                            <div class="col-md-4">
                                    <asp:TextBox ID="txtNroCalle" runat="server" CssClass="form-control"  placeholder="Nro calle" Columns="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNroCalle"
                                    runat="server"
                                    ControlToValidate="txtNroCalle"
                                    ErrorMessage="Ingrese una direccion completa"
                                    Text="*"
                                    ValidationGroup="A">
                                    </asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvNroCalle"
                                    runat="server"
                                    ControlToValidate="txtNroCalle"
                                    ErrorMessage="Ingrese un numero de calle válido"
                                    Type="Integer"
                                    Operator="DataTypeCheck"
                                    ValidationGroup="A">*</asp:CompareValidator>

                            </div>

                        </div>

                     </div>

                        <div class="form-group">
                            <div class="row">
                                 <div class="col-md-2">
                                    <label for="txtPiso">Piso</label>
                                 </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" placeholder="Piso" Columns="5"></asp:TextBox>
                                </div>
                                <div class="col-md-2"></div>
                                <div class="col-md-2">
                                    <label for="txtDepto">Departamento</label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtDepto" runat="server" CssClass="form-control" placeholder="Depto" Columns="5"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                        <div class="form-group">
                              <div class="row">
                                 <div class="col-md-2">
                                      <label for="txtTelefono">Telefono</label>
                                 </div>
                                 <div class="col-md-4">
                                      <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese telefono" Width="196px" ></asp:TextBox>
                                 </div>
                                                                 
                                 <div class="col-md-2">
                                      <label for="txtCelular">Celular</label>
                                 </div>
                                 <div class="col-md-2">
                                     <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Ingrese celular" ></asp:TextBox>

                                 </div>

                              </div>
                        </div>
            

                      <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="ckbActivo" runat="server" CssClass="form-control" Text="Proveedor Activo"></asp:CheckBox>
                            </label>
                        </div>

                        <div class="form-group">
                            
                         <div class="row">
                             <div class="col-md-2">
                                 <label for="cboLocalidad">Fecha de Alta</label>
                             </div>
                             <div class="col-md-8">
                                <asp:TextBox ID="txtFechaAlta" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFechaAlta"
                                runat="server"
                                ControlToValidate="txtFechaAlta"
                                ErrorMessage="Ingrese una fecha"
                                Text="*"
                                ValidationGroup="A">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rfvFechaAlta2"
                                    runat="server" 
                                    ControlToValidate="txtFechaAlta" 
                                    ErrorMessage="Ingrese fecha con el formato dd/mm/aaaa" 
                                    Text="*" 
                                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"
                                    ValidationGroup="A">      
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="compararFecha"
                                     runat="server"
                                     ErrorMessage="Fecha superior a la actual"
                                     Text="*"
                                     ControlToValidate="txtFechaAlta" 
                                    Type="Date" 
                                    Operator="LessThan"
                                    ValidationGroup="A">

                                </asp:CompareValidator>

                             </div>
                             <div class="col-md-2"></div>  
                        </div>
                     </div>
                        
                    </fieldset>

                             
                       

                      <div class="form-group">
                        <asp:ValidationSummary ID="valResumen"
                            runat="server" ValidationGroup="A" ForeColor="Red" ShowMessageBox="True" />
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Button ID="btnAceptar" Text="Guardar" runat="server" CssClass="btn btn-success" Width="150px" OnClick="btnAceptar_Click" ValidationGroup="A" />
                        <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" CssClass="btn btn-default" Width="150px" OnClick="btnCancelar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" Width="150px" OnClick="btnEliminar_Click"/>
                    </div>
                    <br />
                </fieldset>
                <div class="form-group" id="divResultado" runat="server" visible="false">
                    <label for="txtResultado">Clase cargada:</label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResultado" CssClass="form-control"></asp:TextBox>
                </div>
             

            </div>
            <div class="col-md-6">
                     <div class="form-group">
                    <label for="txtNombreBusucar">Buscar Proveedor por Empresa: </label>
                    <asp:TextBox runat="server" ID="txtEmpresaBuscar" CssClass=" form-control" placeholder=""></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />
                </div>
                <label>| Registro de Proveedores |</label>
                <div class="form-group" id="divGrilla" style ="height:800px; width:650px; overflow:auto;" runat="server">
                   <asp:GridView ID="grdGrilla" AutoGenerateColumns="False" DataKeyNames="idProveedor" runat ="server"  CssClass="table table-bordered"  OnSelectedIndexChanged="grdGrilla_SelectedIndexChanged">
                           <Columns>
                               <asp:CommandField ShowSelectButton="True" />
                               <asp:BoundField DataField="nombre" HeaderText="Nombre" Visible="False" />
                               <asp:BoundField DataField="nombreResponsable" HeaderText="Nombre Empresa" />
                               <asp:BoundField DataField="celular" HeaderText="Celular" Visible="False" />
                               <asp:BoundField DataField="eMail" HeaderText="eMail" />
                               <asp:BoundField DataField="descripcion" HeaderText="Localidad" />
                               <asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta" DataFormatString="{0:d}" />
                               <asp:CheckBoxField DataField="activo" Text="Activo" />
                               <asp:BoundField DataField="idProveedor" HeaderText="IdProveedor" Visible="False" />
                           </Columns>
                       </asp:GridView>
                    
                </div>
            </div>
             <script>
                 $(function () {
                     $("#txtFechaAlta").datepicker({ dateFormat: 'dd/mm/yy' }).val();
                 });
  </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" Runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
<%--  <script>
      $(function () {
          $("#txtFechaAlta").datepicker({ dateFormat: 'dd/mm/yy' }).val();
      });
  </script>--%>
</asp:Content>
