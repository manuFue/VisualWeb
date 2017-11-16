using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        // string user= "'" + txtUsuario.Text + "'";
        // string pass= "'" + txtPassword.Text + "'";
        //txtPassword.Text
        //txtusuario.Text


        //if (ValidarUsuario(user, pass))
        if (ValidarUsuario(txtUsuario.Text, txtPassword.Text))
        {
            Session["Usuario"] = txtUsuario.Text;
            Response.Redirect("Inicio.aspx");
        }

    }

    public bool ValidarUsuario(string usuario, string clave)
    {
        bool bandera = false;
        //string us = UsuarioDao.Usuario(usuario);
        //  string pw = UsuarioDao.Password(clave);

        //
        // if (usuario == UsuarioDao.Usuario(usuario) && clave == UsuarioDao.Password(clave) )
        if (UsuarioDao.Usuario(usuario, clave))
        // if (usuario.ToUpper() == "ADM" && clave == "4")
        // if (usuario == us && clave == pw)
        {
            bandera = true;
            Session["Rol"] = UsuarioDao.Permiso(usuario);
            //return true;
        }
        else
            // return false;
            bandera = false;

        return bandera;
    }
}