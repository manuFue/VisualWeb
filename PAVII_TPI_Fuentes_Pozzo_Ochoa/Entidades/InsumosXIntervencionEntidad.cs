using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsumosXIntervencionEntidad
    {
        public int? codIntervencion { get; set; }
        public int? idInsumo { get; set; }
        public string descripcion { get; set; }
        public int? cantidadIntervencion { get; set; }
    }
}
