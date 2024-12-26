using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;

namespace excercise_2
{
    public partial class login : Form
    {
        private Socket Client;
        private string LocalIP;
    public class UserInfo
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
        public static string Passdecode(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string GetLocalIPAddress()
        {
            try
            {
                foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                throw new Exception("Không tìm thấy địa chỉ IPv4 nào!");
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public login()
        {
            InitializeComponent();
            LocalIP = GetLocalIPAddress();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            signup log = new signup();
            log.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = Passdecode(textBox2.Text);
            string ServerIp = LocalIP;
            int port = 11000;

            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);
            await Task.Run(() => Client.Connect(endPoint));

            var Loginpacket = new Packet("LoginRequest", "", username, "", password, "");
            string packetString = Loginpacket.ToPacketString();


            byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);
            await Task.Run(() => Client.Send(messageBytes));

            await ReceiveData();

        }
        private async Task ReceiveData()
        {
            try
            {
                while (Client.Connected)
                {
                    byte[] buffer = new byte[512];
                    int bytesRead = await Task.Run(() => Client.Receive(buffer));
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Packet receivedPacket = Packet.FromPacketString(response);

                    if (receivedPacket.Request == "LoginResponse" && receivedPacket.Message == "LoginSuccessful")
                    {
                        Invoke(new Action(() =>
                        {
                            FindBook find = new FindBook(receivedPacket.Username,receivedPacket.Email);
                            find.Show();
                            this.Hide();
                        }));
                    }
                    else if (receivedPacket.Message == "LoginFailed")
                    {
                        MessageBox.Show("Thông tin đăng nhập không đúng, vui lòng nhập lại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recovery log = new Recovery();
            log.Show();
        }
    }
}


