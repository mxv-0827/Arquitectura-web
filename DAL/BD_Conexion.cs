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
    public class BD_Conexion
    {
        //PROPS
        private static BD_Conexion _instancia;

        private readonly SqlConnection _conexion;
        public Usuario UsuarioLogueado { get; set; }


        //CONSTRUCTOR
        private BD_Conexion() => _conexion = new SqlConnection("Server=FLATASS\\SQLEXPRESS; Database=Juegueteria_Web; Trusted_Connection=True;");
        

        //METODOS
        public static BD_Conexion ObtenerInstancia() => _instancia ?? (_instancia = new BD_Conexion());

        private void AbrirConexion()
        {
            if (_conexion.State == ConnectionState.Closed || _conexion.State == ConnectionState.Broken) _conexion.Open();
        }

        private void CerrarConexion()
        {
            if (_conexion.State == ConnectionState.Open) _conexion.Close();
        }


        internal int Escribir(string sp, SqlParameter[] sqlProps = null)
        {
            int linesAffected;

            using (SqlCommand command = new SqlCommand(sp, _conexion))
            {
                AbrirConexion();

                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(sqlProps ?? Array.Empty<SqlParameter>());

                    linesAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    linesAffected = -1;
                }

                CerrarConexion();

                return linesAffected;
            }
        }


        internal DataTable Leer(string sp, SqlParameter[] sqlProps = null)
        {
            //El sqlDataAdapter gestiona internamente la conexion a la BD en su metodo 'Fill', por ende no es necesario poner los metodos de conexion aca.

            DataTable tabla = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sp, _conexion))
            {
                AbrirConexion();

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddRange(sqlProps ?? Array.Empty<SqlParameter>());

                adapter.Fill(tabla);

                CerrarConexion();
                return tabla;
            }
        }


        internal object ObtenerDato(string sp, SqlParameter[] sqlProps = null)
        {
            object resultado;

            using (SqlCommand command = new SqlCommand(sp, _conexion))
            {
                AbrirConexion();

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlProps ?? Array.Empty<SqlParameter>());

                resultado = command.ExecuteScalar();

                CerrarConexion();
            }

            return resultado;
        }
    }
}
