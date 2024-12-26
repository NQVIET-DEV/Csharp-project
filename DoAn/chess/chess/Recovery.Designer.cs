namespace chess
{
    partial class Recovery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recovery));
            this.Message_lb = new System.Windows.Forms.Label();
            this.Comfirm_btn = new System.Windows.Forms.Button();
            this.Send_btn = new System.Windows.Forms.Button();
            this.ChessOnline_tlt = new System.Windows.Forms.Label();
            this.Passcode_lb = new System.Windows.Forms.Label();
            this.PassCode_txt = new System.Windows.Forms.TextBox();
            this.Email_lb = new System.Windows.Forms.Label();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.Return_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message_lb
            // 
            this.Message_lb.AutoSize = true;
            this.Message_lb.BackColor = System.Drawing.Color.Transparent;
            this.Message_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_lb.ForeColor = System.Drawing.Color.White;
            this.Message_lb.Location = new System.Drawing.Point(30, 112);
            this.Message_lb.MaximumSize = new System.Drawing.Size(0, 200);
            this.Message_lb.Name = "Message_lb";
            this.Message_lb.Size = new System.Drawing.Size(450, 21);
            this.Message_lb.TabIndex = 29;
            this.Message_lb.Text = "Nhập Email để nhận mã khôi phục mật khẩu";
            // 
            // Comfirm_btn
            // 
            this.Comfirm_btn.BackColor = System.Drawing.Color.White;
            this.Comfirm_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_btn.Location = new System.Drawing.Point(147, 345);
            this.Comfirm_btn.Name = "Comfirm_btn";
            this.Comfirm_btn.Size = new System.Drawing.Size(161, 39);
            this.Comfirm_btn.TabIndex = 25;
            this.Comfirm_btn.Text = "Xác Nhận";
            this.Comfirm_btn.UseVisualStyleBackColor = false;
            this.Comfirm_btn.Click += new System.EventHandler(this.Comfirm_btn_Click);
            // 
            // Send_btn
            // 
            this.Send_btn.BackColor = System.Drawing.Color.White;
            this.Send_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_btn.Location = new System.Drawing.Point(147, 232);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(161, 39);
            this.Send_btn.TabIndex = 23;
            this.Send_btn.Text = "Gửi";
            this.Send_btn.UseVisualStyleBackColor = false;
            this.Send_btn.Click += new System.EventHandler(this.Send_btn_Click);
            // 
            // ChessOnline_tlt
            // 
            this.ChessOnline_tlt.AutoSize = true;
            this.ChessOnline_tlt.BackColor = System.Drawing.Color.Transparent;
            this.ChessOnline_tlt.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessOnline_tlt.ForeColor = System.Drawing.Color.White;
            this.ChessOnline_tlt.Location = new System.Drawing.Point(97, 40);
            this.ChessOnline_tlt.Name = "ChessOnline_tlt";
            this.ChessOnline_tlt.Size = new System.Drawing.Size(279, 33);
            this.ChessOnline_tlt.TabIndex = 28;
            this.ChessOnline_tlt.Text = "Chess Game Online";
            // 
            // Passcode_lb
            // 
            this.Passcode_lb.AutoSize = true;
            this.Passcode_lb.BackColor = System.Drawing.Color.White;
            this.Passcode_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passcode_lb.Location = new System.Drawing.Point(60, 297);
            this.Passcode_lb.Name = "Passcode_lb";
            this.Passcode_lb.Size = new System.Drawing.Size(131, 21);
            this.Passcode_lb.TabIndex = 27;
            this.Passcode_lb.Text = "Mã Xác Nhận";
            // 
            // PassCode_txt
            // 
            this.PassCode_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassCode_txt.Location = new System.Drawing.Point(51, 288);
            this.PassCode_txt.Name = "PassCode_txt";
            this.PassCode_txt.Size = new System.Drawing.Size(338, 39);
            this.PassCode_txt.TabIndex = 24;
            this.PassCode_txt.TextChanged += new System.EventHandler(this.Passcode_TextChanged);
            // 
            // Email_lb
            // 
            this.Email_lb.AutoSize = true;
            this.Email_lb.BackColor = System.Drawing.Color.White;
            this.Email_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_lb.Location = new System.Drawing.Point(60, 186);
            this.Email_lb.Name = "Email_lb";
            this.Email_lb.Size = new System.Drawing.Size(65, 21);
            this.Email_lb.TabIndex = 26;
            this.Email_lb.Text = "Email";
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(51, 177);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.Size = new System.Drawing.Size(338, 39);
            this.Email_txt.TabIndex = 22;
            this.Email_txt.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // Return_btn
            // 
            this.Return_btn.BackColor = System.Drawing.Color.White;
            this.Return_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(147, 421);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(161, 39);
            this.Return_btn.TabIndex = 30;
            this.Return_btn.Text = "Quay Lại";
            this.Return_btn.UseVisualStyleBackColor = false;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Recovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.Message_lb);
            this.Controls.Add(this.Comfirm_btn);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.ChessOnline_tlt);
            this.Controls.Add(this.Passcode_lb);
            this.Controls.Add(this.PassCode_txt);
            this.Controls.Add(this.Email_lb);
            this.Controls.Add(this.Email_txt);
            this.Name = "Recovery";
            this.Text = "Recovery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message_lb;
        private System.Windows.Forms.Button Comfirm_btn;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.Label ChessOnline_tlt;
        private System.Windows.Forms.Label Passcode_lb;
        private System.Windows.Forms.TextBox PassCode_txt;
        private System.Windows.Forms.Label Email_lb;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.Button Return_btn;
    }
}