using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace chess
{
    public partial class Recovery : Form
    {
        private TCPClient client;
        private bool Exists;
        private string Passcode = GenerateRandomString(5);
        private string LocalIP;
        public Recovery()
        {
            InitializeComponent();
            LocalIP = GetLocalIPAddress();
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

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
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
        private void Passcode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PassCode_txt.Text))
            {

                Passcode_lb.Visible = true;
            }
            else
            {

                Passcode_lb.Visible = false;
            }
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static bool checkmail(string email)
        {
            string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, Pattern);
        }

        private async void Send_btn_Click(object sender, EventArgs e)
        {
            if (!checkmail(Email_txt.Text))
            {
                MessageBox.Show("Email không đúng định dạng, vui lòng nhập lại");
                return;
            }

            string email = Email_txt.Text;

            // Kiểm tra email tồn tại thông qua server
            await Task.Run(async () =>
            {
                try
                {
                    if (client == null)
                    {
                        client = new TCPClient(LocalIP, 11000);
                    }
                    client.Email = Email_txt.Text;
                    string response = await client.CheckMailAsync(email);
                    Exists = response.StartsWith("SUCCESS");

                    
                    this.Invoke(new Action(() =>
                    {
                        if (!Exists)
                        {
                            MessageBox.Show("Email chưa đăng ký tài khoản, vui lòng đăng ký");
                        }
                        else
                        {
                            try
                            {
                                // Tạo và gửi email nếu email tồn tại
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
                                mailMessage.To.Add(email);
                                smtpclient.Send(mailMessage);

                                // Thông báo thành công
                                Message_lb.Text = "Mã xác nhận đã được gửi tới Email của bạn";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Gửi email thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }));
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối hoặc lỗi kiểm tra email
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }


        private void Comfirm_btn_Click(object sender, EventArgs e)
        {
            if (PassCode_txt.Text == Passcode)
            {
                this.Hide();
                ResetPassword reset = new ResetPassword(client);
                reset.Show();
               
            }
            else if (string.IsNullOrEmpty(PassCode_txt.Text))
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận  ");
            }
            else
            {
                MessageBox.Show("Mã xác nhận không đúng ");
            }
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_2_ log = new Login_2_();
            log.Show();
        }
    }
}
