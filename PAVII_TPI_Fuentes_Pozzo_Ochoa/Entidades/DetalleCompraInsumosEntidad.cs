using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompraInsumosEntidad
    {
        public int? idProveedor { get; set; }
        public DateTime? fechaHora { get; set; }
        public int? codInsumo { get; set; }
        public int? cantidad { get; set; }
        public float? precioUnitario { get; set; }
        public string descripcion { get; set; }

        public DetalleCompraInsumosEntidad() { }

        public DetalleCompraInsumosEntidad(int? id, DateTime? fecha, int? cod, int? cant, float? precio, string desc)
        {
            this.idProveedor = id;
            this.fechaHora = fecha;
            this.codInsumo = cod;
            this.cantidad = cant;
            this.precioUnitario = precio;
            this.descripcion = desc;
        }
    }
}
