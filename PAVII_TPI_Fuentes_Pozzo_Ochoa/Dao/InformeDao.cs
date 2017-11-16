using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class InformeDao
    {
        public static List<InformeQueryEntidad> ListaInforme(int? nroFac, int? nroDoc, DateTime? fd, DateTime? fh, int? forma)
        {

            List<InformeQueryEntidad> lista = new List<InformeQueryEntidad>();

            SqlConnection cn = new SqlConnection();

            cn.ConnectionString = ConnectionString.Cadena();
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            //cmd.CommandText = @"select top 1000 p.idPaciente,p.nroDoc,p.nombre,p.apellido,f.nroFactura,
            //                f.montoTotal,f.fechaFac,df.precio,df.cantidadAbonada,fp.descripcionFP
            //                from pacientes p, Factura f,DetalleFactura df,intervencion i, FormaPago fp 
            //                where df.nroFactura=f.nroFactura and df.codIntervencion=i.codIntervencion 
            //                and f.idPaciente=p.idPaciente and f.idFormaPago=fp.idFP";
            cmd.CommandText = @"select top 1000 p.idPaciente,p.nroDoc,p.nombre,p.apellido,f.nroFactura,
                            f.montoTotal,f.fechaFac,df.precio,df.cantidadAbonada,fp.descripcionFP, t.DescripcionTratamiento
                            from pacientes p, Factura f,DetalleFactura df,intervencion i, FormaPago fp , tratamientos t
                            where df.nroFactura=f.nroFactura and df.codIntervencion=i.codIntervencion 
                            and f.idPaciente=p.idPaciente and f.idFormaPago=fp.idFP and i.codTratamiento=t.idTratamiento";
            if (nroFac.HasValue && nroFac != 0)
            {
                cmd.CommandText += " and f.nroFactura=@NroFactura";
                cmd.Parameters.AddWithValue("@NroFactura", nroFac.Value);
            }

            if (nroDoc.HasValue && nroDoc != 0)
            {
                cmd.CommandText += " and p.nroDoc=@NroDoc";
                cmd.Parameters.AddWithValue("@NroDoc", nroDoc.Value);
            }
            if (fd.HasValue)
            {
                cmd.CommandText += " and f.fechaFac>=@FD";
                cmd.Parameters.AddWithValue("@FD", fd.Value);

            }
            if (fh.HasValue)
            {
                cmd.CommandText += " and f.fechaFac<=@FH";
                cmd.Parameters.AddWithValue("@FH", fh.Value);
            }
            if (forma.HasValue && forma != 0)
            {
                cmd.CommandText += " and f.idFormaPago=@Forma";
                cmd.Parameters.AddWithValue("@Forma", forma.Value);
            }


            cmd.CommandText += " order by p.nombre";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                InformeQueryEntidad i = new InformeQueryEntidad();

                i.Id = (int)dr["idPaciente"];
                if (dr["nroDoc"] != DBNull.Value)
                    i.NroDoc = (int)dr["nroDoc"];
                i.Nombre = dr["nombre"].ToString();
                i.Apellido = dr["apellido"].ToString();
                if (dr["nroFactura"] != DBNull.Value)
                    i.NroFactura = int.Parse(dr["nroFactura"].ToString());
                if (dr["montoTotal"] != DBNull.Value)
                    i.MontoTotal = double.Parse(dr["montoTotal"].ToString());
                if (dr["fechaFac"] != DBNull.Value)
                    i.Fecha = DateTime.Parse(dr["fechaFac"].ToString());
                if (dr["cantidadAbonada"] != DBNull.Value)
                    i.CantidadAbonada = double.Parse(dr["cantidadAbonada"].ToString());
                if (dr["precio"] != DBNull.Value)
                    i.Precio = double.Parse(dr["precio"].ToString());
                // if(dr["descripcionFP"] != DBNull.Value)
                i.DescripcionFP = dr["descripcionFP"].ToString();
                // i.DescripcionCond = dr["descripcion"].ToString();
                i.descripcionTratamiento = dr["DescripcionTratamiento"].ToString();

                lista.Add(i);
            }
            dr.Close();
            cn.Close();

            return lista;
        }




    }
}
