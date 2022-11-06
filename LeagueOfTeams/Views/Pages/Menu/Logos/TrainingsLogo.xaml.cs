using System.Windows;
using System.Windows.Controls;

namespace LeagueOfTeamsUI.Views.Pages.Menu.Logos
{
    public partial class TrainingsLogo : Page
    {
        GameWindow gameWindow;
        TeamTrainingsMenu trainingsMenu;
        public TrainingsLogo(GameWindow gameWindow)
        {
            InitializeComponent();
            this.gameWindow = gameWindow;
            gameWindow.TrainingsButton.Content = this;
            trainingsMenu = new(gameWindow);
        }
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            gameWindow.GameMainFramePageEnumerable(trainingsMenu);
        }
    }
}
