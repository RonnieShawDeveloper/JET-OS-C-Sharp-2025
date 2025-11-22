using System.Windows;
using JET_OS.Services;

namespace JET_OS.Windows
{
    public partial class AccountManagementWindow : Window
    {
        public AccountManagementWindow()
        {
            InitializeComponent();
            WindowManagerService.Instance.RegisterWindow(this);
        }
    }
}
