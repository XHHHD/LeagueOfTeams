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
using LeagueOfTeamsUI.Views.Pages.Services.MemberServices;

namespace LeagueOfTeamsUI.Views.Pages.Services
{
    public partial class TeamsServices : Page
    {
        public TeamsServices()
        {
            InitializeComponent();
            Member1.Content = new TeamMemberLogo();
            Member2.Content = new TeamMemberLogo();
            Member3.Content = new TeamMemberLogo();
            Member4.Content = new TeamMemberLogo();
            Member5.Content = new TeamMemberLogo();
        }
    }
}
