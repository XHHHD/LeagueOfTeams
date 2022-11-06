using LOT.BLL.Models.Teams;
using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks
{
    public partial class TeamSmollLogo930x60 : Page
    {
        GameWindow gameWindow;
        Page previousMenu;
        public TeamSmollLogo930x60(GameWindow gameWindow, Page previousMenu)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            this.previousMenu = previousMenu;
            if(gameWindow.user.Team != null)
                InitComponents(gameWindow.user.Team);
        }

        private void TeamButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.teamMenu, previousMenu);
        }
        private void InitComponents(TeamModel team)
        {
            TeamName.Text = team.Name;
        }
    }
}
