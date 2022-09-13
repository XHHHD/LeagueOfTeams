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

namespace LeagueOfTeamsUI.Views.Pages.Services.Logos
{
    public partial class TopTeamsLogo : Page
    {
        TopTeamsServices topTeamsServices = new TopTeamsServices();
        GameWindow gameWindow;
        public TopTeamsLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            gameWindow.TopTeamsButton.Content = this;
            this.gameWindow = gameWindow;
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(topTeamsServices);
        }
    }
}
