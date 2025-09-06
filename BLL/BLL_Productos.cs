using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_Productos
    {
        private readonly DAL_Productos dal_Productos = new DAL_Productos();

        public DataTable LeerTodos()
        {
            return dal_Productos.LeerTodos("ObtenerTodosProductos");
        }
    }
}
