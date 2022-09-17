using LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks;
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

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class TopTeamsMenu : Page
    {
        GameWindow gameWindow;
        public TopTeamsMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            FirstPlace.Content = new FirstTopTeamLogo(gameWindow);
            SecondPlace.Content = new SecondTopTeamLogo(gameWindow);
            ThirdPlace.Content = new ThirdTopTeamLogo(gameWindow);
            fourthPlace.Content = new TeamSmollLogo930x60(gameWindow);
            fifthPlace.Content = new TeamSmollLogo930x60(gameWindow);
            sixthPlace.Content = new TeamSmollLogo930x60(gameWindow);
            seventhPlace.Content = new TeamSmollLogo930x60(gameWindow);
            eighthPlace.Content = new TeamSmollLogo930x60(gameWindow);
        }
    }
}
