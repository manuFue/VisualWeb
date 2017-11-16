using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CompraInsumosEntidad
    {
        public int? idProveedor { get; set; }
        public DateTime fechaHora { get; set; }
        public double? montoTotal { get; set; }


        public CompraInsumosEntidad() { }

        public CompraInsumosEntidad(int? id, DateTime fecha, double monto)
        {
            this.idProveedor = id;
            this.fechaHora = fecha;
            this.montoTotal = monto;

        }
    }
}
