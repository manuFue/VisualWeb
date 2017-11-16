using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InformeQueryEntidad
    {
        //*****Paciente

        public int? Id { get; set; }
        public int? NroDoc { get; set; }
        public int? IdTipoDoc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //*****Factura
        public int? IdFac { get; set; }
        public int? NroFactura { get; set; }
        public int? IdPaciente { get; set; }
        public double? MontoTotal { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdFormaPago { get; set; }

        //*****DetalleFactura
        public int? NroFacturaDF { get; set; }
        public int? CodIntervencionDF { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? CantidadAbonada { get; set; }

        //*****Intervencion
        public int? CodIntervencion { get; set; }
        public int? IdPacienteInt { get; set; }
        public DateTime? FechaInt { get; set; }
        public DateTime? Hora { get; set; }
        public int? CodTratamiento { get; set; }
        public double? MontoTotalInt { get; set; }
        public string Observaciones { get; set; }
        public int? Condicion { get; set; }

        //*****Condicion
        public int? IdCond { get; set; }
        public string DescripcionCond { get; set; }

        //****FormaPago
        public int? IdFP { get; set; }
        public string DescripcionFP { get; set; }

        //*****Tratamientos
        public int? idTratamiento { get; set; }
        public string descripcionTratamiento { get; set; }
        public double costo { get; set; }


    }
}
