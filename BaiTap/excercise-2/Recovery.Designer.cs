namespace excercise_2
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
            this.Noti_Lb = new System.Windows.Forms.Label();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.Send_btn = new System.Windows.Forms.Button();
            this.Noti2_lb = new System.Windows.Forms.Label();
            this.Comfirm_btn = new System.Windows.Forms.Button();
            this.Comfirm_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Noti_Lb
            // 
            this.Noti_Lb.AutoSize = true;
            this.Noti_Lb.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Noti_Lb.Location = new System.Drawing.Point(85, 37);
            this.Noti_Lb.Name = "Noti_Lb";
            this.Noti_Lb.Size = new System.Drawing.Size(625, 31);
            this.Noti_Lb.TabIndex = 1;
            this.Noti_Lb.Text = "Nhập Email đã đăng ký để nhận mã khôi phục mật khẩu";
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(199, 117);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.Size = new System.Drawing.Size(405, 29);
            this.Email_txt.TabIndex = 4;
            // 
            // Send_btn
            // 
            this.Send_btn.BackColor = System.Drawing.Color.White;
            this.Send_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_btn.Location = new System.Drawing.Point(322, 176);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(161, 39);
            this.Send_btn.TabIndex = 24;
            this.Send_btn.Text = "Gửi";
            this.Send_btn.UseVisualStyleBackColor = false;
            this.Send_btn.Click += new System.EventHandler(this.Send_btn_Click);
            // 
            // Noti2_lb
            // 
            this.Noti2_lb.AutoSize = true;
            this.Noti2_lb.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Noti2_lb.Location = new System.Drawing.Point(278, 252);
            this.Noti2_lb.Name = "Noti2_lb";
            this.Noti2_lb.Size = new System.Drawing.Size(239, 31);
            this.Noti2_lb.TabIndex = 25;
            this.Noti2_lb.Text = "Nhập  Mã Xác Nhận";
            // 
            // Comfirm_btn
            // 
            this.Comfirm_btn.BackColor = System.Drawing.Color.White;
            this.Comfirm_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_btn.Location = new System.Drawing.Point(322, 382);
            this.Comfirm_btn.Name = "Comfirm_btn";
            this.Comfirm_btn.Size = new System.Drawing.Size(161, 39);
            this.Comfirm_btn.TabIndex = 27;
            this.Comfirm_btn.Text = "Xác Nhận";
            this.Comfirm_btn.UseVisualStyleBackColor = false;
            this.Comfirm_btn.Click += new System.EventHandler(this.Comfirm_btn_Click);
            // 
            // Comfirm_txt
            // 
            this.Comfirm_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_txt.Location = new System.Drawing.Point(199, 322);
            this.Comfirm_txt.Name = "Comfirm_txt";
            this.Comfirm_txt.Size = new System.Drawing.Size(405, 29);
            this.Comfirm_txt.TabIndex = 26;
            // 
            // Recovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Comfirm_btn);
            this.Controls.Add(this.Comfirm_txt);
            this.Controls.Add(this.Noti2_lb);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.Email_txt);
            this.Controls.Add(this.Noti_Lb);
            this.Name = "Recovery";
            this.Text = "Recovery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Noti_Lb;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.Label Noti2_lb;
        private System.Windows.Forms.Button Comfirm_btn;
        private System.Windows.Forms.TextBox Comfirm_txt;
    }
}