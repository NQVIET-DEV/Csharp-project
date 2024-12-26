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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class SignUp : Form
    {
        private string Username;
        private string Email;
        private bool isPasswordVisible = false;
        private string LocalIp;
        private TCPClient client;
        public SignUp()
        {
            InitializeComponent();
            LocalIp = GetLocalIPAddress();
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

        private async void btn_singup_Click(object sender, EventArgs e)
        {
            Username = Username_txt.Text;
            Email = Email_txt.Text;
            string Password = Password_txt.Text;
            string Comfirm = Comfirm_txt.Text;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Comfirm) || string.IsNullOrEmpty(Email) )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            if (Password.Length < 5)
            {
                MessageBox.Show("Mật Khẩu Yếu!");
                return;
            }
            if (Password != Comfirm)
            {
                MessageBox.Show("Lỗi Mật Khẩu!");
                return;
            }
            if (!checkmail(Email))
            {
                MessageBox.Show("Email không đúng định dạng , Nhập lại.");
                return;
            }


            await Task.Run(async () =>
            {
                if (client == null)
                {
                    client = new TCPClient(LocalIp, 11000);
                }

               
                string response = await client.RegisterAsync(Username,Password,Email);
                string[] responseParts = response.Split(' ');

                // Cập nhật UI sau khi hoàn tất đăng nhập
                this.Invoke(new Action(() =>
                {
                    if (response.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("Đăng Ký thành công!");
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

        private void label1_Click(object sender, EventArgs e)
        {

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
        public static bool checkmail(string email)
        {
            string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, Pattern);
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
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
        private void Email_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email_txt.Text))
            {

                Email_lb.Visible = true;
            }
            else
            {

                Email_lb.Visible = false;
            }
        }
        private void Comfirm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Comfirm_txt.Text))
            {

                Comfirm_lb.Visible = true;
            }
            else
            {

                Comfirm_lb.Visible = false;
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

        private void ShowPassword_btn_Click(object sender, EventArgs e)
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

        private void ShowComfirm_btn_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                Comfirm_txt.PasswordChar = '\0';
            }
            else
            {
                Comfirm_txt.PasswordChar = '*';
            }
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_2_ log = new Login_2_();
            log.Show();
        }
    }
}
