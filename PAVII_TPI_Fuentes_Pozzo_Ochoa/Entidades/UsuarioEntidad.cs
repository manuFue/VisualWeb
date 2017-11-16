using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioEntidad
    {
        public int? IdLogin { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool? Activo { get; set; }
        public int? IdPermiso { get; set; }
    }
}
