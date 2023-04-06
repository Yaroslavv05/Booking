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
using Сourse_project;

namespace courser_project
{
    /// <summary>
    /// Interaction logic for MainForAdmin.xaml
    /// </summary>
    public partial class MainForAdmin : Window
    {
        public MainForAdmin()
        {
            InitializeComponent();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser del = new DeleteUser();
            Close();
            del.Show();
        }

        private void ContentManagement_Click(object sender, RoutedEventArgs e)
        {
            ContentManagement contetn = new ContentManagement();
            Close();
            contetn.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow forAdmin = new MainWindow();
            Close();
            forAdmin.Show();
        }

    }
}
