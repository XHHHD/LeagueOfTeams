using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class UserStatsMenu : Page
    {
        GameWindow gameWindow;
        public UserStatsMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            UserName.Text = gameWindow.user.Name;
        }
    }
}
