using System.Windows;

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
