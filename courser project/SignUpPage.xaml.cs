using courser_project.Core.Context;
using courser_project.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = new User
                    {
                        Username = NameTextBox.Text,
                        Email = EmailTextBox.Text,
                        Password = PasswordTextBox.Password
                    };
                    db.Add(users);
                    db.SaveChanges();
                }
                MessageBox.Show("ИЗи!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
