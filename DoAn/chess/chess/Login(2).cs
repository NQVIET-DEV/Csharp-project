using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SQLite;
using System.Net.Sockets;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chess
{
    public partial class Login_2_ : Form
    {
        private TCPClient client;
        private bool isPasswordVisible = false;
        private string LocalIP;
       

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
        public Login_2_()
        {
            InitializeComponent();
            LocalIP = GetLocalIPAddress();
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

        private async void btn_login_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                if (client == null)
                {
                    client = new TCPClient(LocalIP, 11000);
                }

                string username = Username_txt.Text;
                string password = Password_txt.Text;
                string response = await client.LoginAsync(username, password);
                string[] responseParts = response.Split(' ');

                // Cập nhật UI sau khi hoàn tất đăng nhập
                this.Invoke(new Action(() =>
                {
                    if (response.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        client.Username = responseParts[3];
                        client.Email = responseParts[4];
                        client.Rating = Convert.ToInt32(responseParts[5]);
                        MatchGame matchGame = new MatchGame(client);
                        matchGame.FormClosed += (s, args) =>
                        {
                            client.Close(); // Ngắt kết nối tới server
                            Application.Exit(); // Đóng hoàn toàn ứng dụng
                            
                        };
                        this.Hide();
                        matchGame.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }));
            });
        }
        private void Username_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username_txt.Text))
            {

                Username_lb.Visible = true;
            }
            else
            {

                Username_lb.Visible = false;
            }
        }
        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password_txt.Text))
            {

                Password_lb.Visible = true;
            }
            else
            {

                Password_lb.Visible = false;
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {

            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Blue;
                label.ForeColor = Color.White;
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {

            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
            }
        }

        private void ShowPassword_btn_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                Password_txt.PasswordChar = '\0';
            }
            else
            {
                Password_txt.PasswordChar = '*';
            }
        }

        private void Signup_lb_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp log = new SignUp();
            log.Show();
        }

        private void Forgot_lb_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recovery log = new Recovery();
            log.Show();
        }
    }
}
