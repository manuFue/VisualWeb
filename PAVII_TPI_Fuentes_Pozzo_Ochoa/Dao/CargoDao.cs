using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class CargoDao
    {
        public static List<CargoEntidad> ObtenerCargos()
        {
            CargoEntidad Cargo = null;
            List<CargoEntidad> ListaCargos = new List<CargoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT IdCargo, DescripcionCargo FROM Cargo";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cargo = new CargoEntidad();
                Cargo.IdCargo = int.Parse(dr["IdCargo"].ToString());
                Cargo.Descripcion = dr["DescripcionCargo"].ToString();

                ListaCargos.Add(Cargo);
            }
            dr.Close();
            cn.Close();
            return ListaCargos;
        }
    }
}
