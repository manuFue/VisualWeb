using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class Turnos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Rol"].ToString() == string.Empty)
        {
            Response.Redirect("Login.aspx");
        }
        bool acceso = false;
        if (Session["Rol"].ToString() == "Administrador" || Session["Rol"].ToString() == "Usuario")
            acceso = true;
        if (!acceso) Response.Redirect("Login.aspx");

        if (!IsPostBack)
        {

        }

    }

    protected void btnBuscarEmp_Click(object sender, EventArgs e)
    {
        gdvEspecialista.DataSource = EmpleadoQueryDao.ObtenerEspecialistasPorApellido(txtEmpleado.Text);
        gdvEspecialista.DataKeyNames = new string[] { "CodEmpleado" };
        gdvEspecialista.DataBind();
        GrillaEspecialistas.Visible = true;
    }

    protected List<HoraEntidad> GenerarHorarios(int horas, DateTime horaInicio)
    {
        List<HoraEntidad> ListaHorario = new List<HoraEntidad>();
        double i = 1;
        while (horas > 0)
        {
            HoraEntidad horaEnLista = new HoraEntidad();
            horaEnLista.Hora = horaInicio.ToShortTimeString();
            horaInicio = horaInicio.AddHours(i);
            ListaHorario.Add(horaEnLista);
            horas--;
        }
        return ListaHorario;
    }

    protected List<HoraEntidad> RestarTurnosOcupados(List<HoraEntidad> ListaCompleta, List<TurnoEntidad> Ocupados)
    {
        bool bandera = true;
        List<HoraEntidad> ListaDisponible = new List<HoraEntidad>();
        foreach (HoraEntidad hora in ListaCompleta)
        {
            foreach (TurnoEntidad turno in Ocupados)
            {
                if (!(String.Compare(turno.hora, hora.Hora) == 0))
                {
                    foreach (HoraEntidad horaDisponible in ListaDisponible)
                    {
                        if (horaDisponible.Hora == hora.Hora)
                            bandera = false;
                    }

                }
                else
                    bandera = false;

            }
            if (bandera)
            {
                ListaDisponible.Add(hora);
            }
            bandera = true;
        }
        return ListaDisponible;
    }

    protected void CargarTurnosDisponibles(List<HoraEntidad> lista)
    {
        gdvGrillaHorarios.DataSource = lista;
        gdvGrillaHorarios.DataKeyNames = new string[] { "hora" };
        gdvGrillaHorarios.DataBind();
    }

    protected void btnBuscarTurno_Click(object sender, EventArgs e)
    {
        try
        {
            COD = (int)(gdvEspecialista.SelectedDataKey.Value);
            EmpleadoEntidad emp = EmpleadoDao.ObtenerPorID(COD);
            DateTime horaInicio = emp.HoraIngreso;
            DateTime horario = DateTime.Parse((emp.HoraEgreso - emp.HoraIngreso).ToString());
            int horas = int.Parse(horario.Hour.ToString());
            List<HoraEntidad> HorarioCompleto = GenerarHorarios(horas, horaInicio);

            List<TurnoEntidad> TurnosOcupados = TurnoDao.TurnosPorFechaPorEspecialista((DateTime.Parse(txtFecha.Text)), ((int)gdvEspecialista.SelectedDataKey.Value));
            if (TurnosOcupados != null)
            {
                if (TurnosOcupados.Count != 0)
                    HorarioCompleto = RestarTurnosOcupados(HorarioCompleto, TurnosOcupados);
            }
            CargarTurnosDisponibles(HorarioCompleto);
            GrillaHoras.Visible = true;

        }
        catch (Exception ex)
        {
            divResultado.Visible = true;
            txtResultado.Text = "Ha ocurrido el siguiente error: " + ex.Message;
        }

    }

    protected void Limpiar()
    {
        GrillaEspecialistas.Visible = false;
        txtEmpleado.Text = String.Empty;
        txtNombreEmpleado.Text = String.Empty;
        txtFecha.Text = String.Empty;
        txtHora.Text = String.Empty;
        GrillaHoras.Visible = false;
        COD = null;
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

    protected void gdvEspecialista_SelectedIndexChanged(object sender, EventArgs e)
    {
        COD = (int)(gdvEspecialista.SelectedDataKey.Value);

        EmpleadoEntidad emp = EmpleadoDao.ObtenerPorID(COD.Value);
        txtNombreEmpleado.Text = emp.Apellido + " " + emp.Nombre;
    }

    protected bool ValidarPaciente(int doc)
    {
        return PacienteDao.ValidarNroDoc(doc);
    }


    protected void btnReservar_Click(object sender, EventArgs e)
    {
        if (!ValidarPaciente(int.Parse(txtPaciente.Text)))
        {
            divResultado.Visible = true;
            txtResultado.Text = "El Numero de Documento ingresado no corresponde a un Paciente registrado.";
            return;
        }
        int? idPaciente = (PacienteDao.ObtenerPorNroDoc(int.Parse(txtPaciente.Text))).Id;
        DateTime fechaValidacion = DateTime.Parse(txtFecha.Text);
        if (ValidarSuperposicion(fechaValidacion, idPaciente, txtHora.Text))
        {
            divResultado.Visible = true;
            txtResultado.Text = "El Paciente ya tiene un turno asignado en esa fecha para ese horario.";
            return;
        }
        TurnoEntidad TurnoGuardar = new TurnoEntidad();
        TurnoGuardar.idPaciente = PacienteDao.ObtenerPorNroDoc(int.Parse(txtPaciente.Text)).Id;
        TurnoGuardar.fecha = txtFecha.Text;
        TurnoGuardar.hora = txtHora.Text;
        TurnoGuardar.codEmpleado = (int)gdvEspecialista.SelectedDataKey.Value;

        TurnoDao.Insertar(TurnoGuardar);
        Limpiar();
    }

    protected bool ValidarSuperposicion(DateTime fecha, int? idPaciente, string hora)
    {
        List<TurnoEntidad> TurnosPaciente = TurnoDao.TurnosPorFechaPorPaciente(fecha, idPaciente);
        foreach (TurnoEntidad turno in TurnosPaciente)
        {
            if (String.Compare(hora, turno.hora) == 0)
                return true;
        }
        return false;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void gdvGrillaHorarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtHora.Text = gdvGrillaHorarios.SelectedDataKey.Value.ToString();
        btnReservar.Enabled = true;
    }
}