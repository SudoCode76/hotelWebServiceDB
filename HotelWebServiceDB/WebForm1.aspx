<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HotelWebServiceDB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Hotel KeyBusy</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/style.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">

        </div>
        <div class="container">

           <h1 class="texto text-center">HOTEL KEYBUSY</h1>

            <asp:Button ID="btnConsultarReservas" runat="server" Text="Consultar Reservas" CssClass="minimal-button" OnClick="btnConsultarReservas_Click" />
            <asp:Button ID="Button1" runat="server" Text="Reservas Simples" CssClass="minimal-button" OnClick="reservasSimples" />
            <asp:Button ID="Button2" runat="server" Text="Lista de las reservas efectuadas el día de hoy" CssClass="minimal-button" OnClick="reservationsToday" />

           <asp:TextBox ID="txtCI" runat="server" placeholder="Ingrese CI"></asp:TextBox>
            <asp:Button ID="btnConsultarReservasPorCI" runat="server" Text="Consultar Reservas" CssClass="minimal-button" OnClick="btnConsultarReservasPorCI_Click" />

            <div class="result">
                <asp:Label ID="lblReservas" runat="server" Text="" CssClass="texto"></asp:Label>
            </div>

        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
