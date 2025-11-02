using BLL;
using localhost;
using SIL.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Administrador_Analisis : System.Web.UI.Page
{
    IXmlManager _xml = new XmlManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ObtenerDetalles();
          
        }

    }
    public DataTable ObtenerDetalles()
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

        return dtAnalisis;
    }




    protected void btnVerReportes_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportexXML.aspx");

    }

    protected async void btnGuardarXml_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = ObtenerDetalles();
            
            string rutaFisica = "C:\\Users\\agusr\\Downloads\\tpintegrador\\TP Integrador VIAND\\TP Integrador VIAND\\Jugueteria\\SIL\\XML\\Estadisticas.xml";

            await _xml.GuardarXml(dt, rutaFisica);

            // Verificar si el archivo realmente se creó
            if (System.IO.File.Exists(rutaFisica))
            {
                ltlMensaje.Text = $"<span style='color:green;'>Reporte '{rutaFisica}' guardado exitosamente.</span>";
            }
            else
            {
                ltlMensaje.Text = $"<span style='color:red;'>No se pudo guardar el archivo XML en '{rutaFisica}'.</span>";
            }
        }
        catch (Exception ex)
        {
            ltlMensaje.Text = $"<span style='color:red;'>Error al guardar XML: {ex.Message}</span>";
        }
    }

}