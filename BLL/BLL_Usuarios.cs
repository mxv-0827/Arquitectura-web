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
    public class BLL_Usuarios
    {
        private readonly DAL_Usuarios _DalUsuarios = new DAL_Usuarios();

        public int Agregar(Usuario usuario)
        {
            return _DalUsuarios.Agregar(usuario, "AgregarUsuarios");
        }

        public int Modificar(Usuario usuario)
        {
            return _DalUsuarios.Modificar(usuario, "ModificarUsuarios");
        }

        public int Desbloquear(string dni)
        {
            return _DalUsuarios.Desbloquear(dni, "DesbloquearUsuarios");
        }

        public int Activar_Desactivar(string dni, bool activo)
        {
            return _DalUsuarios.Activar_Desactivar(dni, activo, "Activar_DesactivarUsuarios");
        }
        
        public DataTable LeerTodos()
        {
            return _DalUsuarios.LeerTodos("ObtenerTodosLosUsuarios");
        }
    }
}
