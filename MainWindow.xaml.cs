using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using JET_OS.Windows;
using JET_OS.Services;

namespace JET_OS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _clockTimer;
        private string _loggedInName;
        private DateTime? _loginTime;

        public MainWindow()
        {
            InitializeComponent();
            InitTaskbarClock();
        }

        private void InitTaskbarClock()
        {
            _clockTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _clockTimer.Tick += (s, e) => UpdateClock();
            _clockTimer.Start();
            UpdateClock();
        }

        private void UpdateClock()
        {
            if (TaskbarClock != null)
                TaskbarClock.Text = DateTime.Now.ToString("hh:mm tt\nMM/dd/yyyy");
            UpdateTitle();
            UpdateLoggedInInfo();
        }

        private void UpdateTitle()
        {
            if (!string.IsNullOrEmpty(_loggedInName) && _loginTime.HasValue)
            {
                Title = $"JET-OS | {_loggedInName} logged in at {_loginTime.Value:hh:mm tt MM/dd/yyyy}";
            }
            else
            {
                Title = "JET-OS";
            }
        }

        private void UpdateLoggedInInfo()
        {
            if (AuthService.Instance.IsLoggedIn && _loginTime.HasValue)
            {
                LoggedInInfoText.Text = $"Logged In: {AuthService.Instance.LoggedInName} at {_loginTime.Value:hh:mm tt} on {_loginTime.Value:MM/dd/yyyy}";
            }
            else
            {
                LoggedInInfoText.Text = string.Empty;
            }
        }

        private void AccountManagementButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AuthService.Instance.IsLoggedIn)
            {
                var loginWindow = new LoginWindow { Owner = this };
                var result = loginWindow.ShowDialog();
                if (result != true)
                    return; // User cancelled login

                _loggedInName = AuthService.Instance.LoggedInName;
                _loginTime = DateTime.Now;
                UpdateTitle();
                UpdateLoggedInInfo();
            }

            var win = new AccountManagementWindow();
            win.Owner = this;
            win.Show();
        }
    }
}