using Chat_Win_App.Services;
using System.Collections.ObjectModel;
namespace Chat_Win_App.Controllers
{
    public class ChatController : IDisposable
    {
        public ObservableCollection<ChatMessage> Messages { get; private set; }
        private readonly UdpService _udpService;
        private readonly TcpService _tcpService;
        public event Action<string> MessageReceived;
        public ChatController(UdpService udpService, TcpService tcpService)
        {
            Messages = new ObservableCollection<ChatMessage>();
            _udpService = udpService ?? throw new ArgumentNullException(nameof(udpService));
            _tcpService = tcpService ?? throw new ArgumentNullException(nameof(tcpService));
            _udpService.MessageReceived += OnMessageReceived;
            _tcpService.MessageReceived += OnMessageReceived;
        }
        public async Task SendMessageUdpAsync(string userName, string messageContent)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("User name and message content cannot be empty.");

            var message = new ChatMessage
            {
                UserName = userName,
                Content = messageContent,
                Timestamp = DateTime.Now
            };
            Messages.Add(message);
            await _udpService.SendMessageAsync($"{userName}: {messageContent}");
        }
        public async Task SendMessageTcpAsync(string userName, string messageContent)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(messageContent))
                throw new ArgumentException("User name and message content cannot be empty.");

            var message = new ChatMessage
            {
                UserName = userName,
                Content = messageContent,
                Timestamp = DateTime.Now
            };
            Messages.Add(message);
            await _tcpService.SendMessageAsync($"{userName}: {messageContent}");
        }
        private void OnMessageReceived(string message)
        {
            var chatMessage = new ChatMessage
            {
                UserName = "Unknown",
                Content = message,
                Timestamp = DateTime.Now
            };
            Messages.Add(chatMessage);
            MessageReceived?.Invoke(message);
        }
        public void ClearMessages()
        {
            Messages.Clear();
        }
        public void Dispose()
        {
            _udpService.MessageReceived -= OnMessageReceived;
            _tcpService.MessageReceived -= OnMessageReceived;
            _udpService?.Dispose();
            _tcpService?.Dispose();
        }
    }
}