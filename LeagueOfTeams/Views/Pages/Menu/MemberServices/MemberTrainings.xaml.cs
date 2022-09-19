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
using LeagueOfTeamsBusinessLogic.Models.Members;
using LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks;

namespace LeagueOfTeamsUI.Views.Pages.Menu.MemberServices
{
    public partial class MemberTrainings : Page
    {
        GameWindow gameWindow;
        PositionLogo position1Logo = new PositionLogo();
        public MemberTrainings(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            Position1.Content = position1Logo;
        }
        private void BackToTheTeamButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.previousMenu);
        }
    }
}
