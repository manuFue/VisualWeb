<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="INFORMECompra.aspx.cs" Inherits="InformeCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <br />
                <h1 style="text-align: center">Informe de Compras</h1>
                <br />
                <br />
            </div>
            <div class="col-md-2"></div>
        </div>

        <div class="row">
           
           
            <div class="col-md-6">

                <fieldset>
                    <legend>Datos</legend>
                     <div class="form-group">
                           <div class="row">
                              <div class="col-md-2">
                                   <label for="txtCuit">Proveedor</label>
                              </div> 
                              <div class="col-md-8">

                               <asp:DropDownList ID="cboproveedor" CssClass="form-control" runat="server" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="0">&lt;Selecione una Proveedor &gt;</asp:ListItem>
                                </asp:DropDownList>

                              </div>
                              <div class="col-md-2">  </div>  
                         </div>
                        </div>

                     <div class="form-group form-inline">
                           <div class="row">
                              <div class="col-md-2">
                                   <label for="txtFD">Fecha Desde</label>
                             </div>
                             <div class ="col-md-3">
                                    <asp:TextBox ID="txtFD" runat="server" placeholder="dd/mm/aaaa" CssClass="form-control" Width="120px" MaxLength="10"></asp:TextBox>
                                    <asp:CompareValidator ID="cvFD" runat="server"
                                    ControlToValidate="txtFD" Type="Date" Operator="DataTypeCheck"
                                    ErrorMessage="Fecha invalida" Text="*" ForeColor="Red" ValidationGroup="A"></asp:CompareValidator>
                             </div>
                              
                         <div class="col-md-2">
                                   <label for="txtFH">Fecha Hasta</label>
                         </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFH" runat="server" placeholder="dd/mm/aaaa" CssClass="form-control" Width="120px" MaxLength="10"></asp:TextBox>
                            <asp:CompareValidator ID="cvFH" runat="server"
                            ControlToValidate="txtFH" Type="Date" Operator="DataTypeCheck"
                            ErrorMessage="Fecha invalida" Text="*" ForeColor="Red" ValidationGroup="A"></asp:CompareValidator>
                        </div>
                               <div class="col-md-2"></div>
                     </div>
                         </div>

                    

                     <div class="form-group">
                           <div class="row">
                              <div class="col-md-2">
                                   <label for="txtCuit">Insumo</label>
                              </div> 
                              <div class="col-md-8">

                                
                                <asp:DropDownList ID="cboInsumos" CssClass="form-control" runat="server" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="0">&lt;Selecione un Insumo &gt;</asp:ListItem>
                                </asp:DropDownList>

                              </div>
                              <div class="col-md-2">  </div>  
                         </div>
                        </div>

                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="150px" CssClass="btn btn-default" OnClick="btnBuscar_Click"/>
                    </fieldset>
                <br />
                 <div class="form-gropu">
                        <asp:TextBox ID="txtResultado" runat="server" TextMode="MultiLine" Columns="70" Rows="5"></asp:TextBox>
                    </div>
                </div>
            <div class="col-md-6">

                <div class="form-group" style ="height:400px; width:600px; overflow:auto;" runat="server">
                    <asp:GridView ID="gdrGrilla" AutoGenerateColumns ="False" runat="server" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="descripcion" HeaderText="Insumo" />
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="nombreEmpresa" HeaderText="Empresa" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:d}" />
                    </Columns>

                </asp:GridView> 
                </div>
                
            </div>
           

        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" Runat="Server">
     <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
  <script>
      $(function () {
          $("#txtFD").datepicker({ dateFormat: 'dd/mm/yy' }).val();
          $("#txtFH").datepicker({ dateFormat: 'dd/mm/yy' }).val();

      });
  </script>
</asp:Content>
