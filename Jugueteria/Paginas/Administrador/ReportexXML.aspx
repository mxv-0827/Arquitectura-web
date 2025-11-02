<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportexXML.aspx.cs" Inherits="Paginas_Administrador_ReportexXML" Async="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visualizador de Reportes XML</title>
   
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #fef4f8; 
            padding-top: 20px;
            margin: 0;
        }
        .reporte-container {
            max-width: 900px;
            margin: 20px auto;
            padding: 25px;
            background-color: #fdf6fa; 
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            border: 1px solid #fce4f4;
        }
        .reporte-selector {
            display: flex;
            gap: 10px;
            align-items: center;
            margin-bottom: 20px;
        }
        .reporte-dropdown {
            flex-grow: 1;
            padding: 8px;
            font-size: 16px;
            border: 1px solid #e0b0d1;
            border-radius: 4px;
        }
        .reporte-boton {
            padding: 9px 20px;
            font-size: 16px;
            color: #ffffff;
            background-color: #8a2be2; 
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .reporte-boton:hover {
            background-color: #6a006a; 
        }
        
       
        .grid-header th { 
            background-color: #6a006a; 
            color: #ffffff;
            font-size: 14px;
            padding: 10px;
            text-align: left;
        }
        .grid-row td { 
             background-color: #fdf6fa;
             padding: 10px;
             border-bottom: 1px solid #fce4f4;
        }
        .grid-alt-row td { 
            background-color: #ffffff;
            padding: 10px;
            border-bottom: 1px solid #fce4f4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
      
        <div class="reporte-container">
            <h2>Visualizador de Reportes XML</h2>
            <p>Selecciona un reporte guardado para ver sus datos.</p>

            <div class="reporte-selector">

                <asp:DropDownList ID="ddlReportes" runat="server" CssClass="reporte-dropdown" />
                
                <asp:Button ID="btnCargar" runat="server" Text="Cargar Reporte" 
                    CssClass="reporte-boton" OnClick="btnCargar_Click" />
            </div>

           
            <asp:Literal ID="ltlMensaje" runat="server" EnableViewState="false" />
            
            <hr style="border:0; border-top: 1px solid #fce4f4; margin: 20px 0;" />

        
            <asp:GridView ID="gvReporte" runat="server" 
                AutoGenerateColumns="true" 
                Width="100%"
                GridLines="None" 
                CellPadding="0"
                CellSpacing="0"
                HeaderStyle-CssClass="grid-header"
                RowStyle-CssClass="grid-row"
                AlternatingRowStyle-CssClass="grid-alt-row"
                EmptyDataText="No hay datos para mostrar. Por favor, seleccione un reporte.">
            </asp:GridView>

        </div>
      

    </form>
</body>
</html>