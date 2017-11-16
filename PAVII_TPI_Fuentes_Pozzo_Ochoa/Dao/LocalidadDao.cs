using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class LocalidadDao
    {
        public static List<LocalidadEntidad> ObtenerLocalidades()
        {
            LocalidadEntidad Local = null;
            List<LocalidadEntidad> ListaLocalidad = new List<LocalidadEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT TOP 1000 IdLoc, DescripcionLoc FROM Localidades";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Local = new LocalidadEntidad();
                Local.Id = int.Parse(dr["IdLoc"].ToString());
                Local.Descripcion = dr["DescripcionLoc"].ToString();

                ListaLocalidad.Add(Local);
            }
            dr.Close();
            cn.Close();
            return ListaLocalidad;
        }
    }
}
