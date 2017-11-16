using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;

public partial class INFORMEIntervenciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Rol"].ToString() == string.Empty)
        {
            Response.Redirect("Login.aspx");
        }
        bool acceso = false;
        if (Session["Rol"].ToString() == "Administrador" || Session["Rol"].ToString() == "Especialista")
            acceso = true;
        if (!acceso) Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            CargarTratamientos();
        }
    }

    protected void CargarTratamientos()
    {


        cboTratamiento.DataSource = TratamientoDao.ObtenerTratamientos();
        cboTratamiento.DataValueField = "idTratamiento";
        cboTratamiento.DataTextField = "descripcionTratamiento";
        cboTratamiento.DataBind();
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        try
        {
            string apellido = txtApellido.Text;

            DateTime? FechaDesde;
            if (!string.IsNullOrEmpty(txtFechaDesde.Text))
            {
                FechaDesde = DateTime.Parse(txtFechaDesde.Text);
            }
            else
            {
                FechaDesde = null;
            }
            DateTime? FechaHasta;
            if (!string.IsNullOrEmpty(txtFechaHasta.Text))
            {
                FechaHasta = DateTime.Parse(txtFechaHasta.Text);
            }
            else
            {
                FechaHasta = null;
            }




            int tratamiento = cboTratamiento.SelectedIndex;

            gdvIntervenciones.DataSource = IntervencionQueryDao.ListaInforme(apellido, FechaDesde, FechaHasta, tratamiento);
            gdvIntervenciones.DataKeyNames = new string[] { "IdPaciente" };
            gdvIntervenciones.DataBind();
        }
        catch (Exception ex)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Error = " + ex.Message;
        }




    }
}