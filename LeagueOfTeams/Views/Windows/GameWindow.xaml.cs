using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AutoMapper;
using LOT.BLL.Models;
using LOT.BLL.Models.Teams;
using LOT.BLL.Services.Teams;
using LeagueOfTeamsUI.Views.Pages.Menu;
using LeagueOfTeamsUI.Views.Pages.Menu.Logos;
using LeagueOfTeamsUI.Views.Pages.Menu.MemberServices;
using System.Collections.Generic;
using LOT.BLL.Models.Ranks;
using LOT.BLL.Models.Members;
using System.Reflection;

namespace LeagueOfTeamsUI.Views
{
    public partial class GameWindow : Window
    {

        public UserModel user;
        public UserStatsLogo userStatsLogo;
        public TrainingsLogo trainingsLogo;
        public TeamStatsLogo teamStatsLogo;
        public LeagueLogo leagueLogo;
        public TopTeamsLogo topTeamsLogo;
        public TopMembersLogo topMembersLogo;
        public TeamMenu teamMenu;
        public NewMemberMenu newMemberMenu;

        public Page previousMenu;
        public GameWindow(WindowState windowState, object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            user = GetTestUserModeel();
            userStatsLogo = new UserStatsLogo(this);
            teamStatsLogo = new TeamStatsLogo(this);
            trainingsLogo = new TrainingsLogo(this);
            leagueLogo = new LeagueLogo(this);
            topTeamsLogo = new TopTeamsLogo(this);
            topMembersLogo = new TopMembersLogo(this);
            teamMenu = new TeamMenu(this);
            newMemberMenu = new NewMemberMenu(this);
            previousMenu = userStatsLogo.userStatsMenu;
            GameMainFramePageEnumerable(userStatsLogo.userStatsMenu);
            if (windowState == WindowState.Maximized)
            {
                CheckedFullScreenButton_Click(sender, e);
                FullScreenButton.IsChecked = true;
            }
        }
        private void GameMainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CheckedFullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            GameMainWindow.WindowState = WindowState.Maximized;
        }
        private void UncheckedFullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            GameMainWindow.WindowState = WindowState.Normal;
        }
        private void MinimizedButton_Click(object sender, RoutedEventArgs e)
        {
            GameMainWindow.WindowState = WindowState.Minimized;
        }

        //I know this method isn`t correct. I know that this is worst method you have ever seen
        //in your life and you would never show this method to your children even as a bad example.
        //I know I'm repeating myself in this method, but it works. Perhaps later I will add
        //some abstract class and make it work by foreach and enumerable collection, but not now.

        //Its not working now. XD
        public void GameMainFramePageEnumerable(Page nextPageContent)
        {
            this.previousMenu = (Page)GameMainFrame.Content;
            NextPage(nextPageContent);
        }
        public void GameMainFramePageEnumerable(Page nextPageContent, Page prewiousMenu)
        {
            this.previousMenu = prewiousMenu;
            NextPage(nextPageContent);
        }
        private void NextPage(Page nextPageContent)
        {
            CurrentlyGamePage.Text = nextPageContent.Title;

            if (userStatsLogo.Title != nextPageContent.Title) userStatsLogo.TButton.IsChecked = false;
            else userStatsLogo.TButton.IsChecked = true;
            if (trainingsLogo.Title != nextPageContent.Title) trainingsLogo.TButton.IsChecked = false;
            else trainingsLogo.TButton.IsChecked = true;
            if (teamStatsLogo.Title != nextPageContent.Title) teamStatsLogo.TButton.IsChecked = false;
            else teamStatsLogo.TButton.IsChecked = true;
            if (leagueLogo.Title != nextPageContent.Title) leagueLogo.TButton.IsChecked = false;
            else leagueLogo.TButton.IsChecked = true;
            if (topTeamsLogo.Title != nextPageContent.Title) topTeamsLogo.TButton.IsChecked = false;
            else topTeamsLogo.TButton.IsChecked = true;
            if (topMembersLogo.Title != nextPageContent.Title) topMembersLogo.TButton.IsChecked = false;
            else topMembersLogo.TButton.IsChecked = true;

            GameMainFrame.Content = nextPageContent;
        }

        private static UserModel GetTestUserModeel()
        {
            var user = new UserModel()
            {
                Id = 1,
                Level = 1,
                Name = "Test Player"
            };
            var team = new TeamModel()
            {
                Id = 1,
                Name = "Test Team",
                ShortName = "TES",
                Description = "This is test team",
                Expiriance = 0,
                Energy = 0,
                MaxEnergy = 100,
                Power = 0,
                Health = 0,
                Teamplay = 0,
                RankPoints = 0,
                UserId = 1,
                User = user,
                Members = new()
            };
            var teamRank = new TeamRankModel()
            {
                Id = 1,
                Name = "Test rank",
                Teams = new List<TeamModel>() { team }
            };
            var member = new MemberModel()
            {
                Id = 1,
                Name = "Test Player",
                Age = 20,
                Power = 10,
                Energy = 10,
                MaxEnergy = 100,
                MentalPower = 10,
                MentalResistance = 10,
                Teamplay = 10,
                Expiriance = 100,
                SkillPoints = 0,
                RankPoints = 0,
                Positions = new()
            };
            var memberRank = new MemberRankModel()
            {
                Id = 1,
                Name = "Test member rank",
                Members = new List<MemberModel>() { member }
            };
            var position = new PositionModel()
            {
                Id = 1,
                Name = "Top",
                Expiriance = 0,
                Rank = 0,
                Power = 10,
                Happines = 10,
                Defence = 10,
                Health = 10,
                Member = member
            };
            member.Positions.Add(position);
            member.MemberRankId = memberRank.Id;
            team.TeamRank = teamRank;
            team.Members.Add(member);
            user.Team = team;
            return user;
        }
    }
}
