# JET-OS

JET-OS is a modern desktop application built with WPF and targeting .NET 10. It is designed to mimic the look and feel of the Windows desktop environment, providing a familiar interface for law enforcement and agency users. The system features a main desktop window, a taskbar, and a suite of proprietary applications tailored for secure, role-based access.

## Key Features

- **Windows-like Desktop UI:** Main window displays application icons and a taskbar with open windows and time/date.
- **Role-Based Access:** Only shows application icons and features the user or organization is authorized to use.
- **Account Management:** Manage user profiles, security settings, permissions, notifications, and preferences.
- **Device Management:** Add, remove, and view managed devices.
- **Security:** Change password, enable two-factor authentication, and manage security questions.
- **Audit & Compliance:** View audit logs and acknowledge compliance requirements.
- **Accessibility:** Supports accessibility features and multiple languages.

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio 2022 or later.
3. Build and run the project.

## Requirements

- .NET 10 SDK
- Windows OS

## Project Structure

- `MainWindow`: The primary desktop interface.
- `Taskbar`: Shows open applications and system time.
- `Windows/AccountManagementWindow.xaml`: UI for managing user accounts and security.
- `Services/WindowManagerService.cs`: Handles open windows and focus management.
- `Media/`: Contains icons and images for the UI.

## License

Specify your license here.
