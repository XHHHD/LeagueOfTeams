using LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks;
using LOT.BLL.Models.Members;
using LOT.BLL.Services.Members;
using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.MemberServices
{
    public partial class NewMemberMenu : Page
    {
        GameWindow gameWindow;
        PositionLogo position1Logo, position2Logo;
        MemberModel member;
        public NewMemberMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            member = MemberGenerator.GenerateNewMember(gameWindow.user.Expiriance);
            InitComponent(member);
        }

        private void BackToThePreviousButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.previousMenu);
        }
        private void InitComponent(MemberModel member)
        {
            MemberName.Text = member.Name;
            Level.Text = member.Level.ToString();
            Age.Text = member.Age.ToString();
            Energy.Text = member.Energy.ToString();
            MaxEnergy.Text = member.MaxEnergy.ToString();
            FreeSkillPoints.Text = member.SkillPoints.ToString();
            Power.Text = member.Power.ToString();
            MentalPower.Text = member.MentalPower.ToString();
            MentalResistance.Text = member.MentalResistance.ToString();
            Teamplay.Text = member.Teamplay.ToString();
            if (member.Positions != null && member.Positions.Count == 1)
            {
                if(position1Logo == null)
                    position1Logo = new(member.Positions[0]);
                Position1.Content = position1Logo;
            }
            if (member.Positions != null && member.Positions.Count == 2)
            {
                if(position2Logo == null)
                    position2Logo = new(member.Positions[1]);
                Position2.Content = position2Logo;
            }
        }
    }
}
