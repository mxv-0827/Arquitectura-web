<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Analisis.aspx.cs" Inherits="Paginas_Administrador_Analisis" %>

<asp:Content ID="HeadContent1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Css/Analisis.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center; margin-top:20px;">
        <asp:Label ID="lblTituloAnalisis" runat="server" Text="PRODUCTOS MÁS VENDIDOS" 
                   Font-Size="Large" Font-Bold="true" CssClass="titulo-analisis" />
        
        <br /><br />

        <asp:GridView ID="gvAnalisis" runat="server" AutoGenerateColumns="false" CssClass="grid-analisis">
            <Columns>
                <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                <asp:BoundField DataField="TotalVendido" HeaderText="Total Vendido" DataFormatString="{0:N0}" />
                <asp:BoundField DataField="SubtotalVendido" HeaderText="Subtotal Vendido" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="Porcentaje" HeaderText="% Respecto Total" DataFormatString="{0:N2}%" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

