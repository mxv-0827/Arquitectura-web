using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

public partial class Paginas_Administrador : System.Web.UI.Page
{
    private DataTable _tablaUsuarios;
    private DataTable _tablaBitacora;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable tablasCorruptas = (DataTable)Session["TablasCorruptas"]; //Obtenemos tablas corruptas por DVH, DVV o ambas

        ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("MainContent");

        if (tablasCorruptas != null && tablasCorruptas.Rows.Count != 0) //minimo una tabla corrupta
        {
            BLL_Integridad bll_Integridad = new BLL_Integridad();

            foreach (DataRow tablaCorrupta in tablasCorruptas.Rows)
            {
                string nombreTabla = tablaCorrupta["Tabla"].ToString().Replace("_", ""); //El nombre de los SPs no incluye '_' en las tablas. Hay q sacarlos

                GridView gvCorrupta = (GridView)contentPlaceHolder.FindControl($"gv{nombreTabla}Corrupta");
                Control divCorrupta = contentPlaceHolder.FindControl($"div{nombreTabla}Corrupta");

                DataTable registrosCorruptos = bll_Integridad.VerificarIntegridad($"VerificarIntegridad{nombreTabla}"); //Obtenemos los registros que fueron corrompidos en la tabla corrupta (agregado/modificado)
                
                divCorrupta.Visible = true;
                gvCorrupta.DataSource = registrosCorruptos;
                gvCorrupta.DataBind();

                if (registrosCorruptos.Rows.Count == 0) gvCorrupta.EmptyDataText = "Se han eliminado registros"; //Para casos de registros borrados
            }

            btnGestionarRolesPermisos.Enabled = false;
            btnGestionarUsuarios.Enabled = false;

            return;
        } 
        

        divUsuarios.Visible = true;
        divBitacora.Visible = true;

        BLL_Usuarios Bll_Usuarios = new BLL_Usuarios();
        _tablaUsuarios = Bll_Usuarios.LeerTodos();

        gvUsuarios.DataSource = _tablaUsuarios;
        gvUsuarios.DataBind();


        BLL_Bitacora Bll_Bitacora = new BLL_Bitacora();
        _tablaBitacora = Bll_Bitacora.LeerTodos();

        gvBitacora.DataSource = _tablaBitacora;
        gvBitacora.DataBind();
    }

    protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsuarios.PageIndex = e.NewPageIndex;

        gvUsuarios.DataSource = _tablaUsuarios;
        gvUsuarios.DataBind();
    }

    protected void gvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBitacora.PageIndex = e.NewPageIndex;

        var lista = _tablaBitacora;
        gvBitacora.DataSource = lista;
        gvBitacora.DataBind();
    }

    protected void btnRealizarBackup_Click(object sender, EventArgs e)
    {
        BLL_Integridad bll_Integridad = new BLL_Integridad();
        bll_Integridad.RealizarBackup();

        BLL_Bitacora bll_Bitacora = new BLL_Bitacora();
        Bitacora entrada = new Bitacora()
        {
            Usuario = ((Usuario)Session["UsuarioLogueado"]).Nombre + " " + ((Usuario)Session["UsuarioLogueado"]).Nombre,
            Accion = "BackUp",
            Horario = DateTime.Now
        };

        bll_Bitacora.Agregar(entrada);
    }

    protected void btnRestaurarDB_Click(object sender, EventArgs e)
    {
        BLL_Integridad bll_Integridad = new BLL_Integridad();
        bll_Integridad.RestaurarBD();

        //Si hay datos corruptos en la BD, NO se registra la bitacora de entrada al principio
        BLL_Bitacora bll_Bitacora = new BLL_Bitacora();
        Bitacora entrada = new Bitacora()
        {
            Usuario = ((Usuario)Session["UsuarioLogueado"]).Nombre + " " + ((Usuario)Session["UsuarioLogueado"]).Nombre,
            Accion = "Restauracion",
            Horario = DateTime.Now
        };

        bll_Bitacora.Agregar(entrada);

        Session["TablasCorruptas"] = null;

        Response.Redirect("/Paginas/Administrador/Administrador.aspx");
    }

    protected void btnGestionRolesPermisos_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Paginas/Administrador/GestionRolesPermisos.aspx");
    }

    protected void btnGestionUsuarios_Click(object sender, EventArgs a)
    {
        Response.Redirect("/Paginas/Administrador/GestionUsuarios.aspx");
    }
}