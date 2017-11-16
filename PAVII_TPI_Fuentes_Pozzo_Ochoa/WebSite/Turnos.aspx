<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Turnos.aspx.cs" Inherits="Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <br />
            <h1 style="text-align: center">Reserva de Turnos</h1>
            <br />
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>


    <div class="row">
        <div class="col-md-6">

            <label for="txtPaciente">Número de Documento del Paciente: </label>
            <div class="form-inline">
                <asp:TextBox ID="txtPaciente" runat="server" CssClass="form-control" Width="350px" placeholder="Ingrese el número de Documento del Paciente" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                     runat="server"
                     ControlToValidate="txtPaciente"
                     ErrorMessage="RequiredFieldValidator"
                     Text="*"
                     ValidationGroup="D">
                     </asp:RequiredFieldValidator>
                             </div>
                
            <br />
            
            <label for="txtEmpleado">Especialista: </label>
            <div class="form-inline">
                <asp:TextBox ID="txtEmpleado" runat="server" CssClass="form-control" Width="350px" placeholder="Ingrese el Apellido del Especialista"></asp:TextBox>

                <asp:Button ID="btnBuscarEmp" runat="server" Text="Buscar Especialista" CssClass="btn btn-info" OnClick="btnBuscarEmp_Click" />

            </div>
            <div class="form-group" id="GrillaEspecialistas" runat="server" visible="false">
                <br />
                <asp:GridView ID="gdvEspecialista" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnSelectedIndexChanged="gdvEspecialista_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="+ Seleccionar +" ShowSelectButton="True" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Horario" HeaderText="Horario" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label for="txtNombreEmpleado">Especialista</label>
                <asp:TextBox ID="txtNombreEmpleado" runat="server" CssClass="form-control" Width="345" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-inline">
                <label for="txtFecha">Fecha&nbsp</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Width="110" placeholder="dd/mm/aaaa" Columns="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFecha"
                    runat="server"
                    Text="*"
                    ControlToValidate="txtFecha"
                    ErrorMessage="Ingrese una fecha"
                    ValidationGroup="D">
                </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvFecha"
                    runat="server"
                    ErrorMessage="Ingrese la Fecha en un formato concreto"
                    Operator="DataTypeCheck"
                    Type="Date"
                    ControlToValidate="txtFecha"
                    Text="*"
                    ValidationGroup="D">

                </asp:CompareValidator>

                <label for="txtHora">&nbsp Horario:&nbsp</label>
                <asp:TextBox ID="txtHora" runat="server" CssClass="form-control" Width="110" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="form-group">
                <asp:ValidationSummary ID="valResumen"
                    runat="server" ValidationGroup="D" ForeColor="Red" ShowMessageBox="True" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnBuscarTurno" runat="server" Text="Buscar turnos Disponibles" CssClass="btn btn-info" OnClick="btnBuscarTurno_Click" ValidationGroup="D" />

            </div>
            <div class="form-group" runat="server" id="GrillaHoras" visible="false">
                <asp:GridView ID="gdvGrillaHorarios" runat="server" CssClass="table table-bordered" Width="150px" AutoGenerateColumns="false" OnSelectedIndexChanged="gdvGrillaHorarios_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" ControlStyle-Width="75" HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="hora" HeaderText="Horarios" ControlStyle-Width="100" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">

            <div class="form-inline">
                <br />
                <asp:Button ID="btnReservar" Enabled="false" runat="server" Text="RESERVAR TURNO" Font-Bold="true" CssClass="btn btn-success btn-block" OnClick="btnReservar_Click" />
            </div>
            <br />
            <div class="form-group" runat="server" id="divResultado" visible="false">
                <asp:TextBox ID="txtResultado" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="70" Rows="5"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-9"></div>
        <div class="col-md-3">
            <br />
            <asp:Button ID="Button2" runat="server" Text="CANCELAR" Font-Bold="true" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>

