using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TratamientoEntidad
    {
        public int? idTratamiento { get; set; }
        public string descripcionTratamiento { get; set; }
        public double costo { get; set; }

        public TratamientoEntidad() { }

        public TratamientoEntidad(int id, string descripcion, double costo)
        {
            this.idTratamiento = id;
            this.descripcionTratamiento = descripcion;
            this.costo = costo;
        }
    }
}
