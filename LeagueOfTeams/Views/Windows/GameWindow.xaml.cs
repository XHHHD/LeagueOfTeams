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
using LeagueOfTeamsUI.Views.Pages.Menu;
using LeagueOfTeamsUI.Views.Pages.Menu.Logos;
using LeagueOfTeamsUI.Views.Pages.Menu.MemberServices;

namespace LeagueOfTeamsUI.Views
{
    public partial class GameWindow : Window
    {
        public UserStatsLogo userStatsLogo;
        public TrainingsLogo trainingsLogo;
        public TeamStatsLogo teamStatsLogo;
        public LeagueLogo leagueLogo;
        public TopTeamsLogo topTeamsLogo;
        public TopMembersLogo topMembersLogo;
        public TeamMenu teamMenu;
        public NewMemberMenu newMemberMenu;

        public Page previousMenu;
        public GameWindow()
        {
            InitializeComponent();
            userStatsLogo = new UserStatsLogo(this);
            previousMenu = userStatsLogo.userStatsMenu;
            teamStatsLogo = new TeamStatsLogo(this);
            trainingsLogo = new TrainingsLogo(this);
            leagueLogo = new LeagueLogo(this);
            topTeamsLogo = new TopTeamsLogo(this);
            topMembersLogo = new TopMembersLogo(this);
            teamMenu = new TeamMenu(this);
            newMemberMenu = new NewMemberMenu(this);
            GameMainFramePageEnumerable(userStatsLogo.userStatsMenu);
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

        //I know this method isn`t correct. I know that this is worst method you have ever seen
        //in your life and you would never show this method to your children even as a bad example.
        //I know I'm repeating myself in this method, but it works. Perhaps later I will add
        //some abstract class and make it work by foreach and enumerable collection, but not now.

        //Its not working now. XD
        public void GameMainFramePageEnumerable(Page nextPageContent)
        {
            this.previousMenu = (Page)GameMainFrame.Content;
            NextPage(nextPageContent);
        }
        public void GameMainFramePageEnumerable(Page nextPageContent, Page prewiousMenu)
        {
            this.previousMenu = prewiousMenu;
            NextPage(nextPageContent);
        }
        private void NextPage(Page nextPageContent)
        {
            CurrentlyGamePage.Text = nextPageContent.Title;

            if (userStatsLogo.Title != nextPageContent.Title) userStatsLogo.TButton.IsChecked = false;
            else userStatsLogo.TButton.IsChecked = true;
            if (trainingsLogo.Title != nextPageContent.Title) trainingsLogo.TButton.IsChecked = false;
            else trainingsLogo.TButton.IsChecked = true;
            if (teamStatsLogo.Title != nextPageContent.Title) teamStatsLogo.TButton.IsChecked = false;
            else teamStatsLogo.TButton.IsChecked = true;
            if (leagueLogo.Title != nextPageContent.Title) leagueLogo.TButton.IsChecked = false;
            else leagueLogo.TButton.IsChecked = true;
            if (topTeamsLogo.Title != nextPageContent.Title) topTeamsLogo.TButton.IsChecked = false;
            else topTeamsLogo.TButton.IsChecked = true;
            if (topMembersLogo.Title != nextPageContent.Title) topMembersLogo.TButton.IsChecked = false;
            else topMembersLogo.TButton.IsChecked = true;

            GameMainFrame.Content = nextPageContent;
        }
    }
}
