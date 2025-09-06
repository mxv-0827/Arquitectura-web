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
    public class DAL_Bitacora
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();


        public int Agregar(Bitacora bitacora, string sp)
        {
            SqlParameter[] lstParams = GenerarSqlPropsArray(bitacora);
            return _conexion.Escribir(sp, lstParams);
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

                if (nombre == "ID") continue; //No mandamos el ID dado q es autoincremental desde la BD.

                SqlParameter sqlProp = new SqlParameter($"{nombre}", valor);
                lstProps.Add(sqlProp);
            }

            return lstProps.ToArray();
        }
    }
}
