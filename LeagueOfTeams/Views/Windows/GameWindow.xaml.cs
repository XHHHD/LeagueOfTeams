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
using LeagueOfTeamsUI.Views.Pages.Services;
using LeagueOfTeamsUI.Views.Pages.Services.Logos;

namespace LeagueOfTeamsUI.Views
{
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            GameMainFrame.Content = new UserStatsPage();
            PlayerStatsButton.Content = new PlayerStatsLogo();
            TeamStatsButton.Content = new TeamStatsLogo();
            LeagueButton.Content = new LeagueLogo();
            TopTeamsButton.Content = new TopTeamsLogo();
            TopMembersButton.Content = new TopMembersLogo();
        }
        private void GameMainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CheckedFullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            GameMainWindow.WindowState = WindowState.Maximized;
        }
        private void UncheckedFullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            GameMainWindow.WindowState = WindowState.Normal;
        }
        private void MinimizedButton_Click(object sender, RoutedEventArgs e)
        {
            GameMainWindow.WindowState = WindowState.Minimized;
        }
    }
}
