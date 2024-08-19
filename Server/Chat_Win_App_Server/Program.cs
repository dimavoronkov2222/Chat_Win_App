using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace Chat_Win_App_Servers
{
    class Program
    {
        private static TcpListener _tcpListener;
        private static readonly int Port = 5000;
        private static readonly List<TcpClient> ConnectedClients = new List<TcpClient>();
        static void Main(string[] args)
        {
            StartServer();
            Console.WriteLine("Server is running...");
            Console.ReadLine();
        }
        private static void StartServer()
        {
            _tcpListener = new TcpListener(IPAddress.Any, Port);
            _tcpListener.Start();
            Console.WriteLine($"TCP Server started on port {Port}");

            Task.Run(() => AcceptClientsAsync());
        }
        private static async Task AcceptClientsAsync()
        {
            while (true)
            {
                var client = await _tcpListener.AcceptTcpClientAsync();
                ConnectedClients.Add(client);
                Task.Run(() => HandleClientAsync(client));
            }
        }
        private static async Task HandleClientAsync(TcpClient client)
        {
            var networkStream = client.GetStream();
            var buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        foreach (var connectedClient in ConnectedClients)
                        {
                            if (connectedClient != client)
                            {
                                var stream = connectedClient.GetStream();
                                await stream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                ConnectedClients.Remove(client);
                client.Close();
            }
        }
    }
}