<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registrarse.aspx.cs" Inherits="Login_Registrarse" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro - Juguetería Mágica</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Css/Registrarse.css" rel="stylesheet" />
</head>
<body class="registro-body">

    <form id="formRegistro" runat="server" class="container py-5">

        <div class="registro-container">
            <h2>🧸 Registro de nuevo usuario</h2>

            <!-- Datos personales -->
            <fieldset class="registro-bloque">
                <legend>Datos personales</legend>

                <div class="form-group">
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="DNI" />
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI"
                        CssClass="text-danger" ErrorMessage="DNI requerido" Display="Dynamic" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                        CssClass="text-danger" ErrorMessage="Nombre requerido" Display="Dynamic" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido" />
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
                        CssClass="text-danger" ErrorMessage="Apellido requerido" Display="Dynamic" />
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Celular" />
                    <asp:RequiredFieldValidator ID="rfvCelular" runat="server" ControlToValidate="txtCelular"
                        CssClass="text-danger" ErrorMessage="Celular requerido" Display="Dynamic" />
                </div>
            </fieldset>

            <!-- Credenciales de la cuenta -->
            <fieldset class="registro-bloque">
                <legend>Credenciales de acceso</legend>

                <div class="form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico"/>

                    <div class="validator-container">
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail"
                            CssClass="text-danger"
                            Display="Dynamic"
                            ErrorMessage="El correo es obligatorio." />

                        <asp:RegularExpressionValidator ID="revEmail" runat="server"
                            ControlToValidate="txtEmail"
                            CssClass="text-danger"
                            Display="Dynamic"
                            ErrorMessage="Formato de correo inválido."
                            ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w{2,}$" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />

                    <asp:RequiredFieldValidator 
                        ID="rfvPassword" 
                        runat="server" 
                        ControlToValidate="txtPassword"
                        CssClass="text-danger" 
                        ErrorMessage="Contraseña requerida" 
                        Display="Dynamic" />

                    <asp:RegularExpressionValidator 
                        ID="revPassword" 
                        runat="server" 
                        ControlToValidate="txtPassword"
                        CssClass="text-danger"
                        Display="Dynamic"
                        ValidationExpression="^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$"
                        ErrorMessage="La contraseña debe tener al menos 6 caracteres, una mayúscula, un número y un símbolo." />
                </div>
            </fieldset>

            <div class="form-group text-center">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrarse" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
