using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Integridad
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();

        public DataTable VerificarIntegridad(string sp)
        {
            return _conexion.Leer(sp);
        }

        public int RealizarBackup(string sp)
        {
            return _conexion.Escribir(sp);
        }

        public int RestaurarBD(string sp) => _conexion.Escribir(sp);
    }
}
