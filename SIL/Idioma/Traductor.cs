using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.IO;
using System.Web;

namespace SIL
{
    public class Traductor
    {
        private Dictionary<string, Dictionary<string, string>> traducciones;

        public Traductor(string rutaArchivo)
        {
            string json = File.ReadAllText(rutaArchivo);
            traducciones = new JavaScriptSerializer().Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
        }

        public Dictionary<string, string> ObtenerTraducciones(string idioma)
        {
            return traducciones[idioma];
        }
    }
}
