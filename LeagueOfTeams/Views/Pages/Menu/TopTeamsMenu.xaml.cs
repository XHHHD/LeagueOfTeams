using LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class TopTeamsMenu : Page
    {
        GameWindow gameWindow;
        public TopTeamsMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            FirstPlace.Content = new FirstTopTeamLogo(gameWindow, this);
            SecondPlace.Content = new SecondTopTeamLogo(gameWindow, this);
            ThirdPlace.Content = new ThirdTopTeamLogo(gameWindow, this);
            fourthPlace.Content = new TeamSmollLogo930x60(gameWindow, this);
            fifthPlace.Content = new TeamSmollLogo930x60(gameWindow, this);
            sixthPlace.Content = new TeamSmollLogo930x60(gameWindow, this);
            seventhPlace.Content = new TeamSmollLogo930x60(gameWindow, this);
            eighthPlace.Content = new TeamSmollLogo930x60(gameWindow, this);
        }
    }
}
