using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace SIL
{
    public class IdiomaManager : IidiomaSubject
    {
        private static IdiomaManager instancia;
        private List<IObserverIdioma> observadores = new List<IObserverIdioma>();
        private Traductor traductor;
        private string idiomaActual = "es";

        private IdiomaManager()
        {
            traductor = new Traductor(HttpContext.Current.Server.MapPath("~/Idioma/Idiomas.json")); // Ruta relativa al .exe o absoluta
        }

        public static IdiomaManager Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new IdiomaManager();
                return instancia;
            }
        }

        public void Suscribir(IObserverIdioma obs) => observadores.Add(obs);
        public void Desuscribir(IObserverIdioma obs) => observadores.Remove(obs);

        public void CambiarIdioma(string nuevoIdioma)
        {
            idiomaActual = nuevoIdioma;
            Notificar();
        }

        public void Notificar()
        {
            var diccionario = traductor.ObtenerTraducciones(idiomaActual);
            foreach (var obs in observadores)
            {
                obs.ActualizarIdioma(diccionario);
            }
        }
    }
}
