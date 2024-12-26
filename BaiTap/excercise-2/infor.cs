using System;
using System.Windows.Forms;
using static excercise_2.login;

namespace excercise_2
{
    public partial class infor : Form
    {
        public infor(string username, string email, string namme,string date)
        {
            InitializeComponent();
            textBox1.Text = username;
            textBox4.Text = email;
            textBox2.Text = namme;
            textBox3.Text = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Close();
        }

       
    }
}
