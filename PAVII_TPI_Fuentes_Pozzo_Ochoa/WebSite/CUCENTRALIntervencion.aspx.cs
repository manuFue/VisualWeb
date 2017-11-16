using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;

public partial class CUCENTRALIntervencion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Rol"].ToString() == string.Empty)
        {
            Response.Redirect("Login.aspx");
        }
        bool acceso = false;
        if (Session["Rol"].ToString() == "Administrador" || Session["Rol"].ToString() == "Especialista" )
            acceso = true;
        if (!acceso) Response.Redirect("Login.aspx");
 
        if (!IsPostBack)
        {
            CargarTratamientos();
            CargarInsumos();
            ListaInsumosxIntervencion = null;
        }
    }

    protected void CargarTratamientos()
    {

        cboTratamiento.DataSource = TratamientoDao.ObtenerTratamientos();
        cboTratamiento.DataValueField = "IdTratamiento";
        cboTratamiento.DataTextField = "DescripcionTratamiento";
        cboTratamiento.DataBind();
    }

    protected void CargarInsumos()
    {

        cboInsumos.DataSource = InsumoDao.ObtenerInsumosValidos();
        cboInsumos.DataValueField = "IdInsumo";
        cboInsumos.DataTextField = "Descripcion";
        cboInsumos.DataBind();
    }


    protected void btnBusqueda_Click(object sender, EventArgs e)
    {
        GrillaTurnos.Visible = true;
        CargarTurnos();

    }

    protected void CargarTurnos()
    {
        gdvTurnos.DataSource = TurnoDao.ObtenerTurnos(txtBusquedaNombre.Text, txtBusquedaApellido.Text);
        gdvTurnos.DataKeyNames = new string[] { "idPaciente" };
        gdvTurnos.DataBind();
    }

    protected void Limpiar()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtFecha.Text = string.Empty;
        txtHora.Text = string.Empty;
        txtObservaciones.Text = string.Empty;
        cboTratamiento.SelectedIndex = 0;
        cboInsumos.SelectedIndex = 0;
        ListaInsumosxIntervencion = null;
        CargarGrillaInsumos();
        divResultado.Visible = false;
        txtResultado.Text = "";

    }

    protected void gdvGrilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        int index = (gdvTurnos.SelectedIndex);

        IDPACIENTE = int.Parse(gdvTurnos.SelectedDataKey.Value.ToString());
        txtNombre.Text = gdvTurnos.Rows[index].Cells[2].Text;
        txtApellido.Text = gdvTurnos.Rows[index].Cells[3].Text;
        txtFecha.Text = gdvTurnos.Rows[index].Cells[4].Text;
        txtHora.Text = gdvTurnos.Rows[index].Cells[5].Text;
    }

    protected int? IDPACIENTE
    {
        get
        {
            if (ViewState["IDPACIENTE"] != null)
                return (int)ViewState["IDPACIENTE"];
            else
            {
                return null;
            }
        }
        set { ViewState["IDPACIENTE"] = value; }
    }

    protected int? COD
    {
        get
        {
            if (ViewState["COD"] != null)
                return (int)ViewState["COD"];
            else
            {
                return null;
            }
        }
        set { ViewState["COD"] = value; }
    }

    protected List<InsumosXIntervencionEntidad> ListaInsumosxIntervencion
    {
        get
        {
            if (Session["ListaInsumosXIntervencion"] == null)
                Session["ListaInsumosXIntervencion"] = new List<InsumosXIntervencionEntidad>();
            return (List<InsumosXIntervencionEntidad>)Session["ListaInsumosXIntervencion"];
        }
        set
        {
            Session["ListaInsumosXIntervencion"] = value;
        }
    }

    protected void btnGuardarInsumo_Click(object sender, EventArgs e)
    {
        if (!ValidarCombo2()) return;
        InsumosXIntervencionEntidad Insumo = new InsumosXIntervencionEntidad();
        Insumo.idInsumo = cboInsumos.SelectedIndex;
        Insumo.descripcion = cboInsumos.SelectedItem.Text;
        Insumo.cantidadIntervencion = int.Parse(txtCantidad.Text);
        ListaInsumosxIntervencion.Add(Insumo);
        CargarGrillaInsumos();
        cboInsumos.ClearSelection();
        txtCantidad.Text = string.Empty;
        divResultado.Visible = false;
        txtResultado.Text = string.Empty;
    }

    protected void CargarGrillaInsumos()
    {
        grdInsumosIntervencion.DataSource = ListaInsumosxIntervencion;
        grdInsumosIntervencion.DataBind();
    }


    protected void RestarInsumos()
    {
        int i = 0;
        while (i < ListaInsumosxIntervencion.Count())
        {
            InsumoDao.RestarInsumos(ListaInsumosxIntervencion[i].idInsumo, ListaInsumosxIntervencion[i].cantidadIntervencion);
            i++;
        }
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        try
        {
            if (!ValidarCombo()) return;
            IntervencionEntidad intervencion = new IntervencionEntidad();

            intervencion.IdPaciente = IDPACIENTE;
            DateTime fecha;
            if (DateTime.TryParse(txtFecha.Text, out fecha))
                intervencion.Fecha = fecha;
            DateTime hora;
            if (DateTime.TryParse(txtHora.Text, out hora))
                intervencion.Hora = hora;
            intervencion.CodTratamiento = cboTratamiento.SelectedIndex;
            intervencion.MontoTotal = CalcularTotal();
            intervencion.Observaciones = txtObservaciones.Text;
            intervencion.Condicion = 1; //Pendiente

            IntervencionDao.Insertar(intervencion, ListaInsumosxIntervencion);

            COD = intervencion.CodIntervencion.Value;

            TurnoDao.ModificarAsignacion(IDPACIENTE, fecha, hora);
            RestarInsumos();
           
            Limpiar();
            GrillaTurnos.Visible = false;
            cboInsumos.Items.Clear();
            CargarInsumos();

        }
        catch (Exception ex)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Ha ocurrido el siguiente error: " + ex.Message;
        }
    }

    protected double CalcularTotal()
    {
        return (((grdInsumosIntervencion.Rows.Count) * 50) + TratamientoDao.ObtenerCostoPorID(cboTratamiento.SelectedIndex));

    }
    protected bool ValidarCombo()
    {
        if (cboTratamiento.SelectedIndex == 0)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Seleccionar un Tipo de Tratamiento es de caracter obligatorio.";
            return false;
        }
        else
            return true;
    }

    protected bool ValidarCombo2()
    {
        if (cboInsumos.SelectedIndex == 0)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Debe seleccionar un Insumo primero.";
            return false;
        }
        else
            return true;
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }




    protected void btnIntervenciones_Click(object sender, EventArgs e)
    {
        Response.Redirect("INFORMEIntervenciones.aspx");
    }
}