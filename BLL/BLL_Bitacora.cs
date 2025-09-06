using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Bitacora
    {
        private readonly DAL_Bitacora _DalBitacora = new DAL_Bitacora();

        public int Agregar(Bitacora bitacora) => _DalBitacora.Agregar(bitacora, "AgregarRegistroBitacora");

        public DataTable LeerTodos() => _DalBitacora.LeerTodos("ObtenerRegistrosBitacora");
    }
}
