<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Paginas_Home" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="~/Estilos/Inicio.css" rel="stylesheet" type="text/css" />

    <div class="home-container">
        <h1 class="titulo-jugueton">¡Bienvenidos a Mundo Magico!</h1>

        <p class="descripcion-jugueteria">
            En <strong>Mundo Magico</strong>, creemos que el juego es una parte esencial del crecimiento. Nos dedicamos a ofrecer juguetes que no solo divierten, sino que también estimulan la creatividad, fomentan la imaginación y fortalecen vínculos. Desde bebés hasta preadolescentes, tenemos opciones para cada etapa de la niñez.
        </p>

        <p class="descripcion-jugueteria">
            Nuestro equipo está formado por apasionados del juego y la educación. Elegimos cuidadosamente cada juguete para garantizar calidad, seguridad y valor educativo. Además, creemos en la atención personalizada, por eso siempre estamos listos para ayudarte a elegir el mejor regalo.
        </p>

        <p class="descripcion-jugueteria">
            Nos encanta ver sonrisas en las caras de nuestros clientes, y trabajamos todos los días para hacer de Juegolandia un lugar donde los chicos y chicas quieran volver una y otra vez. ¡Te esperamos!
        </p>

        <div class="ubicacion-container">
            <h2 class="subtitulo-jugueton">¿Dónde estamos?</h2>
            <p class="direccion-jugueteria">📍 Av. Corrientes 1234, CABA, Buenos Aires</p>

            <div class="mapa-container">
                <iframe
                    width="100%" height="400" style="border:0;" loading="lazy"
                    allowfullscreen 
                    referrerpolicy="no-referrer-when-downgrade"
                    src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d13129.864227376047!2d-58.3939!3d-34.6037!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bccb62f01c6211%3A0x9f6aaed21815ad6!2sAv.%20Corrientes%201234%2C%20C1043AAR%20CABA!5e0!3m2!1ses!2sar!4v1720563512032!5m2!1ses!2sar">
                </iframe>
            </div>
        </div>
    </div>
</asp:Content>
