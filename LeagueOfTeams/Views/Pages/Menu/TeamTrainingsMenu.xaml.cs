using LOT.BLL.Models;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class TeamTrainingsMenu : Page
    {
        GameWindow gameWindow;
        public TeamTrainingsMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            InitComponents(gameWindow.user);
        }
        private void InitComponents(UserModel user)
        {
            if (user.Team != null)
            {
                TeamName.Text = user.Team.Name;
                TeamShortName.Text = user.Team.ShortName;
                TeamLevel.Text = user.Team.Level.ToString();
                TeamEnergy.Text = user.Team.Energy.ToString();
                TeamMaxEnergy.Text = user.Team.MaxEnergy.ToString();

                Expiriance.Text = user.Team.Expiriance.ToString();
                Health.Text = user.Team.Health.ToString();
                Power.Text = user.Team.Power.ToString();
                Teamplay.Text = user.Team.Teamplay.ToString();
                RankPoints.Text = user.Team.RankPoints.ToString();
                if (user.Team.TeamRank != null)
                {
                    Rank.Content = user.Team.TeamRank.Name.ToString();
                }
                if (user.Team.TeamTrail != null)
                {
                    Trail.Text = user.Team.TeamTrail.Name;
                    Trail.ToolTip = user.Team.TeamTrail.Description;
                }
                if (user.Team.Members == null || user.Team.Members.Count == 0)
                {
                    MembersList.Visibility = System.Windows.Visibility.Hidden;
                    NoMembersInTeam.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    NoMembersInTeam.Visibility = System.Windows.Visibility.Hidden;
                    MembersList.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
    }
}
