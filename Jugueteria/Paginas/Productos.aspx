<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Productos.aspx.cs" Inherits="Paginas_Productos" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/Productos.css" rel="stylesheet" />

    <div class="catalogo-container">
        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>
                <div class="producto-card">
                    <img src='<%# Eval("ImagenUrl") %>' alt="Producto" class="producto-imagen" />
                    <h3><%# Eval("Nombre") %></h3>

                    <p class="producto-precio">
                        $<%# String.Format("{0:N2}", Eval("Precio")) %> <span class="por-unidad">c/u</span>
                    </p>

                    <div class="cantidad-control">
                        <button type="button" class="btn-disminuir">-</button>
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="input-cantidad" Text="1" onkeydown="return false"/>
                        <button type="button" class="btn-aumentar">+</button>
                    </div>

                    <asp:Button ID="btnAgregarCarrito" runat="server" 
                        Text="Agregar al carrito" 
                        CssClass="btn-agregar"
                        CommandArgument=<%# Eval("ID") + ";" + Eval("Nombre") + ";" + Eval("Precio") + ";" + Eval("ImagenURL") %>
                        OnClick="btnAgregarCarrito_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.querySelectorAll(".producto-card").forEach(function (card) {
                const input = card.querySelector(".input-cantidad");
                const hidden = card.querySelector("input[type=hidden]");

                card.querySelector(".btn-aumentar").onclick = () => {
                    input.value = parseInt(input.value) + 1;
                    hidden.value = input.value;  // Actualizo el hidden también
                };

                card.querySelector(".btn-disminuir").onclick = () => {
                    if (parseInt(input.value) > 1) {
                        input.value = parseInt(input.value) - 1;
                        hidden.value = input.value; // Actualizo el hidden también
                    }
                };
            });
        });
    </script>
</asp:Content>

