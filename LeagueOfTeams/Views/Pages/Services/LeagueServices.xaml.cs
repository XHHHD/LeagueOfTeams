using LeagueOfTeamsUI.Views.Pages.Services.SmollServicesLinks;
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

namespace LeagueOfTeamsUI.Views.Pages.Services.Logos
{
    public partial class LeagueServices : Page
    {
        public LeagueServices()
        {
            InitializeComponent();
            Team1.Content = new TeamSmollLogo930x60();
            Team2.Content = new TeamSmollLogo930x60();
            Team3.Content = new TeamSmollLogo930x60();
            Team4.Content = new TeamSmollLogo930x60();
            Team5.Content = new TeamSmollLogo930x60();
            Team6.Content = new TeamSmollLogo930x60();
            Team7.Content = new TeamSmollLogo930x60();
            Team8.Content = new TeamSmollLogo930x60();
            Team9.Content = new TeamSmollLogo930x60();
            Team10.Content = new TeamSmollLogo930x60();
        }
    }
}
