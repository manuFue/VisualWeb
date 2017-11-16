using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class CondicionDao
    {
        public static List<CondicionEntidad> ListaCond()
        {
            List<CondicionEntidad> lista = new List<CondicionEntidad>();

            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select top 10 id,descripcion from condicion";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CondicionEntidad c = new CondicionEntidad();

                c.Id = (int)dr["id"];
                c.Descripcion = dr["descripcion"].ToString();

                lista.Add(c);
            }
            dr.Close();
            cn.Close();

            return lista;
        }

    }
}