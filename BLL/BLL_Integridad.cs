using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_Integridad
    {
        private readonly DAL_Integridad _dalIntegridad = new DAL_Integridad();

        public DataTable VerificarIntegridad(string sp)
        {
            return _dalIntegridad.VerificarIntegridad(sp);
        }

        public int RealizarBackup()
        {
            return _dalIntegridad.RealizarBackup("RealizarBackup");
        }

        public int RestaurarBD()
        {
            return _dalIntegridad.RestaurarBD("RestaurarBD");
        }
    }
}
