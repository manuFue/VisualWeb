using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class FormaPagoDao
    {
        public static List<FormaPagoEntidad> ListaForma()
        {
            List<FormaPagoEntidad> lista = new List<FormaPagoEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select top 1000 idFP,descripcionFP from FormaPago";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FormaPagoEntidad f = new FormaPagoEntidad();

                f.IdFP = (int)dr["idFP"];
                f.DescripcionFP = dr["descripcionFP"].ToString();

                lista.Add(f);
            }
            dr.Close();
            cn.Close();

            return lista;
        }
    }
}
