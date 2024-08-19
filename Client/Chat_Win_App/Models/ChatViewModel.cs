using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Chat_Win_App.Services;
namespace Chat_Win_App.Models
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly UdpService _udpService;
        private string _messageToSend;
        private string _receivedMessage;
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();
        public string MessageToSend
        {
            get => _messageToSend;
            set
            {
                _messageToSend = value;
                OnPropertyChanged(nameof(MessageToSend));
            }
        }
        public string ReceivedMessage
        {
            get => _receivedMessage;
            set
            {
                _receivedMessage = value;
                OnPropertyChanged(nameof(ReceivedMessage));
            }
        }
        public ICommand SendMessageCommand { get; }
        public ViewModels.UserViewModel SelectedUser { get; internal set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ChatViewModel()
        {
            _udpService = new UdpService("127.0.0.1", 9000, 9001, Application.Current.Dispatcher);
            _udpService.MessageReceived += OnMessageReceived;
            SendMessageCommand = new RelayCommand(SendMessage, CanSendMessage);
            _udpService.StartListening();
        }
        private void OnMessageReceived(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add($"Received: {message}");
            });
        }
        private bool CanSendMessage()
        {
            return !string.IsNullOrEmpty(MessageToSend);
        }
        private async void SendMessage()
        {
            try
            {
                await _udpService.SendMessageAsync(MessageToSend);
                Messages.Add($"Sent: {MessageToSend}");
                MessageToSend = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}