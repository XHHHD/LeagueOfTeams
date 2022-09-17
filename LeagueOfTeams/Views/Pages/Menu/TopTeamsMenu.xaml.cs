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
