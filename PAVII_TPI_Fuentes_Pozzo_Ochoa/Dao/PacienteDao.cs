using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class PacienteDao
    {
        //****NICO
        // public static string cadena = "Data Source=NICO-PC;Initial Catalog=_PAV_COD;Integrated Security=True";
        //****FACULTAD
        // public static string cadena = "Data Source=maquis;Initial Catalog=_PAV_COD;User ID=avisuales2;Password=avisuales2";

        public static void Insertar(PacienteEntidad paciente)
        {
            SqlConnection cn = new SqlConnection();
            // cn.ConnectionString = "Data Source=NICO-PC;Initial Catalog=PAV02_COD;Integrated Security=True";
            // cn.ConnectionString = cadena;
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"insert into pacientes (nroDoc,idTipoDoc,nombre,apellido,sexo,fechaNacimiento,idLocalidad,telefono,celular,calle,nroCalle,piso,departamento)
                                    values(@nroDoc,@idTipoDoc,@nombre,@apelldio,@sexo,@fechaNacimiento,@idLocalidad,@telefono,@celular,@calle,@nroCalle,@piso,@departamento);select Scope_Identity() as ID";

                cmd.Parameters.AddWithValue("@nroDoc", paciente.NroDoc);
                cmd.Parameters.AddWithValue("@idTipoDoc", paciente.IdTipoDoc);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@apelldio", paciente.Apellido);
                cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@idLocalidad", paciente.IdLocalidad);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@celular", paciente.Celular);
                cmd.Parameters.AddWithValue("@calle", paciente.Calle);
                cmd.Parameters.AddWithValue("@nroCalle", paciente.NroCalle);
                cmd.Parameters.AddWithValue("@piso", paciente.Piso);
                cmd.Parameters.AddWithValue("@departamento", paciente.Departamento);
                cmd.Transaction = tran;
                paciente.Id = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();
            }
            catch (SqlException) { tran.Rollback(); }
            finally { cn.Close(); }

            cn.Close();
        }



        public static PacienteEntidad ObtenerPorID(int id)
        {
            PacienteEntidad p = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select idPaciente,nroDoc,idTipoDoc,nombre,apellido,sexo,fechaNacimiento,idLocalidad,telefono,celular,calle,nroCalle,piso,departamento from pacientes where idPaciente=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                p = new PacienteEntidad();

                p.Id = (int)dr["idPaciente"];
                p.NroDoc = (int)dr["nroDoc"];
                p.IdTipoDoc = (int)dr["idTipoDoc"];
                p.Nombre = dr["nombre"].ToString();
                p.Apellido = dr["apellido"].ToString();
                p.Sexo = (bool)dr["sexo"];
                p.FechaNacimiento = (DateTime)dr["fechaNacimiento"];
                p.IdLocalidad = (int)dr["idLocalidad"];
                p.Telefono = dr["telefono"].ToString();
                p.Celular = dr["celular"].ToString();
                p.Calle = dr["calle"].ToString();
                p.NroCalle = (int)dr["nroCalle"];
                p.Piso = (int)dr["piso"];
                p.Departamento = dr["departamento"].ToString();
            }
            dr.Close();
            cn.Close();

            return p;
        }

        public static void Eliminar(int id)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"delete from pacientes where idPaciente=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException) { tran.Rollback(); }
            finally { cn.Close(); }
        }

        public static void Acutalizar(PacienteEntidad paciente)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"update pacientes set nroDoc=@nroDoc,idTipoDoc=@idTipoDoc,nombre=@nombre,apellido=@apelldio,
                                    sexo=@sexo,fechaNacimiento=@fechaNacimiento,idLocalidad=@idLocalidad,telefono=@telefono,
                                    celular=@celular,calle=@calle,nroCalle=@nroCalle,piso=@piso,departamento=@departamento
                                     where idPaciente=@id";
                cmd.Parameters.AddWithValue("@id", paciente.Id.Value);
                cmd.Parameters.AddWithValue("@nroDoc", paciente.NroDoc);
                cmd.Parameters.AddWithValue("@idTipoDoc", paciente.IdTipoDoc);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@apelldio", paciente.Apellido);
                cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@idLocalidad", paciente.IdLocalidad);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@celular", paciente.Celular);
                cmd.Parameters.AddWithValue("@calle", paciente.Calle);
                cmd.Parameters.AddWithValue("@nroCalle", paciente.NroCalle);
                cmd.Parameters.AddWithValue("@piso", paciente.Piso);
                cmd.Parameters.AddWithValue("@departamento", paciente.Departamento);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException) { tran.Rollback(); }
            finally { cn.Close(); }
        }




        public static bool ValidarNroDoc(int nro)
        {
            bool bandera = true;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select top 1000 idPaciente,nroDoc,idTipoDoc,nombre,apellido,sexo,fechaNacimiento,idLocalidad,telefono,celular,calle,nroCalle,piso,departamento
                          from pacientes where nroDoc=@Nro";

            //cmd.CommandText = @"select from pacientes where nroDoc=@Nro";
            cmd.Parameters.AddWithValue("@Nro", nro);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                bandera = true;
            else
                bandera = false;
            dr.Close();
            cn.Close();

            return bandera;
        }

        public static PacienteEntidad ObtenerPorNroDoc(int nro)
        {
            PacienteEntidad p = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select idPaciente,nroDoc,idTipoDoc,nombre,apellido,sexo,fechaNacimiento,idLocalidad,telefono,celular,calle,nroCalle,piso,departamento from pacientes where nroDoc=@nroDoc";
            cmd.Parameters.AddWithValue("@nroDoc", nro);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                p = new PacienteEntidad();

                p.Id = (int)dr["idPaciente"];
                p.NroDoc = (int)dr["nroDoc"];
                p.IdTipoDoc = (int)dr["idTipoDoc"];
                p.Nombre = dr["nombre"].ToString();
                p.Apellido = dr["apellido"].ToString();
                p.Sexo = (bool)dr["sexo"];
                p.FechaNacimiento = (DateTime)dr["fechaNacimiento"];
                p.IdLocalidad = (int)dr["idLocalidad"];
                p.Telefono = dr["telefono"].ToString();
                p.Celular = dr["celular"].ToString();
                p.Calle = dr["calle"].ToString();
                p.NroCalle = (int)dr["nroCalle"];
                p.Piso = (int)dr["piso"];
                p.Departamento = dr["departamento"].ToString();
            }
            dr.Close();
            cn.Close();

            return p;
        }
    }
}
