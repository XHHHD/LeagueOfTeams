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
using LeagueOfTeamsUI.Views.Pages.Menu.MemberServices;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class TeamsMenu : Page
    {
        GameWindow gameWindow;
        Page previousServices;
        public TeamsMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            Member1.Content = new TeamMemberLogo(gameWindow, this);
            Member2.Content = new TeamMemberLogo(gameWindow, this);
            Member3.Content = new TeamMemberLogo(gameWindow, this);
            Member4.Content = new TeamMemberLogo(gameWindow, this);
            Member5.Content = new TeamMemberLogo(gameWindow, this);
        }
        public TeamsMenu(GameWindow gameWindow, Page previousServices) : this(gameWindow)
        {
            this.previousServices = previousServices;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(previousServices);
        }
    }
}
