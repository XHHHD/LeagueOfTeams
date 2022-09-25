using LeagueOfTeamsUI.Views.Pages.Menu.MemberServices;
using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class UserTeamMenu : Page
    {
        GameWindow gameWindow;
        public UserTeamMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            Member1.Content = new TeamMemberLogo(gameWindow);
            Member2.Content = new TeamMemberLogo(gameWindow);
            Member3.Content = new TeamMemberLogo(gameWindow);
            Member4.Content = new TeamMemberLogo(gameWindow);
            Member5.Content = new TeamMemberLogo(gameWindow);
        }
        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.newMemberMenu, this);
        }
    }
}
