using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoEntidad
    {
        public int? CodEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTipoDoc { get; set; }
        public int NroDoc { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int IdLocalidad { get; set; }
        public string Calle { get; set; }
        public short NroCalle { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public int IdCargo { get; set; }
        public double Sueldo { get; set; }
        public DateTime HoraIngreso { get; set; }
        public DateTime HoraEgreso { get; set; }
        public bool? Activo { get; set; }

        public EmpleadoEntidad() { }

        public EmpleadoEntidad(string Nombre, string Apellido, int IdTipoDoc, int NroDoc, DateTime FechaNacimiento,
            string Telefono, string Celular, int IdLocalidad, string Calle, short NroCalle, string Piso, string Departamento,
            int IdCargo, double Sueldo, DateTime HoraIngreso, DateTime HoraEgreso, bool Activo)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.IdTipoDoc = IdTipoDoc;
            this.NroDoc = NroDoc;
            this.FechaNacimiento = FechaNacimiento;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.IdLocalidad = IdLocalidad;
            this.Calle = Calle;
            this.NroCalle = NroCalle;
            this.Piso = Piso;
            this.Departamento = Departamento;
            this.IdCargo = IdCargo;
            this.Sueldo = Sueldo;
            this.HoraIngreso = HoraIngreso;
            this.HoraEgreso = HoraEgreso;
            this.Activo = Activo;
        }
    }
}
