using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class UsuarioDao
    {

        public static bool Usuario(string usu, string pass)
        {
            bool bandera = false;
            //string usuario = string.Empty;
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=STUKCH;Initial Catalog=_PAV_COD;Integrated Security=True";
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM Usuarios WHERE nombreUsuario = @Usu AND password = @Pass";
            cmd.Parameters.AddWithValue("@Usu", usu);
            cmd.Parameters.AddWithValue("@Pass", pass);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                bandera = true;
                //UsuarioEntidad u = new UsuarioEntidad();
                //u.NombreUsuario = dr["nombreUsuario"].ToString();
                //usuario = u.NombreUsuario;
            }
            dr.Close();
            cn.Close();
            return bandera;
        }

        public static string Permiso(string usu)
        {
            string permiso = String.Empty;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT p.descripcion AS nombrePermiso
                                FROM Usuarios u, Permisos p 
                                WHERE u.idPermiso = p.idPermiso AND nombreUsuario = @Usu ";
            cmd.Parameters.AddWithValue("@Usu", usu);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                permiso = dr["nombrePermiso"].ToString();
            }
            dr.Close();
            cn.Close();
            return permiso;
        }

        public static void NuevaClave(string claveNueva)
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=STUKCH;Initial Catalog=_PAV_COD;Integrated Security=True";
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Update Usuarios set password=@PW";
                cmd.Parameters.AddWithValue("@PW",claveNueva);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                tran.Commit();
            }
            catch (SqlException) { tran.Rollback(); }
            finally { cn.Close(); }

        }

    }
}
