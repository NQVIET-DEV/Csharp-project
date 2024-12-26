using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class ResetPassword : Form
    {
        private TCPClient Client;
        private string Email;
        private bool isPasswordVisible = false;
        public ResetPassword(TCPClient client)
        {
            InitializeComponent();
            Client = client;
            Email = client.Email;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
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
        private void ShowComfirm_btn_Click_1(object sender, EventArgs e)
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
            Login_2_ log = new Login_2_();
            this.Close();
            log.ShowDialog();
        }

        private async void Comfirm_btn_Click(object sender, EventArgs e)
        {
            string password = Password_txt.Text;
            string comfirm = Comfirm_txt.Text;

            if (password != comfirm)
            {
                MessageBox.Show("Xác nhận không khớp vui lòng nhập lại!");
                return;
            }

            string response = await Client.UpdatePassword(password, Email);
            this.Invoke(new Action(() =>
            {
                if (response.StartsWith("SUCCESS"))
                {
                    MessageBox.Show("Thay Đổi Mật Khẩu thành công!");
                  
                    Login_2_ log = new Login_2_();
                    this.Close();
                    log.ShowDialog();
                }
                else
                {
                    MessageBox.Show(response);
                }
            }));
        }

        private void ResetPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Client.Close();
        }
    }
}
