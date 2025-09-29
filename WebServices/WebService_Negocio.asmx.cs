using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public decimal CalcularTotalCarrito(string carritoJson)
        {
            var js = new JavaScriptSerializer();
            Carrito carrito = js.Deserialize<Carrito>(carritoJson);

            decimal precioTotal = 0;

            foreach (var producto in carrito.lstProductos)
            {
                precioTotal += producto.Cantidad * producto.PrecioUnitario;
            }

            return precioTotal;
        }

        [WebMethod]
        public ProductoEstadistica[] ObtenerEstadistica(ProductoDetalle[] detalles)
        {
            // Agrupar por producto
            var consulta = detalles
                .GroupBy(d => d.NombreProducto)
                .Select(g => new ProductoEstadistica
                {
                    NombreProducto = g.Key,
                    TotalVendido = g.Sum(r => r.Cantidad),
                    SubtotalVendido = g.Sum(r => r.Subtotal)
                })
                .ToList();

            // Total de unidades para calcular porcentaje
            int totalProductos = consulta.Sum(x => x.TotalVendido);

            foreach (var item in consulta)
            {
                item.Porcentaje = (double)item.TotalVendido / totalProductos * 100;
            }

            // Ordenar de mayor a menor porcentaje
            return consulta.OrderByDescending(x => x.Porcentaje).ToArray();
        }
    }
}
