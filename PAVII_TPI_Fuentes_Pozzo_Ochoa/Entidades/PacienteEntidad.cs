using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PacienteEntidad
    {
        public int? Id { get; set; }
        public int NroDoc { get; set; }
        public int? IdTipoDoc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool? Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? IdLocalidad { get; set; }
        public string Calle { get; set; }
        public int NroCalle { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int? Piso { get; set; }
        public string Departamento { get; set; }

        //public PacienteEntidad() { }
        //public PacienteEntidad(int? id, int nroDoc, int? idTipoDoc, string nombre,
        //    string apellido, bool sexo, DateTime fechaNac, int? idLocalidad, string celular, string telefono,
        //    string calle, int nroCalle, int? piso, string depto)
        //{

        //    Id = id;
        //    NroDoc = nroDoc;
        //    IdTipoDoc = idTipoDoc;
        //    Nombre = nombre;
        //    Apellido = apellido;
        //    Sexo = sexo;
        //    FechaNacimiento = fechaNac;
        //    IdLocalidad = idLocalidad;
        //    Telefono = telefono;
        //    Celular = celular;
        //    Calle = calle;
        //    NroCalle = nroCalle;
        //    Piso = piso;
        //    Departamento = depto;

        }
}
