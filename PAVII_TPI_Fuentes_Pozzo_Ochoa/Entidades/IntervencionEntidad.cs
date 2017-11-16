using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IntervencionEntidad
    {
        public int? CodIntervencion { get; set; }
        public int? IdPaciente { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Hora { get; set; }
        public int? CodTratamiento { get; set; }
        public double? MontoTotal { get; set; }
        public string Observaciones { get; set; }
        public int? Condicion { get; set; }
    }
}
