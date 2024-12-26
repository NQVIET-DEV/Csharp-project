using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    public class GameRoom
    {
        private TcpClient player1;
        private TcpClient player2;
        private string P1_color;
        private string P2_color;
        private string Time;
        private int currentPlayerIndex = 0;

        public GameRoom(TcpClient player1, TcpClient player2 = null)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void AddPlayer(TcpClient client)
        {
            if (player1 == null)
            {
                player1 = client;
            }
            else if (player2 == null)
            {
                player2 = client;
            }
        }
        public string GetTime()
        { 
            return Time; 
        }
        public void SetTime(string time)
        {
            Time = time;
        }
        public void SetP1Color(string color)
        {
            P1_color = color;   
        }
        public void SetP2Color(string color)
        {
            P2_color = color;
        }
        public string P1Color()
        {
            return P1_color;
        }
        public string P2Color()
        {
            return P2_color;
        }

        public bool IsFull()
        {
            return player1 != null && player2 != null;
        }

        public TcpClient GetLastPlayer()
        {
            return player1 ?? player2;
        }

        public bool HasPlayer(TcpClient client)
        {
            return player1 == client || player2 == client;
        }

        public bool IsCurrentPlayer(TcpClient client)
        {
            return (currentPlayerIndex == 0 && player1 == client) || (currentPlayerIndex == 1 && player2 == client);
        }
        public void SetIndexByColor()
        {
            // Nếu màu của P1 là trắng thì index là 0, nếu đen thì index là 1
            currentPlayerIndex = (P1_color == "WHITE") ? 0 : 1;
        }

        public void SendMove(string from, string to, TcpClient client)
        {
            TcpClient opponent = (client == player1) ? player2 : player1;
            // Gửi nước đi cho cả hai người chơi
            SendMessage(opponent, $"MOVE {from} {to}");
            // SendMessage(client, $"MOVE {from} {to}");
            Console.WriteLine($"Player {(currentPlayerIndex + 1)} moved from {from} to {to}");
            UpdateCurrentPlayer();
        }

        private void UpdateCurrentPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % 2; // Chuyển lượt giữa hai người chơi
        }

        private async void SendMessage(TcpClient client, string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                NetworkStream stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }
        public void SendChatMessage(string message, TcpClient client)
        {
            TcpClient opponent = (client == player1) ? player2 : player1;
            SendMessage(opponent, $"CHAT {message}");
            SendMessage(client, $"CHAT {message}");
            Console.WriteLine($"Chat message from player {(currentPlayerIndex + 1)}: {message}");
        }

        public void RemovePlayer(TcpClient client)
        {
            if (player1 == client)
                player1 = null;
            else if (player2 == client)
                player2 = null;

            // Kiểm tra xem có còn người chơi nào trong phòng không
            if (player1 == null && player2 == null)
            {
                // Xóa phòng khi không còn người chơi
                Console.WriteLine("Game room is empty and will be removed.");
            }
        }

        public void SendMessageToAll(string message)
        {
            if (player1 != null)
            {
                SendMessage(player1, message);
            }

            if (player2 != null)
            {
                SendMessage(player2, message);
            }

            Console.WriteLine($"Broadcast message: {message}");
        }
    }
}
