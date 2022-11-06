using LOT.BLL.Models;
using System.Windows;
using System.Windows.Input;

namespace LeagueOfTeamsUI.Views
{
    public partial class LogginUserStatsWindow : Window
    {
        UserModel user;
        public LogginUserStatsWindow(UserModel user)
        {
            InitializeComponent();
            this.user = user;
            UserName.Content = user.Name;
        }

        private void UserStatsWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void CloseUserStatsButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
