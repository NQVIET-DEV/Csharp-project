namespace chess
{
    partial class MatchGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchGame));
            this.Find_btn = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.AIPlay_btn = new System.Windows.Forms.Button();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.Username_txt = new System.Windows.Forms.TextBox();
            this.Rating_txt = new System.Windows.Forms.TextBox();
            this.CreateRoom_btn = new System.Windows.Forms.Button();
            this.FindRoom_btn = new System.Windows.Forms.Button();
            this.RoomID_txt = new System.Windows.Forms.TextBox();
            this.Notification_txt = new System.Windows.Forms.TextBox();
            this.FindRoom2_btn = new System.Windows.Forms.Button();
            this.CreateRoom2_btn = new System.Windows.Forms.Button();
            this.TimeList_cb = new System.Windows.Forms.CheckedListBox();
            this.TimeSelect_lb = new System.Windows.Forms.Label();
            this.PieceColorSelect_lb = new System.Windows.Forms.Label();
            this.ColorList_cb = new System.Windows.Forms.CheckedListBox();
            this.LogOut_btn = new System.Windows.Forms.Button();
            this.Return_btn = new System.Windows.Forms.Button();
            this.Reload_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Reload_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // Find_btn
            // 
            this.Find_btn.BackColor = System.Drawing.Color.White;
            this.Find_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Find_btn.Location = new System.Drawing.Point(236, 130);
            this.Find_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Find_btn.Name = "Find_btn";
            this.Find_btn.Size = new System.Drawing.Size(213, 48);
            this.Find_btn.TabIndex = 0;
            this.Find_btn.Text = " Trận Ngẫu Nhiên";
            this.Find_btn.UseVisualStyleBackColor = false;
            this.Find_btn.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(305, 96);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Chưa tìm";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AIPlay_btn
            // 
            this.AIPlay_btn.BackColor = System.Drawing.Color.White;
            this.AIPlay_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AIPlay_btn.Location = new System.Drawing.Point(236, 365);
            this.AIPlay_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AIPlay_btn.Name = "AIPlay_btn";
            this.AIPlay_btn.Size = new System.Drawing.Size(213, 48);
            this.AIPlay_btn.TabIndex = 2;
            this.AIPlay_btn.Text = "Chơi Với AI";
            this.AIPlay_btn.UseVisualStyleBackColor = false;
            this.AIPlay_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(12, 39);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.ReadOnly = true;
            this.Email_txt.Size = new System.Drawing.Size(213, 25);
            this.Email_txt.TabIndex = 4;
            // 
            // Username_txt
            // 
            this.Username_txt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_txt.Location = new System.Drawing.Point(12, 8);
            this.Username_txt.Name = "Username_txt";
            this.Username_txt.ReadOnly = true;
            this.Username_txt.Size = new System.Drawing.Size(213, 25);
            this.Username_txt.TabIndex = 5;
            // 
            // Rating_txt
            // 
            this.Rating_txt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rating_txt.Location = new System.Drawing.Point(12, 70);
            this.Rating_txt.Name = "Rating_txt";
            this.Rating_txt.ReadOnly = true;
            this.Rating_txt.Size = new System.Drawing.Size(127, 25);
            this.Rating_txt.TabIndex = 6;
            // 
            // CreateRoom_btn
            // 
            this.CreateRoom_btn.BackColor = System.Drawing.Color.White;
            this.CreateRoom_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRoom_btn.Location = new System.Drawing.Point(236, 205);
            this.CreateRoom_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CreateRoom_btn.Name = "CreateRoom_btn";
            this.CreateRoom_btn.Size = new System.Drawing.Size(213, 48);
            this.CreateRoom_btn.TabIndex = 7;
            this.CreateRoom_btn.Text = "Tạo Phòng";
            this.CreateRoom_btn.UseVisualStyleBackColor = false;
            this.CreateRoom_btn.Click += new System.EventHandler(this.CreateRoom_btn_Click);
            // 
            // FindRoom_btn
            // 
            this.FindRoom_btn.BackColor = System.Drawing.Color.White;
            this.FindRoom_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindRoom_btn.Location = new System.Drawing.Point(236, 281);
            this.FindRoom_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FindRoom_btn.Name = "FindRoom_btn";
            this.FindRoom_btn.Size = new System.Drawing.Size(213, 48);
            this.FindRoom_btn.TabIndex = 8;
            this.FindRoom_btn.Text = "Tìm Phòng";
            this.FindRoom_btn.UseVisualStyleBackColor = false;
            this.FindRoom_btn.Click += new System.EventHandler(this.FindRoom_btn_Click);
            // 
            // RoomID_txt
            // 
            this.RoomID_txt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomID_txt.Location = new System.Drawing.Point(421, 8);
            this.RoomID_txt.Name = "RoomID_txt";
            this.RoomID_txt.ReadOnly = true;
            this.RoomID_txt.Size = new System.Drawing.Size(262, 25);
            this.RoomID_txt.TabIndex = 9;
            this.RoomID_txt.Visible = false;
            // 
            // Notification_txt
            // 
            this.Notification_txt.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notification_txt.Location = new System.Drawing.Point(506, 50);
            this.Notification_txt.Name = "Notification_txt";
            this.Notification_txt.ReadOnly = true;
            this.Notification_txt.Size = new System.Drawing.Size(177, 25);
            this.Notification_txt.TabIndex = 10;
            this.Notification_txt.Visible = false;
            // 
            // FindRoom2_btn
            // 
            this.FindRoom2_btn.BackColor = System.Drawing.Color.White;
            this.FindRoom2_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindRoom2_btn.Location = new System.Drawing.Point(548, 130);
            this.FindRoom2_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.FindRoom2_btn.Name = "FindRoom2_btn";
            this.FindRoom2_btn.Size = new System.Drawing.Size(136, 29);
            this.FindRoom2_btn.TabIndex = 11;
            this.FindRoom2_btn.Text = "Tìm Phòng";
            this.FindRoom2_btn.UseVisualStyleBackColor = false;
            this.FindRoom2_btn.Visible = false;
            this.FindRoom2_btn.Click += new System.EventHandler(this.FindRoom2_btn_Click);
            // 
            // CreateRoom2_btn
            // 
            this.CreateRoom2_btn.BackColor = System.Drawing.Color.White;
            this.CreateRoom2_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRoom2_btn.Location = new System.Drawing.Point(548, 86);
            this.CreateRoom2_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CreateRoom2_btn.Name = "CreateRoom2_btn";
            this.CreateRoom2_btn.Size = new System.Drawing.Size(136, 29);
            this.CreateRoom2_btn.TabIndex = 12;
            this.CreateRoom2_btn.Text = "Tạo Phòng";
            this.CreateRoom2_btn.UseVisualStyleBackColor = false;
            this.CreateRoom2_btn.Visible = false;
            this.CreateRoom2_btn.Click += new System.EventHandler(this.CreateRoom2_btn_Click);
            // 
            // TimeList_cb
            // 
            this.TimeList_cb.BackColor = System.Drawing.SystemColors.Info;
            this.TimeList_cb.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeList_cb.FormattingEnabled = true;
            this.TimeList_cb.Items.AddRange(new object[] {
            "10 Phút",
            "6 Phút",
            "3 Phút",
            "1 Phút"});
            this.TimeList_cb.Location = new System.Drawing.Point(168, 184);
            this.TimeList_cb.Name = "TimeList_cb";
            this.TimeList_cb.Size = new System.Drawing.Size(120, 88);
            this.TimeList_cb.TabIndex = 13;
            this.TimeList_cb.Visible = false;
            this.TimeList_cb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TimeList_cb_ItemCheck);
            // 
            // TimeSelect_lb
            // 
            this.TimeSelect_lb.AutoSize = true;
            this.TimeSelect_lb.BackColor = System.Drawing.Color.Transparent;
            this.TimeSelect_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeSelect_lb.ForeColor = System.Drawing.Color.White;
            this.TimeSelect_lb.Location = new System.Drawing.Point(146, 146);
            this.TimeSelect_lb.Name = "TimeSelect_lb";
            this.TimeSelect_lb.Size = new System.Drawing.Size(164, 21);
            this.TimeSelect_lb.TabIndex = 14;
            this.TimeSelect_lb.Text = "Chọn Thời Gian";
            this.TimeSelect_lb.Visible = false;
            // 
            // PieceColorSelect_lb
            // 
            this.PieceColorSelect_lb.AutoSize = true;
            this.PieceColorSelect_lb.BackColor = System.Drawing.Color.Transparent;
            this.PieceColorSelect_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PieceColorSelect_lb.ForeColor = System.Drawing.Color.White;
            this.PieceColorSelect_lb.Location = new System.Drawing.Point(338, 149);
            this.PieceColorSelect_lb.Name = "PieceColorSelect_lb";
            this.PieceColorSelect_lb.Size = new System.Drawing.Size(186, 21);
            this.PieceColorSelect_lb.TabIndex = 16;
            this.PieceColorSelect_lb.Text = "Chọn Màu Quân Cờ";
            this.PieceColorSelect_lb.Visible = false;
            // 
            // ColorList_cb
            // 
            this.ColorList_cb.BackColor = System.Drawing.SystemColors.Info;
            this.ColorList_cb.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorList_cb.FormattingEnabled = true;
            this.ColorList_cb.Items.AddRange(new object[] {
            "Trắng",
            "Đen"});
            this.ColorList_cb.Location = new System.Drawing.Point(390, 184);
            this.ColorList_cb.Name = "ColorList_cb";
            this.ColorList_cb.Size = new System.Drawing.Size(120, 46);
            this.ColorList_cb.TabIndex = 15;
            this.ColorList_cb.Visible = false;
            this.ColorList_cb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ColorList_cb_ItemCheck);
            // 
            // LogOut_btn
            // 
            this.LogOut_btn.BackColor = System.Drawing.Color.White;
            this.LogOut_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_btn.Location = new System.Drawing.Point(230, 8);
            this.LogOut_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.LogOut_btn.Name = "LogOut_btn";
            this.LogOut_btn.Size = new System.Drawing.Size(122, 29);
            this.LogOut_btn.TabIndex = 17;
            this.LogOut_btn.Text = "Đăng xuất";
            this.LogOut_btn.UseVisualStyleBackColor = false;
            this.LogOut_btn.Click += new System.EventHandler(this.LogOut_btn_Click);
            // 
            // Return_btn
            // 
            this.Return_btn.BackColor = System.Drawing.Color.White;
            this.Return_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(230, 43);
            this.Return_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(122, 29);
            this.Return_btn.TabIndex = 18;
            this.Return_btn.Text = "Quay Lại";
            this.Return_btn.UseVisualStyleBackColor = false;
            this.Return_btn.Visible = false;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Reload_btn
            // 
            this.Reload_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Reload_btn.Image = ((System.Drawing.Image)(resources.GetObject("Reload_btn.Image")));
            this.Reload_btn.Location = new System.Drawing.Point(145, 70);
            this.Reload_btn.Name = "Reload_btn";
            this.Reload_btn.Size = new System.Drawing.Size(36, 25);
            this.Reload_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Reload_btn.TabIndex = 27;
            this.Reload_btn.TabStop = false;
            this.Reload_btn.Click += new System.EventHandler(this.Reload_btn_Click);
            // 
            // MatchGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(695, 458);
            this.Controls.Add(this.Reload_btn);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.LogOut_btn);
            this.Controls.Add(this.FindRoom2_btn);
            this.Controls.Add(this.Notification_txt);
            this.Controls.Add(this.RoomID_txt);
            this.Controls.Add(this.FindRoom_btn);
            this.Controls.Add(this.CreateRoom_btn);
            this.Controls.Add(this.Rating_txt);
            this.Controls.Add(this.Username_txt);
            this.Controls.Add(this.Email_txt);
            this.Controls.Add(this.AIPlay_btn);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.Find_btn);
            this.Controls.Add(this.CreateRoom2_btn);
            this.Controls.Add(this.TimeSelect_lb);
            this.Controls.Add(this.TimeList_cb);
            this.Controls.Add(this.PieceColorSelect_lb);
            this.Controls.Add(this.ColorList_cb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MatchGame";
            this.Text = "MatchGame";
            ((System.ComponentModel.ISupportInitialize)(this.Reload_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Find_btn;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button AIPlay_btn;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.TextBox Username_txt;
        private System.Windows.Forms.TextBox Rating_txt;
        private System.Windows.Forms.Button CreateRoom_btn;
        private System.Windows.Forms.Button FindRoom_btn;
        private System.Windows.Forms.TextBox RoomID_txt;
        private System.Windows.Forms.TextBox Notification_txt;
        private System.Windows.Forms.Button FindRoom2_btn;
        private System.Windows.Forms.Button CreateRoom2_btn;
        private System.Windows.Forms.CheckedListBox TimeList_cb;
        private System.Windows.Forms.Label TimeSelect_lb;
        private System.Windows.Forms.Label PieceColorSelect_lb;
        private System.Windows.Forms.CheckedListBox ColorList_cb;
        private System.Windows.Forms.Button LogOut_btn;
        private System.Windows.Forms.Button Return_btn;
        private System.Windows.Forms.PictureBox Reload_btn;
    }
}