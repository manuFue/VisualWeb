using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class TurnoDao
    {
        public static void Insertar(TurnoEntidad turno)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"INSERT INTO Turnos (
                                    idPaciente, fecha, hora, codEmpleado, asignado) values (
                                    @idPaciente, @fecha, @hora, @codEmpleado, @asignado)";
            cmd.Parameters.AddWithValue("@idPaciente", turno.idPaciente);
            cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(turno.fecha));
            cmd.Parameters.AddWithValue("@hora", DateTime.Parse(turno.hora));
            cmd.Parameters.AddWithValue("@codEmpleado", turno.codEmpleado);
            cmd.Parameters.AddWithValue("@asignado", false);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static List<TurnoEntidad> ObtenerTurnos(string nombre, string apellido)
        {
            TurnoEntidad turno = null;
            List<TurnoEntidad> ListaTurnos = new List<TurnoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  p.idPaciente, p.nombre AS 'nombrePaciente', p.Apellido, t.fecha, t.hora, e.apellido AS 'ApellidoEmpleado' 
                                FROM    Turnos t, Pacientes p, Empleados e
                                WHERE   p.idPaciente = t.idPaciente AND t.codEmpleado = e.codEmpleado AND t.asignado = 'FALSE'";
            if (!string.IsNullOrEmpty(nombre))
            {
                cmd.CommandText += " AND p.nombre like @nom";
                cmd.Parameters.AddWithValue("@nom", nombre + "%");
            }
            if (!string.IsNullOrEmpty(apellido))
            {
                cmd.CommandText += " AND p.Apellido like @ape";
                cmd.Parameters.AddWithValue("@ape", apellido + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                turno = new TurnoEntidad();
                turno.idPaciente = int.Parse(dr["idPaciente"].ToString());
                turno.NombrePaciente = dr["nombrePaciente"].ToString();
                turno.ApellidoPaciente = dr["Apellido"].ToString();
                DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                turno.fecha = fecha.ToShortDateString();
                DateTime hora = DateTime.Parse(dr["hora"].ToString());
                turno.hora = hora.ToShortTimeString();
                turno.ApellidoEmpleado = dr["ApellidoEmpleado"].ToString();

                ListaTurnos.Add(turno);
            }
            dr.Close();
            cn.Close();
            return ListaTurnos;
        }

        public static void ModificarAsignacion(int? Paciente, DateTime fecha, DateTime hora)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.CommandText = @"UPDATE Turnos SET asignado = @asignacion 
                            WHERE idPaciente = @idPaciente AND fecha = @fecha AND hora = @hora";
            cmd.Parameters.AddWithValue("@idPaciente", Paciente);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@hora", hora.TimeOfDay);
            cmd.Parameters.AddWithValue("@asignacion", true);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static List<TurnoEntidad> TurnosPorFechaPorEspecialista(DateTime? fechaTurno, int? codEmp)
        {
            TurnoEntidad turno = null;
            List<TurnoEntidad> ListaTurnos = new List<TurnoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  p.idPaciente, p.nombre AS 'nombrePaciente', p.Apellido, t.fecha, t.hora, e.apellido AS 'apellidoEmpleado' 
                                FROM    Turnos t, Pacientes p, Empleados e
                                WHERE   p.idPaciente = t.idPaciente AND t.codEmpleado = e.codEmpleado AND t.asignado = 'FALSE'";
            if (fechaTurno != null)
            {
                cmd.CommandText += " AND t.fecha = @fecha";
                cmd.Parameters.AddWithValue("@fecha", fechaTurno);
            }
            if (codEmp != null)
            {
                cmd.CommandText += " AND t.codEmpleado = @codEmp";
                cmd.Parameters.AddWithValue("@codEmp", codEmp);
            }
            cmd.CommandText += " ORDER BY t.hora";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                turno = new TurnoEntidad();
                turno.idPaciente = int.Parse(dr["idPaciente"].ToString());
                turno.NombrePaciente = dr["nombrePaciente"].ToString();
                turno.ApellidoPaciente = dr["Apellido"].ToString();
                DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                turno.fecha = fecha.ToShortDateString();
                DateTime hora = DateTime.Parse(dr["hora"].ToString());
                turno.hora = hora.ToShortTimeString();
                turno.ApellidoEmpleado = dr["apellidoEmpleado"].ToString();

                ListaTurnos.Add(turno);
            }
            dr.Close();
            cn.Close();
            return ListaTurnos;
        }

        public static List<TurnoEntidad> TurnosPorFechaPorPaciente(DateTime? fechaTurno, int? idPaciente)
        {
            TurnoEntidad turno = null;
            List<TurnoEntidad> ListaTurnos = new List<TurnoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  p.idPaciente, p.nombre AS 'nombrePaciente', p.Apellido, t.fecha, t.hora, e.apellido AS 'apellidoEmpleado' 
                                FROM    Turnos t, Pacientes p, Empleados e
                                WHERE   p.idPaciente = t.idPaciente AND t.codEmpleado = e.codEmpleado";
            if (fechaTurno != null)
            {
                cmd.CommandText += " AND t.fecha = @fecha";
                cmd.Parameters.AddWithValue("@fecha", fechaTurno);
            }
            if (idPaciente != null)
            {
                cmd.CommandText += " AND p.idPaciente = @idPaciente";
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                turno = new TurnoEntidad();
                turno.idPaciente = int.Parse(dr["idPaciente"].ToString());
                turno.NombrePaciente = dr["nombrePaciente"].ToString();
                turno.ApellidoPaciente = dr["Apellido"].ToString();
                DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                turno.fecha = fecha.ToShortDateString();
                DateTime hora = DateTime.Parse(dr["hora"].ToString());
                turno.hora = hora.ToShortTimeString();
                turno.ApellidoEmpleado = dr["apellidoEmpleado"].ToString();

                ListaTurnos.Add(turno);
            }
            dr.Close();
            cn.Close();
            return ListaTurnos;
        }
    }
    }

