using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = String.Empty;
        


        A1.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        A2.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        A3.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());

        A4.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        A5.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        A6.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());

        A7.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        A8.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());
        A9.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());

        A10.Visible = !string.IsNullOrEmpty(Session["Usuario"].ToString());

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Session["Rol"].ToString() == "Administrador")
        {
            A1.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A1.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A2.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A3.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A4.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A5.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A6.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A7.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A8.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A9.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A10.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A12.Visible = false;

        }

        if (Session["Rol"].ToString() == "Especialista")
        {
            A1.Visible = false;
            A1.Visible = false;
            A2.Visible = false;
            A3.Visible = false;
            A4.Visible = false;
            A5.Visible = false;
            A6.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A7.Visible = false;
            A8.Visible = false;
            A9.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A10.Visible = false;
            A12.Visible = false;

        }

        if (Session["Rol"].ToString() == "Usuario")
        {
            A1.Visible = false;
            A1.Visible = false;
            A2.Visible = false;
            A3.Visible = false;
            A4.Visible = false;
            A5.Visible = false;
            A6.Visible = false;
            A7.Visible = false;
            A8.Visible = false;
            A9.Visible = false;
            A10.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
            A12.Visible = false;

        }


        //A1.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
        //A2.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
        //A3.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());

        //A4.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
        //A5.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
        //A6.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());

        //A7.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
        //A8.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
        //A9.Visible = !string.IsNullOrEmpty(Session["Rol"].ToString());
    }
}
