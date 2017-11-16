using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class EmpleadoQueryDao
    {
               public static List<EmpleadoQuery> ObtenerTodosCompleto()
        {
            List<EmpleadoQuery> listQuery = new List<EmpleadoQuery>();
            EmpleadoQuery emp = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  Empleados.codEmpleado, Empleados.Nombre, Empleados.Apellido, Empleados.idTipoDoc, Empleados.NroDoc, Empleados.FechaNacimiento, 
                                        Empleados.Telefono, Empleados.Celular, Empleados.idLocalidad, Empleados.Calle, Empleados.NroCalle, Empleados.Piso, Empleados.Departamento,
                                        Empleados.IdCargo, Empleados.Sueldo, Empleados.HoraIngreso, Empleados.HoraEgreso, Empleados.Activo, 
                                        TipoDocumentos.idTD AS Expr1, TipoDocumentos.DescripcionTD, Localidades.idLoc AS Expr2, Localidades.DescripcionLoc, Cargo.idCargo AS Expr3, Cargo.DescripcionCargo
                                FROM    Empleados
                                        LEFT OUTER JOIN TipoDocumentos ON Empleados.idTipoDoc = TipoDocumentos.idTD
                                        LEFT OUTER JOIN Localidades ON Empleados.idLocalidad = Localidades.idLoc
                                        LEFT OUTER JOIN Cargo ON Empleados.idCargo = Cargo.idCargo
                                WHERE   1 = 1";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new EmpleadoQuery()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["IdTipoDoc"].ToString()),
                    DescripcionTD = dr["DescripcionTD"].ToString(),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["IdLocalidad"].ToString()),
                    DescripcionLoc = dr["DescripcionLoc"].ToString(),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["IdCargo"].ToString()),
                    DescripcionCargo = dr["DescripcionCargo"].ToString(),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listQuery.Add(emp);
            }

            dr.Close();
            cn.Close();
            return listQuery;
        }

        public static List<EmpleadoQuery> ObtenerEmpleadoCompletoPorApellido(string Apellido)
        {
            List<EmpleadoQuery> listQuery = new List<EmpleadoQuery>();
            EmpleadoQuery emp = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  Empleados.codEmpleado, Empleados.Nombre, Empleados.Apellido, Empleados.idTipoDoc, Empleados.NroDoc, Empleados.FechaNacimiento, 
                                        Empleados.Telefono, Empleados.Celular, Empleados.idLocalidad, Empleados.Calle, Empleados.NroCalle, Empleados.Piso, Empleados.Departamento,
                                        Empleados.IdCargo, Empleados.Sueldo, Empleados.HoraIngreso, Empleados.HoraEgreso, Empleados.Activo, 
                                        TipoDocumentos.idTD AS Expr1, TipoDocumentos.DescripcionTD, Localidades.idLoc AS Expr2, Localidades.DescripcionLoc, Cargo.idCargo AS Expr3, Cargo.DescripcionCargo
                                FROM    Empleados
                                        LEFT OUTER JOIN TipoDocumentos ON Empleados.idTipoDoc = TipoDocumentos.idTD
                                        LEFT OUTER JOIN Localidades ON Empleados.idLocalidad = Localidades.idLoc
                                        LEFT OUTER JOIN Cargo ON Empleados.idCargo = Cargo.idCargo
                                WHERE   1 = 1";
            if (!string.IsNullOrEmpty(Apellido))
            {
                cmd.CommandText += " AND Apellido like @ape";
                cmd.Parameters.AddWithValue("@ape", Apellido + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new EmpleadoQuery()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["idTipoDoc"].ToString()),
                    DescripcionTD = dr["DescripcionTD"].ToString(),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["idLocalidad"].ToString()),
                    DescripcionLoc = dr["DescripcionLoc"].ToString(),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["idCargo"].ToString()),
                    DescripcionCargo = dr["DescripcionCargo"].ToString(),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listQuery.Add(emp);
            }
            dr.Close();
            cn.Close();
            return listQuery;
        }


        public static List<EmpleadoQuery> ObtenerEmpleadoCompletoPorNombre(string Nombre)
        {
            List<EmpleadoQuery> listQuery = new List<EmpleadoQuery>();
            EmpleadoQuery emp = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  Empleados.codEmpleado, Empleados.Nombre, Empleados.Apellido, Empleados.idTipoDoc, Empleados.NroDoc, Empleados.FechaNacimiento, 
                                        Empleados.Telefono, Empleados.Celular, Empleados.idLocalidad, Empleados.Calle, Empleados.NroCalle, Empleados.Piso, Empleados.Departamento,
                                        Empleados.IdCargo, Empleados.Sueldo, Empleados.HoraIngreso, Empleados.HoraEgreso, Empleados.Activo, 
                                        TipoDocumentos.idTD AS Expr1, TipoDocumentos.DescripcionTD, Localidades.idLoc AS Expr2, Localidades.DescripcionLoc, Cargo.idCargo AS Expr3, Cargo.DescripcionCargo
                                FROM    Empleados
                                        LEFT OUTER JOIN TipoDocumentos ON Empleados.idTipoDoc = TipoDocumentos.idTD
                                        LEFT OUTER JOIN Localidades ON Empleados.idLocalidad = Localidades.idLoc
                                        LEFT OUTER JOIN Cargo ON Empleados.idCargo = Cargo.idCargo
                                WHERE   1 = 1";
            if (!string.IsNullOrEmpty(Nombre))
            {
                cmd.CommandText += " AND Nombre like @nom";
                cmd.Parameters.AddWithValue("@nom", Nombre + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new EmpleadoQuery()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["idTipoDoc"].ToString()),
                    DescripcionTD = dr["DescripcionTD"].ToString(),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["idLocalidad"].ToString()),
                    DescripcionLoc = dr["DescripcionLoc"].ToString(),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["idCargo"].ToString()),
                    DescripcionCargo = dr["DescripcionCargo"].ToString(),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listQuery.Add(emp);
            }
            dr.Close();
            cn.Close();
            return listQuery;
        }

        public static List<EmpleadoQuery> EmpleadosActivos()
        {
            List<EmpleadoQuery> listQuery = new List<EmpleadoQuery>();
            EmpleadoQuery emp = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  Empleados.codEmpleado, Empleados.Nombre, Empleados.Apellido, Empleados.idTipoDoc, Empleados.NroDoc, Empleados.FechaNacimiento, 
                                        Empleados.Telefono, Empleados.Celular, Empleados.idLocalidad, Empleados.Calle, Empleados.NroCalle, Empleados.Piso, Empleados.Departamento,
                                        Empleados.IdCargo, Empleados.Sueldo, Empleados.HoraIngreso, Empleados.HoraEgreso, Empleados.Activo, 
                                        TipoDocumentos.idTD AS Expr1, TipoDocumentos.DescripcionTD, Localidades.idLoc AS Expr2, Localidades.DescripcionLoc, Cargo.idCargo AS Expr3, Cargo.DescripcionCargo
                                FROM    Empleados
                                        LEFT OUTER JOIN TipoDocumentos ON Empleados.idTipoDoc = TipoDocumentos.idTD
                                        LEFT OUTER JOIN Localidades ON Empleados.idLocalidad = Localidades.idLoc
                                        LEFT OUTER JOIN Cargo ON Empleados.idCargo = Cargo.idCargo
                                WHERE   Empleados.Activo = 1";

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new EmpleadoQuery()
                {
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["IdTipoDoc"].ToString()),
                    DescripcionTD = dr["DescripcionTD"].ToString(),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["IdLocalidad"].ToString()),
                    DescripcionLoc = dr["DescripcionLoc"].ToString(),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["IdCargo"].ToString()),
                    DescripcionCargo = dr["DescripcionCargo"].ToString(),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listQuery.Add(emp);
            }

            dr.Close();
            cn.Close();
            return listQuery;
        }

        public static List<EmpleadoQuery> ObtenerEspecialistasPorApellido(string Apellido)
        {
            List<EmpleadoQuery> listQuery = new List<EmpleadoQuery>();
            EmpleadoQuery emp = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT  Empleados.codEmpleado, Empleados.Nombre, Empleados.Apellido, Empleados.idTipoDoc, Empleados.NroDoc, Empleados.FechaNacimiento, 
                                        Empleados.Telefono, Empleados.Celular, Empleados.idLocalidad, Empleados.Calle, Empleados.NroCalle, Empleados.Piso, Empleados.Departamento,
                                        Empleados.IdCargo, Empleados.Sueldo, Empleados.HoraIngreso, Empleados.HoraEgreso, Empleados.Activo, 
                                        TipoDocumentos.idTD AS Expr1, TipoDocumentos.DescripcionTD, Localidades.idLoc AS Expr2, Localidades.DescripcionLoc, Cargo.idCargo AS Expr3, Cargo.DescripcionCargo
                                FROM    Empleados
                                        LEFT OUTER JOIN TipoDocumentos ON Empleados.idTipoDoc = TipoDocumentos.idTD
                                        LEFT OUTER JOIN Localidades ON Empleados.idLocalidad = Localidades.idLoc
                                        LEFT OUTER JOIN Cargo ON Empleados.idCargo = Cargo.idCargo
                                WHERE   1 = 1 AND Cargo.DescripcionCargo = 'Especialista' AND Empleados.Activo = 'True'";
            if (!string.IsNullOrEmpty(Apellido))
            {
                cmd.CommandText += " AND Apellido like @ape";
                cmd.Parameters.AddWithValue("@ape", Apellido + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new EmpleadoQuery()
                {
                    Horario = dr["HoraIngreso"].ToString() + " - " + dr["HoraEgreso"].ToString(),
                    Nombre = dr["Nombre"].ToString(),
                    Apellido = dr["Apellido"].ToString(),
                    IdTipoDoc = int.Parse(dr["idTipoDoc"].ToString()),
                    DescripcionTD = dr["DescripcionTD"].ToString(),
                    NroDoc = int.Parse(dr["NroDoc"].ToString()),
                    FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                    Telefono = dr["Telefono"].ToString(),
                    Celular = dr["Celular"].ToString(),
                    IdLocalidad = int.Parse(dr["idLocalidad"].ToString()),
                    DescripcionLoc = dr["DescripcionLoc"].ToString(),
                    Calle = dr["Calle"].ToString(),
                    NroCalle = short.Parse(dr["NroCalle"].ToString()),
                    Piso = dr["Piso"].ToString(),
                    Departamento = dr["Departamento"].ToString(),
                    IdCargo = int.Parse(dr["idCargo"].ToString()),
                    DescripcionCargo = dr["DescripcionCargo"].ToString(),
                    Sueldo = double.Parse(dr["Sueldo"].ToString()),
                    HoraIngreso = DateTime.Parse(dr["HoraIngreso"].ToString()),
                    HoraEgreso = DateTime.Parse(dr["HoraEgreso"].ToString()),
                    Activo = bool.Parse(dr["Activo"].ToString()),
                    CodEmpleado = (int)dr["CodEmpleado"]
                };
                listQuery.Add(emp);
            }
            dr.Close();
            cn.Close();
            return listQuery;
        }
    }
}
