using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int ID { get; set; }

        public string Usuario { get; set; }

        public string Accion { get; set; }

        public DateTime Horario { get; set; }
    }
}
