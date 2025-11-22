using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace JET_OS.Services
{
    public class WindowInfo
    {
        public Window Window { get; set; }
        public ImageSource Icon { get; set; }
        public string Title { get; set; }
    }

    public class WindowManagerService
    {
        private static WindowManagerService _instance;
        public static WindowManagerService Instance => _instance ??= new WindowManagerService();

        private readonly List<Window> _openWindows = new();
        public IReadOnlyList<Window> OpenWindows => _openWindows.AsReadOnly();
        public Window FocusedWindow { get; private set; }

        public event EventHandler WindowsChanged;
        public event EventHandler FocusedWindowChanged;

        private WindowManagerService() { }

        public void RegisterWindow(Window window)
        {
            if (!_openWindows.Contains(window))
            {
                _openWindows.Add(window);
                window.Activated += (s, e) => {
                    FocusedWindow = window;
                    FocusedWindowChanged?.Invoke(this, EventArgs.Empty);
                };
                window.Closed += (s, e) => {
                    _openWindows.Remove(window);
                    WindowsChanged?.Invoke(this, EventArgs.Empty);
                };
                WindowsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SetFocus(Window window)
        {
            if (_openWindows.Contains(window))
            {
                FocusedWindow = window;
                FocusedWindowChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        // New: Get info for all open windows (for taskbar binding)
        public IEnumerable<WindowInfo> GetOpenWindowInfos()
        {
            return _openWindows.Select(w => new WindowInfo
            {
                Window = w,
                Icon = w.Icon,
                Title = w.Title
            });
        }
    }
}
