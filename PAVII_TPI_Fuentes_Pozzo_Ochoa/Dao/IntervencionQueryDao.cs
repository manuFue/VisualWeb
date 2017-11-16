using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class IntervencionQueryDao
    {
        public static List<IntervencionQuery> ListaInforme(string Apellido, DateTime? fechaDesde, DateTime? fechaHasta, int? idTratamiento)
        {

            List<IntervencionQuery> lista = new List<IntervencionQuery>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000 p.idPaciente,p.nombre,p.apellido AS 'Apellido', t.fecha, t.hora, 
                                    c.descripcion, tr.descripcionTratamiento, i.montoTotal, i.observaciones
                                    FROM pacientes p, Turnos t, Intervencion i, tratamientos tr, Condicion c
                                    WHERE p.idPaciente = t.idPaciente AND t.idPaciente = i.idPaciente AND t.fecha = i.fecha 
                                    AND t.hora = i.hora AND i.codTratamiento = tr.idTratamiento AND i.idCondicion = c.id";

            if (!string.IsNullOrEmpty(Apellido))
            {
                cmd.CommandText += " AND p.apellido LIKE @ape";
                cmd.Parameters.AddWithValue("@ape", Apellido + "%");
            }
            if (fechaDesde.HasValue)
            {
                cmd.CommandText += " and i.fecha >= @FD";
                cmd.Parameters.AddWithValue("@FD", fechaDesde.Value);

            }
            if (fechaHasta.HasValue)
            {
                cmd.CommandText += " and i.fecha <= @FH";
                cmd.Parameters.AddWithValue("@FH", fechaHasta.Value);
            }
            if (idTratamiento.HasValue && idTratamiento != 0)
            {
                cmd.CommandText += " and tr.idTratamiento=@Trat";
                cmd.Parameters.AddWithValue("@Trat", idTratamiento.Value);
            }
            cmd.CommandText += " ORDER BY Apellido";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IntervencionQuery i = new IntervencionQuery();

                i.IdPaciente = (int)dr["idPaciente"];
                i.nombrePaciente = dr["nombre"].ToString();
                i.apellidoPaciente = dr["apellido"].ToString();
                DateTime fecha;
                if (dr["fecha"] != DBNull.Value)
                {
                    fecha = DateTime.Parse(dr["fecha"].ToString());
                    i.fecha = fecha.ToShortDateString();
                }
                if (dr["hora"] != DBNull.Value)
                    i.hora = dr["hora"].ToString();
                i.descripcionTratamiento = dr["descripcionTratamiento"].ToString();
                i.descripcionCondicion = dr["descripcion"].ToString();
                if (dr["montoTotal"] != DBNull.Value)
                    i.montoTotal = double.Parse(dr["montoTotal"].ToString());
                i.observaciones = dr["observaciones"].ToString();

                lista.Add(i);
            }
            dr.Close();
            cn.Close();

            return lista;
        }



        public static List<IntervencionQuery> ListaInteevencionesFactura(int id)
        {

            List<IntervencionQuery> lista = new List<IntervencionQuery>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            cmd.CommandText = @"SELECT TOP 1000 p.idPaciente,tr.descripcionTratamiento,i.codIntervencion, i.montoTotal,i.observaciones, c.descripcion
                                    FROM pacientes p,  Intervencion i, tratamientos tr, Condicion c
                                    WHERE  p.idPaciente=@Id and p.idPaciente = i.idPaciente AND 
                                    i.codTratamiento = tr.idTratamiento AND i.idCondicion = c.id and c.id=1";
            cmd.Parameters.AddWithValue("Id", id);


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IntervencionQuery i = new IntervencionQuery();

                i.codIntervencion = (int)dr["codIntervencion"];
                i.IdPaciente = (int)dr["idPaciente"];
                i.descripcionTratamiento = dr["descripcionTratamiento"].ToString();
                i.descripcionCondicion = dr["descripcion"].ToString();
                if (dr["montoTotal"] != DBNull.Value)
                    i.montoTotal = double.Parse(dr["montoTotal"].ToString());
                i.observaciones = dr["observaciones"].ToString();

                lista.Add(i);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

    }
}
