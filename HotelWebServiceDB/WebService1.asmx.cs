using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HotelWebServiceDB
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string allReservations()
        {
            string connectionString = "Data Source=SUDO-DESKTOP\\SQLEXPRESS;Initial Catalog=hotelTarea;Integrated Security=True;\r\n";

            string query = @"SELECT R.Id_reserva, R.Id_habitacion, H.tipo AS TipoHabitacion, R.Id_persona, P.nombre AS NombrePersona, P.ci AS CIPersona, R.fecha, R.hora_inicio, R.hora_fin
                             FROM Reserva R
                             JOIN Habitacion H ON R.Id_habitacion = H.Id_habitacion
                             JOIN Persona P ON R.Id_persona = P.Id_persona";

            string reservasText = "Reservas:<br/>";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idReserva = (int)reader["Id_reserva"];
                    int idHabitacion = (int)reader["Id_habitacion"];
                    string tipoHabitacion = (string)reader["TipoHabitacion"];
                    int idPersona = (int)reader["Id_persona"];
                    string nombrePersona = (string)reader["NombrePersona"];
                    string ciPersona = (string)reader["CIPersona"];
                    DateTime fecha = (DateTime)reader["fecha"];
                    TimeSpan horaInicio = (TimeSpan)reader["hora_inicio"];
                    TimeSpan horaFin = (TimeSpan)reader["hora_fin"];

                    reservasText += $"Reserva #{idReserva}: Habitación #{idHabitacion} ({tipoHabitacion}), Persona: {nombrePersona} (CI: {ciPersona}), Fecha: {fecha.ToShortDateString()}, Hora de inicio: {horaInicio}, Hora de fin: {horaFin}<br/>";
                }
            }

            return reservasText;

        }

        [WebMethod]
        public string simplesReservations()
        {
            string connectionString = "Data Source=SUDO-DESKTOP\\SQLEXPRESS;Initial Catalog=hotelTarea;Integrated Security=True;";

            string query = @"SELECT R.Id_reserva, R.Id_habitacion, R.Id_persona, P.nombre AS NombrePersona, P.ci AS CIPersona, R.fecha, R.hora_inicio, R.hora_fin
                     FROM Reserva R
                     JOIN Habitacion H ON R.Id_habitacion = H.Id_habitacion
                     JOIN Persona P ON R.Id_persona = P.Id_persona
                     WHERE H.tipo = 'Simple'";


            string reservasSimplesText = "Reservas de Habitaciones Simples:<br/>";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int idReserva = (int)reader["Id_reserva"];
                    int idHabitacion = (int)reader["Id_habitacion"];
                    string nombrePersona = (string)reader["NombrePersona"];
                    string ciPersona = (string)reader["CIPersona"];
                    DateTime fecha = (DateTime)reader["fecha"];
                    TimeSpan horaInicio = (TimeSpan)reader["hora_inicio"];
                    TimeSpan horaFin = (TimeSpan)reader["hora_fin"];

                    reservasSimplesText += $"Reserva #{idReserva}: Habitación #{idHabitacion}, Persona: {nombrePersona} (CI: {ciPersona}), Fecha: {fecha.ToShortDateString()}, Hora de inicio: {horaInicio}, Hora de fin: {horaFin}<br/>";
                }
            }
            return reservasSimplesText;
        }

        [WebMethod]
        public string todayReservations()
        {

            string connectionString = "Data Source=SUDO-DESKTOP\\SQLEXPRESS;Initial Catalog=hotelTarea;Integrated Security=True;\r\n";


            DateTime fechaHoy = DateTime.Today;


            string query = $@"SELECT R.Id_reserva, R.Id_habitacion, H.tipo AS TipoHabitacion, R.Id_persona, P.nombre AS NombrePersona, P.ci AS CIPersona, R.fecha, R.hora_inicio, R.hora_fin
                              FROM Reserva R
                              JOIN Habitacion H ON R.Id_habitacion = H.Id_habitacion
                              JOIN Persona P ON R.Id_persona = P.Id_persona
                              WHERE R.fecha = '{fechaHoy.ToString("yyyy-MM-dd")}'";


            string reservasHoyText = "Reservas de hoy:<br/>";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

 
                while (reader.Read())
                {
                    int idReserva = (int)reader["Id_reserva"];
                    int idHabitacion = (int)reader["Id_habitacion"];
                    string tipoHabitacion = (string)reader["TipoHabitacion"];
                    int idPersona = (int)reader["Id_persona"];
                    string nombrePersona = (string)reader["NombrePersona"];
                    string ciPersona = (string)reader["CIPersona"];
                    DateTime fecha = (DateTime)reader["fecha"];
                    TimeSpan horaInicio = (TimeSpan)reader["hora_inicio"];
                    TimeSpan horaFin = (TimeSpan)reader["hora_fin"];


                    reservasHoyText += $"Reserva #{idReserva}: Habitación #{idHabitacion} ({tipoHabitacion}), Persona: {nombrePersona} (CI: {ciPersona}), Fecha: {fecha.ToShortDateString()}, Hora de inicio: {horaInicio}, Hora de fin: {horaFin}<br/>";
                }
            }


            return reservasHoyText;

        }

        [WebMethod]
        public string reservasPorCI(string ci)
        {

            string connectionString = "Data Source=SUDO-DESKTOP\\SQLEXPRESS;Initial Catalog=hotelTarea;Integrated Security=True;\r\n";


            string query = $@"SELECT R.Id_reserva, R.Id_habitacion, H.tipo AS TipoHabitacion, R.Id_persona, P.nombre AS NombrePersona, P.ci AS CIPersona, R.fecha, R.hora_inicio, R.hora_fin
                              FROM Reserva R
                              JOIN Habitacion H ON R.Id_habitacion = H.Id_habitacion
                              JOIN Persona P ON R.Id_persona = P.Id_persona
                              WHERE P.ci = '{ci}'";


            string reservasPorCIText = $"Reservas realizadas por la persona con CI: {ci}<br/>";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    int idReserva = (int)reader["Id_reserva"];
                    int idHabitacion = (int)reader["Id_habitacion"];
                    string tipoHabitacion = (string)reader["TipoHabitacion"];
                    int idPersona = (int)reader["Id_persona"];
                    string nombrePersona = (string)reader["NombrePersona"];
                    string ciPersona = (string)reader["CIPersona"];
                    DateTime fecha = (DateTime)reader["fecha"];
                    TimeSpan horaInicio = (TimeSpan)reader["hora_inicio"];
                    TimeSpan horaFin = (TimeSpan)reader["hora_fin"];


                    reservasPorCIText += $"Reserva #{idReserva}: Habitación #{idHabitacion} ({tipoHabitacion}), Persona: {nombrePersona} (CI: {ciPersona}), Fecha: {fecha.ToShortDateString()}, Hora de inicio: {horaInicio}, Hora de fin: {horaFin}<br/>";
                }
            }


            return reservasPorCIText;
        }
    }
}
