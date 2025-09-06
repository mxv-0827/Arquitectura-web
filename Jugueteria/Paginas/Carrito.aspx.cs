using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BE; // Suponiendo que acá está la clase ProductoCarrito, Carrito, etc.

public partial class Paginas_Carrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarCarrito();
        }
    }

    private void CargarCarrito()
    {
        Carrito carrito = Session["Carrito"] as Carrito;

        if (carrito == null || carrito.lstProductos.Count == 0)
        {
            pnlCarritoVacio.Visible = true;
            pnlTotales.Visible = false;
            rptCarrito.DataSource = null;
            rptCarrito.DataBind();
        }
        else
        {
            pnlCarritoVacio.Visible = false;
            pnlTotales.Visible = true;

            rptCarrito.DataSource = carrito.lstProductos;
            rptCarrito.DataBind();

            // Actualizar totales
            lblCantidadTotal.Text = carrito.lstProductos.Sum(p => p.Cantidad).ToString();
            lblTotalPagar.Text = carrito.lstProductos.Sum(p => p.Cantidad * p.PrecioUnitario).ToString("N2");
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        Button btnEliminar = (Button)sender;
        int idProducto = int.Parse(btnEliminar.CommandArgument);

        Carrito carrito = Session["Carrito"] as Carrito;
        if (carrito != null)
        {
            var productoEliminar = carrito.lstProductos.FirstOrDefault(p => p.ID == idProducto);

            if (productoEliminar != null)
            {
                carrito.lstProductos.Remove(productoEliminar);

                carrito.CalcularCantidadProductos();
                carrito.PrecioTotal -= productoEliminar.PrecioUnitario * productoEliminar.Cantidad;

                Session["Carrito"] = carrito;
            }
        }

        CargarCarrito();
    }
}
