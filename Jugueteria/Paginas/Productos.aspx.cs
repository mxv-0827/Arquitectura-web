using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

public partial class Paginas_Productos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BLL_Productos bll_Productos = new BLL_Productos();

            DataTable dtProductos = bll_Productos.LeerTodos();
            rptProductos.DataSource = dtProductos;
            rptProductos.DataBind();
        }
    }

    protected void btnAgregarCarrito_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        RepeaterItem item = (RepeaterItem)btn.NamingContainer;

        string[] args = btn.CommandArgument.Split(';');

        int id = int.Parse(args[0]);
        string nombre = args[1].ToString();
        decimal precio = decimal.Parse(args[2]);
        string url = args[3].ToString();

        int cantidad = int.Parse(((TextBox)item.FindControl("txtCantidad")).Text);

        ProductoCarrito productoCarrito = new ProductoCarrito
        {
            ID = id,
            Nombre = nombre,
            PrecioUnitario = precio,
            Cantidad = cantidad,
            ImagenURL = url
        };

        Carrito carrito = (Carrito)Session["Carrito"];

        bool prodYaAgregado = carrito.lstProductos.Any(prod => prod.ID == id);
            
        //Si existe aumentamos la cantidad, no creamos un nuevo registro en la lista
        if (prodYaAgregado)
        {
            ProductoCarrito productoAgregado = carrito.lstProductos.Where(prod => prod.ID == id).FirstOrDefault();
            productoAgregado.Cantidad += cantidad;
        }

        else
        {
            carrito.lstProductos.Add(productoCarrito);
        }

        Session["Carrito"] = carrito;

        //Reiniciamos contador
        ((TextBox)item.FindControl("txtCantidad")).Text = "1";
    }


    //Necesario por el commandArgument - Sino arroja errores de seguridad
    protected void RepeaterProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var producto = (Producto)e.Item.DataItem;
            Button btnAgregar = (Button)e.Item.FindControl("btnAgregar");
            string cmdArg = $"{producto.ID};{producto.Precio}";

            btnAgregar.CommandArgument = cmdArg;

            // Registrar para validación de evento
            Page.ClientScript.RegisterForEventValidation(btnAgregar.UniqueID, cmdArg);
        }
    }

}