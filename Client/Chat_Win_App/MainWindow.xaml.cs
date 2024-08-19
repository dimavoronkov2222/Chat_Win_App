using System.Data.SqlClient;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using Microsoft.Win32;
namespace Chat_Win_App
{
    public partial class MainWindow : Window
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private readonly string _connectionString = "Data Source=DESKTOP-18724IK;Initial Catalog=ChatApp;Integrated Security=True";
        private readonly string _serverIp = "192.168.100.49";
        private readonly int _serverPort = 5000;
        private readonly string _messagesFilePath = "chatlog.txt";
        public MainWindow()
        {
            InitializeComponent();
            LoadUserList();
            ConnectToServer();
            LoadMessages();
        }
        private void ConnectToServer()
        {
            try
            {
                _tcpClient = new TcpClient(_serverIp, _serverPort);
                _networkStream = _tcpClient.GetStream();
                Task.Run(() => ListenForMessages());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while connecting to the server: {ex.Message}");
            }
        }
        private void LoadUserList()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT Username FROM Users", connection);
                    var reader = command.ExecuteReader();
                    Dispatcher.Invoke(() => UserListBox.Items.Clear());
                    while (reader.Read())
                    {
                        Dispatcher.Invoke(() => UserListBox.Items.Add(reader["Username"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading users: {ex.Message}");
            }
        }
        private void ListenForMessages()
        {
            var buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = _networkStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Dispatcher.Invoke(() => MessageListBox.Items.Add(message));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while receiving data: {ex.Message}");
            }
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageTextBox.Text;
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            try
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                _networkStream.Write(bytes, 0, bytes.Length);
                var formattedMessage = $"Me: {message}";
                MessageListBox.Items.Add(formattedMessage);
                SaveMessage(formattedMessage);
                MessageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while sending the message: {ex.Message}");
            }
        }
        private void SendFileButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                var fileName = Path.GetFileName(filePath);
                var fileData = File.ReadAllBytes(filePath);
                var fileSize = fileData.Length;
                try
                {
                    var fileHeader = Encoding.UTF8.GetBytes($"FILE:{fileName}:{fileSize}");
                    _networkStream.Write(fileHeader, 0, fileHeader.Length);
                    _networkStream.Write(fileData, 0, fileData.Length);
                    MessageListBox.Items.Add($"Sent file: {fileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while sending the file: {ex.Message}");
                }
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            _networkStream?.Close();
            _tcpClient?.Close();
            base.OnClosed(e);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SaveMessage(string message)
        {
            try
            {
                using (var writer = new StreamWriter(_messagesFilePath, true))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the message: {ex.Message}");
            }
        }

        private void LoadMessages()
        {
            try
            {
                if (File.Exists(_messagesFilePath))
                {
                    using (var reader = new StreamReader(_messagesFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            MessageListBox.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading messages: {ex.Message}");
            }
        }
    }
}