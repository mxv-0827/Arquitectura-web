using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Factura
    {
        public Guid ID { get; set; }
        public string DNI_Cliente { get; set; }
        public int CantidadProductos { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
