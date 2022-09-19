﻿using LeagueOfTeamsUI.Views.Pages.Menu.MemberServices;
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

namespace LeagueOfTeamsUI.Views.Pages.Menu
{
    public partial class UserTeamMenu : Page
    {
        GameWindow gameWindow;
        public UserTeamMenu(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            Member1.Content = new TeamMemberLogo(gameWindow);
            Member2.Content = new TeamMemberLogo(gameWindow);
            Member3.Content = new TeamMemberLogo(gameWindow);
            Member4.Content = new TeamMemberLogo(gameWindow);
            Member5.Content = new TeamMemberLogo(gameWindow);
        }
        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(gameWindow.newMemberMenu, this);
        }
    }
}
