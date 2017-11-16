using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidad
    {
        public int? Id { get; set; }
        public int? NroFactura { get; set; }
        public int? IdPaciente { get; set; }
        public double? MontoTotal { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdFormaPago { get; set; }
    }
}
