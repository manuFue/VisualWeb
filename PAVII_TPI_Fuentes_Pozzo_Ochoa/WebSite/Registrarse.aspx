<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registrarse.aspx.cs" Inherits="Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">



    <fieldset>
        <legend>Cambio de contraseña</legend>

        <div class="form-group">
            <label for="txtUsuario">Nombre Usuario</label>
            <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" Columns="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server"
                 ControlToValidate="txtUsuario" Text="*" ErrorMessage="Falta el usuario"
                 ValidationGroup="D" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtClave">Password</label>
            <asp:TextBox ID="txtClave" runat="server" placeholder="Contraseña" TextMode="Password" Columns="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvClave" runat="server"
                 ControlToValidate="txtClave" Text="*" ErrorMessage="Falta la clave"
                 ValidationGroup="D" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtClaveNueva">Password Nueva</label>
            <asp:TextBox ID="txtClaveNueva" runat="server" placeholder="Contraseña Nueva" TextMode="Password" Columns="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvClaveNueva" runat="server"
                 ControlToValidate="txtClaveNueva" Text="*" ErrorMessage="Falta la clave nueva"
                 ValidationGroup="D" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <br />
        <div class="form´-inline">
            <asp:Button ID="btnAceptar" runat="server" Text="Acpetar" CssClass=" btn btn-success" OnClick="btnAceptar_Click" ValidationGroup="D" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelar_Click" />

        </div>
        <asp:ValidationSummary ID="vsSummary" runat="server" ShowMessageBox="true"  ValidationGroup="D" ForeColor="Red"/>
        <br />
        <div class="form-group">
            <asp:TextBox ID="txtResultado" runat="server" TextMode="MultiLine" Columns="70" Rows="5"></asp:TextBox>
        </div>

    </fieldset>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
</asp:Content>

