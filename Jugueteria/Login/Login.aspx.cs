using BE;
using BLL;
using SIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Login_Login : System.Web.UI.Page
{
    private int _intentosFallidos { get; set; }
    private bool _estaSuscrita {  get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UltimaPaginaVisitada"] = "/Login/Login.aspx";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Credenciales credenciales = new Credenciales
        {
            Email = txtUsuario.Text,
            Password = txtPassword.Text,
        };

        BLL_Credenciales login = new BLL_Credenciales();
        Usuario usuarioLogueado = null;

        try
        {
           usuarioLogueado  = login.Login(credenciales);
        }

        catch (UnauthorizedAccessException) //Cuenta inactiva o bloqueada
        {
            string script = "alert('Hubo un problema con la cuenta del usuario. Puede que haya sido bloqueada o desactivada.');";
            ClientScript.RegisterStartupScript(this.GetType(), "CuentaBloqueada", script, true);

            return;
        }

        if (usuarioLogueado == null) // Aca ya quiere decir que le pifio al mail y/o password
        {
            if (Session["IntentosFallidos"] == null) Session["IntentosFallidos"] = 1;
            else Session["IntentosFallidos"] = (int)Session["IntentosFallidos"] + 1;

            if ((int)Session["IntentosFallidos"] == 3)
            {
                Session["Bloqueado"] = true;
                Response.Redirect("Bloqueado.aspx");
            }

            txtPassword.Text = "";
            txtPassword.Focus();

            lblMensajeError.Visible = true;

            return;
        }

        Session["UsuarioLogueado"] = usuarioLogueado;

        BLL_Integridad bll_Integridad = new BLL_Integridad();

        DataTable tablaIntegridadDVVEstado = bll_Integridad.VerificarIntegridad("VerificarIntegridadDVV"); //Realiza una verificacion en toda la BD si se ELIMINARON REGISTROS malevolamente
        DataRow[] tablasCorruptasDVV = tablaIntegridadDVVEstado.Select("Estado = true"); //false = OK - true = NO OK

        DataTable tablaIntegridadDVHEstado = bll_Integridad.VerificarIntegridad("VerificarIntegridadDVH"); //Realiza una verificacion en toda la BD si se AGREGARON o MODIFICARON REGISTROS malevolamente
        DataRow[] tablasCorruptasDVH = tablaIntegridadDVHEstado.Select("Estado = true"); //false = OK - true = NO OK

        DataTable tablasCorruptasUnificada = tablaIntegridadDVVEstado.Clone(); // Clona la estructura (columnas y tipos) sin datos - Podia haber sido la de DVH tmbn

        // Combinar ambas listas
        foreach (DataRow row in tablasCorruptasDVV.Concat(tablasCorruptasDVH))
        {
            // Usar filtro LINQ para verificar si ya existe (compara valores de todas las columnas)
            bool existe = tablasCorruptasUnificada.AsEnumerable().Any(r =>
                r.ItemArray.SequenceEqual(row.ItemArray)
            );

            if (!existe)
                tablasCorruptasUnificada.ImportRow(row);
        }


        if (tablasCorruptasUnificada.Rows.Count > 0)
        {
            Session["TablasCorruptas"] = tablasCorruptasUnificada;

            //Si hay datos corruptos y NO es admin muestra pantalla de error -> NO PUEDE HACER NADA
            if (!usuarioLogueado.Rol.Nombre.Contains("Administrador")) Response.Redirect("/Paginas/Error.aspx");

            else Response.Redirect("/Paginas/Administrador/Administrador.aspx");
        }

        else if (tablasCorruptasDVV.Length == 0)
        {
            BLL_Bitacora bll_Bitacora = new BLL_Bitacora();
            Bitacora entrada = new Bitacora()
            {
                Usuario = usuarioLogueado.Nombre + " " + usuarioLogueado.Apellido,
                Accion = "ENTRADA",
                Horario = DateTime.Now
            };

            //bll_Bitacora.Agregar(entrada);
        }

        //Creamos ya el carrito de compras
        Session["Carrito"] = new Carrito();

        if (!usuarioLogueado.Rol.Nombre.Contains("Administrador")) Response.Redirect("/Paginas/Home.aspx");
        else Response.Redirect("/Paginas/Administrador/Administrador.aspx");
    }

    protected void btnRegistro_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registrarse.aspx");
    }
}