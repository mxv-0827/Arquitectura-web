using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Bloqueado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Si no esta bloqueado, es redirigido a la ultima pagina de la app visitada
        if (Session["Bloqueado"] == null || (bool)Session["Bloqueado"] == false) Response.Redirect(Session["UltimaPaginaVisitada"].ToString());
    }
}