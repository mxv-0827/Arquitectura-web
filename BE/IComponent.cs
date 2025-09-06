using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IComponent
    {
        int ID { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }  
        
        bool TienePermiso(string permiso);
    }
}
