using LOT.BLL;
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
        public UserStatsMenu userStatsMenu;
        public UserStatsLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            userStatsMenu = new(gameWindow);
            UserName.Text = gameWindow.user.Name;
            gameWindow.UserStatsButton.Content = this;
        }

        public void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(userStatsMenu);
        }
    }
}
