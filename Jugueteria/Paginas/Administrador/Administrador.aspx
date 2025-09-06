<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Administrador.aspx.cs" Inherits="Paginas_Administrador" EnableSessionState="True" %>

<asp:Content ID="HeadContent1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Css/Administrador.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">

        <div class="grid-container" runat="server" id="divUsuariosCorrupta" visible ="false">
            <h2 runat="server">Listado de usuarios CORRUPTOS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvUsuariosCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divCredencialesCorrupta" visible ="false">
            <h2 runat="server">Listado de credenciales CORRUPTAS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvCredencialesCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divRolesCorrupta" visible ="false">
            <h2 runat="server">Listado de roles CORRUPTAS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvRolesCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta.."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divFamiliasCorrupta" visible ="false">
            <h2 runat="server">Listado de familias CORRUPTAS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvFamiliasCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta.."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divPermisosCorrupta" visible ="false">
            <h2 runat="server">Listado de permisos CORRUPTOS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvPermisosCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divRolesFamiliasCorrupta" visible ="false">
            <h2 runat="server">Listado de roles_familias CORRUPTOS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvRolesFamiliasCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvBitacora_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divRolesPermisosCorrupta" visible ="false">
            <h2 runat="server">Listado de roles_permisos CORRUPTOS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvRolesPermisosCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvBitacora_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        

        <div class="grid-container" runat="server" id="divFamiliasPermisosCorrupta" visible ="false">
            <h2 runat="server">Listado de familias_permisos CORRUPTOS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvFamiliasPermisosCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvBitacora_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divJerarquiaFamiliasCorrupta" visible ="false">
            <h2 runat="server">Listado de jerarquia_familias CORRUPTAS</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvJerarquiaFamiliasCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="Se han eliminado registros de manera corrupta."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container" runat="server" id="divBitacoraCorrupta" visible ="false">
            <h2 runat="server">Listado de bitacora CORRUPTA</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvBitacoraCorrupta"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-corrupta"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="No hay registros en la bitácora."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvBitacora_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <!-- Usuarios -->
        <div class="grid-container" runat="server" id="divUsuarios" visible ="false">
            <h2 runat="server">Listado de usuarios</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvUsuarios"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-usuarios"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="No hay registros disponibles."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>

        <!-- Bitácora -->
        <div class="grid-container" runat="server" id="divBitacora" visible ="false">
            <h2 runat="server">Bitácora</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvBitacora"
                    AutoGenerateColumns="true"
                    CssClass="grid-admin grid-bitacora"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="No hay registros en la bitácora."
                    AllowPaging="true"
                    PageSize="5" 
                    OnPageIndexChanging="gvBitacora_PageIndexChanging">
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="botones-gestion">
        <asp:Button CssClass="btn-verde" runat="server" id="btnRealizarBackup" OnClick="btnRealizarBackup_Click" Text="Realizarr BackUp"/>
        <asp:Button CssClass="btn-verde" runat="server" id="btnRestaurarBD" OnClick="btnRestaurarDB_Click" Text="Restaurar Base de Datos"/>
        <asp:Button CssClass="btn-verde" runat="server" id="btnGestionarRolesPermisos" OnClick="btnGestionRolesPermisos_Click" Text="Gestionar Roles y Permisos"/>
        <asp:Button CssClass="btn-verde" runat="server" id="btnGestionarUsuarios" OnClick="btnGestionUsuarios_Click" Text="Gestionar Usuarios"/>
    </div>

</asp:Content>
