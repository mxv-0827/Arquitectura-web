using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Carrito
    {
        public decimal PrecioTotal { get; set; }
        public int CantidadProductos { get; set; }

        public List<ProductoCarrito> lstProductos = new List<ProductoCarrito>();

        public void CalcularCantidadProductos()
        {
            CantidadProductos = lstProductos.Count;
        }
    }
}
