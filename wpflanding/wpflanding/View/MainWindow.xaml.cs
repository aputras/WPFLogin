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
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpflanding.Controller;
using wpflanding.View;

namespace wpflanding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LandingController callLanding = new LandingController();
        public MainWindow()
        {
            InitializeComponent();
            email.Text = Properties.Settings.Default.Username;
            password.Password = Properties.Settings.Default.Password;
        }

        private void btn_signin(object sender, RoutedEventArgs e)
        {
            string dataemail = email.Text;
            string datapassword = password.Password;
            var status = callLanding.login(dataemail, datapassword);
            //var status = callLanding.login(dataemail, datapassword);
            if (status == true)
            {
                Home home = new Home();
                home.Show();
                Close();
            }
        }

        private void btn_signup(object sender, RoutedEventArgs e)
        {
            Register newWindow = new Register();
            newWindow.Show();
            Close();
        }

        private void Checked_rememberme(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Username = email.Text;
            Properties.Settings.Default.Password = password.Password;
            Properties.Settings.Default.Save();
        }
    }
}
