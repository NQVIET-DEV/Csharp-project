using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excercise_2
{
    public partial class ResetPassword : Form
    {
        private Socket Client;
        private string Email;
        public ResetPassword(Socket client,string email)
        {
            InitializeComponent();
            Email = email;
            Client = client;
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

        private async void Comfirm_btn_Click(object sender, EventArgs e)
        {
            string password = Passdecode(Password_txt.Text);
            string comfirm = Passdecode(Comfirm_txt.Text);
            if (password != comfirm)
            {
                MessageBox.Show("Xác nhận không khớp vui lòng nhập lại!");
                return;
            }

            try
            {
                using (Client)
                {
                    var Signuppacket = new Packet("ChangePasswordRequest", "", "", "", password, Email);
                    string packetString = Signuppacket.ToPacketString();
                    byte[] messageBytes = Encoding.UTF8.GetBytes(packetString);


                    await Task.Run(() => Client.Send(messageBytes));

                    byte[] buffer = new byte[512];


                    int bytesRead = await Task.Run(() => Client.Receive(buffer));
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Packet receivedPacket = Packet.FromPacketString(response);
                    if (receivedPacket.Request == "ChangePasswordResponse")
                    {
                        if (receivedPacket.Message == "ChangeSuccessful")
                        {
                            MessageBox.Show("Thay đổi thành công");
                            Client.Close();
                            this.Close();
                            login log = new login();
                            log.Show();
                        }
                        else if (receivedPacket.Message == "ChangeFailed")
                        {
                            MessageBox.Show("Thay đổi thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }


    }
}
