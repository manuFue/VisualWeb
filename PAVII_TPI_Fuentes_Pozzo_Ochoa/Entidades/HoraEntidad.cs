using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HoraEntidad
    {
        private string hora; 
        public string Hora { get { return hora; }  set { this.hora = value; }  }

        public HoraEntidad() { }

        public HoraEntidad(string hora)
        {
            this.hora = hora;
        }
    }
}
