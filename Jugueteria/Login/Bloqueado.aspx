<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bloqueado.aspx.cs" Inherits="Login_Bloqueado" EnableSessionState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Css/Bloqueado.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="bloqueo-box">
            <h2>Acceso bloqueado</h2>
            <p>Se han detectado múltiples intentos fallidos de inicio de sesión.</p>
            <p>Por razones de seguridad, el sistema ha sido bloqueado temporalmente.</p>
        </div>
    </form>
</body>
</html>
