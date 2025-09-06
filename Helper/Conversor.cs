using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class Conversor
    {
        //Clase usada para hacer conversiones q requieran mucho codigo

        public static T DeDataRowAEntidad<T>(DataRow fila) where T : new()
        {
            var obj = new T();

            foreach (DataColumn col in fila.Table.Columns)
            {
                var prop = typeof(T).GetProperty(col.ColumnName);
                if (prop != null && fila[col] != DBNull.Value)
                    prop.SetValue(obj, Convert.ChangeType(fila[col], prop.PropertyType));
            }
            return obj;
        }

        public static SqlParameter[] DeEntidadASqlPropArray<T>(T entidad)
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
