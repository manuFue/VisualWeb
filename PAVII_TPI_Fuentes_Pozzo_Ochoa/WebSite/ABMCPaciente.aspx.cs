using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;
public partial class ABMCPaciente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Rol"].ToString() == string.Empty)
        {
            Response.Redirect("Login.aspx");
        }
        bool acceso = false;
        if (Session["Rol"].ToString() == "Administrador")
            acceso = true;
        if (!acceso) Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {
            CargarGrilla();
            ComboLocalidad();
            ComboTipoDoc();
            btnEliminar.Enabled = false;
        }
    }


    protected void CargarGrilla()
    {
        gdvGrilla.DataSource = PacienteQueryDao.ListaPac();
        gdvGrilla.DataKeyNames = new string[] { "Id" };
        gdvGrilla.DataBind();
    }
    protected void ComboLocalidad()
    {
        cboLocalidad.DataSource = LocalidadDao.ObtenerLocalidades();
        cboLocalidad.DataValueField = "Id";
        cboLocalidad.DataTextField = "Descripcion";
        cboLocalidad.DataBind();
    }
    protected void ComboTipoDoc()
    {
        cboTipoDoc.DataSource = TipoDocumentoDao.ObtenerTipos();
        cboTipoDoc.DataValueField = "Id";
        cboTipoDoc.DataTextField = "Descripcion";
        cboTipoDoc.DataBind();
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidarCampos()) return;
            int dni;
            int.TryParse(txtNroDoc.Text, out dni);


            PacienteEntidad paciente = new PacienteEntidad();

            paciente.NroDoc = dni;
            //paciente.IdTipoDoc = (cboTipoDoc.SelectedIndex + 1);
            paciente.IdTipoDoc = cboTipoDoc.SelectedIndex;
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            if (rdbSexoM.Checked)
                paciente.Sexo = true;
            else
                paciente.Sexo = false;

            DateTime fecha;
            if (DateTime.TryParse(txtFechaNac.Text, out fecha))
                paciente.FechaNacimiento = fecha;
            //paciente.IdLocalidad = (cboLocalidad.SelectedIndex + 1);
            paciente.IdLocalidad = cboLocalidad.SelectedIndex;
            paciente.Calle = txtCalle.Text;
            int nro;
            if (int.TryParse(txtNroCalle.Text, out nro))
                paciente.NroCalle = nro;

            if (string.IsNullOrEmpty(txtTelefono.Text))
                paciente.Telefono = string.Empty;
            // paciente.Telefono = null;
            else { paciente.Telefono = txtTelefono.Text; }

            if (string.IsNullOrEmpty(txtCelular.Text))
                paciente.Celular = string.Empty;
            // paciente.Celular = null;
            else { paciente.Celular = txtCelular.Text; }

            int piso;
            if (string.IsNullOrEmpty(txtPiso.Text))
                //paciente.Piso = null;
                paciente.Piso = 0;
            else
            {
                if (int.TryParse(txtPiso.Text, out piso))
                    paciente.Piso = piso;
            }
            if (string.IsNullOrEmpty(txtDepto.Text))
                paciente.Departamento = string.Empty;
            // paciente.Departamento = null;
            else { paciente.Departamento = txtDepto.Text; }


            if (ID.HasValue)
            {
                paciente.Id = ID.Value;
                PacienteDao.Acutalizar(paciente);
                ID = null;

            }
            else
            {
                if (PacienteDao.ValidarNroDoc(dni))
                {
                    txtResultado.Text = "Actualmente existe un paciente con el mismo numero de documento";
                    txtNroDoc.Focus();
                    return;
                }
                else
                {
                    PacienteDao.Insertar(paciente);
                    ID = paciente.Id.Value;
                    ID = null;
                }
            }

            CargarGrilla();
            Limpiar();

        }
        catch (Exception ex)
        {
            txtResultado.Text = "Error= " + ex.Message;
        }

    }


    public void Limpiar()
    {

        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtFechaNac.Text = string.Empty;
        cboTipoDoc.SelectedIndex = 0;
        txtNroDoc.Text = string.Empty;
        cboLocalidad.SelectedIndex = 0;
        txtCalle.Text = string.Empty;
        txtNroCalle.Text = string.Empty;
        txtPiso.Text = string.Empty;
        txtDepto.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelular.Text = string.Empty;
        rdbSexoF.Checked = false;
        rdbSexoM.Checked = false;
    }
    protected List<PacienteEntidad> ListaPacientes
    {
        get
        {
            if (Session["Lista"] == null)
                Session["Lista"] = new List<PacienteEntidad>();
            return (List<PacienteEntidad>)Session["Lista"];
        }
    }

    protected int? ID
    {
        get
        {
            if (ViewState["ID"] != null)
                return (int)ViewState["ID"];
            else
            { return null; }
        }
        set { ViewState["ID"] = value; }
    }


    protected void gdvGrilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            btnEliminar.Enabled = true;

            ID = int.Parse(gdvGrilla.SelectedDataKey.Value.ToString());
            PacienteEntidad p = PacienteDao.ObtenerPorID(ID.Value);

            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            if (p.FechaNacimiento != null)
                txtFechaNac.Text = p.FechaNacimiento.ToShortDateString();
            //cboTipoDoc.SelectedIndex = ((int)p.IdTipoDoc -1);
            cboTipoDoc.SelectedIndex = (int)p.IdTipoDoc;
            txtNroDoc.Text = p.NroDoc.ToString();
            if (p.Sexo.HasValue)
            {
                if (p.Sexo.Value)
                    rdbSexoM.Checked = true;
                else
                    rdbSexoF.Checked = true;
            }
            //cboLocalidad.SelectedIndex = ((int)p.IdLocalidad -1);
            cboLocalidad.SelectedIndex = (int)p.IdLocalidad;
            txtCalle.Text = p.Calle;
            txtNroCalle.Text = p.NroCalle.ToString();
            if (p.Piso.HasValue)
                txtPiso.Text = p.Piso.ToString();
            if (p.Departamento != null)
                txtDepto.Text = p.Departamento;
            if (p.Telefono != null)
                txtTelefono.Text = p.Telefono;
            if (p.Celular != null)
                txtCelular.Text = p.Celular;
        }
        catch (Exception ex) { txtResultado.Text = "Error= " + ex.Message; }

    }



    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ID.HasValue && !IntervencionDao.ValidarEliminacionPaciente(ID.Value))
            {
                PacienteDao.Eliminar(ID.Value);
                CargarGrilla();
                Limpiar();
                btnEliminar.Enabled = false;
            }
            else {
                txtResultado.Focus();
                txtResultado.Text = "El paciente no se puede eliminar. Tiene intervenciones realizadas"; }
        }
        catch (Exception ex) { txtResultado.Text = "Error= " + ex.Message; }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Limpiar();
        txtResultado.Text = string.Empty;
        ID = null;
        btnEliminar.Enabled = false;
    }

    protected void btnBusqueda_Click(object sender, EventArgs e)
    {
        gdvGrilla.DataSource = PacienteQueryDao.ObtenerPorNombre(txtBusquedaNombre.Text);
        gdvGrilla.DataKeyNames = new string[] { "Id" };
        gdvGrilla.DataBind();
    }

    protected bool ValidarCampos()
    {
        bool bandera = true;
        if (cboTipoDoc.SelectedIndex == 0)
        {
            bandera = false;
            txtResultado.Focus();
            txtResultado.Text = "Falta seleccionar Tipo de documento";
            return bandera;
        }
        if (cboLocalidad.SelectedIndex == 0)
        {
            bandera = false;
            txtResultado.Focus();
            txtResultado.Text = "Falta seleccionar Localidad";
            return bandera;
        }
        if (rdbSexoF.Checked == false && rdbSexoM.Checked == false)
        {
            bandera = false;
            txtResultado.Text = "Falta seleccionar sexo";
            txtResultado.Focus();
        }

        return bandera;

    }

}