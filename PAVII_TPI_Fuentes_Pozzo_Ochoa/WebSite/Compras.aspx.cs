using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class Compras : System.Web.UI.Page
{

    public static List<DetalleCompraInsumosEntidad> listaD = new List<DetalleCompraInsumosEntidad>();


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
            cargarCombos();
            listaD.Clear();
            btnGuardar.Enabled = false;


        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        try
        {
            DetalleCompraInsumosEntidad detalle = new DetalleCompraInsumosEntidad();
            cboProveedor.Enabled = false;
            btnGuardar.Enabled = true;
            detalle.idProveedor = cboInsumos.SelectedIndex;
            //detalle.fechaHora = horaActual;
            detalle.codInsumo = cboInsumos.SelectedIndex;
            detalle.descripcion = cboInsumos.SelectedItem.ToString();
            float precio;
            if (float.TryParse(txtPrecio.Text, out precio))

            { detalle.precioUnitario = precio; }

            detalle.cantidad = int.Parse(txtCantidad.Text);

            agregarEnLista(detalle);

        }
        catch (Exception ex)
        {
            txtResultado.Visible = true;
            txtResultado.Text = "Ha ocurrido el siguiente error: " + ex.Message;
        }

    }
    protected void cargarCombos()
    {
        cboProveedor.DataSource = ProveedorDao.obtener();
        cboProveedor.DataValueField = "idProveedor";
        cboProveedor.DataTextField = "nombreResponsable";
        cboProveedor.DataBind();
        cboInsumos.DataSource = InsumoDao.ObtenerInsumos();
        cboInsumos.DataValueField = "idInsumo";
        cboInsumos.DataTextField = "descripcion";
        cboInsumos.DataBind();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        limpiar();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        DateTime hora = DateTime.Now;
        if (!Page.IsValid) return;
        try
        {
            CompraInsumosEntidad compra = new CompraInsumosEntidad();

            compra.fechaHora = hora;
            compra.idProveedor = cboProveedor.SelectedIndex;
            compra.montoTotal = calcularTotal();

            foreach (DetalleCompraInsumosEntidad det in listaD)
            {
                det.fechaHora = hora;
            }

            ComprasDao.InsertarCompra(compra, listaD);
            limpiar();

        }
        catch (Exception ex)
        {
            txtResultado.Visible = true;
            txtResultado.Text = "Ha ocurrido el siguiente error: " + ex.Message;
        }
    }

    protected void agregarEnLista(DetalleCompraInsumosEntidad detalle)
    {
        if (listaD.Count > 0)
        {
            bool bandera = false;
            foreach (DetalleCompraInsumosEntidad det in listaD)
            {
                if (det.codInsumo == detalle.codInsumo)
                {
                    det.cantidad = det.cantidad + detalle.cantidad;
                    bandera = true;
                }
            }

            if (bandera == false)
            {
                listaD.Add(detalle);
            }

        }
        else
        {
            listaD.Add(detalle);
        }


        cargarGrilla();
        calcularTotal();
    }


    protected float? calcularTotal()
    {
        float? total = 0;

        foreach (DetalleCompraInsumosEntidad det in listaD)
        {

            total = total + (det.cantidad * det.precioUnitario);

        }
        txtTotal.Text = total.ToString();
        return total;
    }

    public void limpiar()
    {
        cboInsumos.SelectedIndex = 0;
        cboProveedor.SelectedIndex = 0;
        cboProveedor.Enabled = true;
        txtCantidad.Text = "";
        txtPrecio.Text = "";
        txtTotal.Text = "";
        gdrInsumos.DataSource = null;
        gdrInsumos.DataBind();
        listaD.Clear();
        btnGuardar.Enabled = false;
    }

    protected void cargarGrilla()
    {
        gdrInsumos.DataSource = listaD;
        gdrInsumos.DataBind();
    }




}