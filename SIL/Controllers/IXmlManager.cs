using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Controllers
{
    public interface IXmlManager
    {

        Task GuardarXml(DataTable dt, string ruta);

        Task<DataTable> LeerXml(string ruta);






    }
}
