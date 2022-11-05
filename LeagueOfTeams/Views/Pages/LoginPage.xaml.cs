using LeagueOfTeamsUI.Views;
using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginStatsButton_Click(object sender, RoutedEventArgs e)
        {
            LogginUserStatsWindow logginedUserStats = new LogginUserStatsWindow();
            if (logginedUserStats.ShowDialog() == true);
        }
    }
}
