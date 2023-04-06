using courser_project;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Сourse_project
{
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Window
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            using (SqlConnection connection = new SqlConnection("Data Source=YAROSLAV;Initial Catalog=Booking;Integrated Security=True; TrustServerCertificate = True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    if (username.ToLower() == "admin")
                    {
                        MainForAdmin pageAdmin = new MainForAdmin();
                        Close();
                        pageAdmin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sign in successful!");
                        Main main = new Main();
                        Close();
                        main.Show();
                    }
                }
                else if (username.ToLower() == "admin")
                {
                   
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow signUpPage = new MainWindow();
            Close();
            signUpPage.Show();
        }
    }
}
