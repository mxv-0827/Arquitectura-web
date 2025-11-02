using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml;

namespace SIL.Controllers
{
    public class XmlManager : IXmlManager
    {

        public Task GuardarXml(DataTable dt, string ruta)
        {
            return Task.Run(() =>
            {
                XmlTextWriter writer = null;

                try
                {
                    writer = new XmlTextWriter(ruta, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("ReporteEstadistica");


                    foreach (DataRow row in dt.Rows)
                    {
                        writer.WriteStartElement("Producto");

                        foreach (DataColumn col in dt.Columns)
                        {
                            string Nombretag = col.ColumnName
                            .Replace("%", "")
                            .Replace(" ", "")
                            .Trim();

                            writer.WriteElementString(Nombretag, row[col].ToString());


                        }

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al generar el XML: " + ex.Message);
                }
                finally
                {
                    writer?.Close();
                }

            });
        }

        public Task<DataTable> LeerXml(string ruta)
        {
            return (Task<DataTable>)Task.Run(() =>
            {
                using (XmlTextReader reader = new XmlTextReader(ruta))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(reader);

                    if(ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }

                }
                return new DataTable("Vacio");

            });



        }
    }
}
