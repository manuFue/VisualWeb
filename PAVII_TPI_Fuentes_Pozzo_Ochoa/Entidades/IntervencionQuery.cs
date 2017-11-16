using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
        public class IntervencionQuery
    {

        public int? codIntervencion { get; set; }
        public double montoTotal { get; set; }
        public string observaciones { get; set; }

        public string descripcionCondicion { get; set; }

        public int? IdPaciente { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }


        public string descripcionTratamiento { get; set; }

    }

}
