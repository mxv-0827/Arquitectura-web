using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL
{
    public interface IObserverIdioma
    {
        void ActualizarIdioma(Dictionary<string, string> traducciones);
    }
}
