<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Compras.aspx.cs" Inherits="Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
        <div class="row" >
            <div class="col-md-2"></div>
            <div class="col-md-5">
                <br />
                <h1 style="text-align: center">Compras</h1>
                <br />
                <br />
            </div>
            <div class="col-md-2"></div>
        </div>

       <div class="row">
           <div class="col-md-6">
                <fieldset id="Proveedores">
                        <legend>Proveedor</legend>
                        <asp:DropDownList ID="cboProveedor" CssClass="form-control" runat="server"  AppendDataBoundItems="true" >
                        <asp:ListItem Value="0">&lt;Selecione un Proveedor &gt;</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProveedor"
                                       runat="server"
                                      ControlToValidate="cboProveedor"
                                      ErrorMessage="Selecione un Proveedor"
                                      Text="*"
                                      ValidationGroup="A"
                                      InitialValue="0" >
                            </asp:RequiredFieldValidator>
                                        
                            
                </fieldset>
                <br />
                <fieldset id="Insumos">
                    <legend>Insumos</legend>
                    <asp:DropDownList ID="cboInsumos" CssClass="form-control" runat="server" AppendDataBoundItems="true" >
                    <asp:ListItem Value="0">&lt;Selecione un Insumo &gt;</asp:ListItem>
                    </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="rfvInsumo"
                                       runat="server"
                                      ControlToValidate="cboInsumos"
                                      ErrorMessage="Selecione un Insumo"
                                      Text="*"
                                      ValidationGroup="A"
                                      InitialValue="0" >
                            </asp:RequiredFieldValidator>
                    <br />
                    <div class="form-inline">
                          <div class="col-md-2">
                                <label for="txtCantidad">Cantidad</label>
                          </div>
                          
                          <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="Ingrese la cantidad"></asp:TextBox> 
                          <asp:RequiredFieldValidator ID="rfvCantidad"
                                      runat="server"
                                      ControlToValidate="txtCantidad"
                                      ErrorMessage="Ingrese una Cantidad"
                                      Text="*"
                                      ValidationGroup="A">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="rfvCantidad2"
                                           runat ="server"
                                           ControlToValidate="txtCantidad"
                                           ErrorMessage="*Ingrese Valores Numericos"
                                           ForeColor="Red"
                                           ValidationExpression="^[0-9]*"
                                            ValidationGroup="A">
                            </asp:RegularExpressionValidator>
                          
                    </div>
                    <br />
                    <div class="form-inline">
                        <div class="col-md-2">
                              <label for="txtPrecio">Precio Unitario</label>
                        </div>
                       
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ingrese Precio Unitario"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvPrecio"
                                      runat="server"
                                      ControlToValidate="txtPrecio"
                                      ErrorMessage="Ingrese una Precio"
                                      Text="*"
                                      ValidationGroup="A">
                          </asp:RequiredFieldValidator>
                         <asp:CompareValidator ID="CompareValidator1" 
                             runat="server" 
                             ControlToValidate="txtPrecio"
                             ErrorMessage="Ingrese un valor numerico" 
                             Operator="DataTypeCheck" 
                             Type="Currency"
                             Text ="*"
                             ValidationGroup="A">
                             
                         </asp:CompareValidator>
                        
                    </div>
               </fieldset>
               <br />
              <div class="form-group">
              <asp:Button ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-primary" Width="150px" OnClick="btnAgregar_Click" ValidationGroup="A" />
              <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" CssClass="btn btn-danger" Width="150px" OnClick="btnCancelar_Click" />
              <asp:Button ID="btnGuardar" Text="GUARDAR" runat="server" CssClass="btn btn-success" Width="150px" OnClick="btnGuardar_Click" />
              </div>
               <asp:TextBox ID="txtResultado" runat="server" Visible="false" CssClass =" form-control"></asp:TextBox>
               <br />
            
               <div class="form-group">
                        <asp:ValidationSummary ID="valResumen"
                            runat="server" ValidationGroup="A" ForeColor="Red" ShowMessageBox="True" />
               </div>
          </div>

            

          <div class="col-md-6">

                 <div class="form-group">
                     <div class="row">
                          <div class="col-md-6">
                       <label>|Insumos de  la Compra|</label>
                   </div>
                   <div class="col-md-6 form-inline">
                       <label For="txtTotal">TOTAL: </label>
                       <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"  Width="100px" placeholder="0" Enabled="false"></asp:TextBox>
                   </div>
                     </div>
                  
                    
               </div>

               <div class ="form-group"  style ="height:320px; width:500px; overflow:auto;">
                     <asp:GridView ID="gdrInsumos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                      <Columns>
                       <asp:BoundField DataField="idProveedor" HeaderText="IdProveedor" Visible="False" />
                       <asp:BoundField DataField="fechaHora" HeaderText="fechaHora" Visible="False" />
                       <asp:BoundField DataField="codInsumo" HeaderText="codInsumo" Visible="False" />
                       <asp:BoundField DataField="descripcion" HeaderText="Insumo" />
                       <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                       <asp:BoundField DataField="precioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                   </Columns>
                </asp:GridView>
               </div>

             

          </div>
       </div>

        
            
       

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" Runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>

