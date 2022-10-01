using System.Windows;
using System.Windows.Controls;
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
