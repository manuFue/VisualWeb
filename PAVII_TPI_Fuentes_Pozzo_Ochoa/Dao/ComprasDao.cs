using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class ComprasDao
    {
        public static void InsertarCompra(CompraInsumosEntidad compra, List<DetalleCompraInsumosEntidad> detalle)
        {
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            ////2. Crear el objeto command para ejecutar el insert
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT INTO CompraInsumos (idProveedor, fechaHora, montoTotal)
                                       VALUES ( @id, @fecha, @monto)";
                cmd.Parameters.AddWithValue("@id", compra.idProveedor);
                cmd.Parameters.AddWithValue("@fecha", compra.fechaHora);
                cmd.Parameters.AddWithValue("@monto", compra.montoTotal);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                foreach (DetalleCompraInsumosEntidad det in detalle)
                {
                    SqlCommand cmdDetalle = new SqlCommand();
                    cmdDetalle.Connection = cn;
                  
                    cmdDetalle.CommandText = @"INSERT INTO detalleCompraInsumos (idProveedor, fechaHora, codInsumo, cantidad, precioUnitario)
                                                      VALUES(@id, @fecha, @cod, @cant, @precio)";
                    cmdDetalle.Parameters.AddWithValue("@id", det.idProveedor);
                    cmdDetalle.Parameters.AddWithValue("@fecha", det.fechaHora);
                    cmdDetalle.Parameters.AddWithValue("@cod", det.codInsumo);
                    cmdDetalle.Parameters.AddWithValue("@cant", det.cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", det.precioUnitario);
                    cmdDetalle.Transaction = tran;
                 
                    cmdDetalle.ExecuteNonQuery();

                }

                foreach (DetalleCompraInsumosEntidad deta in detalle)
                {
                    SqlCommand cmdCant = new SqlCommand();
                    cmdCant.Connection = cn;
                    cmdCant.CommandText = @"UPDATE Insumos set
                                             cantidadStock = cantidadStock + @cant
                                            WHERE idInsumo = @id";
                    cmdCant.Parameters.AddWithValue("@cant", deta.cantidad);
                    cmdCant.Parameters.AddWithValue("@id", deta.codInsumo);
                    cmdCant.Transaction = tran;
                    cmdCant.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (SqlException)
            {
                tran.Rollback();
            }
            finally { cn.Close(); }

            cn.Close();
        }
    }
}



