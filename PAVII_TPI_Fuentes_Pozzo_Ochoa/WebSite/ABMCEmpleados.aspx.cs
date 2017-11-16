using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Rol"].ToString() == string.Empty)
        {
            Response.Redirect("Login.aspx");
        }
        bool acceso = false;
        if(Session["Rol"].ToString() == "Administrador")
            acceso = true;
        if(!acceso) Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            Limpiar();
            cvFechaNac.ValueToCompare = DateTime.Today.ToShortDateString();
            CargarTipoDocumentos();
            CargarLocalidades();
            CargarCargos();
            CargarGrilla();
        }
    }


    protected void CargarCargos()
    {

        cboCargo.DataSource = CargoDao.ObtenerCargos();
        cboCargo.DataValueField = "IdCargo";
        cboCargo.DataTextField = "Descripcion";
        cboCargo.DataBind();
    }
    protected void CargarTipoDocumentos()
    {
                cboTipoDoc.DataSource = TipoDocumentoDao.ObtenerTipos();
        cboTipoDoc.DataValueField = "Id";
        cboTipoDoc.DataTextField = "Descripcion";
        cboTipoDoc.DataBind();
    }
    protected void CargarLocalidades()
    {

        cboLocalidad.DataSource = LocalidadDao.ObtenerLocalidades();
        cboLocalidad.DataValueField = "Id";
        cboLocalidad.DataTextField = "Descripcion";
        cboLocalidad.DataBind();
    }

    protected void CargarGrilla()
    {
        grdEmpleados.DataSource = (from emp in EmpleadoQueryDao.ObtenerTodosCompleto()
                                   orderby emp.Apellido
                                   select emp);
        grdEmpleados.DataKeyNames = new string[] { "CodEmpleado" };
        grdEmpleados.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        try
        {
            if (!ValidarCombos()) return;
            EmpleadoEntidad empleado = new EmpleadoEntidad();

            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.IdTipoDoc = cboTipoDoc.SelectedIndex;

            int doc;
            if (int.TryParse(txtNroDoc.Text, out doc))
                empleado.NroDoc = doc;

            DateTime fecha;
            if (DateTime.TryParse(txtFechaNac.Text, out fecha))
                empleado.FechaNacimiento = fecha;

            empleado.IdLocalidad = cboLocalidad.SelectedIndex;
            empleado.Calle = txtCalle.Text;

            short nroC;
            if (short.TryParse(txtNroCalle.Text, out nroC))
                empleado.NroCalle = nroC;

            empleado.Piso = txtPiso.Text;

            empleado.Departamento = txtDepto.Text;

            empleado.Telefono = txtTelefono.Text;

            empleado.Celular = txtCelular.Text;

            empleado.IdCargo = cboCargo.SelectedIndex;

            double sueldo;
            if (double.TryParse(txtSueldo.Text, out sueldo))
                empleado.Sueldo = sueldo;

            DateTime horaIngreso;
            if (DateTime.TryParse(txtHoraDesde.Text, out horaIngreso))
                empleado.HoraIngreso = horaIngreso;

            DateTime horaEgreso;
            if (DateTime.TryParse(txtHoraHasta.Text, out horaEgreso))
                empleado.HoraEgreso = horaEgreso;

            empleado.Activo = ckbActivo.Checked;

            if (COD.HasValue)
            {
                empleado.CodEmpleado = COD.Value;
                EmpleadoDao.Actualizar(empleado);
            }
            else
            {
                if (ValidarNroDoc()) return;
                EmpleadoDao.Insertar(empleado);
            }


            COD = empleado.CodEmpleado.Value;
            btnEliminar.Enabled = true;
            btnEliminar.CssClass = "btn btn-danger";
            CargarGrilla();
            divResultado.Visible = false;
            txtResultado.Text = "";
        }
        catch (Exception ex)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Ha ocurrido el siguiente error: " + ex.Message;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (COD.HasValue)
        {
            EmpleadoDao.Eliminar(COD.Value);
            CargarGrilla();
            Limpiar();
        }
    }

    protected void Limpiar()
    {
        COD = null;
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        cboTipoDoc.SelectedIndex = 0;
        txtNroDoc.Text = string.Empty;
        txtFechaNac.Text = string.Empty;
        cboLocalidad.SelectedIndex = 0;
        txtCalle.Text = string.Empty;
        txtNroCalle.Text = string.Empty;
        txtPiso.Text = string.Empty;
        txtDepto.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelular.Text = string.Empty;
        cboCargo.SelectedIndex = 0;
        txtSueldo.Text = string.Empty;
        txtHoraDesde.Text = string.Empty;
        txtHoraHasta.Text = string.Empty;
        ckbActivo.Checked = false;

        btnEliminar.Enabled = false;
        btnEliminar.CssClass = "btn btn-danger disabled";

        divResultado.Visible = false;
        txtResultado.Text = "";
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

    protected bool ValidarNroDoc()
    {
        divResultado.Visible = true;
        txtResultado.Text = "El Número de Documento ingresado ya esta registrado.";
        return EmpleadoDao.ExisteNroDoc(int.Parse(txtNroDoc.Text));
    }

    protected bool ValidarCombos()
    {
        if (cboTipoDoc.SelectedIndex == 0 || cboLocalidad.SelectedIndex == 0 || cboCargo.SelectedIndex == 0)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Seleccionar un Tipo de documento, una Localidad y un Cargo es de caracter obligatorio.";
            return false;
        }
        else
            return true;
    }

    protected void grdEmpleados_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();

        COD = int.Parse(grdEmpleados.SelectedDataKey.Value.ToString());

        EmpleadoEntidad emp = EmpleadoDao.ObtenerPorID(COD.Value);
        txtNombre.Text = emp.Nombre;
        txtApellido.Text = emp.Apellido;
        cboTipoDoc.SelectedIndex = (int)emp.IdTipoDoc;
        txtNroDoc.Text = emp.NroDoc.ToString();
        txtFechaNac.Text = emp.FechaNacimiento.ToShortDateString();
        cboLocalidad.SelectedIndex = (int)emp.IdLocalidad;
        txtCalle.Text = emp.Calle;
        txtNroCalle.Text = emp.NroCalle.ToString();
        txtPiso.Text = emp.Piso.ToString();
        txtDepto.Text = emp.Departamento.ToString();
        txtTelefono.Text = emp.Telefono.ToString();
        txtCelular.Text = emp.Celular.ToString();
        cboCargo.SelectedIndex = (int)emp.IdCargo;
        txtSueldo.Text = emp.Sueldo.ToString();
        txtHoraDesde.Text = emp.HoraIngreso.ToShortTimeString();
        txtHoraHasta.Text = emp.HoraEgreso.ToShortTimeString();
        ckbActivo.Checked = emp.Activo.Value;

        btnEliminar.Enabled = true;
        btnEliminar.CssClass = "btn btn-danger";
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (rbtnApellido.Checked == true)
            grdEmpleados.DataSource = EmpleadoQueryDao.ObtenerEmpleadoCompletoPorApellido(txtBuscar.Text);
        else
            grdEmpleados.DataSource = EmpleadoQueryDao.ObtenerEmpleadoCompletoPorNombre(txtBuscar.Text);
        grdEmpleados.DataKeyNames = new string[] { "CodEmpleado" };
        grdEmpleados.DataBind();
    }



}
