<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="INFORMEFactura.aspx.cs" Inherits="INFORMEFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <br />
            <h1 style="text-align: center">Facturas</h1>
            <br />
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <div class="row">

        <div class="col-md-6">

            <fieldset>
                <legend>Filtros Opcionales</legend>
                <div class="form-group">
                    <label for="txtNroFactura">Nro de Factura</label>
                    <asp:TextBox ID="txtNroFactura" runat="server" placeholder="Nro Factura" Columns="10" MaxLength="10"></asp:TextBox>
                    <asp:CompareValidator ID="cvNroFac" runat="server"
                        ControlToValidate="txtNroFactura" Type="Integer" Operator="DataTypeCheck"
                        ErrorMessage="Nro invalido" Text="*" ForeColor="Red" ValidationGroup="B"></asp:CompareValidator>
                    <asp:RangeValidator ID="rvFac" runat="server"
                        ControlToValidate="txtNroFactura" ErrorMessage="Nro entre 1 y 10000" Text="*"
                        MaximumValue="10000" MinimumValue="0" ValidationGroup="B" ForeColor="Red" Type="Integer"></asp:RangeValidator>
                </div>
                <div class="form-group">
                    <label for="txtNroDocumento">Nro de Documento</label>
                    <asp:TextBox ID="txtNroDocumento" runat="server" placeholder="Nro Documento" Columns="15" MaxLength="8"></asp:TextBox>
                    <asp:CompareValidator ID="cvNroDoc" runat="server"
                        ControlToValidate="txtNroDocumento" Type="Integer" Operator="DataTypeCheck"
                        ErrorMessage="Nro invalido" Text="*" ForeColor="Red" ValidationGroup="B"></asp:CompareValidator>
                    <asp:RangeValidator ID="rvDoc" runat="server"
                        ControlToValidate="txtNroDocumento" ErrorMessage="Nro entre 1 y 100000000" Text="*"
                        MaximumValue="100000000" MinimumValue="0" ValidationGroup="B" ForeColor="Red" Type="Integer"></asp:RangeValidator>

                </div>
                <div class="form-inline">
                    <label for="txtFD">Fecha Desde</label>
                    <asp:TextBox ID="txtFD" runat="server" placeholder="dd/mm/aaaa" Columns="10" MaxLength="10"></asp:TextBox>
                    <asp:CompareValidator ID="cvFD" runat="server"
                        ControlToValidate="txtFD" Type="Date" Operator="DataTypeCheck"
                        ErrorMessage="Fecha invalida" Text="*" ForeColor="Red" ValidationGroup="B"></asp:CompareValidator>
                    <label for="txtFH">Fecha Hasta</label>
                    <asp:TextBox ID="txtFH" runat="server" placeholder="dd/mm/aaaa" Columns="10" MaxLength="10"></asp:TextBox>
                    <asp:CompareValidator ID="cvFH" runat="server"
                        ControlToValidate="txtFH" Type="Date" Operator="DataTypeCheck"
                        ErrorMessage="Fecha invalida" Text="*" ForeColor="Red" ValidationGroup="B"></asp:CompareValidator>

                </div>
                <br />
                <div class="form-group">
                    <label for="cboFormaPago">Forma de Pago</label>
                    <asp:DropDownList ID="cboFormaPago" runat="server" AppendDataBoundItems>
                        <asp:ListItem Value="0">&lt;Sin seleccionar&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="B" CssClass="btn btn-success" OnClick="btnBuscar_Click" />

                </div>
                <br />
                <div class="form-group">
                    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ForeColor="Red" ValidationGroup="B" />
                </div>
                <br />
                <div class="form-gropu">
                    <asp:TextBox ID="txtResultado" runat="server" TextMode="MultiLine" Columns="70" Rows="5"></asp:TextBox>
                </div>
            </fieldset>


        </div>
        <div class="col-md-6">
            <div style="width: 170%; height: 300px; overflow: scroll">
                <asp:GridView ID="gdvGrillaInforme" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                        <asp:BoundField DataField="NroDoc" HeaderText="NroDocumento" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="NroFactura" HeaderText="NroFactura" />
                        <asp:BoundField DataField="descripcionTratamiento" HeaderText="Tratamiento" />
                        <asp:BoundField DataField="MontoTotal" HeaderText="Monto" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="CantidadAbonada" HeaderText="Cantidad Abonada" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}"/>
                        <asp:BoundField DataField="DescripcionFP" HeaderText="Forma de Pago" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>

