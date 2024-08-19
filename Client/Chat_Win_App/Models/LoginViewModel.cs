using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Chat_Win_App.Services;
namespace Chat_Win_App.Models
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly TcpService _tcpService;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {
            _tcpService = new TcpService("127.0.0.1", 5000);
            LoginCommand = new RelayCommand(Login, CanLogin);
        }
        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
        private async void Login()
        {
            try
            {
                await _tcpService.ConnectAsync();
                string message = $"{Username}:{Password}";
                await _tcpService.SendMessageAsync(message);

                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}