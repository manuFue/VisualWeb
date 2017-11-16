<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CUCENTRALFactura.aspx.cs" Inherits="CUCENTRALFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <br />
            <h1 style="text-align: center">CUCentralFactura</h1>
            <br />
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <div class="row">

        <div class="col-md-6">



            <fieldset>
                <legend>Paciente</legend>
                <div class="form-group">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" Columns="50" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtApellido">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" Columns="50" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNroDoc">Nro Documento</label>
                    <asp:TextBox ID="txtNroDoc" runat="server" Columns="10" Enabled="false"></asp:TextBox>
                </div>
            </fieldset>
            <br />
            <br />
            <br />
            <fieldset>
                <legend>Factura</legend>


                <div class="form-group">
                    <label for="txtNroFactura">Nro Factura</label>
                    <asp:TextBox ID="txtNroFactura" runat="server" Enabled="false" Columns="5"></asp:TextBox>

                </div>
                <br />
                <div class="form-group">
                    <div style="width: 80%; height: 160px; overflow: scroll">

                        <asp:GridView ID="gdvFactura" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="NroFactura" HeaderText="Nro Factura" />
                                <asp:BoundField DataField="CodIntervencion" HeaderText="Codigo Intervencion" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}"/>
                                <asp:BoundField DataField="CantidadAbonada" HeaderText="Cantidad Abonada" DataFormatString="{0:C}"/>
                            </Columns>
                        </asp:GridView>

                    </div>


                </div>
                <div class="form-group">
                    <label for="txtTotal">Total</label>
                    <asp:TextBox ID="txtTotal" runat="server" Columns="7" Enabled="false"></asp:TextBox>
                </div>
                <br />
                <div class="form-inline">
                    <label for="txtFecha">Fecha</label>
                    <asp:TextBox ID="txtFecha" runat="server" Columns="10" Enabled="false"></asp:TextBox>
                    
                    <label for="txtMonto">Monto</label>
                    <asp:TextBox ID="txtMonto" runat="server" Columns="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMonto" runat="server"
                        ControlToValidate="txtMonto" Text="*" ErrorMessage="Falta ingresar el monto"
                        ValidationGroup="C" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvMonto" runat="server"
                        ControlToValidate="txtMonto" Text="*" ErrorMessage="Nro invalido"
                        ValidationGroup="C" ForeColor="Red" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                    <asp:RangeValidator ID="rvMonto" runat="server"
                        ControlToValidate="txtMonto" Text="*" ErrorMessage="el nro debe ser entre 1 y 100000"
                        ValidationGroup="C" ForeColor="Red" Type="Double" MinimumValue="1" MaximumValue="100000"></asp:RangeValidator>

                    <label for="cboForma">Forma de Pago</label>
                    <asp:DropDownList ID="cboForma" runat="server" AppendDataBoundItems>
                        <asp:ListItem Value="0">&lt;Sin seleccionar&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:ValidationSummary ID="vsSummary" runat="server" ShowMessageBox="true"  ValidationGroup="C" ForeColor="Red" />
            </fieldset>
            
            <br />
            <div class="form-inline">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" ValidationGroup="C" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelar_Click" />

            </div>
            <br />
            <div class="form-group">
                <asp:TextBox ID="txtResultado" runat="server" TextMode="MultiLine" Columns="70" Rows="5"></asp:TextBox>
            </div>


        </div>
        <div class="col-md-6">
            <fieldset>
                <legend>Consultar</legend>
                <div class="form-inline">
                    <label for="txtBuscarPac">Nombre Paciente:</label>
                    <asp:TextBox ID="txtBuscarPac" runat="server" placeholder="buscar paciente" Columns="50"></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />
                </div>
                <br />
                <div class="form-group">


                    <div style="width: 90%; height: 160px; overflow: scroll">
                        <asp:GridView ID="gdvPacFac" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnSelectedIndexChanged="gdvPacFac_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="DescripcionTD" HeaderText="Tipo Documento" />
                                <asp:BoundField DataField="NroDoc" HeaderText="Nro Documento" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </fieldset>

            <br />
            <div class="form-group">
                <fieldset>
                    <legend>Intervenciones</legend>
                    <div style="width: 100%; height: 160px; overflow: scroll">
                        <div class="form-group">
                            <asp:GridView ID="gdvIntervenciones" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnSelectedIndexChanged="gdvIntervenciones_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="codIntervencion" HeaderText="CodigoIntervencion" Visible="False" />
                                    <asp:BoundField DataField="descripcionTratamiento" HeaderText="Tratamiento" />
                                    <asp:BoundField DataField="montoTotal" HeaderText="Total" DataFormatString="{0:C}"/>
                                    <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                                    <asp:BoundField DataField="descripcionCondicion" HeaderText="Condicion" />
                                </Columns>
                            </asp:GridView>
                        </div>


                    </div>

                </fieldset>
            </div>


        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>

