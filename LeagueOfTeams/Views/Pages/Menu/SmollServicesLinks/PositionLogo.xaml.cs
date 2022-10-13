using LOT.BLL.Models.Positions;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.SmollServicesLinks
{
    public partial class PositionLogo : Page
    {
        public PositionLogo(PositionModel position)
        {
            InitializeComponent();
            InitComponents(position);
        }
        private void InitComponents(PositionModel position)
        {
            Level.Text = position.Level.ToString();
            Expiriance.Text = (1000 - position.Expiriance).ToString();
            Rank.Text = position.Rank.ToString();
            Power.Text = position.Power.ToString();
            Happines.Text = position.Happines.ToString();
            Defence.Text = position.Defence.ToString();
            Health.Text = position.Health.ToString();
        }
    }
}
