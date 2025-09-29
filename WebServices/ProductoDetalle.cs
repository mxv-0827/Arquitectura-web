using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices
{
    [Serializable]
    public class ProductoDetalle
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}