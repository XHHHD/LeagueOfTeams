using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.MemberServices
{
    public partial class TeamMemberLogo : Page
    {
        GameWindow gameWindow;
        MemberTrainings memberTrainings;
        EnemyTeamMember enemyTeamMember;
        bool isThisUserTeam;
        public TeamMemberLogo(GameWindow gameWindow, bool isThisUserTeam)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            if (gameWindow.user.Team != null)
                if (gameWindow.user.Team.Members != null && gameWindow.user.Team.Members.Count >= 1)
                    memberTrainings = new MemberTrainings(gameWindow, gameWindow.user.Team.Members[0]);
            if (gameWindow.user.Team != null)
                if (gameWindow.user.Team.Members != null && gameWindow.user.Team.Members.Count >= 1)
                    enemyTeamMember = new EnemyTeamMember(gameWindow, gameWindow.user.Team.Members[0]);
            this.isThisUserTeam = isThisUserTeam;
        }

        private void MemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (isThisUserTeam)
            {
                if (memberTrainings != null)
                    gameWindow.GameMainFramePageEnumerable(memberTrainings);
            }
            else
            {
                if (enemyTeamMember != null)
                    gameWindow.GameMainFramePageEnumerable(enemyTeamMember);
            }
        }
    }
}
