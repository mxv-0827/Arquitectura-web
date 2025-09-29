using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices
{
    [Serializable]
    public class ProductoEstadistica
    {
        public string NombreProducto { get; set; }
        public int TotalVendido { get; set; }
        public double Porcentaje { get; set; }
        public decimal SubtotalVendido { get; set; }
    }
}