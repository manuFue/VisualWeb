<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMCEmpleados.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-2"></div>
        <div class="col-md-8">
            <br />
            <h1 style="text-align: center">ABMC - Empleados</h1>
            <br />
            <br />
        </div>
        <div class="col-md-2"></div>
    </div>

    <div class="row">
        <div class="col-md-6">


            <%-- groupBox  DatosPersonales --%>
            <fieldset id="AltaEmpleado">
                <fieldset id="DatosPersonales">
                    <legend>Datos Personales</legend>
                    <div class="form-inline">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Width="400" placeholder="Ingrese el Nombre" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre"
                            runat="server"
                            ControlToValidate="txtNombre"
                            ErrorMessage="Ingrese un Nombre"
                            Text="*"
                            ValidationGroup="A">
                        </asp:RequiredFieldValidator>
                    </div>

                    <br />

                    <div class="form-inline">
                        <label for="txtApellido">Apellido</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Width="395" placeholder="Ingrese el Apellido" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido"
                            runat="server"
                            ControlToValidate="txtApellido"
                            ErrorMessage="Ingrese un Apellido"
                            Text="*"
                            ValidationGroup="A">
                        </asp:RequiredFieldValidator>
                    </div>

                    <br />

                    <div id="datepicker"></div>
                    <div class="form-inline">
                        <label for="txtFechaNac">Fecha de nacimiento</label>
                        <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" Width="110" placeholder="dd/mm/aaaa" MaxLength="10"></asp:TextBox>
                        <asp:CompareValidator ID="cvFechaNac"
                            runat="server"
                            ControlToValidate="txtFechaNac"
                            ErrorMessage="Ingrese una Fecha válida"
                            Type="Date"
                            Operator="LessThan"
                            ValidationGroup="A">*</asp:CompareValidator>
                        <asp:CompareValidator ID="cv2FechaNac"
                            runat="server"
                            ErrorMessage="Ingrese la Fecha en un formato concreto"
                            Operator="DataTypeCheck"
                            Type="Date"
                            ControlToValidate="txtFechaNac"
                            Text="*"
                            ValidationGroup="A"></asp:CompareValidator>
                    </div>

                    <br />

                    <div class="form-inline">
                        <label>Documento </label>
                        <asp:DropDownList ID="cboTipoDoc" runat="server" CssClass="form-control" Width="100" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">&lt; Tipo &gt;</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rvfTipoDoc"
                            runat="server"
                            ControlToValidate="cboTipoDoc"
                            ErrorMessage="Seleccione Tipo de Documento"
                            Text="*"
                            ValidationGroup="A">
                        </asp:RequiredFieldValidator>

                        <asp:TextBox ID="txtNroDoc" runat="server" CssClass="form-control" Width="190" placeholder="Número de Documento" MaxLength="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNroDoc"
                            runat="server"
                            ControlToValidate="txtNroDoc"
                            ErrorMessage="Ingrese un Número de Documento"
                            Text="*"
                            ValidationGroup="A">
                        </asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvNroDoc"
                            runat="server"
                            ControlToValidate="txtNroDoc"
                            Type="Integer"
                            MaximumValue="100000000"
                            MinimumValue="1"
                            ErrorMessage="El Número de Documento debe estar entre 1 y 100000000"
                            Text="*"
                            ValidationGroup="A"></asp:RangeValidator>
                    </div>
                </fieldset>
                <br />
                <br />

                <%--groupBox Domicilio--%>
                <fieldset id="Domicilio">
                    <legend>Domicilio</legend>
                    <div class="form-inline">
                        <label for="cboLocalidad">Localidad</label>
                        <asp:DropDownList ID="cboLocalidad" runat="server" CssClass="form-control" Width="200" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">&lt;Seleccione Localidad&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <br />

                    <div class="form-inline">
                        <label for="txtCalle">Calle&nbsp</label>

                        <asp:TextBox ID="txtCalle" runat="server" placeholder="Ingrese Nombre de Calle" CssClass="form-control" Width="310" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCalle"
                            runat="server"
                            ControlToValidate="txtCalle"
                            ErrorMessage="Ingrese una direccion completa."
                            Text="*"
                            ValidationGroup="A">
                        </asp:RequiredFieldValidator>

                        <%--<label for="txtNroCalle">Nro calle</label>--%>
                        <asp:TextBox ID="txtNroCalle" runat="server" CssClass="form-control" Width="90" placeholder="Número" MaxLength="4"></asp:TextBox>
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

                    <br />

                    <div class="form-inline">
                        <label for="txtPiso">Piso&nbsp&nbsp</label>
                        <asp:TextBox ID="txtPiso" runat="server" CssClass="form-control" Width="100" placeholder="( Opcional )" MaxLength="2"></asp:TextBox>

                        <label for="txtDepto">&nbsp Departamento </label>
                        <asp:TextBox ID="txtDepto" runat="server" CssClass="form-control" Width="100" placeholder="( Opcional )" MaxLength="2"></asp:TextBox>

                    </div>

                    <br />

                    <div class="form-inline">
                        <label for="txtTelefono">Telefono&nbsp</label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Width="150" placeholder="#### - #######" MaxLength="12"></asp:TextBox>

                        <label for="txtCelular">&nbsp Celular</label>
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" Width="175" placeholder="#### - ########" MaxLength="13"></asp:TextBox>
                    </div>
                </fieldset>

                <br />
                <br />

                <fieldset id="Datos Laborales">
                    <legend>Datos Laborales</legend>

                    <div class="form-inline">
                        <label for="cboCargod">Cargo&nbsp&nbsp</label>
                        <asp:DropDownList ID="cboCargo" CssClass="form-control" Width="175" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">&lt;Seleccione Cargo&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <br />

                    <div class="form-inline">
                        <label for="txtSueldo">Sueldo&nbsp</label>
                        <asp:TextBox ID="txtSueldo" runat="server" CssClass="form-control" Width="175" placeholder="Una Cantidad en $" MaxLength="5"></asp:TextBox>
                        <asp:CompareValidator ID="cvSueldo"
                            runat="server"
                            ControlToValidate="txtSueldo"
                            ErrorMessage="Ingrese un monto de dinero válido"
                            ValidationGroup="A"
                            Operator="DataTypeCheck"
                            Type="Currency"
                            Text="*"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="rvSueldo"
                            runat="server"
                            Text="*"
                            ControlToValidate="txtSueldo"
                            ErrorMessage="Ingrese un sueldo"
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </div>

                    <br />

                    <label><u>Horarios</u></label>

                    <br />

                    <div class="form-inline">
                        <label for="txtHoraDesde">Desde:&nbsp&nbsp</label>
                        <asp:TextBox ID="txtHoraDesde" runat="server" CssClass="form-control" Width="100" placeholder="00:00"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revHoraDesde"
                            runat="server"
                            ControlToValidate="txtHoraDesde"
                            ErrorMessage="Ingrese una horario válido"
                            ValidationExpression="^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                            ValidationGroup="A"
                            Text="*"></asp:RegularExpressionValidator>

                        <label for="txtHoraHasta">Hasta:&nbsp&nbsp</label>
                        <asp:TextBox ID="txtHoraHasta" runat="server" CssClass="form-control" Width="100" placeholder="00:00"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revHoraHasta"
                            runat="server"
                            ControlToValidate="txtHoraHasta"
                            ErrorMessage="Ingrese una horario válido"
                            ValidationExpression="^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                            ValidationGroup="A"
                            Text="*"></asp:RegularExpressionValidator>
                    </div>

                    <br />

                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="ckbActivo" runat="server" Text="Empleado Activo"></asp:CheckBox>
                        </label>
                    </div>

                </fieldset>
                <br />
            </fieldset>
        </div>
        <div class="col-md-6">
            <fieldset>
                <legend>Buscar Empleado</legend>
                <div class="form-group">
                    <asp:RadioButton ID="rbtnNombre" Text="- Buscar por Nombre" runat="server" GroupName="Busqueda" Value="0" />

                </div>
                <div class="form-group">
                    <asp:RadioButton ID="rbtnApellido" Text="- Buscar Por Apellido" runat="server" GroupName="Busqueda" Value="1" />
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtBuscar" placeholder=""></asp:TextBox>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />
                </div>

            </fieldset>
            <div class="row">
                <div class="col-md-6">
                    <label>| Registro de Empleados |</label>
                    <div class="form-group" id="divGrilla" runat="server" style="width: 250%; height: 400px; overflow: scroll">
                        <asp:GridView ID="grdEmpleados" AutoGenerateColumns="False" CssClass="table table-bordered" runat="server" OnSelectedIndexChanged="grdEmpleados_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField SelectText=" Mostrar" ShowSelectButton="True" />
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="DescripcionCargo" HeaderText="Cargo" />
                                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>


        </div>
        <div class="row">
            <div class="col-md-6">
                <br />
                <div class="form-group">
                    <asp:ValidationSummary ID="valResumen"
                        runat="server" ValidationGroup="A" ForeColor="Red" ShowMessageBox="True" />
                </div>
                <br />
                <div class="form-group">
                    <asp:Button ID="btnAceptar" Text="GUARDAR EMPLEADO" runat="server" CssClass="btn btn-success" Font-Bold="true" OnClick="btnGuardar_Click" ValidationGroup="A" />
                    <asp:Button ID="btnCancelar" Text="CANCELAR" runat="server" CssClass="btn btn-default" Font-Bold="true" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Font-Bold="true" Text="ELIMINAR EMPLEADO" OnClick="btnEliminar_Click" />
                </div>
                <br />


                <div class="form-group" id="divResultado" runat="server" visible="false">
                    <label for="txtResultado">Error al guardar el empleado:</label>
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResultado" CssClass="form-control"></asp:TextBox>
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
