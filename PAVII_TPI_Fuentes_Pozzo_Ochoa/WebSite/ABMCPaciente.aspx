<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMCPaciente.aspx.cs" Inherits="ABMCPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <br />
            <h1 style="text-align: center">Pacientes</h1>
            <br />
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <div class="row">

        <div class="col-md-6">


            <%-- groupBox  DatosPersonales global--%>
            <fieldset id="altaPaciente">
                <fieldset>
                    <legend>Datos Personales</legend>
                    <div class="form-group">
                        <label for="txtNombre">Nombre*</label>
                        <asp:TextBox ID="txtNombre" runat="server" placeholder="Ingrese su nombre" Columns="50" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                            ControlToValidate="txtNombre" ErrorMessage="Ingrese el Nombre"
                            Text="*" ValidationGroup="A" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtApellido">Apellido*</label>
                        <asp:TextBox ID="txtApellido" runat="server" placeholder="Ingrese su Apellido" Columns="50" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                            ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido"
                            Text="*" ValidationGroup="A" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtFechaNac">Fecha de nacimiento*</label>
                        <asp:TextBox ID="txtFechaNac" runat="server" placeholder="dd/mm/aaaa" Columns="10" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
                            ControlToValidate="txtFechaNac" ErrorMessage="Ingrese fecha"
                            Text="*" ValidationGroup="A" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvFecha" runat="server"
                            ControlToValidate="txtFechaNac" ErrorMessage="Fecha invalida"
                            Type="Date" Text="*" Operator="DataTypeCheck"
                            ValidationGroup="A" ForeColor="Red"></asp:CompareValidator>
                    </div>
                    <div class="form-group">
                        <label for="cboTipoDoc">Tipo de documento*</label>
                        <asp:DropDownList ID="cboTipoDoc" runat="server" AppendDataBoundItems>
                            <asp:ListItem Value="0">&lt;Sin seleccionar&gt;</asp:ListItem>
                        </asp:DropDownList>
                    

                        <label for="txtNroDoc">Nro de documento*</label>
                        <asp:TextBox ID="txtNroDoc" runat="server" placeholder="Nro documento" Columns="15" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNroDoc" runat="server"
                            ControlToValidate="txtNroDoc" ErrorMessage="Falta nro Documento" Text="*"
                            ValidationGroup="A" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvNroDoc" runat="server"
                            ControlToValidate="txtNroDoc" Type="Integer" Operator="DataTypeCheck"
                            ErrorMessage="Nro Documento invalido" Text="*" ValidationGroup="A" ForeColor="Red"></asp:CompareValidator>
                        <asp:RangeValidator ID="rvDNI" runat="server"
                            ControlToValidate="txtNroDoc" Type="Integer" MaximumValue="100000000"
                            MinimumValue="1" ErrorMessage="DNI debe estar entre 1 y 100000000"
                            Text="*" ValidationGroup="A"></asp:RangeValidator>
                    </div>
                    <div class="form-group>">
                        <label for="rdbSexo">Sexo*  </label>
                        <asp:RadioButton ID="rdbSexoF" runat="server" Text="Femenino" GroupName="sexo" value="0" />
                        <asp:RadioButton ID="rdbSexoM" runat="server" Text="Masculino" GroupName="sexo" value="1" />

                    </div>

                </fieldset>
                <br />
                <br />

                <%--groupBox Domicilio--%>
                <fieldset>
                    <legend>Domicilio</legend>
                    <div class="form-group">
                        <label for="cboLocalidad">Localidad*</label>
                        <asp:DropDownList ID="cboLocalidad" runat="server" AppendDataBoundItems>
                            <asp:ListItem Value="0">&lt;Sin seleccionar&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txtCalle">Calle*</label>
                        <asp:TextBox ID="txtCalle" runat="server" placeholder="Ingrese su calle" Columns="40" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCalle" runat="server"
                            ControlToValidate="txtCalle" ErrorMessage="Falta calle" Text="*"
                            ValidationGroup="A" ForeColor="Red"></asp:RequiredFieldValidator>

                        <label for="txtNroCalle">Nro calle*</label>
                        <asp:TextBox ID="txtNroCalle" runat="server" placeholder="Nro calle" Columns="10" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNroCalle" runat="server"
                            ControlToValidate="txtNroCalle" ErrorMessage="Falta Nro de calle" Text="*"
                            ValidationGroup="A" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvNroCalle" runat="server"
                            ControlToValidate="txtNroCalle" Type="Integer" Operator="DataTypeCheck"
                            ErrorMessage="Nro invalido" Text="*" ValidationGroup="A" ForeColor="Red"></asp:CompareValidator>
                        <asp:RangeValidator ID="rvNro" runat="server"
                            ControlToValidate="txtNroCalle" ErrorMessage="nro entre 1 y 100000" Text="*"
                            MaximumValue="100000" MinimumValue="1" ValidationGroup="A" ForeColor="Red" Type="Integer"></asp:RangeValidator>
                    </div>

                    <div class="form-inline">
                        <label for="txtPiso">Piso</label>
                        <asp:TextBox ID="txtPiso" runat="server" placeholder="( Opcional )" Columns="10" MaxLength="20"></asp:TextBox>
                        <asp:CompareValidator ID="cvPiso" runat="server"
                            ControlToValidate="txtPiso" ErrorMessage="Ingrese un nro" Text="*"
                            ValidationGroup="A" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
                        <asp:RangeValidator ID="rvPiso" runat="server"
                            ControlToValidate="txtPiso" ErrorMessage="Piso entre 0 y 1000" Text="*"
                            MaximumValue="1000" MinimumValue="0" ValidationGroup="A" ForeColor="Red" Type="Integer"></asp:RangeValidator>
                        <label for="txtDepto">Departamento</label>
                        <asp:TextBox ID="txtDepto" runat="server" placeholder="( Opcional )" Columns="20" MaxLength="20"></asp:TextBox>
                    </div>
                    <br />
                    <div class="form-inline">
                        <label for="txtTelefono">Telefono</label>
                        <asp:TextBox ID="txtTelefono" runat="server" placeholder="#### - #######" Columns="20" MaxLength="20"></asp:TextBox>
                        <asp:CompareValidator ID="cvTel" runat="server"
                            ControlToValidate="txtTelefono" ErrorMessage="Telefono invalido" Text="*"
                            Type="Integer" Operator="DataTypeCheck" ValidationGroup="A" ForeColor="Red"></asp:CompareValidator>

                        <label for="txtCelular">Celular</label>
                        <asp:TextBox ID="txtCelular" runat="server" placeholder="#### - #######" Columns="20" MaxLength="20"></asp:TextBox>
                        <asp:CompareValidator ID="cvCel" runat="server"
                            ControlToValidate="txtCelular" ErrorMessage="Celular invalido" Text="*"
                            Type="Integer" Operator="DataTypeCheck" ValidationGroup="A" ForeColor="Red"></asp:CompareValidator>
                    </div>
                </fieldset>

                <br />
                <br />
                <div class="form-group">
                    <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" CssClass="btn btn-success" OnClick="btnAceptar_Click" ValidationGroup="A" />
                    <asp:Button ID="btnNuevo" Text="Nuevo" runat="server" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
                    <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                </div>
                <br />
                <div class="form-group">
                    <asp:ValidationSummary ID="vsSummary" runat="server" ShowMessageBox="true" ValidationGroup="A" ForeColor="Red" />
                </div>
                <br />
                <div class="form-group">
                    <asp:TextBox ID="txtResultado" runat="server" Columns="70" Rows="5" TextMode="MultiLine"></asp:TextBox>

                </div>
            </fieldset>
        </div>


        <%-- Columna Grilla--%>
        <div class="col-md-6">

            <%--<button>Consultar</button>--%>

            <fieldset>
                <legend>Consultar</legend>
                <div id="buscar">
                    <label fr="txtBusquedaNombre">Paciente Nombre:</label>
                    <asp:TextBox ID="txtBusquedaNombre" runat="server" Columns="40" MaxLength="50"></asp:TextBox>

                    <asp:Button ID="btnBusqueda" Text="Busqueda" runat="server" CssClass="btn btn-info" OnClick="btnBusqueda_Click" />
                </div>
            </fieldset>

            <br />
            <br />
            <div class="form-group" id="grilla" runat="server">
                <div style="width: 180%; height: 400px; overflow: scroll">
                <asp:GridView ID="gdvGrilla" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnSelectedIndexChanged="gdvGrilla_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="IdTipoDoc" HeaderText="TipoDoc" Visible="False" />
                        <asp:BoundField DataField="IdTD" HeaderText="idTd" Visible="False" />
                        <asp:BoundField DataField="DescripcionTD" HeaderText="Tipo Documento" />
                        <asp:BoundField DataField="NroDoc" HeaderText="Nro Documento" />
                        <asp:BoundField DataField="Sexo" HeaderText="Sexo" Visible="False" />
                        <asp:BoundField DataField="IdLocalidad" HeaderText="Loc" Visible="False" />
                        <asp:BoundField DataField="IdLoc" HeaderText="idLoc" Visible="False" />
                        <asp:BoundField DataField="DescripcionLoc" HeaderText="Localidad" />
                        <asp:BoundField DataField="Calle" HeaderText="Calle" />
                        <asp:BoundField DataField="NroCalle" HeaderText="NroCalle" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="Piso" HeaderText="Piso" />
                        <asp:BoundField DataField="Departamento" HeaderText="Depto" />
                    </Columns>
                </asp:GridView>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#txtFechaNac").datepicker({ dateFormat: 'dd/mm/yy' }).val();
        });
    </script>
</asp:Content>

