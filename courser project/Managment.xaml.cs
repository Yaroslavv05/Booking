using courser_project.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace courser_project
{
    /// <summary>
    /// Interaction logic for ContentManagement.xaml
    /// </summary>
    public partial class ContentManagement : Window
    {
        public ContentManagement()
        {
            InitializeComponent();
            LoadHotels();
            LoadRooms();
        }

        private void LoadHotels()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=YAROSLAV;Initial Catalog=Booking;Integrated Security=True; TrustServerCertificate = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Hotels", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string hotelName = reader["HotelName"].ToString();
                    // Retrieve other hotel information from the database as needed
                    // and display them in the UI (e.g., add them to a ListBox or DataGrid)
                    // For example, if you have a ListBox named lstHotels, you can do:
                    // lstHotels.Items.Add(hotelName);
                }
                reader.Close();
            }
        }

        private void LoadRooms()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=YAROSLAV; Initial Catalog=Booking; Integrated Security=True; TrustServerCertificate = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Rooms", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string roomNumber = reader["RoomNumber"].ToString();
                    // Retrieve other room information from the database as needed
                    // and display them in the UI (e.g., add them to a ListBox or DataGrid)
                    // For example, if you have a ListBox named lstRooms, you can do:
                    // lstRooms.Items.Add(roomNumber);
                }
                reader.Close();
            }
        }

        private void AddHotel_Click(object sender, RoutedEventArgs e)
        {
            // Handle logic for adding a hotel here
        }

        private void UpdateHotel_Click(object sender, RoutedEventArgs e)
        {
            // Handle logic for updating a hotel here
        }

        private void DeleteHotel_Click(object sender, RoutedEventArgs e)
        {
            // Handle logic for deleting a hotel here
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            // Handle logic for adding a room here
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            // Handle logic for updating a room here
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            // Handle logic for deleting a room here
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // Handle navigation to the previous page here
            // For example:
            // NavigationService.GoBack();
        }
    }
}
