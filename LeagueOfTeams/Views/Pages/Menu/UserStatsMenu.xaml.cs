using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class UserStatsMenu : Page
    {
        public UserStatsMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            UserName.Text = gameWindow.user.Name;
        }
    }
}
