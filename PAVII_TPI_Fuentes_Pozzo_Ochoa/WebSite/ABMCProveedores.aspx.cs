using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class ABMCProveedores : System.Web.UI.Page
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
            CargarLocalidades();
            CargarGrilla();
            btnEliminar.Enabled = false;
            compararFecha.ValueToCompare = DateTime.Today.ToShortDateString();

        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid) return;
        try
        {
            ProveedorEntidad prov = new ProveedorEntidad();

            prov.nombre = txtNombre.Text;
            prov.nombreResponsable = txtEmpresa.Text;
            prov.cuit = txtCuit.Text;


            DateTime fecha;
            if (DateTime.TryParse(txtFechaAlta.Text, out fecha))
                prov.fechaAlta = fecha;

            prov.idLocalidad = cboLocalidad.SelectedIndex;
            prov.calle = txtCalle.Text;

            short nroC;
            if (short.TryParse(txtNroCalle.Text, out nroC))
                prov.nroCalle = nroC;

            int nroP;
            if (int.TryParse(txtPiso.Text, out nroP))
                prov.piso = nroP;

            prov.departamento = txtDepto.Text;

            prov.telefono = txtTelefono.Text;

            prov.celular = txtCelular.Text;

            prov.activo = ckbActivo.Checked;
            prov.eMail = txtEmail.Text;

            if (COD.HasValue)
            {
                prov.idProveedor = COD.Value;
                ProveedorDao.Actualizar(prov);
                CargarGrilla();
            }
            else
                if (ProveedorDao.estaCargado(prov.nombreResponsable))
                {
                    divResultado.Visible = true;
                    txtResultado.Text = "Actualmente existe un Proveedor de la empresa: ";
                    txtResultado.Text += prov.nombreResponsable.ToString();

                    txtEmpresa.Focus();
                    return;
                }
                else
                {
                    ProveedorDao.InsertarProveedor(prov);
                    COD = prov.idProveedor.Value;
                    btnEliminar.Enabled = true;
                    btnEliminar.CssClass = "btn btn-danger";
                    CargarGrilla();
                    Limpiar();
                }




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
            ProveedorDao.Eliminar(COD.Value);
            CargarGrilla();
            Limpiar();
        }

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        grdGrilla.DataSource = ProveedorDao.ObtenerPorEmpresa(txtEmpresaBuscar.Text);
        grdGrilla.DataBind();
    }




    protected void grdGrilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();

        COD = int.Parse(grdGrilla.SelectedDataKey.Value.ToString());

        ProveedorQuery prov = ProveedorDao.ObtenerPorID(COD.Value);
        txtNombre.Text = prov.nombre;
        txtEmpresa.Text = prov.nombreResponsable;
        txtCuit.Text = prov.cuit;
        txtEmail.Text = prov.eMail;
        txtFechaAlta.Text = prov.fechaAlta.ToShortDateString();
        cboLocalidad.SelectedIndex = (int)prov.idLocalidad;
        txtCalle.Text = prov.calle;
        txtNroCalle.Text = prov.nroCalle.ToString();
        txtPiso.Text = prov.piso.ToString();
        txtDepto.Text = prov.departamento.ToString();
        txtTelefono.Text = prov.telefono.ToString();
        txtCelular.Text = prov.celular.ToString();
        ckbActivo.Checked = prov.activo.Value;

        btnEliminar.Enabled = true;
        btnEliminar.CssClass = "btn btn-danger";

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
        grdGrilla.DataSource = ProveedorDao.obtener();
        grdGrilla.DataBind();

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


    protected void Limpiar()
    {
        COD = null;
        txtEmail.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtEmpresa.Text = string.Empty;
        txtCuit.Text = string.Empty;
        txtFechaAlta.Text = string.Empty;
        cboLocalidad.SelectedIndex = 0;
        txtCalle.Text = string.Empty;
        txtNroCalle.Text = string.Empty;
        txtPiso.Text = string.Empty;
        txtDepto.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelular.Text = string.Empty;
        ckbActivo.Checked = false;

        btnEliminar.Enabled = false;
        btnEliminar.CssClass = "btn btn-danger disabled";
    }
}
