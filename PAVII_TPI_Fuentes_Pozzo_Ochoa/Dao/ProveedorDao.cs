using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class ProveedorDao
    {
             //   public static string cadena = "Data Source=maquis;Initial Catalog=_PAV_COD;User ID=avisuales2;Password=avisuales2";
        //public static string cadena = "Data Source=MATIAS8A-PC;Initial Catalog=_PAV_COD;Integrated Security=True";

        public static void InsertarProveedor (ProveedorEntidad prov)
        {
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
     
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Insert into proveedores (nombre, nombreResponsable, cuit, telefono, celular, eMail, idLocalidad, 
                                                         calle, nroCalle, departamento, piso, fechaAlta, activo )
                              values (@nombre, @nombreResponsable, @cuit, @telefono, @celular, @eMail, @idLocalidad,
                                      @calle, @nroCalle, @departamento, @piso, @fechaAlta, @activo);
                              select Scope_Identity() as ID";
            cmd.Parameters.AddWithValue("@nombre",prov.nombre);
            cmd.Parameters.AddWithValue("@nombreResponsable", prov.nombreResponsable);
            cmd.Parameters.AddWithValue("@cuit", prov.cuit);
            cmd.Parameters.AddWithValue("@telefono", prov.telefono);
            cmd.Parameters.AddWithValue("@celular", prov.celular);
            cmd.Parameters.AddWithValue("@eMail", prov.eMail);
            cmd.Parameters.AddWithValue("@idLocalidad", prov.idLocalidad);
            cmd.Parameters.AddWithValue("@calle", prov.calle);
            cmd.Parameters.AddWithValue("@nroCalle", prov.nroCalle);
            cmd.Parameters.AddWithValue("@departamento", prov.departamento);
            cmd.Parameters.AddWithValue("@piso", prov.piso);
            cmd.Parameters.AddWithValue("@fechaAlta", prov.fechaAlta);
            cmd.Parameters.AddWithValue("@activo", prov.activo);

            //cmd.ExecuteNonQuery();
            //cmd = new SqlCommand("select Scope_Identity() as ID",cn);
            prov.idProveedor = Convert.ToInt32(cmd.ExecuteScalar());
            
           
            //Cerrar siempre la conexion
            cn.Close();
        }

        public static void Actualizar(ProveedorEntidad prov)
        {
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"update proveedores set 
                                    nombre = @nombre,
                                    nombreResponsable = @nombreResponsable,
                                    cuit = @cuit,
                                    telefono = @telefono,
                                    celular = @celular,
                                    eMail = @eMail,
                                    idLocalidad = @idLocalidad,
                                    calle = @calle,
                                    nroCalle = @nroCalle,
                                    departamento = @departamento,
                                    piso = @piso,
                                    fechaAlta = @fechaAlta,
                                    activo = @activo
                               where idProveedor = @idProveedor";
            cmd.Parameters.AddWithValue("@nombre", prov.nombre);
            cmd.Parameters.AddWithValue("@nombreResponsable", prov.nombreResponsable);
            cmd.Parameters.AddWithValue("@cuit", prov.cuit);
            cmd.Parameters.AddWithValue("@telefono", prov.telefono);
            cmd.Parameters.AddWithValue("@celular", prov.celular);
            cmd.Parameters.AddWithValue("@eMail", prov.eMail);
            cmd.Parameters.AddWithValue("@idLocalidad", prov.idLocalidad);
            cmd.Parameters.AddWithValue("@calle", prov.calle);
            cmd.Parameters.AddWithValue("@nroCalle", prov.nroCalle);
            cmd.Parameters.AddWithValue("@departamento", prov.departamento);
            cmd.Parameters.AddWithValue("@piso", prov.piso);
            cmd.Parameters.AddWithValue("@fechaAlta", prov.fechaAlta);
            cmd.Parameters.AddWithValue("@activo", prov.activo);
            cmd.Parameters.AddWithValue("@idProveedor", prov.idProveedor);

              cmd.ExecuteNonQuery();

            //Cerrar siempre la conexion
            cn.Close();
        }


        public static List<ProveedorQuery>  obtener()
        {

            List<ProveedorQuery> gr = new List<ProveedorQuery>();
             //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select [idProveedor],
                                        [nombre],
                                        [nombreResponsable],
                                        [cuit],
                                        [telefono],
                                        [celular],
                                        [eMail],
                                        [idLocalidad],
                                        [calle],
                                        [nroCalle],
                                        [piso],
                                        [departamento],
                                        [fechaAlta],
                                        [activo],
                                        [descripcionLoc]
                                  from proveedores join localidades on idLocalidad = idLoc
                                  order by nombreResponsable";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
               ProveedorQuery g = new ProveedorQuery()
                {
                    idProveedor =int.Parse(dr["idProveedor"].ToString()),
                    nombre = (dr["nombre"].ToString()),
                    nombreResponsable = (dr["nombreResponsable"].ToString()),
                    cuit = (dr["cuit"].ToString()),
                    telefono = (dr["telefono"].ToString()),
                    celular = (dr["celular"].ToString()),
                    eMail = (dr["eMail"].ToString()),
                    idLocalidad = int.Parse(dr["idLocalidad"].ToString()),
                    calle = (dr["calle"].ToString()),
                    nroCalle = int.Parse(dr["nroCalle"].ToString()),
                    piso = int.Parse(dr["piso"].ToString()),
                    departamento = (dr["departamento"].ToString()),
                    fechaAlta = DateTime.Parse(dr["fechaAlta"].ToString()),
                    activo = bool.Parse(dr["activo"].ToString()),
                    descripcion = (dr["descripcionLoc"].ToString())
                };

                gr.Add(g);
            }
            dr.Close();
            cn.Close();
            return gr;

        }


        public static void Eliminar(int id)
        {
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"delete from proveedores where idProveedor = @idProveedor";
            cmd.Parameters.AddWithValue("@idProveedor", id);
            cmd.ExecuteNonQuery();

            //Cerrar siempre la conexion
            cn.Close();
        }

        public static ProveedorQuery ObtenerPorID(int id) 
        {
            ProveedorQuery g = null;
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select [idProveedor],
                                        [nombre],
                                        [nombreResponsable],
                                        [cuit],
                                        [telefono],
                                        [celular],
                                        [eMail],
                                        [idLocalidad],
                                        [calle],
                                        [nroCalle],
                                        [piso],
                                        [departamento],
                                        [fechaAlta],
                                        [activo],
                                        [descripcionLoc]
                              from proveedores join localidades on idLocalidad = idLoc
                              where idProveedor = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {

                    g = new ProveedorQuery()
                {
                    idProveedor = int.Parse(dr["idProveedor"].ToString()),
                    nombre = (dr["nombre"].ToString()),
                    nombreResponsable = (dr["nombreResponsable"].ToString()),
                    cuit = (dr["cuit"].ToString()),
                    telefono = (dr["telefono"].ToString()),
                    celular = (dr["celular"].ToString()),
                    eMail = (dr["eMail"].ToString()),
                    idLocalidad = int.Parse(dr["idLocalidad"].ToString()),
                    calle = (dr["calle"].ToString()),
                    nroCalle = int.Parse(dr["nroCalle"].ToString()),
                    piso = int.Parse(dr["piso"].ToString()),
                    departamento = (dr["departamento"].ToString()),
                    fechaAlta = DateTime.Parse(dr["fechaAlta"].ToString()),
                    activo = bool.Parse(dr["activo"].ToString()),
                    descripcion = (dr["descripcionLoc"].ToString())
                };

              
            }
            dr.Close();
            cn.Close();
            return g;

        }


        public static List<ProveedorQuery> ObtenerPorEmpresa(string nombreR)
        {
            List<ProveedorQuery> ListaProv = new List<ProveedorQuery>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select [idProveedor],
                                        [nombre],
                                        [nombreResponsable],
                                        [cuit],
                                        [telefono],
                                        [celular],
                                        [eMail],
                                        [idLocalidad],
                                        [calle],
                                        [nroCalle],
                                        [piso],
                                        [departamento],
                                        [fechaAlta],
                                        [activo],
                                        [descripcionLoc]
                              from proveedores join localidades on idLocalidad = idLoc
                              WHERE nombreResponsable LIKE @nombreR";
            cmd.Parameters.AddWithValue("@nombreR", nombreR + "%");
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ProveedorQuery g = new ProveedorQuery()
                {
                    idProveedor = int.Parse(dr["idProveedor"].ToString()),
                    nombre = (dr["nombre"].ToString()),
                    nombreResponsable = (dr["nombreResponsable"].ToString()),
                    cuit = (dr["cuit"].ToString()),
                    telefono = (dr["telefono"].ToString()),
                    celular = (dr["celular"].ToString()),
                    eMail = (dr["eMail"].ToString()),
                    idLocalidad = int.Parse(dr["idLocalidad"].ToString()),
                    calle = (dr["calle"].ToString()),
                    nroCalle = int.Parse(dr["nroCalle"].ToString()),
                    piso = int.Parse(dr["piso"].ToString()),
                    departamento = (dr["departamento"].ToString()),
                    fechaAlta = DateTime.Parse(dr["fechaAlta"].ToString()),
                    activo = bool.Parse(dr["activo"].ToString()),
                    descripcion = (dr["descripcionLoc"].ToString())
                };
                ListaProv.Add(g);
            }
            dr.Close();
            cn.Close();
            return ListaProv;
        }

        public static bool estaCargado( string nomRes)
        {
            bool bandera;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand ins = new SqlCommand();
            ins.Connection = cn;
            ins.CommandText = @"select nombreResponsable
                                            from proveedores
                                            where nombreResponsable = @nomRes";
            ins.Parameters.AddWithValue("@nomRes", nomRes);

            SqlDataReader dr = ins.ExecuteReader();
            if(dr.Read())
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }
            dr.Close();
            cn.Close();
            return bandera;
             
        }
    }
}
