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
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {
        public update()
        {
            InitializeComponent();
        }

        private void btn_NewUpdate(object sender, RoutedEventArgs e)
        {
            LandingController CallLanding = new LandingController();

            string DataUsername = username.Text;
            string DataPassword = password.Password;

            CallLanding.ChangePass(DataUsername, DataPassword);
        }
    }
}
