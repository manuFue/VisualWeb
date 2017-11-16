using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class EmpleadoDao
    {
        public static void Insertar(EmpleadoEntidad empleado)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"INSERT INTO Empleados (
                                    Nombre, Apellido, IdTipoDoc, NroDoc, Fechanacimiento,
                                    Telefono, Celular, IdLocalidad, Calle, NroCalle, Piso, Departamento,
                                    IdCargo, Sueldo, HoraIngreso, HoraEgreso, Activo) values (
                                    @Nombre, @Apellido, @IdTipoDoc, @NroDoc, @Fechanacimiento,
                                    @Telefono, @Celular, @IdLocalidad, @Calle, @NroCalle, @Piso, @Departamento,
                                    @idCargo, @Sueldo, @HoraIngreso, @HoraEgreso, @Activo);select Scope_Identity() as ID";
            cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
            cmd.Parameters.AddWithValue("@IdTipoDoc", empleado.IdTipoDoc);
            cmd.Parameters.AddWithValue("@NroDoc", empleado.NroDoc);
            cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
            cmd.Parameters.AddWithValue("@Celular", empleado.Celular);
            cmd.Parameters.AddWithValue("@IdLocalidad", empleado.IdLocalidad);
            cmd.Parameters.AddWithValue("@Calle", empleado.Calle);
            cmd.Parameters.AddWithValue("@NroCalle", empleado.NroCalle);
            cmd.Parameters.AddWithValue("@Piso", empleado.Piso);
            cmd.Parameters.AddWithValue("@Departamento", empleado.Departamento);
            cmd.Parameters.AddWithValue("@IdCargo", empleado.IdCargo);
            cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
            cmd.Parameters.AddWithValue("@HoraIngreso", empleado.HoraIngreso);
            cmd.Parameters.AddWithValue("@HoraEgreso", empleado.HoraEgreso);
            cmd.Parameters.AddWithValue("@Activo", empleado.Activo);
            empleado.CodEmpleado = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
        }

        public static void Actualizar(EmpleadoEntidad empleado)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"UPDATE Empleados SET 
                                    Nombre = @Nombre,
                                    Apellido = @Apellido,
                                    IdTipoDoc = @IdTipoDoc,
                                    NroDoc = @NroDoc,
                                    FechaNacimiento = @FechaNacimiento,
                                    Telefono = @Telefono,
                                    Celular = @Celular,
                                    IdLocalidad = @IdLocalidad,
                                    Calle = @Calle,
                                    NroCalle = @NroCalle,
                                    Piso = @Piso,
                                    Departamento = @Departamento,
                                    IdCargo = @IdCargo,
                                    Sueldo = @Sueldo,
                                    HoraIngreso = @HoraIngreso,
                                    HoraEgreso = @HoraEgreso,
                                    Activo = @Activo
                                WHERE CodEmpleado = @ID";
            cmd.Parameters.AddWithValue("@ID", empleado.CodEmpleado);
            cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
            cmd.Parameters.AddWithValue("@IdTipoDoc", empleado.IdTipoDoc);
            cmd.Parameters.AddWithValue("@NroDoc", empleado.NroDoc);
            cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
            cmd.Parameters.AddWithValue("@Celular", empleado.Celular);
            cmd.Parameters.AddWithValue("@IdLocalidad", empleado.IdLocalidad);
            cmd.Parameters.AddWithValue("@Calle", empleado.Calle);
            cmd.Parameters.AddWithValue("@NroCalle", empleado.NroCalle);
            cmd.Parameters.AddWithValue("@Piso", empleado.Piso);
            cmd.Parameters.AddWithValue("@Departamento", empleado.Departamento);
            cmd.Parameters.AddWithValue("@IdCargo", empleado.IdCargo);
            cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
            cmd.Parameters.AddWithValue("@HoraIngreso", empleado.HoraIngreso);
            cmd.Parameters.AddWithValue("@HoraEgreso", empleado.HoraEgreso);
            cmd.Parameters.AddWithValue("@Activo", empleado.Activo);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void Eliminar(int cod)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"DELETE FROM Empleados WHERE CodEmpleado = @ID";
            cmd.Parameters.AddWithValue("@ID", cod);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static EmpleadoEntidad ObtenerPorID(int? cod)
        {
            EmpleadoEntidad emp = null;
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT 
                                [CodEmpleado], 
                                [Nombre],
                                [Apellido],
                                [IdTipoDoc],
                                [NroDoc],
                                [FechaNacimiento],
                                [Telefono],
                                [Celular],
                                [IdLocalidad],
                                [Calle],
                                [NroCalle],
                                [Piso],
                                [Departamento],
                                [IdCargo],
                                [Sueldo],
                                [HoraIngreso],
                                [HoraEgreso],
                                [Activo] FROM Empleados WHERE CodEmpleado = @id";
            cmd.Parameters.AddWithValue("@id", cod);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                emp = new EmpleadoEntidad()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["IdTipoDoc"].ToString()),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["IdLocalidad"].ToString()),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["IdCargo"].ToString()),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };

            }
            dr.Close();
            cn.Close();
            return emp;
        }

        public static List<EmpleadoEntidad> ObtenerTodos()
        {
            List<EmpleadoEntidad> listEmpleados = new List<EmpleadoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000
                                [CodEmpleado], 
                                [Nombre],
                                [Apellido],
                                [IdTipoDoc],
                                [NroDoc],
                                [FechaNacimiento],
                                [Telefono],
                                [Celular],
                                [IdLocalidad],
                                [Calle],
                                [NroCalle],
                                [Piso],
                                [Departamento],
                                [IdCargo],
                                [Sueldo],
                                [HoraIngreso],
                                [HoraEgreso],
                                [Activo] FROM Empleados";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EmpleadoEntidad emp = new EmpleadoEntidad()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["IdTipoDoc"].ToString()),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["IdLocalidad"].ToString()),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["IdCargo"].ToString()),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listEmpleados.Add(emp);
            }
            dr.Close();
            cn.Close();
            return listEmpleados;
        }

        public static List<EmpleadoEntidad> ObtenerPorNombre(string Nombre)
        {
            List<EmpleadoEntidad> listEmpleados = new List<EmpleadoEntidad>();
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000
                                [CodEmpleado], 
                                [Nombre],
                                [Apellido],
                                [IdTipoDoc],
                                [NroDoc],
                                [FechaNacimiento],
                                [Telefono],
                                [Celular],
                                [IdLocalidad],
                                [Calle],
                                [NroCalle],
                                [Piso],
                                [Departamento],
                                [IdCargo],
                                [Sueldo],
                                [HoraIngreso],
                                [HoraEgreso],
                                [Activo] FROM Empleados WHERE Nombre LIKE @Nombre";
            cmd.Parameters.AddWithValue("@Nombre", Nombre + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EmpleadoEntidad emp = new EmpleadoEntidad()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["IdTipoDoc"].ToString()),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["IdLocalidad"].ToString()),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["IdCargo"].ToString()),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listEmpleados.Add(emp);
            }
            dr.Close();
            cn.Close();
            return listEmpleados;
        }

        public static List<EmpleadoEntidad> ObtenerPorApellido(string Apellido)
        {
            List<EmpleadoEntidad> listEmpleados = new List<EmpleadoEntidad>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000
                                [CodEmpleado], 
                                [Nombre],
                                [Apellido],
                                [IdTipoDoc],
                                [NroDoc],
                                [FechaNacimiento],
                                [Telefono],
                                [Celular],
                                [IdLocalidad],
                                [Calle],
                                [NroCalle],
                                [Piso],
                                [Departamento],
                                [IdCargo],
                                [Sueldo],
                                [HoraIngreso],
                                [HoraEgreso],
                                [Activo] FROM Empleados WHERE Apellido LIKE @Apellido";
            cmd.Parameters.AddWithValue("@Apellido", Apellido + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EmpleadoEntidad emp = new EmpleadoEntidad()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["IdTipoDoc"].ToString()),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["IdLocalidad"].ToString()),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["IdCargo"].ToString()),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listEmpleados.Add(emp);
            }
            dr.Close();
            cn.Close();
            return listEmpleados;
        }


        public static bool ExisteNroDoc(int nroDoc)
        {
            bool flag = false;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT TOP 1000
                                [CodEmpleado], 
                                [Nombre],
                                [Apellido],
                                [IdTipoDoc],
                                [NroDoc],
                                [FechaNacimiento],
                                [Telefono],
                                [Celular],
                                [IdLocalidad],
                                [Calle],
                                [NroCalle],
                                [Piso],
                                [Departamento],
                                [IdCargo],
                                [Sueldo],
                                [HoraIngreso],
                                [HoraEgreso],
                                [Activo] FROM Empleados WHERE NroDoc = @Nro";
            cmd.Parameters.AddWithValue("@Nro", nroDoc);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                flag = true;
            dr.Close();
            cn.Close();
            return flag;
        }
    }
}
