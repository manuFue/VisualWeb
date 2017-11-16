using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{

    public class TipoDocumentoDao
    {
        public static List<TipoDocumentoEntidad> ObtenerTipos()
        {
            TipoDocumentoEntidad tip = null;
            List<TipoDocumentoEntidad> ListaTipos = new List<TipoDocumentoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT IdTD, DescripcionTD FROM TipoDocumentos";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tip = new TipoDocumentoEntidad();
                tip.Id = int.Parse(dr["IdTD"].ToString());
                tip.Descripcion = dr["DescripcionTD"].ToString();

                ListaTipos.Add(tip);
            }
            dr.Close();
            cn.Close();
            return ListaTipos;
        }
    }
}
