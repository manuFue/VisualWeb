using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoQuery : EmpleadoEntidad
    {
        public string DescripcionTD { get; set; }
        public string DescripcionLoc { get; set; }
        public string DescripcionCargo { get; set; }
        public string Horario { get; set; }
    }
}
