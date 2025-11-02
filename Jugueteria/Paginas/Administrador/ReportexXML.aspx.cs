using SIL.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Administrador_ReportexXML : System.Web.UI.Page
{
    private readonly IXmlManager _xml = new XmlManager();

    
    private const string ArchivoReferencia =
        @"C:\Users\agusr\Downloads\tpintegrador\TP Integrador VIAND\TP Integrador VIAND\Jugueteria\SIL\XML\Estadisticas.xml";

    private static string BaseFolder
        => Path.GetDirectoryName(ArchivoReferencia) ?? @"C:\";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenarReporte();
        }
    }

    private void LlenarReporte()
    {
        try
        {
            ltlMensaje.Text = string.Empty;

            if (!Directory.Exists(BaseFolder))
            {
                
                ltlMensaje.Text = "<div class='alert alert-danger' role='alert'>No se encontró la carpeta del XML.</div>";
                btnCargar.Enabled = false;
                return;
            }

           
            string[] archivos = Directory.GetFiles(BaseFolder, "*.xml", SearchOption.TopDirectoryOnly);

            if (archivos == null || archivos.Length == 0)
            {
                ltlMensaje.Text = "No se encontraron reportes XML guardados en la carpeta.";
                btnCargar.Enabled = false;
                return;
            }

            ddlReportes.Items.Clear();
            ddlReportes.Items.Add(new ListItem("-- Seleccione un reporte --", ""));

            foreach (string rutaCompleta in archivos.OrderBy(Path.GetFileName))
            {
                string nombreArchivo = Path.GetFileName(rutaCompleta);
                ddlReportes.Items.Add(new ListItem(nombreArchivo, nombreArchivo));
            }

          
            string refName = Path.GetFileName(ArchivoReferencia);
            var item = ddlReportes.Items.FindByValue(refName);
            if (item != null) ddlReportes.SelectedValue = refName;

            btnCargar.Enabled = true;
        }
        catch (Exception ex)
        {
            ltlMensaje.Text = $"<span style='color:red;'>Error al listar reportes: {Server.HtmlEncode(ex.Message)}</span>";
            btnCargar.Enabled = false;
        }
    }

    protected async void btnCargar_Click(object sender, EventArgs e)
    {
        ltlMensaje.Text = string.Empty;
        gvReporte.DataSource = null;

        try
        {
            string nombreArchivo = ddlReportes.SelectedValue;
            if (string.IsNullOrWhiteSpace(nombreArchivo))
            {
                ltlMensaje.Text = "Por favor, seleccione un reporte de la lista.";
                gvReporte.DataBind();
                return;
            }

            string rutaFisica = Path.Combine(BaseFolder, nombreArchivo);

            if (!File.Exists(rutaFisica))
            {
                ltlMensaje.Text = "<span style='color:red;'>El archivo seleccionado no existe.</span>";
                gvReporte.DataBind();
                return;
            }

            DataTable dt = await _xml.LeerXml(rutaFisica).ConfigureAwait(false);

            if (dt == null || dt.Rows.Count == 0)
            {
                ltlMensaje.Text = "<span style='color:#b36b00;'>El XML se leyó pero no contiene filas para mostrar.</span>";
            }
            else
            {
                ltlMensaje.Text = $"<span style='color:green;'>Mostrando reporte: {Server.HtmlEncode(nombreArchivo)}</span>";
            }

            gvReporte.DataSource = dt;
            gvReporte.DataBind();
        }
        catch (Exception ex)
        {
            ltlMensaje.Text = $"<span style='color:red;'>Error al cargar y leer el reporte: {Server.HtmlEncode(ex.Message)}</span>";
            gvReporte.DataBind();
        }
    }




}