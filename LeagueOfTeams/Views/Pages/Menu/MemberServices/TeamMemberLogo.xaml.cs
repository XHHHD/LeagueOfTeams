using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.MemberServices
{
    public partial class TeamMemberLogo : Page
    {
        GameWindow gameWindow;
        MemberTrainings memberTrainings;
        EnemyTeamMember enemyTeamMember;
        public TeamMemberLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            if(gameWindow.user.Team != null)
                if(gameWindow.user.Team.Members != null && gameWindow.user.Team.Members.Count >= 1)
                    memberTrainings = new MemberTrainings(gameWindow, gameWindow.user.Team.Members[0]);
            if (gameWindow.user.Team != null)
                if (gameWindow.user.Team.Members != null && gameWindow.user.Team.Members.Count >= 1)
                    enemyTeamMember = new EnemyTeamMember(gameWindow, gameWindow.user.Team.Members[0]);
        }

        private void MemberButton_Click(object sender, RoutedEventArgs e)
        {
            //Need equals something else
            if(gameWindow.GameMainFrame.Content == gameWindow.userStatsLogo.userStatsMenu)
                if(memberTrainings != null)
                    gameWindow.GameMainFramePageEnumerable(memberTrainings);
            else
                if(enemyTeamMember != null)
                    gameWindow.GameMainFramePageEnumerable(enemyTeamMember);
        }
    }
}
