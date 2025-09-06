using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Permisos
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();


        public int Agregar(Permiso permiso, string sp)
        {
            SqlParameter[] sqlProps = GenerarSqlPropsArray(permiso);
            return _conexion.Escribir(sp, sqlProps);
        }

        public DataTable LeerTodos(string sp) => _conexion.Leer(sp);




        private SqlParameter[] GenerarSqlPropsArray(object entidad)
        {
            PropertyInfo[] entityProps = entidad.GetType().GetProperties();
            List<SqlParameter> lstProps = new List<SqlParameter>();

            foreach (PropertyInfo prop in entityProps)
            {
                string nombre = prop.Name;
                object valor = prop.GetValue(entidad);

                SqlParameter sqlProp = new SqlParameter($"{nombre}", valor);
                lstProps.Add(sqlProp);
            }

            return lstProps.ToArray();
        }
    }
}
