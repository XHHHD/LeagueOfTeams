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

namespace LeagueOfTeamsUI.Views.Pages.Menu.MemberServices
{
    public partial class MemberTrainings : Page
    {
        GameWindow gameWindow;
        Page previousServices;
        public MemberTrainings(GameWindow gameWindow, Page previousServices)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            this.previousServices = previousServices;
        }

        private void BackToTheTeamButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(previousServices);
        }
    }
}
