using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TurnoEntidad
    {
        public int? idPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int codEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }

        public TurnoEntidad() { }

        public TurnoEntidad(int idPaciente, string NombreP, string Apellido, string fecha, string hora, int codEmpleado, string apellidoEmpleado)
        {
            this.idPaciente = idPaciente;
            this.NombrePaciente = NombreP;
            this.ApellidoPaciente = Apellido;
            this.fecha = fecha;
            this.hora = hora;
            this.codEmpleado = codEmpleado;
            this.ApellidoEmpleado = apellidoEmpleado;
        }
    }
}
