using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class ConnectionString
    {
        public static string Cadena()
        {
            //****Nico
           // string cadena = "Data Source=NICO-PC;Initial Catalog=_PAV_COD;Integrated Security=True";

            //****Facultad
            //string cadena = "Data Source=maquis;Initial Catalog=_PAV_COD;User ID=avisuales2;Password=avisuales2";

            //****LIMBO
            string cadena = "Data Source = LIMBO\SQL_DECK; Initial Catalog = _PAV_COD; Integrated Security = True";

            return cadena;
        }
    }
}
