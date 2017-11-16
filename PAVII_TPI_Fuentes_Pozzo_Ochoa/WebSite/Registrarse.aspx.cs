using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class Registrarse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    public bool ValidarUsuario(string usuario, string clave)
    {
        bool bandera = false;
       
        if (UsuarioDao.Usuario(usuario, clave))
        {
            bandera = true;
            
        }
        else
            bandera = false;

        return bandera;
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarUsuario(txtUsuario.Text, txtClave.Text))
            {
                UsuarioDao.NuevaClave(txtClaveNueva.Text);
                Response.Redirect("Login.aspx");
            }
            else
                txtResultado.Text = "Usuario y/o clave incorrecta";
        }
        catch { }
        
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtUsuario.Text = string.Empty;
        txtClave.Text = string.Empty;
        txtClaveNueva.Text = string.Empty;
    }
}