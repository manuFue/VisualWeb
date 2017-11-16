<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">

    <fieldset >
        <legend>Login</legend>
        <div class="form-group">
            <label for="txtUsuario">Usuario</label>
            <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" Columns="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                 ControlToValidate="txtUsuario" Text="*" ErrorMessage="Falta el usuario"
                 ValidationGroup="E" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <label for="txtPassword">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" Columns="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                 ControlToValidate="txtPassword" Text="*" ErrorMessage="Falta la clave"
                 ValidationGroup="E" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <h6><a href="Registrarse.aspx">Cambiar Contraseña</a></h6>
            <br />
            <asp:Button ID="btnlogin" runat="server" Text="Inicar Sesion" CssClass="btn btn-info" OnClick="btnlogin_Click" ValidationGroup="E" />
        </div>
        <asp:ValidationSummary ID="vsSummary" runat ="server" ShowMessageBox="true" ValidationGroup="E" ForeColor="Red" />

    </fieldset>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderPie" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>

