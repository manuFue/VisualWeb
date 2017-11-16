using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;
public partial class INFORMEFactura : System.Web.UI.Page
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
            CargarCombo();
        }
    }

    protected void CargarCombo()
    {
        cboFormaPago.DataSource = FormaPagoDao.ListaForma();
        cboFormaPago.DataValueField = "idFP";
        cboFormaPago.DataTextField = "DescripcionFP";
        cboFormaPago.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            int nroFactura;
            int.TryParse(txtNroFactura.Text, out nroFactura);


            int nroDoc;
            int.TryParse(txtNroDocumento.Text, out nroDoc);
            DateTime? fd;
            if (!string.IsNullOrEmpty(txtFD.Text))
            {
                fd = DateTime.Parse(txtFD.Text);
            }
            else
            {
                fd = null ;

            }

            DateTime? fh;
            if (!string.IsNullOrEmpty(txtFH.Text))
            {
                fh = DateTime.Parse(txtFH.Text);
            }
            else
            {
                fh = null;

            }

            //int condicion = (cboCondicion.SelectedIndex + 1);
            int forma = cboFormaPago.SelectedIndex;

            gdvGrillaInforme.DataSource = InformeDao.ListaInforme(nroFactura, nroDoc, fd, fh, forma);
            gdvGrillaInforme.DataKeyNames = new string[] { "Id" };
            gdvGrillaInforme.DataBind();
        }
        catch (Exception ex)
        {
            txtResultado.Text = "Error = " + ex.Message;
        }


    }


}