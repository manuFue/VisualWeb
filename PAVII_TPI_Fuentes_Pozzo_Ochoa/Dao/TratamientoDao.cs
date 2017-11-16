using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class TratamientoDao
    {
        public static List<TratamientoEntidad> ObtenerTratamientos()
        {
            TratamientoEntidad trat = null;
            List<TratamientoEntidad> ListaTratamientos = new List<TratamientoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT IdTratamiento, DescripcionTratamiento, costo FROM Tratamientos";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                trat = new TratamientoEntidad();
                trat.idTratamiento = int.Parse(dr["IdTratamiento"].ToString());
                trat.descripcionTratamiento = dr["DescripcionTratamiento"].ToString();
                trat.costo = double.Parse(dr["costo"].ToString());

                ListaTratamientos.Add(trat);
            }
            dr.Close();
            cn.Close();
            return ListaTratamientos;
        }

        public static double ObtenerCostoPorID(int idTratamiento)
        {
            double costo = 0;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT costo FROM Tratamientos WHERE idTratamiento = @id";
            cmd.Parameters.AddWithValue("@id", idTratamiento);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                costo = double.Parse(dr["costo"].ToString());
            }
            dr.Close();
            cn.Close();
            return costo;
        }
    }
}
