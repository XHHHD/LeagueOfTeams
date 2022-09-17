using LeagueOfTeamsUI.Views.Pages.Menu.Logos;
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

namespace LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks
{
    public partial class TeamSmollLogo930x60 : Page
    {
        GameWindow gameWindow;
        public TeamSmollLogo930x60(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
        }

        private void TeamButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.teamsServices);
        }
    }
}
