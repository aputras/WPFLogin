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
using wpflanding.Controller;

namespace wpflanding.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        LandingController CallLanding = new LandingController();
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register(object sender, RoutedEventArgs e)
        {
            string dataemail = email.Text;
            string datafullname = fullname.Text;
            string datausername = username.Text;
            string datapassword = password.Password;

            CallLanding.AddUser(dataemail, datafullname, datausername, datapassword);
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
