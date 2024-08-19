using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Threading;
namespace Chat_Win_App.Services
{
    public class UdpService : IDisposable
    {
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _endPoint;
        private readonly Encoding _encoding = Encoding.UTF8;
        private readonly Dispatcher _dispatcher;
        public event Action<string> MessageReceived;
        public UdpService(string serverIp, int serverPort, int localPort, Dispatcher dispatcher)
        {
            _endPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
            _udpClient = new UdpClient(localPort);
            _dispatcher = dispatcher;
        }
        public async Task SendMessageAsync(string message)
        {
            try
            {
                var messageBytes = _encoding.GetBytes(message);
                await _udpClient.SendAsync(messageBytes, messageBytes.Length, _endPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void StartListening()
        {
            Task.Run(ReceiveMessagesAsync);
        }
        private async Task ReceiveMessagesAsync()
        {
            try
            {
                while (true)
                {
                    var result = await _udpClient.ReceiveAsync();
                    var message = _encoding.GetString(result.Buffer);
                    OnMessageReceived(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving messages: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        protected virtual void OnMessageReceived(string message)
        {
            if (MessageReceived != null)
            {
                _dispatcher.Invoke(() => MessageReceived?.Invoke(message));
            }
        }
        public void Dispose()
        {
            _udpClient?.Close();
        }
    }
}