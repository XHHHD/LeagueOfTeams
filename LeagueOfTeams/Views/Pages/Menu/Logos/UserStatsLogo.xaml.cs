using LeagueOfTeamsBusinessLogic;
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
    public partial class UserStatsLogo : Page
    {
        GameWindow gameWindow;
        public UserStatsMenu userStatsMenu = new();
        public UserStatsLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            gameWindow.UserStatsButton.Content = this;
            this.gameWindow = gameWindow;
        }

        public void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(userStatsMenu);
        }
    }
}
