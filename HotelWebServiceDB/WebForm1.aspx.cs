using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace HotelWebServiceDB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultarReservas_Click(object sender, EventArgs e)
        {
            // Crear una instancia del cliente del servicio web
            ServiceAllReservations.WebService1SoapClient serviceClient = new ServiceAllReservations.WebService1SoapClient();

            // Llamar al método allReservations del servicio web
            string reservasText = serviceClient.allReservations();

            // Mostrar el resultado en el control Label
            lblReservas.Text = reservasText;

        }



        protected void reservasSimples(object sender, EventArgs e)
        {
            ServiceSimpleReservations.WebService1SoapClient serviceSimple = new ServiceSimpleReservations.WebService1SoapClient();
            string reservasSimplesText = serviceSimple.simplesReservations();
            lblReservas.Text = reservasSimplesText;

        }

        protected void reservationsToday(object sender, EventArgs e)
        {
            ServiceTodayReservations.WebService1SoapClient serviceToday = new ServiceTodayReservations.WebService1SoapClient();
            string reservasHoyText = serviceToday.todayReservations();
            lblReservas.Text = reservasHoyText;

        }
        protected void btnConsultarReservasPorCI_Click(object sender, EventArgs e)
        {
            // Obtener el CI ingresado por el usuario
            string ci = txtCI.Text;

            // Crear una instancia del cliente del servicio web
            ServiceCiReservas.WebService1SoapClient serviceClient = new ServiceCiReservas.WebService1SoapClient();

            // Llamar al método reservasPorCI del servicio web pasando el CI como argumento
            string reservasPorCIText = serviceClient.reservasPorCI(ci);

            // Mostrar el resultado en el control Label
            lblReservas.Text = reservasPorCIText;
        }
    }
}