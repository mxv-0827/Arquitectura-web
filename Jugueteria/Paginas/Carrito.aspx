<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Carrito.aspx.cs" Inherits="Paginas_Carrito" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/Carrito.css" rel="stylesheet" />

    <asp:Panel ID="pnlCarritoVacio" runat="server" CssClass="mensaje-carrito-vacio" Visible="false">
        <p>Actualmente, no tenes ningun producto en el carrito. Dirigite al apartado de 'Productos' para empezar a agregarlos.</p>
        <asp:HyperLink ID="hlIrATienda" runat="server" NavigateUrl="~/Paginas/Productos.aspx" CssClass="btn btn-primary btn-ir-tienda">
            Ir a 'Productos'
        </asp:HyperLink>
    </asp:Panel>

    <asp:Panel ID="pnlTotales" runat="server" CssClass="panel-totales">
        <h3>Detalle de la compra</h3>
        <p>Total productos: <asp:Label ID="lblCantidadTotal" runat="server" Text="0" /></p>
        <p>Total a pagar: $<asp:Label ID="lblTotalPagar" runat="server" Text="0.00" /></p>
        <asp:Button ID="btnPagar" runat="server" CssClass="btn btn-success btn-pagar" Text="Pagar" />
    </asp:Panel>

    <div class="contenedor-carrito">
        <asp:Repeater ID="rptCarrito" runat="server">
            <ItemTemplate>
                <div class="item-carrito">
                    <img src='<%# Eval("ImagenUrl") %>' alt="Producto" class="img-carrito" />
                    <div class="info-carrito">
                        <h4><%# Eval("Nombre") %></h4>
                        <p>Cantidad: <%# Eval("Cantidad") %></p>
                        <p>Precio unitario: $<%# String.Format("{0:N2}", Eval("PrecioUnitario")) %></p>
                        <p>Subtotal: $<%# String.Format("{0:N2}", Convert.ToInt32(Eval("Cantidad")) * Convert.ToDecimal(Eval("PrecioUnitario"))) %></p>
                    </div>

                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn-eliminar btn btn-danger" 
                        CommandArgument='<%# Eval("ID") %>' Text="&#128465;" 
                        OnClick="btnEliminar_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
