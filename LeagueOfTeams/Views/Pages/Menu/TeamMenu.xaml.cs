using System.Windows;
using System.Windows.Controls;
using LeagueOfTeamsUI.Views.Pages.Menu.MemberServices;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class TeamMenu : Page
    {
        GameWindow gameWindow;
        public TeamMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            Member1.Content = new TeamMemberLogo(gameWindow);
            Member2.Content = new TeamMemberLogo(gameWindow);
            Member3.Content = new TeamMemberLogo(gameWindow);
            Member4.Content = new TeamMemberLogo(gameWindow);
            Member5.Content = new TeamMemberLogo(gameWindow);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.previousMenu);
        }
    }
}
