using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFacturaEntidad
    {
        public int? NroFactura { get; set; }
        public int? CodIntervencion { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? CantidadAbonada { get; set; }
    }
}
