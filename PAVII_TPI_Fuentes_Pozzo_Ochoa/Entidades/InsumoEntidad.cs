using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InsumoEntidad
    {
        public int? idInsumo { get; set; }
        public string descripcion { get; set; }
        public int? cantidadStock { get; set; }
        public int? puntoReposicion { get; set; }

        public InsumoEntidad() { }

        public InsumoEntidad(int? id, string desc, int? cantidadStock, int punto)
        {
            idInsumo = id;
            descripcion = desc;
            this.cantidadStock = cantidadStock;
            this.puntoReposicion = punto;
        }
    }
    }

