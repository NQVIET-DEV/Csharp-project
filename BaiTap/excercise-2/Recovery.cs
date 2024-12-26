using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excercise_2
{
    public partial class Recovery : Form
    {
        private bool Result;
        private string LocalIP;
        private string Passcode = GenerateRandomString(5);
        private Socket Client;
        public Recovery()
        {
            InitializeComponent();
            LocalIP = GetLocalIPAddress();
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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

        public static bool checkmail(string email)
        {
            string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, Pattern);
        }
        private async Task<bool> IsMailExists(string email)
        {
            string ServerIp = LocalIP;
            int port = 11000;
            Result = false;

            try
            {
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIp), port);

                await Task.Run(() => Client.Connect(endPoint));

                var Signuppacket = new Packet("CheckRequest", "", "", "", "", email);
                string packetString = Signuppacket.ToPacketString();
                byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);

                await Task.Run(() => Client.Send(messageBytes));

                Result = await ReceiveData();
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Lỗi kết nối: " + ex.Message)));
                return false;
            }
            return Result;
        }

        private async Task<bool> ReceiveData()
        {
            try
            {

                byte[] buffer = new byte[512];
                int bytesRead = await Task.Run(() => Client.Receive(buffer));
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Packet receivedPacket = Packet.FromPacketString(response);

                if (receivedPacket.Request == "CheckResponse" && receivedPacket.Message == "Found")
                {
                    Result = true;

                }
                else if (receivedPacket.Message == "Not Found")
                {
                    Result = false;

                }

            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Lỗi kết nối: " + ex.Message)));
            }
            return Result;
        }

        private async void Send_btn_Click(object sender, EventArgs e)
        {
            if (!checkmail(Email_txt.Text))
            {
                MessageBox.Show("Email không đúng định dạng vui lòng nhập lại");
            }
            else if (!await IsMailExists(Email_txt.Text))
            {
                MessageBox.Show("Email chưa đăng ký tài khoản vui lòng đăng ký");
            }
            {
                try
                {
                    SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("23521383@gm.uit.edu.vn", "jeof nwcs exlb ssdt"),
                        EnableSsl = true
                    };
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("23521383@gm.uit.edu.vn"),
                        Subject = "Mã Khôi Phục Mật Khẩu",
                        Body = "Mã Khôi Phục cho tài khoản của bạn là " + Passcode,
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(Email_txt.Text);
                    smtpclient.Send(mailMessage);
                    Noti_Lb.Text = "Mã xác nhận đã được gửi tới Email của bạn";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gửi email thất bại: " + ex.Message);
                }
            }
        }

        private  void Comfirm_btn_Click(object sender, EventArgs e)
        {
            if (Comfirm_txt.Text == Passcode)
            {
                ResetPassword reset = new ResetPassword(Client,Email_txt.Text);
                reset.Show();
                this.Hide();
            }
            else if (string.IsNullOrEmpty(Comfirm_txt.Text))
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận  ");
            }
            else
            {
                MessageBox.Show("Mã xác nhận không đúng ");
            }
        }
    }
}
