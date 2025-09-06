
<%@ Application Language="C#" %>
<%@ Import Namespace="Jugueteria" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="BLL" %>
<%@ Import Namespace="BE" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }


    void Application_PostAcquireRequestState(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        var session = context?.Session;
        string ruta = context.Request.Url.AbsolutePath.ToLower();

        if (session != null)
        {
            if (session["Bloqueado"] != null &&
                (bool)session["Bloqueado"] &&
                !ruta.EndsWith("/bloqueado"))
            {
                context.Response.Redirect("~/Login/Bloqueado.aspx", true);
            }

            if (!ruta.EndsWith("/login") &&
                session["Bloqueado"] != null &&
                !(bool)session["Bloqueado"] &&
                session["UsuarioLogueado"] == null)
            {
                context.Response.Redirect("~/Login.aspx", true);
            }

            if (ruta.Contains("administrador"))
            {
                var usuario = session["UsuarioLogueado"] as Usuario;
                bool noEsAdmin = usuario == null || !usuario.Rol.Nombre.Contains("Administrador");

                if (noEsAdmin)
                {
                    string ultimaPagina = session["UltimaPaginaVisitada"]?.ToString();
                    context.Response.Redirect(ultimaPagina);
                }
            }

            if (session["TablasCorruptas"] != null)
            {
                var usuario = session["UsuarioLogueado"] as Usuario;
                bool noEsAdmin = usuario == null || !usuario.Rol.Nombre.Contains("Administrador");

                if (noEsAdmin && !ruta.EndsWith("/error"))
                    context.Response.Redirect("~/Paginas/Error.aspx");
            }
        }
    }

</script>
