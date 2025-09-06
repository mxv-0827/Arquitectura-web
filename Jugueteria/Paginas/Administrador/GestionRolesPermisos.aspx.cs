using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Paginas_Administrador_GestionRolesPermisos : System.Web.UI.Page
{
    private DataTable _tablaRoles;
    private DataTable _tablaPermisos;

    protected void Page_Load(object sender, EventArgs e)
    {
        BLL_Roles bll_Roles = new BLL_Roles();
        _tablaRoles = bll_Roles.LeerTodosCompleto();

        BLL_Permisos bll_Permisos = new BLL_Permisos();
        _tablaPermisos = bll_Permisos.LeerTodos();
        

    }
}