<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="INFORMEIntervenciones.aspx.cs" Inherits="INFORMEIntervenciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <br />
                <h1 style="text-align: center">Búsqueda de Intervenciones</h1>
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
                        <label for="txtFD">Apellido del Paciente</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese el Apellido" Width="415"></asp:TextBox>

                        <br />
                    </div>
                    <div class="form-inline">
                        <label for="txtFD">Fecha Desde</label>
                        <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" Width="110" placeholder="dd/mm/aaaa" Columns="10"></asp:TextBox>
                        <asp:CompareValidator ID="cvFechaDesde" runat="server"
                            ControlToValidate="txtFechaDesde"
                            Type="Date"
                            Operator="DataTypeCheck"
                            ErrorMessage="Fecha invalida"
                            Text="*"
                            ValidationGroup="B"></asp:CompareValidator>
                        <label for="txtFH">Fecha Hasta</label>
                        <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" Width="110" placeholder="dd/mm/aaaa" Columns="10"></asp:TextBox>
                        <asp:CompareValidator ID="cvFechaHasta"
                            runat="server"
                            ControlToValidate="txtFechaHasta"
                            Type="Date"
                            Operator="DataTypeCheck"
                            ErrorMessage="Fecha invalida"
                            Text="*"
                            ValidationGroup="B"></asp:CompareValidator>

                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <label for="cboTratamiento">Tratamiento Realizado</label>
                        <asp:DropDownList ID="cboTratamiento" CssClass="form-control" Width="300" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">&lt;Seleccione un Tratamiento&gt;</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Intervenciones" ValidationGroup="B" CssClass="btn btn-success" OnClick="btnBuscar_Click" />

                    </div>

                    <div class="form-group">
                        <asp:ValidationSummary ID="valResumen" runat="server" ValidationGroup="B" ForeColor="Red" ShowMessageBox="True" />
                    </div>
                    <div class="form-group" id="divResultado" runat="server" visible="false">
                        <asp:TextBox ID="txtResultado" runat="server" TextMode="MultiLine" Columns="70" Rows="5"></asp:TextBox>
                    </div>
                </fieldset>


            </div>
            <div class="col-md-6">
                <div class="form-group" id="divGrilla" runat="server">
                    <asp:GridView ID="gdvIntervenciones" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="apellidoPaciente" HeaderText="Apellido"  />
                            <asp:BoundField DataField="nombrePaciente" HeaderText="Nombre" />
                            <asp:BoundField DataField="descripcionTratamiento" HeaderText="Tratamiento" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="hora" HeaderText="Hora" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:BoundField DataField="montoTotal" HeaderText="Monto" />
                            <asp:BoundField DataField="descripcionCondicion" HeaderText="Condicion" />
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
