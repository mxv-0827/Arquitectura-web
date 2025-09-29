using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Detalle
    {
        BD_Conexion conexion = BD_Conexion.ObtenerInstancia();


        public void AgregarDetalle(Detalle detalle, string sp)
        {
            conexion.Escribir(sp, GenerarSqlPropsArray(detalle));
        }

        public DataTable ObtenerTodosDetalles(string sp)
        {
            return conexion.Leer(sp);
        }

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
