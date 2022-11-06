using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.Logos
{
    public partial class TeamStatsLogo : Page
    {
        GameWindow gameWindow;
        public UserTeamMenu userTeamMenu;
        public TeamStatsLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            gameWindow.TeamStatsButton.Content = this;
            userTeamMenu = new UserTeamMenu(gameWindow);
            if(gameWindow.user.Team != null)
                TeamName.Text = gameWindow.user.Team.Name;
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(userTeamMenu);
        }
    }
}
