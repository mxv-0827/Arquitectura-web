using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

public partial class Paginas_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UsuarioLogueado"] == null) Response.Redirect(Session["UltimaPaginaVisitada"].ToString());

        Session["UltimaPaginaVisitada"] = "/Paginas/Home.aspx";
    }
}