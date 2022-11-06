using LOT.BLL.Models;
using LOT.BLL.Services;
using System.Windows;

namespace LeagueOfTeamsUI.Views
{
    public partial class AuthorizationWindow : Window
    {
        public bool IsItRegistration = false;

        public UserModel User { get; set; }

        private UserService _userService;

        public string Login => loggingBox.Text;

        public string Password => passwordBox.Password;

        public AuthorizationWindow()
        {
            InitializeComponent();
            _userService = new();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Authorization() is true)
            {
                this.DialogResult = true;
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (Registration() is true)
            {
                IsItRegistration = true;
                this.DialogResult = true;
            }
        }

        /// <summary>
        /// Check authorization form.
        /// </summary>
        /// <returns>TRUE if the form is complited. FALSE if the form is not completed.</returns>
        private bool AreAuthorizationFormIsComplited()
        {
            if (Login is null || Login == "")
                MessageBox.Show("Please, enter your loggin!");
            else if (Password is null || Password == "")
                MessageBox.Show("Please, enter your password!");
            else
                return true;
            return false;
        }

        /// <summary>
        /// User verification.
        /// </summary>
        /// <returns>TRUE, if verification successful. FALSE, if verification fail`s.</returns>
        private bool Authorization()
        {
            if (AreAuthorizationFormIsComplited() is true)
            {
                _userService.Authorization(User, Login, Password);
                if (User is null)
                {
                    MessageBox.Show("Wrong login or password.");
                }
                else
                {
                    MessageBox.Show("Authorization successful!");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Registration and authorization new user. 
        /// </summary>
        /// <returns></returns>
        private bool Registration()
        {
            if (AreAuthorizationFormIsComplited() is true)
            {
                User = _userService.RegisterNewUser(Login, Password);
                if (User is null)
                {
                    MessageBox.Show("Login is already used!");
                }
                else
                {
                    MessageBox.Show("Registration successful!");
                    return true;
                }
            }
            return false;
        }
    }
}
