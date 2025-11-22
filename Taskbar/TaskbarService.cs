using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using JET_OS.Services;

namespace JET_OS.Taskbar
{
    public class TaskbarService : INotifyPropertyChanged
    {
        private static TaskbarService _instance;
        public static TaskbarService Instance => _instance ??= new TaskbarService();

        public ObservableCollection<WindowInfo> Windows { get; } = new();

        private WindowInfo _focusedWindow;
        public WindowInfo FocusedWindow
        {
            get => _focusedWindow;
            private set
            {
                if (_focusedWindow != value)
                {
                    _focusedWindow = value;
                    OnPropertyChanged(nameof(FocusedWindow));
                }
            }
        }

        private TaskbarService()
        {
            // Initial population
            UpdateWindows();
            UpdateFocus();
            // Subscribe to window events
            WindowManagerService.Instance.WindowsChanged += (s, e) => UpdateWindows();
            WindowManagerService.Instance.FocusedWindowChanged += (s, e) => UpdateFocus();
        }

        private void UpdateWindows()
        {
            Windows.Clear();
            foreach (var info in WindowManagerService.Instance.GetOpenWindowInfos())
                Windows.Add(info);
        }

        private void UpdateFocus()
        {
            var focused = WindowManagerService.Instance.FocusedWindow;
            FocusedWindow = Windows.FirstOrDefault(w => w.Window == focused);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
