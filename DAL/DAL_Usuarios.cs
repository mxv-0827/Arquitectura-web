using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Usuarios
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();


        public int Agregar(Usuario usuario, string sp)
        {
            SqlParameter[] lstProps = new SqlParameter[]
            {
                new SqlParameter("DNI", usuario.DNI),
                new SqlParameter("Nombre", usuario.Nombre),
                new SqlParameter("Apellido", usuario.Apellido),
                new SqlParameter("Celular", usuario.Celular),
                new SqlParameter("ID_Rol", usuario.Rol.ID),
            };

            return _conexion.Escribir(sp, lstProps);
        }

        public int Modificar(Usuario usuario, string sp)
        {
            SqlParameter[] lstProps = new SqlParameter[]
            {
                new SqlParameter("DNI", usuario.DNI),
                new SqlParameter("Nombre", usuario.Nombre),
                new SqlParameter("Apellido", usuario.Apellido),
                new SqlParameter("Celular", usuario.Celular),
                new SqlParameter("ID_Rol", usuario.Rol.ID)
            };

            return _conexion.Escribir(sp, lstProps);
        }

        public int Desbloquear(string dni, string sp) //Campo 'BLOQUEADO' estaablecido en sp 
        {
            SqlParameter[] lstProps = new SqlParameter[]
            {
                new SqlParameter("DNI", dni),
            };

            return _conexion.Escribir(sp, lstProps);
        }

        public int Activar_Desactivar(string dni, bool activo, string sp)
        {
            SqlParameter[] lstProps = new SqlParameter[]
            {
                new SqlParameter("DNI", dni),
                new SqlParameter("Activo", activo),
            };

            return _conexion.Escribir(sp, lstProps);
        }
        public DataTable LeerTodos(string sp) => _conexion.Leer(sp);
    }
}
