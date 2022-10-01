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
            gameWindow.TeamStatsButton.Content = this;
            this.gameWindow = gameWindow;
            userTeamMenu = new UserTeamMenu(gameWindow);
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(userTeamMenu);
        }
    }
}
