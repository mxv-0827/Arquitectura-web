using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoCarrito
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public string ImagenURL { get; set; }
    }
}
