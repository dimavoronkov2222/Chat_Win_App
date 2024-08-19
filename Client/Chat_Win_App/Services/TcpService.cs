using System.Net.Sockets;
using System.Text;
using System.Windows;
namespace Chat_Win_App.Services
{
    public class TcpService : IDisposable
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private readonly string _serverIp;
        private readonly int _serverPort;
        private readonly Encoding _encoding = Encoding.UTF8;
        public event Action<string> MessageReceived;
        public TcpService(string serverIp, int serverPort)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
        }
        public async Task ConnectAsync()
        {
            try
            {
                _tcpClient = new TcpClient();
                await _tcpClient.ConnectAsync(_serverIp, _serverPort);
                _networkStream = _tcpClient.GetStream();
                Task.Run(ReceiveMessagesAsync);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
        public async Task SendMessageAsync(string message)
        {
            if (_networkStream == null)
                throw new InvalidOperationException("Not connected to the server.");

            try
            {
                var messageBytes = _encoding.GetBytes(message);
                await _networkStream.WriteAsync(messageBytes, 0, messageBytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024];
            try
            {
                while (true)
                {
                    if (_networkStream == null)
                        throw new InvalidOperationException("Not connected to the server.");
                    var bytesRead = await _networkStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        var message = _encoding.GetString(buffer, 0, bytesRead);
                        MessageReceived?.Invoke(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving messages: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispose();
            }
        }
        public void Dispose()
        {
            _networkStream?.Close();
            _tcpClient?.Close();
            _networkStream = null;
            _tcpClient = null;
        }
    }
}