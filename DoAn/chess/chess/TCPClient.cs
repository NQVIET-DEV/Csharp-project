using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace chess
{
    public class TCPClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        public event Action<bool> MatchFound;
        public string PieceColor;
        public string RoomID;
        public int Rating = 1200;
        public string Username = "null";
        public string Password = "null";
        public string Email = "null";
        public int UserId { get; private set; }
        public int Rank { get; private set; }

        public TCPClient(string serverIP, int serverPort)
        {
            tcpClient = new TcpClient();
            ConnectToServer(serverIP, serverPort).Wait();
        }

        private async Task ConnectToServer(string serverIP, int serverPort)
        {
            try
            {
                await tcpClient.ConnectAsync(IPAddress.Parse(serverIP), serverPort);
                stream = tcpClient.GetStream();
                // _ = ListenForOpponentMovesAsync();
                Console.WriteLine("Connected to the server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection error: {ex.Message}");
            }
        }

        public async Task<string> RegisterAsync(string username, string password, string email)
        {
            string request = $"REGISTER {username} {password} {email}";
            return await SendRequestAsync(request);
        }

        public async Task<string> Logout(string username)
        {
            string request = $"LOGOUT {username}";
            return await SendRequestAsync(request);
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            string request = $"LOGIN {username} {password}";
            return await SendRequestAsync(request);
        }

        public async Task<string> CheckMailAsync(string email)
        {
            string request = $"CHECK {email}";
            return await SendRequestAsync(request);
        }

        public async Task<string> UpdatePassword(string password,string email)
        {
            string resquest = $"UPDATEPASSWORD {password} {email}";
            return await SendRequestAsync(resquest);
        }
        public async Task<string> FindMatchAsync()
        {
            string response = await SendRequestAsync("FIND_MATCH");

            if (response.StartsWith("WAITING"))
            {
                Console.WriteLine("Waiting for a match...");
                await ListenForMatchFoundAsync(); // Lắng nghe thông báo tìm thấy trận đấu
            }

            return response;
        }

      
        public async Task<string> SendRequestAsync(string request)
        {
            try
            {
                if (!tcpClient.Connected)
                {
                    throw new InvalidOperationException("Client is not connected to the server.");
                }

                byte[] data = Encoding.UTF8.GetBytes(request + "\n");
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();

                return await ReceiveResponseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending request: {ex.Message}");
                return "ERROR";
            }
        }

        public async Task<string> ReceiveResponseAsync()
        {
            try
            {
                byte[] buffer = new byte[2048];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving response: {ex.Message}");
                return "ERROR";
            }
        }
        public async Task<string> WaitForMatchAsync()
        {
            try
            {
                // Liên tục đọc phản hồi từ server đến khi trận đấu có sẵn
                return await ReadResponseAsync();
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        private async Task<string> ReadResponseAsync()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
        }

        public async Task ListenForMatchFoundAsync()
        {
            try
            {
                while (true)
                {
                    string message = await ReceiveResponseAsync();
                    if (message.StartsWith("MATCH_FOUND"))
                    {
                        bool isWhite = message.Contains("WHITE");
                        // Mở form bàn cờ trên UI thread
                        //OpenChessBoardForm(isWhite);
                        MatchFound?.Invoke(isWhite);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving match found: {ex.Message}");
            }
        }
      
        public async Task SendMove(string from, string to)
        {
            // Chuyển nước đi thành dạng tin nhắn và gửi tới server
            // Ví dụ: "MOVE <từ> <đến>"
            string message = $"MOVE {from} {to}";
            await SendMessageToServer(message); // Gọi phương thức gửi tin nhắn tới server
        }

        private async Task SendMessageToServer(string message)
        {
            try
            {
                if (!tcpClient.Connected)
                {
                    throw new InvalidOperationException("Client is not connected to the server.");
                }

                byte[] data = Encoding.UTF8.GetBytes(message + "\n"); // Thêm ký tự xuống dòng để đánh dấu kết thúc tin nhắn
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync(); // Đảm bảo dữ liệu được gửi ngay lập tức
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message to server: {ex.Message}");
            }
        }
        public async Task SendMessageAsync(string message)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);
        }
        public void Close()
        {
            stream?.Close();
            tcpClient?.Close();
            Console.WriteLine("Disconnected from server.");
        }
    }
}