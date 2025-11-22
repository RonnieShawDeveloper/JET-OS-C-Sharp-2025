using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JET_OS.Services;

namespace JET_OS.Taskbar
{
    public partial class TaskbarControl : UserControl
    {
        public TaskbarControl()
        {
            InitializeComponent();
        }

        private void TaskbarIcon_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is ContentPresenter cp && cp.Content is WindowInfo info && info.Window != null)
            {
                if (info.Window.WindowState == WindowState.Minimized)
                    info.Window.WindowState = WindowState.Normal;
                info.Window.Activate();
            }
        }
    }
}
