using LeagueOfTeamsUI.Views;
using LOT.BLL.Models;
using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Pages
{
    public partial class LoginLogo : Page
    {
        LogginUserStatsWindow logginedUserStats;
        public LoginLogo(UserModel user)
        {
            InitializeComponent();
            UserName.Content = user.Name;
            logginedUserStats = new(user);
        }

        private void LoginStatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (logginedUserStats.ShowDialog() == true);
        }
    }
}
