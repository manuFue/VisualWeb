using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class PacienteQueryDao
    {
        public static List<PacienteQueryEntidad> ListaPac()
        {
            List<PacienteQueryEntidad> lista = new List<PacienteQueryEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select top 1000 p.idPaciente,p.nroDoc,p.idTipoDoc,p.nombre,p.apellido,p.sexo,p.fechaNacimiento,
                                    p.idLocalidad,p.telefono,p.celular,p.calle,p.nroCalle,p.piso,
                                    p.departamento, td.idTD, td.descripcionTD,l.idLoc,l.descripcionLoc 
                                    from pacientes p, tipoDocumentos td, localidades l
                                   where p.idTipoDoc=td.idTD and p.idLocalidad=l.idLoc
                                    order by nombre";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PacienteQueryEntidad p = new PacienteQueryEntidad();

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
                p.IdTD = (int)dr["idTD"];
                p.DescripcionTD = dr["descripcionTD"].ToString();
                p.IdLoc = (int)dr["idLoc"];
                p.DescripcionLoc = dr["descripcionLoc"].ToString();
                lista.Add(p);
            }
            dr.Close();
            cn.Close();
            return lista;
        }


        public static List<PacienteQueryEntidad> ObtenerPorNombre(string nombre)
        {
            List<PacienteQueryEntidad> lista = new List<PacienteQueryEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"select top 1000 p.idPaciente,p.nroDoc,p.idTipoDoc,p.nombre,p.apellido,p.sexo,p.fechaNacimiento,
                                    p.idLocalidad,p.telefono,p.celular,p.calle,p.nroCalle,p.piso,
                                    p.departamento, td.idTD, td.descripcionTD,l.idLoc,l.descripcionLoc 
                                    from pacientes p, tipoDocumentos td, localidades l
                                   where p.idTipoDoc=td.idTD and p.idLocalidad=l.idLoc and p.nombre like @nombre
                                    order by nombre";
            cmd.Parameters.AddWithValue("@nombre", nombre + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PacienteQueryEntidad p = new PacienteQueryEntidad();

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
                p.IdTD = (int)dr["idTD"];
                p.DescripcionTD = dr["descripcionTD"].ToString();
                p.IdLoc = (int)dr["idLoc"];
                p.DescripcionLoc = dr["descripcionLoc"].ToString();
                lista.Add(p);
            }
            dr.Close();
            cn.Close();
            return lista;
        }


    }
}

