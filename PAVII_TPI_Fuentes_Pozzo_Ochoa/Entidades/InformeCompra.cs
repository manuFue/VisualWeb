using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InformeCompra
    {
        public string descripcion { get; set; }
        public int? cantidad { get; set; }
        public string nombreEmpresa { get; set; }
        public DateTime? fecha { get; set; }



        public InformeCompra() { }

        public InformeCompra(string Descripcion, int? Cantidad, string NombreEmpresa, DateTime? Fecha)
        {
            descripcion = Descripcion;
            cantidad = Cantidad;
            nombreEmpresa = NombreEmpresa;
            fecha = Fecha;

        }

    }
}

