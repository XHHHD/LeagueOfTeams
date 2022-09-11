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

namespace LeagueOfTeamsUI.Views
{
    public partial class AuthorizationWindow : Window
    {
        public bool IsItRegistration = false;
        public string Login => loggingBox.Text;
        public string Password => passwordBox.Text;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            IsItRegistration = true;
            Accept_Click(sender, e);
        }
    }
}
