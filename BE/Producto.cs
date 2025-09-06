using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string ImagenURL { get; set; }
    }
}
