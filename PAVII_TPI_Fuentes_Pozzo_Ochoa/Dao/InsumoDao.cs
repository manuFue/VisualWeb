using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class InsumoDao
    {
               public static List<InsumoEntidad> ObtenerInsumosValidos()
        {
            List<InsumoEntidad> listInsumos = new List<InsumoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000 idInsumo, descripcion, cantidadStock, puntoReposicion
                                FROM Insumos
                                WHERE puntoReposicion < cantidadStock";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                InsumoEntidad i = new InsumoEntidad()
                {
                    idInsumo = int.Parse(dr["idInsumo"].ToString()),
                    descripcion = (dr["descripcion"].ToString()),
                    cantidadStock = int.Parse(dr["cantidadStock"].ToString()),
                    puntoReposicion = int.Parse(dr["puntoReposicion"].ToString())
                };

                listInsumos.Add(i);
            }
            dr.Close();
            cn.Close();
            return listInsumos;
        }

               public static List<InsumoEntidad> ObtenerInsumos()
               {
                   List<InsumoEntidad> listInsumos = new List<InsumoEntidad>();
                   //1. Abrir la conexion
                   SqlConnection cn = new SqlConnection();
                   cn.ConnectionString = ConnectionString.Cadena();
                   cn.Open();
                   //2. Crear el objeto command para ejecutar el insert
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = cn;
                   cmd.CommandText = @"Select idInsumo, descripcion, cantidadStock, puntoReposicion
                                from Insumos";

                   SqlDataReader dr = cmd.ExecuteReader();
                   while (dr.Read())
                   {
                       InsumoEntidad i = new InsumoEntidad()
                       {
                           idInsumo = int.Parse(dr["idInsumo"].ToString()),
                           descripcion = (dr["descripcion"].ToString()),
                           cantidadStock = int.Parse(dr["cantidadStock"].ToString()),
                           puntoReposicion = int.Parse(dr["puntoReposicion"].ToString())
                       };

                       listInsumos.Add(i);
                   }
                   dr.Close();
                   cn.Close();
                   return listInsumos;
               }

        public static void RestarInsumos(int? id, int? cantidad)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"UPDATE Insumos SET cantidadStock = (cantidadStock - @cantidad)
                                WHERE idInsumo = @idInsumo";
            cmd.Parameters.AddWithValue("@idInsumo", id);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
