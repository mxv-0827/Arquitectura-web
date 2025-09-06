using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

public partial class Login_Registrarse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        BLL_Integridad bll_Integridad = new BLL_Integridad();
        BLL_Usuarios bll_Usuario = new BLL_Usuarios();

        Usuario usuarioRegistrar = new Usuario
        {
            DNI = txtDNI.Text,
            Nombre = txtNombre.Text,
            Apellido = txtApellido.Text,
            Celular = txtCelular.Text,
        };
        Perfil rolUsuario = new Perfil
        {
            ID = 3 //Rol de CLIENTE - Default
        };
        usuarioRegistrar.Rol = rolUsuario;
        
        bll_Usuario.Agregar(usuarioRegistrar);

        BLL_Credenciales bll_Credenciales = new BLL_Credenciales();

        Credenciales credenciales = new Credenciales
        {
            DNI_Usuario = usuarioRegistrar.DNI,
            Email = txtEmail.Text,
            Password = txtPassword.Text,
        };

        bll_Credenciales.Agregar(credenciales);

        usuarioRegistrar = bll_Credenciales.Login(credenciales); //Reutilizamos procesos para traer al usuario con los roles y permisos q tnga

        Session["UsuarioLogueado"] = usuarioRegistrar;

        BLL_Bitacora bll_Bitacora = new BLL_Bitacora();
        Bitacora entrada = new Bitacora()
        {
            Usuario = usuarioRegistrar.Nombre + " " + usuarioRegistrar.Apellido,
            Accion = "ENTRADA",
            Horario = DateTime.Now
        };

        bll_Bitacora.Agregar(entrada);

        Response.Redirect("/Paginas/Home.aspx");
    }
}