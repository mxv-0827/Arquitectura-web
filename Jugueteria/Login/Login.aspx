<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" EnableSessionState="True" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Css/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container" runat="server">
            <h2 id="H_IniciarSesion" runat="server">Iniciar sesión</h2>

            <div class="form-group" runat="server">
                <asp:Label ID="lblUsuario" runat="server" Text="Correo electrónico:" AssociatedControlID="txtUsuario" />
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control input-ancho" />
    
                <div class="error-group" runat="server">
                    <asp:RequiredFieldValidator 
                        ID="rfvUsuario" 
                        runat="server"
                        ControlToValidate="txtUsuario"
                        ErrorMessage="El correo es obligatorio."
                        CssClass="validator" 
                        Display="Dynamic" />

                    <asp:RegularExpressionValidator 
                        ID="revUsuario" 
                        runat="server"
                        ControlToValidate="txtUsuario"
                        ErrorMessage="Debe ser un correo válido."
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                        CssClass="validator" 
                        Display="Dynamic" />
                </div>
            </div>

            <!-- Contraseña -->
            <div class="form-group" runat="server">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:" AssociatedControlID="txtPassword" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control input-ancho" />
    
                <div class="error-group" runat="server">
                    <asp:RequiredFieldValidator 
                        ID="rfvPassword" 
                        runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="La contraseña es obligatoria."
                        CssClass="validator" 
                        Display="Dynamic" />
                </div>
            </div>
                <asp:Label ID="lblMensajeError" runat="server" CssClass="error-message" Visible="False">El correo o la contraseña son incorrectos.</asp:Label>
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesion" CssClass="btn-login input-ancho" OnClick="btnLogin_Click" CausesValidation="true"/>
                <asp:Button ID="BtnRegistro" runat="server" Text="Registrarse" CssClass="btn-login input-ancho" OnClick="btnRegistro_Click" CausesValidation="false"/>
            </div>       
    </form>
</body>
</html>
