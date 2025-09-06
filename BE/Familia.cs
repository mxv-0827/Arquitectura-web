using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia : IComponent
    {
        public List<IComponent> lstComponentes = new List<IComponent>();

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string HashUnico { get; set; }


        public void Agregar(IComponent componente) => lstComponentes.Add(componente);

        public void Eliminar(IComponent componente) => lstComponentes.Remove(componente);


        public bool TienePermiso(string permiso)
        {
            foreach (IComponent component in lstComponentes)
            {
                if (component.TienePermiso(permiso))
                    return true;
            }

            return false;
        }
    }
}
