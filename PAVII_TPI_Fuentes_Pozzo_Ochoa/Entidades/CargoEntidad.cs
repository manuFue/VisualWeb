using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CargoEntidad
     {
        public int? IdCargo { get; set; }
        public string Descripcion { get; set; }

        public CargoEntidad() {}

        public CargoEntidad(int id, string descripcion)
        {
            this.IdCargo = id;
            this.Descripcion = descripcion;
        }
    }
}
