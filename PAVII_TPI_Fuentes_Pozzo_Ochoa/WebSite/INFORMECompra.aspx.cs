using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;

public partial class InformeCompra : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarCombo();

        }
    }


    protected void cargarCombo()
    {
        cboproveedor.DataSource = ProveedorDao.obtener();
        cboproveedor.DataValueField = "idProveedor";
        cboproveedor.DataTextField = "nombreResponsable";
        cboproveedor.DataBind();
        cboInsumos.DataSource = InsumoDao.ObtenerInsumos();
        cboInsumos.DataValueField = "idInsumo";
        cboInsumos.DataTextField = "descripcion";
        cboInsumos.DataBind();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int? idProv;
            int? idIns;
            DateTime? fd;
            DateTime? fh;

            if (cboproveedor.SelectedIndex != 0)
            {
                idProv = cboproveedor.SelectedIndex + 1;
            }
            else
            {
                idProv = null;
            }

            if (cboInsumos.SelectedIndex != 0)
            {
                idIns = cboInsumos.SelectedIndex;
            }
            else
            {
                idIns = null;
            }

            if (txtFD.Text != "")
            {
                fd = DateTime.Parse(txtFD.Text);
            }
            else
            {
                fd = null;
            }

            if (txtFH.Text != "")
            {
                fh = DateTime.Parse(txtFH.Text);
            }
            else
            {
                fh = null;
            }

            gdrGrilla.DataSource = InformeCompraDao.ListaInforme(idProv, idIns, fd, fh);
            gdrGrilla.DataBind();
        }
        catch (Exception ex)
        {
            txtResultado.Text = "Error = " + ex.Message;
        }

    }
}
