using System.Windows;
using JET_OS.Services;

namespace JET_OS.Windows
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            WindowManagerService.Instance.RegisterWindow(this);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UserNameTextBox.Text;
            var password = PasswordBox.Password;
            if (AuthService.Instance.Login(username, password))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
