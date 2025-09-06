using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

public partial class Paginas_Administrador_GestionUsuarios : System.Web.UI.Page
{
    //ESTO DE LAS PROPS NO ES NECESARIO EN WINFORMS - PONER SOLO 'private _tablaUsuarios; private _tablaRoles'
    private DataTable _tablaUsuarios
    {
        get
        {
            return ViewState["TablaUsuarios"] as DataTable;
        }
        set
        {
            ViewState["TablaUsuarios"] = value;
        }
    }

    private DataTable _tablaRoles
    {
        get
        {
            return ViewState["TablaRoles"] as DataTable;
        }
        set
        {
            ViewState["TablaRoles"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BLL_Usuarios Bll_Usuarios = new BLL_Usuarios();
            _tablaUsuarios = Bll_Usuarios.LeerTodos();

            BLL_Roles Bll_Roles = new BLL_Roles();
            _tablaRoles = Bll_Roles.LeerTodos();

            gvUsuarios.DataSource = _tablaUsuarios;
            gvUsuarios.DataBind();

            cbxRol.DataSource = _tablaRoles;
            cbxRol.DataTextField = "Nombre";
            cbxRol.DataValueField = "ID";
            cbxRol.DataBind();

            btnModificar.Enabled = false;
            btnActivarDesactivar.Enabled = false;
            btnDesbloquear.Enabled = false;
        }
    }

    protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsuarios.PageIndex = e.NewPageIndex;

        gvUsuarios.DataSource = _tablaUsuarios;
        gvUsuarios.DataBind();
    }

    protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvUsuarios.SelectedRow;

        txtDNI.Enabled = false;

        txtDNI.Text = row.Cells[1].Text;
        txtNombre.Text = row.Cells[2].Text;
        txtApellido.Text = row.Cells[3].Text;
        txtCelular.Text = row.Cells[4].Text;

        cbxRol.ClearSelection(); //solo en asp,net
        cbxRol.Items.FindByText(row.Cells[7].Text).Selected = true;

        btnAgregar.Enabled = false;
        btnModificar.Enabled = true;
        btnActivarDesactivar.Enabled = true;

        divEmailPassword.Visible = false;

        bool esActivo = ((CheckBox)row.Cells[5].Controls[0]).Checked;
        if (esActivo) btnActivarDesactivar.Text = "DESACTIVAR";
        else btnActivarDesactivar.Text = "REACTIVAR";

        bool esBloqueado = ((CheckBox)row.Cells[6].Controls[0]).Checked;
        if (esBloqueado) btnDesbloquear.Enabled = true;
    }

    protected void btnBorrarContenido_Click(object sendeer, EventArgs e)
    {
        BorrarContenido();
    }

    protected void btnAgregar_Click(object sendeer, EventArgs e)
    {
        bool existeDNI = _tablaUsuarios.AsEnumerable().Any(r => r[0].ToString() == txtDNI.Text);

        if (existeDNI)
        {
            lblErrorDNI.Visible = true;
            lblErrorDNI.Text = "El DNI introducido ya existe.";

            return;
        }

        Usuario usuario = new Usuario //Activo y bloqueado se asignan solos en el SP
        {
            DNI = txtDNI.Text,
            Nombre = txtNombre.Text,
            Apellido = txtApellido.Text,
            Celular = txtCelular.Text
        };
        usuario.Rol = new Perfil();
        usuario.Rol.ID = int.Parse(cbxRol.SelectedValue); //Unicamente vale con el ID. Al loguearse, se asignan los permisos (y roles hijos) solos

        BLL_Usuarios bll_Usuarios = new BLL_Usuarios();
        bll_Usuarios.Agregar(usuario);

        Credenciales credenciales = new Credenciales
        {
            DNI_Usuario = txtDNI.Text,
            Email = txtEmail.Text,
            Password = txtPassword.Text
        };

        BLL_Credenciales bll_Credenciales = new BLL_Credenciales();
        bll_Credenciales.Agregar(credenciales);

        divMensajeExito.Visible = true;

        DataRowOperacion("Agregar", usuario); //Agrega, modifica o elimina el usuario del dt.
        BorrarContenido();
    }

    protected void btnModificar_Click(object sendeer, EventArgs e)
    {
        Usuario usuario = new Usuario //Activo y bloqueado se asignan solos en el SP
        {
            DNI = txtDNI.Text,
            Nombre = txtNombre.Text,
            Apellido = txtApellido.Text,
            Celular = txtCelular.Text
        };
        usuario.Rol = new Perfil();
        usuario.Rol.ID = int.Parse(cbxRol.SelectedValue); //Unicamente vale con el ID. Al loguearse, se asignan los permisos (y roles hijos) solos

        BLL_Usuarios bll_Usuarios = new BLL_Usuarios();
        bll_Usuarios.Modificar(usuario);

        divMensajeExito.Visible = true;

        DataRowOperacion("Modificar", usuario); //Agrega, modifica o elimina el usuario del dt.
        BorrarContenido();
    }

    protected void btnActivarDesactivar_Click(object sendeer, EventArgs e)
    {
        Usuario usuario = new Usuario //Activo y bloqueado se asignan solos en el SP
        {
            DNI = txtDNI.Text,
            Activo = btnActivarDesactivar.Text == "REACTIVAR" ? true : false
        };

        BLL_Usuarios bll_Usuarios = new BLL_Usuarios();
        bll_Usuarios.Activar_Desactivar(usuario.DNI, usuario.Activo);

        divMensajeExito.Visible = true;

        DataRowOperacion("ActivarDesactivar", usuario); //Agrega, modifica o elimina el usuario del dt.
        BorrarContenido();
    }

    protected void btnDesbloquear_Click(object sendeer, EventArgs e)
    {
        Usuario usuario = new Usuario //Activo y bloqueado se asignan solos en el SP
        {
            DNI = txtDNI.Text,
            Bloqueado = false
        };

        BLL_Usuarios bll_Usuarios = new BLL_Usuarios();
        bll_Usuarios.Desbloquear(usuario.DNI);

        divMensajeExito.Visible = true;

        DataRowOperacion("Desbloquear", usuario); //Agrega, modifica o elimina (soft) el usuario del dt.
        BorrarContenido();
    }


    private void BorrarContenido()
    {
        txtDNI.Enabled = true;
        txtDNI.Text = string.Empty;

        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtCelular.Text = string.Empty;

        btnAgregar.Enabled = true;
        btnModificar.Enabled = false;
        btnActivarDesactivar.Enabled = false;
        btnDesbloquear.Enabled = false;

        txtEmail.Text = string.Empty;
        txtPassword.Text = string.Empty;

        lblErrorDNI.Visible = false;
        lblErrorNombre.Visible = false;
        lblErrorApellido.Visible = false;
        lblErrorCelular.Visible = false;

        lblErrorEmail.Visible = false;
        lblErrorPassword.Visible = false;

        btnActivarDesactivar.Text = "REACTIVAR/DESACTIVAR";

        divEmailPassword.Visible = true;
    }

    private void DataRowOperacion(string operacion, Usuario usuario)
    {
        DataRow drUsuario = _tablaUsuarios.Select($"DNI = '{usuario.DNI}'")[0]; //Devuelve referencia, por lo q ya se modifica directamente en el dt

        if(drUsuario != null)
        {
            if (operacion == "Modificar")
            {
                drUsuario["Nombre"] = usuario.Nombre;
                drUsuario["Apellido"] = usuario.Apellido;
                drUsuario["Celular"] = usuario.Celular;
                drUsuario["Rol"] = cbxRol.SelectedItem.Text; //No guardamos el nombre del rol en el rol.Nombre - Usamos el que selecciono en el cbx
            }

            else if (operacion == "ActivarDesactivar") drUsuario["Activo"] = usuario.Activo;
            else if (operacion == "Desbloquear") drUsuario["Bloqueado"] = usuario.Bloqueado;
            
        }

        else //No existe el usuario de el dt, por lo que este fue AGREGADO
        {
            DataRow nuevaFila = _tablaUsuarios.NewRow();

            nuevaFila["DNI"] = usuario.DNI;
            nuevaFila["Nombre"] = usuario.Nombre;
            nuevaFila["Apellido"] = usuario.Apellido;
            nuevaFila["Celular"] = usuario.Celular;
            nuevaFila["Activo"] = true; //defecto
            nuevaFila["Bloqueado"] = false; //defecto
            nuevaFila["Rol"] = usuario.Rol.ID;

            // Agregar la fila al DataTable
            _tablaUsuarios.Rows.Add(nuevaFila);
        }

        // Reenlazar el GridView
        gvUsuarios.DataSource = _tablaUsuarios;
        gvUsuarios.DataBind();
    }
}