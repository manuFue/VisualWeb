using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LocalidadEntidad
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }

        public LocalidadEntidad() { }

        public LocalidadEntidad(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
