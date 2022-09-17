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
    public partial class TopMembersLogo : Page
    {
        TopMembersMenu topMembersServices = new TopMembersMenu();
        GameWindow gameWindow;
        public TopMembersLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            gameWindow.TopMembersButton.Content = this;
            this.gameWindow = gameWindow;
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(topMembersServices);
        }
    }
}
