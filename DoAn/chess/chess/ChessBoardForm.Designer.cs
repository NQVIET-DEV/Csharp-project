namespace chess
{
    partial class ChessBoardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessBoardForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_luot = new System.Windows.Forms.Label();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.timelabel = new System.Windows.Forms.Label();
            this.rtb_historychat = new System.Windows.Forms.RichTextBox();
            this.txb_message = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.Username_txt = new System.Windows.Forms.TextBox();
            this.RoomID_txt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 382);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_luot
            // 
            this.lbl_luot.BackColor = System.Drawing.Color.Transparent;
            this.lbl_luot.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_luot.ForeColor = System.Drawing.Color.White;
            this.lbl_luot.Location = new System.Drawing.Point(593, 364);
            this.lbl_luot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_luot.Name = "lbl_luot";
            this.lbl_luot.Size = new System.Drawing.Size(120, 38);
            this.lbl_luot.TabIndex = 1;
            this.lbl_luot.Text = "Lượt của: ";
            this.lbl_luot.Click += new System.EventHandler(this.lbl_luot_Click);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // timelabel
            // 
            this.timelabel.BackColor = System.Drawing.Color.Transparent;
            this.timelabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timelabel.ForeColor = System.Drawing.Color.White;
            this.timelabel.Location = new System.Drawing.Point(593, 326);
            this.timelabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(154, 38);
            this.timelabel.TabIndex = 3;
            this.timelabel.Text = "Thời gian còn lại:";
            // 
            // rtb_historychat
            // 
            this.rtb_historychat.Location = new System.Drawing.Point(14, 19);
            this.rtb_historychat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rtb_historychat.Name = "rtb_historychat";
            this.rtb_historychat.Size = new System.Drawing.Size(279, 213);
            this.rtb_historychat.TabIndex = 4;
            this.rtb_historychat.Text = "";
            // 
            // txb_message
            // 
            this.txb_message.Location = new System.Drawing.Point(14, 238);
            this.txb_message.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txb_message.Name = "txb_message";
            this.txb_message.Size = new System.Drawing.Size(182, 22);
            this.txb_message.TabIndex = 6;
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.ForeColor = System.Drawing.Color.Black;
            this.btn_send.Location = new System.Drawing.Point(216, 235);
            this.btn_send.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(61, 23);
            this.btn_send.TabIndex = 7;
            this.btn_send.Text = "Gửi";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Username_txt
            // 
            this.Username_txt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_txt.Location = new System.Drawing.Point(610, 10);
            this.Username_txt.Name = "Username_txt";
            this.Username_txt.ReadOnly = true;
            this.Username_txt.Size = new System.Drawing.Size(139, 22);
            this.Username_txt.TabIndex = 8;
            // 
            // RoomID_txt
            // 
            this.RoomID_txt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomID_txt.Location = new System.Drawing.Point(755, 10);
            this.RoomID_txt.Name = "RoomID_txt";
            this.RoomID_txt.ReadOnly = true;
            this.RoomID_txt.Size = new System.Drawing.Size(129, 22);
            this.RoomID_txt.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rtb_historychat);
            this.groupBox1.Controls.Add(this.txb_message);
            this.groupBox1.Controls.Add(this.btn_send);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(596, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 282);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat";
            // 
            // ChessBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(906, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RoomID_txt);
            this.Controls.Add(this.Username_txt);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.lbl_luot);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ChessBoardForm";
            this.Text = "ChessBoardForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_luot;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.RichTextBox rtb_historychat;
        private System.Windows.Forms.TextBox txb_message;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox Username_txt;
        private System.Windows.Forms.TextBox RoomID_txt;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}