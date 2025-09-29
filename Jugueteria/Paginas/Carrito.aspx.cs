using BE; // Suponiendo que acá está la clase ProductoCarrito, Carrito, etc.
using BLL;
using localhost;
using System;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        WebService webService = new WebService();

        BE.Carrito carritoBE = Session["Carrito"] as BE.Carrito;

        pnlCarritoVacio.Visible = false;
        pnlTotales.Visible = true;

        rptCarrito.DataSource = carritoBE.lstProductos;
        rptCarrito.DataBind();

        // Actualizar totales
        lblCantidadTotal.Text = carritoBE.lstProductos.Sum(p => p.Cantidad).ToString();

        // --- Serialización a JSON para enviar al WebService ---
        var js = new JavaScriptSerializer();
        string carritoJson = js.Serialize(carritoBE);

        // Llamada al WebService pasando el JSON
        decimal total = webService.CalcularTotalCarrito(carritoJson);

        lblTotalPagar.Text = total.ToString();
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

    protected void btnPagar_Click(object sender, EventArgs e)
    {
        Usuario usuario = Session["UsuarioLogueado"] as Usuario;
        Carrito carrito = Session["Carrito"] as Carrito;

        BLL_Factura bll_Factura = new BLL_Factura();
        BLL_Detalle bll_Detalle = new BLL_Detalle();


        Factura factura = new Factura
        {
            ID = Guid.NewGuid(),
            DNI_Cliente = usuario.DNI,
            CantidadProductos = carrito.lstProductos.Count,
            PrecioTotal = decimal.Parse(lblTotalPagar.Text),
            FechaCompra = DateTime.Now
        };

        bll_Factura.RegistrarFactura(factura);

        foreach(ProductoCarrito producto in carrito.lstProductos)
        {
            Detalle detalle = new Detalle
            {
                ID_Factura = factura.ID,
                ID_Producto = producto.ID,
                Cantidad = producto.Cantidad,
                Subtotal = producto.PrecioUnitario * producto.Cantidad
            };

            bll_Detalle.AgregarDetalle(detalle);
        }

        // --- Vaciar carrito ---
        carrito.lstProductos.Clear();
        carrito.CantidadProductos = 0;
        carrito.PrecioTotal = 0;
        Session["Carrito"] = carrito;

        // Actualizar controles en la página
        rptCarrito.DataSource = null;
        rptCarrito.DataBind();
        lblCantidadTotal.Text = "0";
        lblTotalPagar.Text = "0.00";

        // Mostrar el modal
        string script = "mostrarModal();";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModalPago", script, true);
    }
}
