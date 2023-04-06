using courser_project.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace courser_project
{
    /// <summary>
    /// Interaction logic for DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=YAROSLAV;Initial Catalog=Booking;Integrated Security=True; TrustServerCertificate = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString()
                        // Retrieve other user information from the database as needed
                    };
                    users.Add(user);
                }
                reader.Close();

                userComboBox.ItemsSource = users;
                userComboBox.DisplayMemberPath = "Username";
                userComboBox.SelectedValuePath = "Id";
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = userComboBox.SelectedItem as User;
            if (selectedUser != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=YAROSLAV;Initial Catalog=Booking;Integrated Security=True; TrustServerCertificate = True"))
                    {
                        connection.Open();
                        string query = "DELETE FROM Users WHERE Id = @UserId";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", selectedUser.Id);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User deleted successfully.");
                                LoadUsers(); // Refresh the user list after deleting a user
                            }
                            else
                            {
                                MessageBox.Show("User not found or failed to delete.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainForAdmin forAdmin = new MainForAdmin();
            Close();
            forAdmin.Show();
        }
    }
}
