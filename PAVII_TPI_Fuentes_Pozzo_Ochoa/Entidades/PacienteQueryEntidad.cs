using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PacienteQueryEntidad
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

        //********Localidad
        public int? IdLoc { get; set; }
        public string DescripcionLoc { get; set; }

        //******TipoDoc
        public int? IdTD { get; set; }
        public string DescripcionTD { get; set; }

    }
}
