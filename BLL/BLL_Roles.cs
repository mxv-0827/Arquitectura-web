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
    public class BLL_Roles
    {
        private readonly DAL_Roles _DalRoles = new DAL_Roles();


        public DataTable LeerTodos()
        {
            return _DalRoles.LeerTodos("ObtenerTodosRoles");
        }

        public DataTable LeerTodosCompleto()
        {
            return _DalRoles.LeerTodos("ObtenerTodosRolesCompleto");
        }
    }
}
