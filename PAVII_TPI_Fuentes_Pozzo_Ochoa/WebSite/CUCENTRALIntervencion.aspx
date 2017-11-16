<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CUCENTRALIntervencion.aspx.cs" Inherits="CUCENTRALIntervencion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <br />
            <h1 style="text-align: center">Registrar Nueva Intervención</h1>
            <br />
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <div class="row">

        <div class="col-md-6">
            <fieldset>
                <legend>Turno</legend>
                <div class="form-group" id="buscar">
                    <label for="txtBusquedaNombre">Nombre o Apellido del Paciente:</label>
                    <asp:TextBox ID="txtBusquedaNombre" runat="server" CssClass="form-control" placeholder="Ingrese el Nombre del Paciente" Columns="40" MaxLength="50"></asp:TextBox>
                    <br />

                    <asp:TextBox ID="txtBusquedaApellido" runat="server" CssClass="form-control" placeholder="Ingrese el Apellido del Paciente" Columns="40" MaxLength="50"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnBusqueda" Text="Buscar Turnos" runat="server" CssClass="btn btn-info" OnClick="btnBusqueda_Click" />
                </div>
            </fieldset>
        </div>

        <br />
        <br />
        <div class="col-md-6">
            <div class="form-group" id="GrillaTurnos" runat="server" style="width: 100%; height: 200px; overflow: scroll" visible="false">
                <asp:GridView ID="gdvTurnos" Visible="true" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvGrilla_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField SelectText="Asignar" ShowSelectButton="True" />
                        <asp:BoundField DataField="idPaciente" HeaderText="idPaciente" Visible="false" />
                        <asp:BoundField DataField="NombrePaciente" HeaderText="Nombre" />
                        <asp:BoundField DataField="ApellidoPaciente" HeaderText="Apellido" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Hora" HeaderText="Hora" />
                        <asp:BoundField DataField="ApellidoEmpleado" HeaderText="Especialista" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <fieldset>
                <legend>Intervención</legend>
                <div class="form-group">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                    <br />

                    <label for="txtApellido">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-inline">
                    <label for="txtFecha">Fecha de Intervención&nbsp</label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Width="110" Enabled="false"></asp:TextBox>
                </div>

                <br />

                <div class="form-inline">
                    <label for="txtHora">Hora de Intervención&nbsp&nbsp&nbsp</label>
                    <asp:TextBox ID="txtHora" runat="server" CssClass="form-control" Width="112" Enabled="true"></asp:TextBox>
                </div>
            </fieldset>

            <br />

            <fieldset>
                <div class="form-inline">
                    <label for="cboTratamiento">Tratamiento a Realizar&nbsp</label>
                    <asp:DropDownList ID="cboTratamiento" runat="server" CssClass="form-control" Width="175" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">&lt;Sin Seleccionar&gt;</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />

                <div class="form-group" id="divObservaciones" runat="server">
                    <label for="txtObservaciones">Observaciones:</label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtObservaciones" CssClass="form-control"></asp:TextBox>
                </div>
            </fieldset>

        </div>

        <div class="col-md-6">
            <fieldset>
                <legend>Insumos Utilizados</legend>
                <div class="form-inline">
                    <label for="cboInsumos">Insumo:&nbsp</label>
                    <asp:DropDownList ID="cboInsumos" runat="server" CssClass="form-control" Width="200" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">&lt;Sin Seleccionar&gt;</asp:ListItem>
                    </asp:DropDownList>

                    <label for="txtCantidad">&nbsp&nbsp Cantidad&nbsp</label>
                    <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" Width="100" placeholder=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCantidad"
                        runat="server"
                        ControlToValidate="txtCantidad"
                        ErrorMessage="Debe ingresar una cantidad utilizada"
                        Text="*"
                        ValidationGroup="C"></asp:RequiredFieldValidator>
                </div>

                <br />

                <asp:Button ID="btnGuardarInsumo" runat="server" Text="Agregar Insumo" class="btn btn-info" OnClick="btnGuardarInsumo_Click" />
                <br />
                <br />
                <asp:GridView ID="grdInsumosIntervencion" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="descripcion" HeaderText="Insumo" />
                        <asp:BoundField DataField="cantidadIntervencion" HeaderText="Cantidad" />
                    </Columns>
                </asp:GridView>
                <div class="form-group">
                    <asp:ValidationSummary ID="valResumen"
                        runat="server" ValidationGroup="C" ForeColor="Red" ShowMessageBox="True" />
                </div>
            </fieldset>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-inline">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Width="200" Font-Bold="true" Text="REGISTRAR" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default" Width="200" Font-Bold="true" Text="CANCELAR" OnClick="btnCancelar_Click" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-inline" style="text-align: right">
                <asp:Button ID="btnIntervenciones" runat="server" CssClass="btn btn-primary" Font-Bold="true" Text="Ver Todas las Intervenciones" OnClick="btnIntervenciones_Click" />
            </div>
        </div>
    </div>
    <div class="form-group" id="divResultado" runat="server" visible="false">
        <label for="txtResultado">Error al registrar la Intervencion:</label>
        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResultado" CssClass="form-control"></asp:TextBox>
    </div>
    </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>


