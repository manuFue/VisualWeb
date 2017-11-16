using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;

public partial class CUCENTRALFactura : System.Web.UI.Page
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
            CargarComboFP();
            CargarGrilla();
            btnAceptar.Enabled = false;
           // Numeros = null;
        }
    }

    protected void CargarComboFP()
    {
        cboForma.DataSource = FormaPagoDao.ListaForma();
        cboForma.DataValueField = "IdFP";
        cboForma.DataTextField = "DescripcionFP";
        cboForma.DataBind();
    }
    protected void CargarGrilla()
    {
        gdvPacFac.DataSource = PacienteQueryDao.ListaPac();
        gdvPacFac.DataKeyNames = new string[] { "Id" };
        gdvPacFac.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

        gdvPacFac.DataSource = PacienteQueryDao.ObtenerPorNombre(txtBuscarPac.Text);
        gdvPacFac.DataKeyNames = new string[] { "Id" };
        gdvPacFac.DataBind();
        

    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Validar()) return;

            if (!ValidarMonto()) return;

     
            FacturaEntidad f = new FacturaEntidad();

            int nro;
            if (int.TryParse(txtNroFactura.Text, out nro))
                f.NroFactura = nro;
            f.IdPaciente = ID.Value;
            double monto;
            if (double.TryParse(txtMonto.Text, out monto))
                f.MontoTotal = monto;
            DateTime fecha;
            if (DateTime.TryParse(txtFecha.Text, out fecha))
                f.Fecha = fecha;
            f.IdFormaPago = cboForma.SelectedIndex;

            FacturaDao.InsertarFacutura(f, Lista);

            Limpiar();
            Limpiar2();

    }
        catch (Exception ex) { txtResultado.Text = "Error = " + ex.Message; }
    }

    protected bool ValidarMonto()
    {
        bool bandera = false;
        double? monto = double.Parse(txtMonto.Text);
        double? total = Total;
        if (monto == total)
        {
            bandera = true;
        }
        else
        {
            bandera = false;
            txtResultado.Focus();
            txtResultado.Text = "El monto debe ser igual al total a pagar";

        }

        return bandera;
    }


    protected bool Validar()
    {
        bool bandera = true;
        if (cboForma.SelectedIndex == 0)
        {
            bandera = false;
            txtResultado.Focus();
            txtResultado.Text = "Falta seleccionar Forma de Pago";
            return bandera;
        }

        return bandera;
    }

    protected void Limpiar2()
    {

        Lista.Clear();
        ID = null;
        IdIntervencion = null;
        Total = null;
        Numeros = null;
        gdvFactura.DataSource = null;
        gdvFactura.DataBind();
        gdvIntervenciones.DataSource = null;
        gdvIntervenciones.DataBind();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
        Limpiar2();
        btnAceptar.Enabled = false;
    }

    protected int? ID
    {
        get { if(ViewState["ID"]!=null)
                    return (int)ViewState["ID"];
        else{ return null; }

        }
        set { ViewState["ID"] = value; }
    }

    protected int? IdIntervencion
    {
        get
        {
            if (ViewState["IdIntervencion"] != null)
                return (int)ViewState["IdIntervencion"];
            else { return null; }

        }
        set { ViewState["IdIntervencion"] = value; }
    }



    protected void gdvPacFac_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        Limpiar2();
        txtFecha.Text = DateTime.Now.ToShortDateString();

        try
        {
            ID = int.Parse(gdvPacFac.SelectedDataKey.Value.ToString());
            PacienteEntidad p = PacienteDao.ObtenerPorID(ID.Value);

            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            txtNroDoc.Text = p.NroDoc.ToString();

            CargarGrillaIntervenciones(ID.Value);

        }
        catch (Exception ex) { txtResultado.Text = "Error = " + ex.Message; }

        txtNroFactura.Text = (FacturaDao.NroFactura()).ToString();

    }

    protected void CargarGrillaIntervenciones(int id)
    {
        
        gdvIntervenciones.DataSource = IntervencionQueryDao.ListaInteevencionesFactura(id);
        gdvIntervenciones.DataKeyNames = new string[] { "codIntervencion" };
        gdvIntervenciones.DataBind();
    }

    protected void Limpiar()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtNroDoc.Text = string.Empty;
        txtFecha.Text = string.Empty;
        txtMonto.Text = string.Empty;
        cboForma.SelectedIndex = 0;
        txtNroFactura.Text = string.Empty;
        txtTotal.Text = string.Empty;
    }


    protected void gdvIntervenciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            IdIntervencion = int.Parse(gdvIntervenciones.SelectedDataKey.Value.ToString());


            if (ValidarRepetidos(Numeros))
            {
                Numeros.Add(IdIntervencion.Value);
                //obtenerporid
                IntervencionEntidad i = IntervencionDao.IntervencionPorID(IdIntervencion.Value);

                double precio = i.MontoTotal.Value;

                Lista.Add(new DetalleFacturaEntidad()
                {
                    NroFactura = int.Parse(txtNroFactura.Text),
                    CodIntervencion = IdIntervencion.Value,
                    Cantidad = 1,
                    Precio = i.MontoTotal,
                    CantidadAbonada = 0
                });

                Total = Total + precio;
                txtTotal.Text = Total.ToString();

                CargarGrillaFactura();
                btnAceptar.Enabled = true;
            }

           

        }
        catch (Exception ex) { txtResultado.Text = "Error = " + ex.Message; }

    
    }

    protected bool ValidarRepetidos( List<int?> numeros)
    {

        bool bandera = true; ;

        if (Lista.Count > 0)
        {
            foreach (int? nro in numeros)
            {
                if (nro.Value == IdIntervencion.Value)
                {
                    bandera = false;
                    break;
                }

                else
                {
                    bandera = true;
                   // Numeros.Add(IdIntervencion.Value);
                }

            }

        }
        else
        {
            bandera = true;
            //Numeros.Add(IdIntervencion.Value);
        }
            


        return bandera;
    }

    protected List<int?> Numeros
    {
        get
        {
            if (Session["nro"] == null)
                Session["nro"] = new List<int?>();
            return (List<int?>)Session["nro"];
        }

        set { Session["nro"] = value; }
    }


    protected double? Total
    {
        get
        {
            if (ViewState["Total"] != null)
                return (double)ViewState["Total"];
            else { return 0; }

        }
        set { ViewState["Total"] = value; }
    }

    protected List<DetalleFacturaEntidad> Lista
    {
        get
        {
            if (Session["lista"] == null)
                Session["lista"] = new List<DetalleFacturaEntidad>();
            return (List<DetalleFacturaEntidad>)Session["lista"];
        }

        set { Session["lista"] = value; }
    }

    protected void CargarGrillaFactura()
    {
        gdvFactura.DataSource = Lista;
        gdvFactura.DataBind();
    }




}