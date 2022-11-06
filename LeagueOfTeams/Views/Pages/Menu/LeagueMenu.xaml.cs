using LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.Logos
{
    public partial class LeagueMenu : Page
    {
        GameWindow gameWindow;
        public LeagueMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            Team1.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team2.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team3.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team4.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team5.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team6.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team7.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team8.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team9.Content = new TeamSmollLogo930x60(gameWindow, this);
            Team10.Content = new TeamSmollLogo930x60(gameWindow, this);
        }
    }
}
