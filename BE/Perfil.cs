using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Perfil
    {
        public List<IComponent> lstComponentes = new List<IComponent>();

        public int ID { get; set;    }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string HashUnico { get; set; }
    }
}
