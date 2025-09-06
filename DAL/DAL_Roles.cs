using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Roles
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();


        //public int Agregar(Usuario usuario, string sp)
        //{

        //}

        public DataTable LeerTodos(string sp) => _conexion.Leer(sp);
    }
}
