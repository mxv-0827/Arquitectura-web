using BLL;
using localhost;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Administrador_Analisis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 1. Traer los detalles desde la BLL (SP)
            BLL_Detalle bll_Detalle = new BLL_Detalle();
            DataTable dtDetalles = bll_Detalle.ObtenerTodosDetalles();

            // 2. Convertir a array de DTO para enviar al WS
            var detallesArray = dtDetalles.AsEnumerable()
                .Select(r => new ProductoDetalle
                {
                    NombreProducto = r.Field<string>("NombreProducto"),
                    Cantidad = r.Field<int>("Cantidad"),
                    Subtotal = r.Field<decimal>("Subtotal")
                })
                .ToArray();

            // 3. Llamada al WebService
            WebService ws = new WebService(); // proxy generado
            var estadistica = ws.ObtenerEstadistica(detallesArray);

            // 4. Convertir a DataTable para GridView
            DataTable dtAnalisis = new DataTable();
            dtAnalisis.Columns.Add("NombreProducto", typeof(string));
            dtAnalisis.Columns.Add("TotalVendido", typeof(int));
            dtAnalisis.Columns.Add("SubtotalVendido", typeof(decimal));
            dtAnalisis.Columns.Add("Porcentaje", typeof(double));

            foreach (var item in estadistica)
            {
                dtAnalisis.Rows.Add(item.NombreProducto, item.TotalVendido, item.SubtotalVendido, item.Porcentaje);
            }

            // 5. Asignar al GridView
            gvAnalisis.DataSource = dtAnalisis;
            gvAnalisis.DataBind();
        }
    }
}