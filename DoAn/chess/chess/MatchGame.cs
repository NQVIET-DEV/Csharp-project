using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace chess
{
    public partial class MatchGame : Form
    {
        private TCPClient client;
        private bool isFindingMatch = false;
        private string timeInText;
        private string Time;
       // private bool WaitingPlayer = false;

        public MatchGame(TCPClient client)
        {
            InitializeComponent();
            this.client = client;
            Username_txt.Text = client.Username;
            Email_txt.Text = client.Email;
            Rating_txt.Text = client.Rating.ToString();
           
        }
        private static string GenerateRandomString(int length)
        {
            const string chars = "0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private async void btn_find_Click(object sender, EventArgs e)
        {
            if (isFindingMatch)
            {
                MessageBox.Show("Đang tìm trận. Vui lòng chờ...");
                return;
            }

            isFindingMatch = true;
            lblStatus.Text = "Đang tìm trận...";

            // Gửi yêu cầu tìm trận
            await FindMatchAsync();
        }

        private async Task FindMatchAsync()
        {
            try
            {
                // Gửi yêu cầu tìm trận tới server
                string response = await client.FindMatchAsync();

                // Kiểm tra phản hồi từ server
                if (response.StartsWith("WAITING"))
                {
                    lblStatus.Text = "Chờ đợi người chơi khác...";
                    await ListenForMatchAsync(); // Lắng nghe thông báo tìm thấy trận
                }
                else if (response.StartsWith("MATCH_FOUND"))
                {
                    OpenChessBoard(response,true); // Mở bàn cờ nếu tìm thấy trận
                }
                else
                {
                    lblStatus.Text = "Lỗi: " + response;
                    isFindingMatch = false;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi: " + ex.Message;
                isFindingMatch = false;
            }
        }

        private async Task ListenForMatchAsync()
        {
            while (true)
            {
                // Đọc phản hồi từ server về việc tìm trận
                string response = await client.WaitForMatchAsync();

                if (response.StartsWith("MATCH_FOUND"))
                {
                    OpenChessBoard(response, true); // Mở bàn cờ khi trận đấu được tìm thấy
                    break;
                }
                else if(response.StartsWith("START"))
                {
                    OpenChessBoard(response,false); // Mở bàn cờ khi trận đấu được tìm thấy
                    break;
                }    
                else
                {
                    lblStatus.Text = response;
                    await Task.Delay(1000); // Đợi một chút rồi kiểm tra lại
                }
            }
        }

        private void OpenChessBoard(string matchResponse,bool IsRandom,string time = null)
        {
            if (string.IsNullOrEmpty(matchResponse))
            {
                MessageBox.Show("Lỗi: Phản hồi trận đấu không hợp lệ.");
                return;
            }

            string[] parts = matchResponse.Split(' ');

            if (parts.Length < 2)
            {
                MessageBox.Show("Lỗi: Định dạng phản hồi trận đấu không hợp lệ.");
                return;
            }

            string playerColor = parts[1]; // "WHITE" hoặc "BLACK"
            MessageBox.Show($"Trận đấu đã tìm thấy! Bạn đang chơi với màu: {playerColor}");
            if(IsRandom)
            {
                Time = "300";
            }    
            // Mở bàn cờ không chặn giao diện
            ChessBoardForm chessBoard = new ChessBoardForm(client, playerColor,Time);
            this.Hide();
            chessBoard.Show();
            chessBoard.FormClosed += (s, e) => this.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
           
        }
        private void FindRoom_btn_Click(object sender, EventArgs e)
        {
            Find_btn.Visible = !Find_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            lblStatus.Visible = !lblStatus.Visible;


            RoomID_txt.Text = string.Empty;
            RoomID_txt.Visible = !RoomID_txt.Visible;
            RoomID_txt.ReadOnly = false;
            Notification_txt.Visible = !Notification_txt.Visible;
            FindRoom2_btn.Visible = !FindRoom2_btn.Visible;
            Return_btn.Visible = !Return_btn.Visible;


        }

        private  void CreateRoom_btn_Click(object sender, EventArgs e)
        {
            Find_btn.Visible = !Find_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            lblStatus.Visible = !lblStatus.Visible;

            RoomID_txt.Visible = !RoomID_txt.Visible;
            Notification_txt.Visible = !Notification_txt.Visible;

            RoomID_txt.Text = GenerateRandomString(5);
            CreateRoom2_btn.Visible = ! CreateRoom2_btn.Visible;
            TimeSelect_lb.Visible = !TimeSelect_lb.Visible;
            TimeList_cb.Visible = !TimeList_cb.Visible;
            PieceColorSelect_lb.Visible = !PieceColorSelect_lb.Visible;
            ColorList_cb.Visible= !ColorList_cb.Visible;
            Return_btn.Visible = !Return_btn.Visible;
        }

        private async void FindRoom2_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoomID_txt.Text))
            {
                Notification_txt.Text = "Vui lòng nhập mã phòng.";
                return;
            }

            string roomId = RoomID_txt.Text.Trim();
            string request = $"FINDROOM {roomId}";

            try
            {
                string response = await client.SendRequestAsync(request);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    client.RoomID = parts[2];
                    Time = parts[3]; 
                    Notification_txt.Text = "Phòng đã tìm thấy! Đang kết nối...";
                    OpenChessBoard(response,false,Time);
                }
                else if (response.StartsWith("ERROR"))
                {
                    Notification_txt.Text = "Phòng không tồn tại. Vui lòng kiểm tra lại.";
                }
                else
                {
                    Notification_txt.Text = $"Lỗi: {response}";
                }
            }
            catch (Exception ex)
            {
                Notification_txt.Text = $"Lỗi: {ex.Message}";
            }
        }

        private async void CreateRoom2_btn_Click(object sender, EventArgs e)
        {
            
            string roomId = RoomID_txt.Text.Trim();
            string request = null;
            if(client.PieceColor == "Trắng")
            {
                request = $"CREATEROOM {roomId} WHITE {Time}";
            }    
            else if (client.PieceColor == "Đen")
            {
                request = $"CREATEROOM {roomId} BLACK {Time}";
            }    
            try
            {
                string response = await client.SendRequestAsync(request);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    client.RoomID = parts[2];
                    Notification_txt.Text = parts[0];
                    await ListenForMatchAsync(); // Lắng nghe thông báo tìm thấy người chơi
                }
                else if (response.StartsWith("ERROR"))
                {
                    Notification_txt.Text = "Phòng đã tồn tại";
                }
                else
                {
                    Notification_txt.Text = $"Lỗi: {response}";
                }
            }
            catch (Exception ex)
            {
                Notification_txt.Text = $"Lỗi: {ex.Message}";
            }
        }

        private void TimeList_cb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < TimeList_cb.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    TimeList_cb.SetItemChecked(i, false);
                }
            }

            // Lấy mục được chọn
            if (e.NewValue == CheckState.Checked)
            {
                timeInText = TimeList_cb.Items[e.Index].ToString();
                switch(timeInText)
                {
                    case "10 Phút":
                        Time = "600";
                        break;
                    case "6 Phút":
                        Time = "360";
                        break;
                    case "3 Phút":
                        Time = "180";
                        break;
                    case "1 Phút":
                        Time = "60";
                        break;
                }    
                MessageBox.Show($"Bạn đã chọn: {timeInText}");
            }
        }

        private void ColorList_cb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < ColorList_cb.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    ColorList_cb.SetItemChecked(i, false);
                }
            }

            // Lấy mục được chọn
            if (e.NewValue == CheckState.Checked)
            {
                client.PieceColor = ColorList_cb.Items[e.Index].ToString();
                MessageBox.Show($"Bạn đã chọn: {client.PieceColor}");
            }
        }

        private async void LogOut_btn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                string response = await client.Logout(client.Username);
                string[] responseParts = response.Split(' ');
                this.Invoke(new Action(() =>
                {
                    if (response.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("Đăng Xuất Thành Công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }));
            });

        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Return_btn.Visible = !Return_btn.Visible;
            Find_btn.Visible = !Find_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            lblStatus.Visible = !lblStatus.Visible;

            RoomID_txt.Visible = !RoomID_txt.Visible;
            Notification_txt.Visible = !Notification_txt.Visible;

            if(FindRoom2_btn.Visible)
            {
                FindRoom2_btn.Visible = !FindRoom2_btn.Visible;
            }
            if (CreateRoom2_btn.Visible)
            {
                CreateRoom2_btn.Visible = !CreateRoom2_btn.Visible;
            }
            if(TimeList_cb.Visible)
            {
                TimeList_cb.Visible = !TimeList_cb.Visible;
            }
            if(TimeSelect_lb.Visible)
            {
                TimeSelect_lb.Visible = !TimeSelect_lb.Visible;
            }   
            if(PieceColorSelect_lb.Visible)
            {
                PieceColorSelect_lb.Visible = !PieceColorSelect_lb.Visible;
            }
            if (ColorList_cb.Visible)
            {
                ColorList_cb.Visible = !ColorList_cb.Visible;
            }
        }

        private async void  Reload_btn_Click(object sender, EventArgs e)
        {
            string request = $"UPDATE {client.Username}";
            try
            {
                string response = await client.SendRequestAsync(request);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    Rating_txt.Text = parts[1];
                  
                }
                else if (response.StartsWith("ERROR"))
                {
                    MessageBox.Show("Lỗi gói tin");
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            catch (Exception ex)
            {
                Notification_txt.Text = $"Lỗi: {ex.Message}";
            }
        }
    }
}