using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class InformeCompraDao
    {
        public static List<ProveedorEntidad> ObtenerProveedores()
        {
            List<ProveedorEntidad> listProv = new List<ProveedorEntidad>();
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select idProveedor, nombreResponsable
                                from proveedores";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProveedorEntidad p = new ProveedorEntidad()
                {
                    idProveedor = int.Parse(dr["idProveedor"].ToString()),
                    nombreResponsable = (dr["nombreResponsable"].ToString())
                };

                listProv.Add(p);
            }
            dr.Close();
            cn.Close();
            return listProv;
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
            cmd.CommandText = @"Select idInsumo, descripcion
                                from Insumos";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                InsumoEntidad i = new InsumoEntidad()
                {
                    idInsumo = int.Parse(dr["idInsumo"].ToString()),
                    descripcion = (dr["descripcion"].ToString())
                };

                listInsumos.Add(i);
            }
            dr.Close();
            cn.Close();
            return listInsumos;
        }



        public static List<InformeCompra> ListaInforme(int? IdProveedor, int? idInsumo, DateTime? fd, DateTime? fh)
        {

            List<InformeCompra> lista = new List<InformeCompra>();
            SqlConnection cn = new SqlConnection();
            // cn.ConnectionString = "Data Source=NICO-PC;Initial Catalog=PAV02_COD;Integrated Security=True";
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select I.descripcion as 'descripcion', D.cantidad as 'cantidad', P.nombreResponsable as 'nombreEmpresa',
                                        C.fechaHora as 'fecha'
                               from compraInsumos C JOIN detalleCompraInsumos D ON C.idProveedor = D.idProveedor 
                               JOIN Insumos I ON D.codInsumo = I.idInsumo
                               JOIN proveedores P ON C.idProveedor = P.idProveedor
                               where 1=1 ";


            if (IdProveedor.HasValue)
            {
                cmd.CommandText += " and C.idProveedor = @idProv ";
                cmd.Parameters.AddWithValue("@idProv", IdProveedor);
            }
            if (idInsumo.HasValue)
            {
                cmd.CommandText += " and D.codInsumo=@codIns ";
                cmd.Parameters.AddWithValue("@codIns", idInsumo.Value);
            }

            if (fd.HasValue)
            {
                cmd.CommandText += " and C.fechaHora >= @FD ";
                cmd.Parameters.AddWithValue("@FD", fd.Value);

            }
            if (fh.HasValue)
            {
                cmd.CommandText += " and C.fechaHora <= @FH ";
                cmd.Parameters.AddWithValue("@FH", fh.Value);
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                InformeCompra i = new InformeCompra()
                {

                    descripcion = (dr["descripcion"].ToString()),
                    cantidad = int.Parse(dr["cantidad"].ToString()),
                    nombreEmpresa = dr["nombreEmpresa"].ToString(),
                    fecha = DateTime.Parse(dr["fecha"].ToString()),


                };
                lista.Add(i);
            }
            dr.Close();
            cn.Close();

            return lista;
        }
    }
}

