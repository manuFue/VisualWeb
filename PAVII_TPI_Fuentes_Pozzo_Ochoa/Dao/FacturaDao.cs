using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
    
namespace Dao
{
    public class FacturaDao
    {
        public static int NroFactura()
        {
            int nro=0;

            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @" select count (nroFactura) as nroFactura from factura ";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               FacturaEntidad f = new FacturaEntidad();

                f.NroFactura = (int)dr["nroFactura"];
                nro = ((int)f.NroFactura) + 1;
            }
            dr.Close();
            cn.Close();
            cn.Close();

            return nro;
        }


        public static void InsertarFacutura(FacturaEntidad factura, List<DetalleFacturaEntidad> detalles)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"insert into Factura (nroFactura,idPaciente,montoTotal,fechaFac,idFormaPago) 
                                    values(@NroFactura,@IdPaciente,@MontoTotal,@Fecha,@IdForma); select Scope_Identity() as ID";
                cmd.Parameters.AddWithValue("@NroFactura", factura.NroFactura);
                cmd.Parameters.AddWithValue("@IdPaciente", factura.IdPaciente);
                cmd.Parameters.AddWithValue("@MontoTotal", factura.MontoTotal);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@IdForma", factura.IdFormaPago);
                cmd.Transaction = tran;
                factura.Id = Convert.ToInt32(cmd.ExecuteScalar());

                
                foreach (DetalleFacturaEntidad dt in detalles)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cmd2.CommandText = @"insert into DetalleFactura (nroFactura,codIntervencion,cantidad,precio,cantidadAbonada) values(@NroFactura,@CodIntervencion,@Cantidad,@Precio,@CantidadAbonada)";
                    cmd2.Parameters.AddWithValue("@NroFactura", dt.NroFactura);
                    cmd2.Parameters.AddWithValue("@CodIntervencion", dt.CodIntervencion.Value);
                    cmd2.Parameters.AddWithValue("@Cantidad", dt.Cantidad);
                    cmd2.Parameters.AddWithValue("@Precio", dt.Precio);
                    cmd2.Parameters.AddWithValue("@CantidadAbonada", dt.Precio);
                    
                    cmd2.Transaction = tran;
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = cn;
                    cmd3.CommandText = @"update intervencion set idCondicion=2 where codIntervencion =@Cod";
                    cmd3.Parameters.AddWithValue("@Cod", dt.CodIntervencion.Value);
                   // cmd3.Parameters.AddWithValue("@Condicion", condicion);
                    cmd3.Transaction = tran;
                    cmd3.ExecuteNonQuery();
                }

        
                tran.Commit();
            }
            catch (SqlException) { tran.Rollback(); }
            finally { cn.Close(); }
        }

    }
}
