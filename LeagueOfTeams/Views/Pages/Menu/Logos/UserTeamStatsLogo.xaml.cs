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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeagueOfTeamsUI.Views.Pages.Menu.Logos
{
    public partial class TeamStatsLogo : Page
    {
        public UserTeamMenu userTeamService;
        GameWindow gameWindow;
        public TeamStatsLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            gameWindow.TeamStatsButton.Content = this;
            this.gameWindow = gameWindow;
            userTeamService = new UserTeamMenu(gameWindow);
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(userTeamService);
        }
    }
}
