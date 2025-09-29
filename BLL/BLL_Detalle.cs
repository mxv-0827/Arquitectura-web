using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Detalle
    {
        DAL_Detalle dal_Detalle = new DAL_Detalle();

        public void AgregarDetalle(Detalle detalle)
        {
            dal_Detalle.AgregarDetalle(detalle, "AgregarDetallesFactura");
        }

        public DataTable ObtenerTodosDetalles()
        {
            return dal_Detalle.ObtenerTodosDetalles("ObtenerTodosLosDetalles");
        }
    }
}
