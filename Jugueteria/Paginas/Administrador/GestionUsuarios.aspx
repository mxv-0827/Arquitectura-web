<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GestionUsuarios.aspx.cs" Inherits="Paginas_Administrador_GestionUsuarios" EnableSessionState="True" %>

<asp:Content ID="HeadContent1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Css/GestionUsuarios.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">

        <!-- Contenedor del Grid de usuarios -->
        <div class="grid-container" runat="server" id="divUsuarios" visible="true">
            <h2>Listado de usuarios</h2>
            <div class="grid-wrapper">
                <asp:GridView runat="server" ID="gvUsuarios"
                    AutoGenerateColumns="true"
                    AutoGenerateSelectButton="true"
                    CssClass="grid-admin grid-usuarios"
                    ShowHeaderWhenEmpty="true"
                    EmptyDataText="No hay registros disponibles."
                    AllowPaging="true"
                    PageSize="5"
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging"
                    OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" >
                </asp:GridView>
            </div>
        </div>

        <!-- Formulario de gestión de usuarios debajo del grid -->
        <div class="form-usuarios" runat="server" id="divFormUsuarios">
            <div class="form-header">
                <h3>Gestión de Usuario</h3>
                <asp:Button runat="server" ID="btnBorrarContenido" Text="BORRAR CONTENIDO" CssClass="btn-rojo" OnClick="btnBorrarContenido_Click" />
            </div>

            <div class="form-row-row">
                <div class="form-row">
                    <label for="txtDNI">DNI</label>
                    <asp:TextBox runat="server" ID="txtDNI" CssClass="input-text"></asp:TextBox>
                    <asp:Label runat="server" ID="lblErrorDNI" CssClass="label-error" Visible="false" />
                </div>
                <div class="form-row">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="input-text"></asp:TextBox>
                    <asp:Label runat="server" ID="lblErrorNombre" CssClass="label-error" Visible="false" />
                </div>
                <div class="form-row">
                    <label for="txtApellido">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="input-text"></asp:TextBox>
                    <asp:Label runat="server" ID="lblErrorApellido" CssClass="label-error" Visible="false" />
                </div>
            </div>

            <div class="form-row-row">
                <div class="form-row">
                    <label for="txtCelular">Celular</label>
                    <asp:TextBox runat="server" ID="txtCelular" CssClass="input-text"></asp:TextBox>
                    <asp:Label runat="server" ID="lblErrorCelular" CssClass="label-error" Visible="false" />
                </div>

                <div class="form-row">
                    <label for="cbxRol">Rol</label>
                    <asp:DropDownList runat="server" ID="cbxRol" CssClass="input-select"></asp:DropDownList>
                </div>
            </div>

            <div id="divEmailPassword" runat="server" style="margin-top: 20px; text-align: left !important;">
                <h3 style="margin-bottom: 15px; color: #444; font-weight: 600;">Credenciales Usuario</h3>

                <div style="display: flex; gap: 20px;">
                    <div class="form-row" style="flex: 1;">
                        <label for="txtEmail">Email</label>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="input-text" TextMode="Email"></asp:TextBox>
                        <asp:Label runat="server" ID="lblErrorEmail" CssClass="label-error" Visible="false"></asp:Label>
                    </div>
                    <div class="form-row" style="flex: 1;">
                        <label for="txtPassword">Password</label>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="input-text" TextMode="Password"></asp:TextBox>
                        <asp:Label runat="server" ID="lblErrorPassword" CssClass="label-error" Visible="false"></asp:Label>
                    </div>

                </div>
            </div>

            <div class="form-buttons">
                <asp:Button runat="server" ID="btnAgregar" Text="AGREGAR" CssClass="btn-accion" OnClick="btnAgregar_Click" />
                <asp:Button runat="server" ID="btnModificar" Text="MODIFICAR" CssClass="btn-accion" OnClick="btnModificar_Click" />
                <asp:Button runat="server" ID="btnActivarDesactivar" Text="REACTIVAR/DESACTIVAR" CssClass="btn-accion" OnClick="btnActivarDesactivar_Click" />
                <asp:Button runat="server" ID="btnDesbloquear" Text="DESBLOQUEAR" CssClass="btn-accion" OnClick="btnDesbloquear_Click" />
            </div>

            <div class="mensaje-exito" runat="server" id="divMensajeExito" visible="false">
                <asp:Label runat="server" ID="lblOperacionExitosa" Text="✔ Operación exitosa" CssClass="label-exito" ClientIDMode="Static"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

