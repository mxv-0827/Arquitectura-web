using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLL_Credenciales
    {
        private readonly DAL_Credenciales _DalCredenciales = new DAL_Credenciales();

        public int Agregar(Credenciales credenciales)
        {
            return _DalCredenciales.Agregar(credenciales, "AgregarCredenciales");
        }

        //public int Modificar(Credenciales credenciales)
        //{

        //}

        //public int Eliminar(Credenciales credenciales)
        //{

        //}

        public Usuario Login(Credenciales credenciales)
        {
            return _DalCredenciales.Login(credenciales, "ObtenerUsuarioPorCredenciales");
        }
    }
}
