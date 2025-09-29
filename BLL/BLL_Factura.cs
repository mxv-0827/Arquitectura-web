using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Factura
    {
        DAL_Factura dal_Factura = new DAL_Factura();

        public void RegistrarFactura(Factura factura)
        {
            dal_Factura.RegistrarFactura(factura, "AgregarFacturas");
        }
    }
}
