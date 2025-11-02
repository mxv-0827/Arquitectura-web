<%@  Page Async ="true" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Analisis.aspx.cs" Inherits="Paginas_Administrador_Analisis" %>

<asp:Content ID="HeadContent1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Css/Analisis.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center; margin-top:20px;">
        <asp:Label ID="lblTituloAnalisis" runat="server" Text="PRODUCTOS MÁS VENDIDOS" 
                   Font-Size="Large" Font-Bold="true" CssClass="titulo-analisis" />
        
        <br /><br />
        <%-- NUEVA SECCIÓN DE BOTONES --%>
        <div class="accion-container">
            <asp:Button ID="btnGuardarXml" runat="server" Text="Guardar Reporte XML" 
                CssClass="btn-accion" OnClick="btnGuardarXml_Click" />
                
            <asp:Button ID="btnVerReportes" runat="server" Text="Ver Reportes Guardados" 
                CssClass="btn-accion" OnClick="btnVerReportes_Click" />
            
            <br /><br />
            <asp:Literal ID="ltlMensaje" runat="server" EnableViewState="false" />
        </div>
        <%-- FIN DE NUEVA SECCIÓN --%>

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

