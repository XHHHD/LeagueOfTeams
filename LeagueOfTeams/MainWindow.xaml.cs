using System.Windows;
using System.Windows.Input;
using LeagueOfTeamsUI.Views;
using LeagueOfTeamsUI.Pages;

namespace LOT.BLL
{
    public partial class MainWindow : Window
    {
        AuthorizationWindow autorisationWindow;
        public MainWindow()
        {
            InitializeComponent();
            autorisationWindow = new();
        }
        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CheckedFullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowMain.WindowState = WindowState.Maximized;
        }
        private void UncheckedFullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            WindowMain.WindowState = WindowState.Normal;
        }
        private void MinimizedButton_Click(object sender, RoutedEventArgs e)
        {
            WindowMain.WindowState = WindowState.Minimized;
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (autorisationWindow.ShowDialog() == true)
            {
                if (autorisationWindow.User != null)
                {
                    LoginFrame.Content = new LoginLogo(autorisationWindow.User);
                }
            }
            else
            {
                MessageBox.Show("You must be logged in!");
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow(WindowState, sender, e);
            game.Show();
            WindowMain.Close();
        }
    }
}
