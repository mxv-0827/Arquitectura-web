using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BE;
using SIL;

namespace DAL
{
    public class DAL_Credenciales
    {
        private readonly BD_Conexion _conexion = BD_Conexion.ObtenerInstancia();

        public int Agregar(Credenciales credenciales, string sp)
        {
            credenciales.Password = Encriptador.EncriptarContraseña(credenciales.Password, credenciales.Email);

            SqlParameter[] lstProps = GenerarSqlPropsArray(credenciales);
            return _conexion.Escribir(sp, lstProps);
        }


        public Usuario Login(Credenciales credenciales, string sp)
        {
            SqlParameter[] lstParams = new SqlParameter[]
            {
                new SqlParameter("Email", credenciales.Email),
                new SqlParameter("Password", Encriptador.EncriptarContraseña(credenciales.Password, credenciales.Email))
            };

            DataTable tablaUsuarioLogueado = _conexion.Leer(sp, lstParams);

            if (tablaUsuarioLogueado.Rows.Count == 0) return null;

            Usuario usuarioLogueado = new Usuario
            {
                DNI = tablaUsuarioLogueado.Rows[0]["DNI"].ToString(),
                Nombre = tablaUsuarioLogueado.Rows[0]["Nombre"].ToString(),
                Apellido = tablaUsuarioLogueado.Rows[0]["Apellido"].ToString(),
                Celular = tablaUsuarioLogueado.Rows[0]["Celular"].ToString(),
                Activo = (bool)tablaUsuarioLogueado.Rows[0]["Activo"],
                Bloqueado = (bool)tablaUsuarioLogueado.Rows[0]["Bloqueado"],
            };

            if (!usuarioLogueado.Activo || usuarioLogueado.Bloqueado) throw new UnauthorizedAccessException();

            DataTable tablaRolUsuarioLogueado = _conexion.Leer("ObtenerPerfilConJerarquia", GenerarSqlPropsArray(new { PerfilID = int.Parse(tablaUsuarioLogueado.Rows[0]["Rol_ID"].ToString()) }));
            DataRow RowRolUsuarioAsignado = tablaRolUsuarioLogueado.Rows[0]; //SIEMPRE el primer registro trae el rol asignado a el mismo 

            Perfil rolUsuarioAsignado = new Perfil
            {
                ID = int.Parse(RowRolUsuarioAsignado["ID"].ToString()),
                Nombre = RowRolUsuarioAsignado["Nombre"].ToString(),
                Descripcion = RowRolUsuarioAsignado["Descripcion"].ToString()
            };
            
            tablaRolUsuarioLogueado.Rows.Remove(RowRolUsuarioAsignado); //Ahora la sacamos de la Table para agregar el resto a lstComponente

            CrearJerarquiaRoles(rolUsuarioAsignado, tablaRolUsuarioLogueado);
            usuarioLogueado.Rol = rolUsuarioAsignado;

            _conexion.UsuarioLogueado = usuarioLogueado; //El usuario logueado ya es de acceso publico (verificar accesos desde aca)

            return usuarioLogueado;
        }



        //-------------------------------------------------------------------------------
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

        private void CrearJerarquiaRoles(Perfil rolPadre, DataTable tablaComponentes) //Aca se organiza la jerarquia de roles (COMPOSITE) por cada rol q tnga el rol principal asignado - Se pone aca dado q se utilizan datos del LOGIN
        {
            // Buscar familias hijas sin padre
            var familiasHijasSinPadre= tablaComponentes.AsEnumerable()
                .Where(r => r["Parent_ID"] == DBNull.Value && r["Tipo"].ToString() == "FAMILIA");

            foreach (var fila in familiasHijasSinPadre)
            {
                Familia familia = new Familia
                {
                    ID = Convert.ToInt32(fila["ID"]),
                    Nombre = fila["Nombre"].ToString(),
                    Descripcion = fila["Descripcion"].ToString(),
                };

                rolPadre.lstComponentes.Add(familia);
            }

            //Busco los permisos directos del perfil
            var permisosDelPerfil = tablaComponentes.AsEnumerable()
                .Where(r => r["Familia_Contenedora_ID"] == DBNull.Value && r["Tipo"].ToString() == "PERMISO");

            foreach (var fila in permisosDelPerfil)
            {
                Permiso permiso = new Permiso
                {
                    ID = Convert.ToInt32(fila["ID"]),
                    Nombre = fila["Nombre"].ToString(),
                    Descripcion = fila["Descripcion"].ToString(),
                };

                rolPadre.lstComponentes.Add(permiso);
            }

            //Ahora asignamos las familias y permisos de las familias padres
            var restoDejerarquia = tablaComponentes.AsEnumerable()
                .Where(r => r["Parent_ID"] != DBNull.Value || r["Familia_Contenedora_ID"] != DBNull.Value);


            foreach (var fila in restoDejerarquia)
            {
                int id = Convert.ToInt32(fila["ID"]);
                string nombre = fila["Nombre"].ToString();
                string descripcion = fila["Descripcion"].ToString();
                string tipo = fila["Tipo"].ToString();

                IComponent compHijo;

                if (tipo == "FAMILIA")
                {
                    int idPadre = Convert.ToInt32(fila["Parent_ID"]);

                    compHijo = new Familia
                    {
                        ID = id,
                        Nombre = nombre,
                        Descripcion = descripcion,
                    };

                    //Agregamos la familia a su respectivo padre
                    AsignarElementoANodosNietos(rolPadre.lstComponentes, idPadre, compHijo);
                }

                else if (tipo == "PERMISO")
                {
                    int idPadre = Convert.ToInt32(fila["Familia_Contenedora_ID"]);

                    compHijo = new Permiso
                    {
                        ID = id,
                        Nombre = nombre,
                        Descripcion = descripcion,
                    };

                    //Agregamos la familia a su respectivo padre
                    AsignarElementoANodosNietos(rolPadre.lstComponentes, idPadre, compHijo);
                }
            }
        }


        private void AsignarElementoANodosNietos(IEnumerable<IComponent> componentes, int idBuscado, IComponent compAgregar)
        {
            foreach (var comp in componentes)
            {
                if (comp is Familia fam)
                {
                    if (fam.ID == idBuscado)
                    {
                        fam.Agregar(compAgregar);
                        break;
                    }

                    else 
                        AsignarElementoANodosNietos(fam.lstComponentes, idBuscado, compAgregar);
                }
            }
        }
    }
}
