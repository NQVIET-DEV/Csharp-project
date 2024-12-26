using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
namespace chess
{
    public partial class ChessBoardForm : Form
    {
        private TCPClient client;
        private string playerColor; // Màu của người chơi ("WHITE" hoặc "BLACK")
        private bool isRandom;
        private PieceColor currentPlayer;
        private PictureBox[,] pictureBoxes;
        private (int, int)? selectedCell = null;
        private bool isPlayerTurn;
        private ChessBoard chessBoard;
        private int turn = 0;
        private int timeLeft; // Thời gian còn lại cho người chơi hiện tại (tính bằng giây)
        private int opponentTimeLeft; // Thời gian còn lại cho đối thủ
        private int TimeSelected;
        private Timer timer;
        private bool isGameOver = false;
       
        public ChessBoardForm(TCPClient client, string playerColor,string time)
        {
            InitializeComponent();
          
            Username_txt.Text = client.Username;
            RoomID_txt.Text = client.RoomID;
            this.client = client;
            this.playerColor = playerColor.ToLower();
            this.currentPlayer = this.playerColor == "white" ? PieceColor.White : PieceColor.Black;
            this.isPlayerTurn = playerColor == "WHITE";
            if(this.playerColor == "white")
            {
                lbl_luot.Text = $"Lượt của {client.Username}";
                
               
            }
            else if(this.playerColor == "black")
            {
                lbl_luot.Text = "Lượt của đối thủ ";
            }    
            pictureBoxes = new PictureBox[8, 8];
            chessBoard = new ChessBoard();
            InitializeBoard();
            //timeLeft = 600;
            timeLeft = int.Parse(time);
            TimeSelected = int.Parse(time);

            timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateTimeLabels();
           
            Task.Run(() => ListenForInformation());
         
        }

        private void InitializeBoard()
        {
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();


            for (int i = 0; i < 8; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));

                for (int j = 0; j < 8; j++)
                {
                    PictureBox picBox = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = (i, j)
                    };
                    picBox.BackColor = (i + j) % 2 == 0 ? Color.White : Color.Gray;
                    picBox.Click += OnCellClick;
                    pictureBoxes[i, j] = picBox;
                    tableLayoutPanel1.Controls.Add(picBox, j, i);
                    UpdatePictureBox(i, j); // Cập nhật hình ảnh quân cờ ban đầu
                }
            }
        }
        private void CheckTurn(bool Turn)
        {
            if(Turn)
            {
                lbl_luot.Text = $"Lượt của {client.Username}";
            }    
            else
            {
                lbl_luot.Text = "Lượt của đối thủ";
            }
        }

      
        private void UpdateTimeLabels()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            timelabel.Text = $"Thời gian: {minutes:D2}:{seconds:D2}";

            minutes = opponentTimeLeft / 60;
            seconds = opponentTimeLeft % 60;
           
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Giảm thời gian cho người chơi hiện tại
            timeLeft--;
            UpdateTimeLabels(); // Cập nhật label mỗi giây

            if (timeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("Hết thời gian! Đến lượt của đối thủ.");
                SwitchTurn(); // Chuyển lượt cho đối thủ
            }
        }
        private async Task ListenForOpponentChat()
        {
            isPlayerTurn = true;
            while (true)
            {
                string respone = await client.ReceiveResponseAsync();
                if (respone.StartsWith("CHAT"))
                {
                    rtb_historychat.Invoke((MethodInvoker)delegate
                    {
                        rtb_historychat.AppendText("Đối thủ: " + respone.Substring(5) + "\n");
                    });
                }    
            }
        }
       
        private async Task ListenForInformation()
        {
            while (true)
            {
                try
                {
                    string response = await client.ReceiveResponseAsync();

                    if (response.StartsWith("CHAT"))
                    {
                        string chatMessage = response.Substring(5).Trim(); // Bỏ prefix "CHAT "

                        // Phân biệt tin nhắn của mình hay của đối thủ
                        string sender = chatMessage.Split(':')[0]; // Lấy người gửi (dạng "username: message")
                        string message = chatMessage.Substring(chatMessage.IndexOf(':') + 1).Trim(); // Nội dung tin nhắn

                        if (sender == client.Username)
                        {
                            rtb_historychat.Invoke((MethodInvoker)delegate
                            {
                                rtb_historychat.AppendText($"Bạn: {message}\n"); // Tin nhắn của bạn
                            });
                        }
                        else
                        {
                            rtb_historychat.Invoke((MethodInvoker)delegate
                            {
                                rtb_historychat.AppendText($"Đối thủ: {message}\n"); // Tin nhắn của đối thủ
                            });
                        }
                    }
                    else if (response.StartsWith("MOVE"))
                    {
                        string[] parts = response.Split(' ');
                        if (parts.Length == 3)
                        {
                            string from = parts[1];
                            string to = parts[2];
                            ApplyMove(from, to);
                            timeLeft = TimeSelected; // Đặt lại thời gian cho người chơi
                            opponentTimeLeft = TimeSelected; // Đặt lại thời gian cho đối thủ
                            UpdateTimeLabels();
                            isPlayerTurn = true;
                            CheckTurn(isPlayerTurn);
                        }
                    }
                    else if(response.StartsWith("GAMEOVER!!"))
                    {
                        this.Close();
                    }   
                    else if (response.StartsWith("ERROR"))
                    {
                        Console.WriteLine($"Error in ListenForInformation: {response}");
                    }    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ListenForInformation: {ex.Message}");
                }
            }
        }


        private async  void OnCellClick(object sender, EventArgs e)
        {
            // Kiểm tra xem có phải lượt của người chơi hay không
            if (!isPlayerTurn)
            {
                MessageBox.Show("Chưa tới lượt của bạn!");
                return;
            }

            
            PictureBox clickedPictureBox = sender as PictureBox;
            var (row, col) = ((int, int))clickedPictureBox.Tag;

            // Kiểm tra việc chọn ô
            if (selectedCell == null)
            {
                // Chọn ô cờ
                //ChessPiece piece = chessBoard.Board[row, col];
                if (chessBoard.Board[row, col] != null && chessBoard.Board[row, col].Color == currentPlayer)
                {
                    selectedCell = (row, col);
                    pictureBoxes[row, col].BackColor = Color.LightBlue;
                    HighlightValidMoves(row, col); // Đánh dấu các ô cờ hợp lệ
                }
                else
                {
                    MessageBox.Show("Bạn không thể chọn ô này! Ô trống hoặc không phải quân cờ của bạn.");
                }
            }
            else
            {
                turn++;
                
                var (startX, startY) = selectedCell.Value;
                if (chessBoard.IsValidMove(startX, startY, row, col))
                {
                    string from = $"{startX}{startY}";
                    string to = $"{row}{col}";
                 
                    ApplyMove(from, to);
                    await client.SendMove(from,to);
                   
                    timeLeft = TimeSelected; // Đặt lại thời gian cho người chơi hiện tại
                    opponentTimeLeft = TimeSelected;
                    isPlayerTurn = false; // Chuyển lượt cho đối thủ
                    lbl_luot.Text = "Lượt của đối thủ";
                }
                else
                {
                    MessageBox.Show("Nước đi không hợp lệ!");
                }
               
                selectedCell = null;
                ResetBoardColors(); // Khôi phục màu sắc bàn cờ
            }
        }
        
        private void ApplyMove(string from, string to)
        {
            int startX = int.Parse(from[0].ToString());
            int startY = int.Parse(from[1].ToString());
            int endX = int.Parse(to[0].ToString());
            int endY = int.Parse(to[1].ToString());

            // Di chuyển quân cờ
            chessBoard.Board[endX, endY] = chessBoard.Board[startX, startY];
            chessBoard.Board[startX, startY] = null;

            // Cập nhật hình ảnh quân cờ
            UpdatePictureBox(startX, startY);
            UpdatePictureBox(endX, endY);
            HandleGameResult();
        }
        private async void HandleGameResult()
        {
            string result = GetGameResult();
            if (result == null) return;
            string request = $"GAMEOVER {RoomID_txt.Text} {result} {client.Username}";
            string response = await client.SendRequestAsync(request);
            string[] responseParts = response.Split(' ');
            if(response.StartsWith("GAMEOVER!!"))
            {
                EndGame(result);
            }
            else if (response.StartsWith("ERROR"))
            {
               MessageBox.Show("Lỗi");
            }
          
        }
        private void EndGame(string result)
        {
            timer.Stop();
            MessageBox.Show(result, "Game Over");
            isGameOver = true;
           // this.Close();
        }

        private void UpdatePictureBox(int row, int col)
        {
            ChessPiece piece = chessBoard.Board[row, col];
            if (piece != null)
            {
                string imagePath = GetPieceImagePath(piece);
                if (!string.IsNullOrEmpty(imagePath))
                {
                    pictureBoxes[row, col].Image = Image.FromFile(imagePath);
                }
            }
            else
            {
                pictureBoxes[row, col].Image = null;
            }
        }

        private string GetPieceImagePath(ChessPiece piece)
        {
            string color = piece.Color == PieceColor.White ? "white" : "black";
            string type = piece.Type.ToString().ToLower();
            string imagePath = $"{color}_{type}.png";

            if (!System.IO.File.Exists(imagePath))
            {
                MessageBox.Show($"Không tìm thấy hình ảnh: {imagePath}");
                return null;
            }
            return imagePath;
        }

        private void HighlightValidMoves(int startX, int startY)
        {
            ChessPiece currentPiece = chessBoard.Board[startX, startY];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // Kiểm tra nếu nước đi là hợp lệ
                    if (chessBoard.IsValidMove(startX, startY, i, j))
                    {
                        pictureBoxes[i, j].BackColor = Color.LightGreen; // Đánh dấu ô hợp lệ
                    }
                }
            }
        }

        private void ResetBoardColors()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pictureBoxes[i, j].BackColor = (i + j) % 2 == 0 ? Color.White : Color.Gray;
                }
            }
        }
        private string GetGameResult()
        {
            bool whiteKingExists = false;
            bool blackKingExists = false;

            foreach (var piece in chessBoard.Board)
            {
                if (piece != null && piece.Type == PieceType.King)
                {
                    if (piece.Color == PieceColor.White)
                        whiteKingExists = true;
                    else if (piece.Color == PieceColor.Black)
                        blackKingExists = true;
                }
            }

            if (!whiteKingExists && blackKingExists)
                return "BLACK wins!";
            else if (!blackKingExists && whiteKingExists)
                return "WHITE wins!";
            else
                return null; // Trò chơi chưa kết thúc
        }
        private void lbl_luot_Click(object sender, EventArgs e)
        {
           
        }
        private void SwitchTurn()
        {
            // Chuyển lượt
            isPlayerTurn = !isPlayerTurn;

            // Đặt lại thời gian
            timeLeft = isPlayerTurn ? TimeSelected : TimeSelected; // Thời gian cho người chơi hiện tại
            opponentTimeLeft = !isPlayerTurn ? TimeSelected : TimeSelected; // Thời gian cho đối thủ

            // Cập nhật lại label thời gian
            UpdateTimeLabels();

            // Bắt đầu lại timer cho người chơi hiện tại
            timer.Start();
        }
        private async void btn_send_Click(object sender, EventArgs e)
        {
            string message = txb_message.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                string formattedMessage = $"{client.Username}: {message}"; // Định dạng tin nhắn kèm username
                await client.SendMessageAsync("CHAT " + formattedMessage); // Gửi tin nhắn qua server
                txb_message.Text = ""; // Xóa nội dung sau khi gửi
            }
        }

        private void ChessBoardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MatchGame log = new MatchGame(client);
            log.Show();
        }

       
    }
}
