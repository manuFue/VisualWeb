using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProveedorQuery
    {
            public int? idProveedor { get; set; }
            public string nombre { get; set; }
            public string nombreResponsable { get; set; }
            public string cuit { get; set; }
            public string telefono { get; set; }
            public string celular { get; set; }
            public string eMail { get; set; }
            public int? idLocalidad { get; set; }
            public string calle { get; set; }
            public int? nroCalle { get; set; }
            public string departamento { get; set; }
            public int? piso { get; set; }
            public DateTime fechaAlta { get; set; }
            public bool? activo { get; set; }
            public string descripcion { get; set; }


            public ProveedorQuery() { }

            public ProveedorQuery(int? IdProveedor, string Nombre, string NombreResponsable, string Cuit, string Telefono, string Celular, string Email, int IdLocalidad,
                           string Calle, int? NroCalle, string Departamento, int Piso, DateTime FechaAlta, bool Activo, string Descripcion)
            {
                idProveedor = IdProveedor;
                nombre = Nombre;
                nombreResponsable = NombreResponsable;
                cuit = Cuit;
                telefono = Telefono;
                celular = Celular;
                eMail = Email;
                idLocalidad = IdLocalidad;
                calle = Calle;
                nroCalle = NroCalle;
                departamento = Departamento;
                piso = Piso;
                fechaAlta = FechaAlta;
                activo = Activo;
                descripcion = Descripcion;
            }
                    }
}
