using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Productos
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();


        public DataTable LeerTodos(string sp)
        {
            return _conexion.Leer(sp);
        }
    }
}
