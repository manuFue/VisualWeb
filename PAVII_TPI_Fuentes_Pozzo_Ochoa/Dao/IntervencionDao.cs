using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class IntervencionDao
    {

        public static IntervencionEntidad IntervencionPorID(int id)
        {

            IntervencionEntidad i = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000 i.codIntervencion,i.idPaciente,i.fecha,i.hora,i.codTratamiento,i.montoTotal,i.observaciones,i.idCondicion
                                from intervencion i   
                                where i.codIntervencion=@Id";
            cmd.Parameters.AddWithValue("@Id", id);


            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = new IntervencionEntidad();

                i.CodIntervencion = (int)dr["codIntervencion"];
                i.IdPaciente = (int)dr["idPaciente"];
                i.Fecha = (DateTime)dr["fecha"];
                i.Hora = DateTime.Parse(dr["hora"].ToString());
                i.CodIntervencion = (int)dr["codTratamiento"];
                i.MontoTotal = double.Parse(dr["montoTotal"].ToString());
                i.Observaciones = dr["observaciones"].ToString();
                i.Condicion = (int)dr["idCondicion"];

            }
            dr.Close();
            cn.Close();

            return i;
        }


        public static bool ValidarEliminacionPaciente(int id)
        {
            bool bandera = true;

            SqlConnection cn = new SqlConnection();
            // cn.ConnectionString = "Data Source=NICO-PC;Initial Catalog=PAV02_COD;Integrated Security=True";
            // cn.ConnectionString = cadena;
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select top 1000 i.codIntervencion
                            from  intervencion i 
                            where  i.idPaciente=@Id";
            // and i.idCondicion=2;

            //cmd.CommandText = @"select from pacientes where nroDoc=@Nro";
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                bandera = true;
            else
                bandera = false;

            dr.Close();
            cn.Close();

            return bandera;
        }

        public static void Insertar(IntervencionEntidad intervencion, List<InsumosXIntervencionEntidad> ListaInsumos)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = cn;
            try
            {
                cmd.CommandText = @"INSERT INTO Intervencion 
                                    (idPaciente,
                                    fecha,
                                    hora,
                                    codTratamiento,
                                    montoTotal,
                                    observaciones,
                                    idCondicion) values (
                                    @idPaciente,
                                    @fecha,
                                    @hora,
                                    @codTratamiento,
                                    @montoTotal,
                                    @observaciones,
                                    @condicion);select Scope_Identity() as ID";
                cmd.Parameters.AddWithValue("@idPaciente", intervencion.IdPaciente);
                cmd.Parameters.AddWithValue("@fecha", intervencion.Fecha);
                cmd.Parameters.AddWithValue("@hora", intervencion.Hora);
                cmd.Parameters.AddWithValue("@codTratamiento", intervencion.CodTratamiento);
                cmd.Parameters.AddWithValue("@montoTotal", intervencion.MontoTotal);
                cmd.Parameters.AddWithValue("@observaciones", intervencion.Observaciones);
                cmd.Parameters.AddWithValue("@condicion", intervencion.Condicion);


                intervencion.CodIntervencion = Convert.ToInt32(cmd.ExecuteScalar());
                foreach (InsumosXIntervencionEntidad insumo in ListaInsumos)
                {
                    insumo.codIntervencion = intervencion.CodIntervencion;

                    SqlCommand cmdIn = new SqlCommand();
                    cmdIn.Transaction = tran;
                    cmdIn.Connection = cn;
                    cmdIn.CommandText = @"INSERT INTO InsumosXIntervencion (codIntervencion, idInsumo, cantidadInsumos)
                                        values (@codIntervencion, @idInsumo, @cantidadInsumos)
                                        ;select Scope_Identity() as ID";
                    cmdIn.Parameters.AddWithValue("@codIntervencion", insumo.codIntervencion);
                    cmdIn.Parameters.AddWithValue("@idInsumo", insumo.idInsumo);
                    cmdIn.Parameters.AddWithValue("@cantidadInsumos", insumo.cantidadIntervencion);
                    cmdIn.ExecuteNonQuery();
                }
                tran.Commit();

            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw new Exception("Error al guardar la intervencion: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
