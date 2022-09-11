using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
using LeagueOfTeamsUI.Views;
using LeagueOfTeamsUI.Pages;

namespace LeagueOfTeamsBusinessLogic
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            AuthorizationWindow autorisationWindow = new AuthorizationWindow();

            if (autorisationWindow.ShowDialog() == true)
            {
                if (autorisationWindow.Password == "123")
                {
                    LoginFrame.Content = new LoginPage();
                    MessageBox.Show("Authorization successful!");
                }
                else MessageBox.Show("Wrong login or password!");
            }
            else
            {
                MessageBox.Show("You must be logged in!");
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            game.Show();
            WindowMain.Close();
        }
    }
}
