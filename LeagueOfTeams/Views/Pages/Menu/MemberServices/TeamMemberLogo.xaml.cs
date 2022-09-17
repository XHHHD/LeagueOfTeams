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
    public partial class TeamMemberLogo : Page
    {
        GameWindow gameWindow;
        MemberTrainings memberTrainings;
        public TeamMemberLogo(GameWindow gameWindow, Page previousServices)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            memberTrainings = new MemberTrainings(gameWindow, previousServices);
        }

        private void MemberButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(memberTrainings);
        }
    }
}
