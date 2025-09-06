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
    public class BLL_Permisos
    {
        private readonly DAL_Permisos dal_Permisos = new DAL_Permisos();

        public int Agregar(Permiso permiso) => dal_Permisos.Agregar(permiso, "AgregarPermisos");

        //public int Modificar(Permiso permiso) => dal_Permisos.Modificar(permiso, "ModificarPermisos");

        public DataTable LeerTodos() => dal_Permisos.LeerTodos("ObtenerTodosPermisos");
    }
}
