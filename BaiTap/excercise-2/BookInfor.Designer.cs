namespace excercise_2
{
    partial class BookInfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookInfor));
            this.BookInfor_grp = new System.Windows.Forms.GroupBox();
            this.Description_txt = new System.Windows.Forms.TextBox();
            this.Description_lb = new System.Windows.Forms.Label();
            this.PublishedDate_txt = new System.Windows.Forms.TextBox();
            this.PublishedDate_lb = new System.Windows.Forms.Label();
            this.Author_txt = new System.Windows.Forms.TextBox();
            this.Author_lb = new System.Windows.Forms.Label();
            this.Name_txt = new System.Windows.Forms.TextBox();
            this.Name_lb = new System.Windows.Forms.Label();
            this.Thumbnail_pic = new System.Windows.Forms.PictureBox();
            this.BookInfor_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // BookInfor_grp
            // 
            this.BookInfor_grp.Controls.Add(this.Description_txt);
            this.BookInfor_grp.Controls.Add(this.Description_lb);
            this.BookInfor_grp.Controls.Add(this.PublishedDate_txt);
            this.BookInfor_grp.Controls.Add(this.PublishedDate_lb);
            this.BookInfor_grp.Controls.Add(this.Author_txt);
            this.BookInfor_grp.Controls.Add(this.Author_lb);
            this.BookInfor_grp.Controls.Add(this.Name_txt);
            this.BookInfor_grp.Controls.Add(this.Name_lb);
            this.BookInfor_grp.Location = new System.Drawing.Point(514, 12);
            this.BookInfor_grp.Name = "BookInfor_grp";
            this.BookInfor_grp.Size = new System.Drawing.Size(274, 413);
            this.BookInfor_grp.TabIndex = 0;
            this.BookInfor_grp.TabStop = false;
            this.BookInfor_grp.Text = "Thông tin sách";
            // 
            // Description_txt
            // 
            this.Description_txt.Location = new System.Drawing.Point(6, 241);
            this.Description_txt.Multiline = true;
            this.Description_txt.Name = "Description_txt";
            this.Description_txt.ReadOnly = true;
            this.Description_txt.Size = new System.Drawing.Size(261, 166);
            this.Description_txt.TabIndex = 7;
            // 
            // Description_lb
            // 
            this.Description_lb.AutoSize = true;
            this.Description_lb.Location = new System.Drawing.Point(6, 225);
            this.Description_lb.Name = "Description_lb";
            this.Description_lb.Size = new System.Drawing.Size(38, 13);
            this.Description_lb.TabIndex = 6;
            this.Description_lb.Text = "Mô Tả";
            // 
            // PublishedDate_txt
            // 
            this.PublishedDate_txt.Location = new System.Drawing.Point(6, 178);
            this.PublishedDate_txt.Name = "PublishedDate_txt";
            this.PublishedDate_txt.ReadOnly = true;
            this.PublishedDate_txt.Size = new System.Drawing.Size(261, 20);
            this.PublishedDate_txt.TabIndex = 5;
            // 
            // PublishedDate_lb
            // 
            this.PublishedDate_lb.AutoSize = true;
            this.PublishedDate_lb.Location = new System.Drawing.Point(6, 162);
            this.PublishedDate_lb.Name = "PublishedDate_lb";
            this.PublishedDate_lb.Size = new System.Drawing.Size(86, 13);
            this.PublishedDate_lb.TabIndex = 4;
            this.PublishedDate_lb.Text = "Ngày Phát Hành";
            // 
            // Author_txt
            // 
            this.Author_txt.Location = new System.Drawing.Point(6, 113);
            this.Author_txt.Name = "Author_txt";
            this.Author_txt.ReadOnly = true;
            this.Author_txt.Size = new System.Drawing.Size(261, 20);
            this.Author_txt.TabIndex = 3;
            // 
            // Author_lb
            // 
            this.Author_lb.AutoSize = true;
            this.Author_lb.Location = new System.Drawing.Point(6, 97);
            this.Author_lb.Name = "Author_lb";
            this.Author_lb.Size = new System.Drawing.Size(67, 13);
            this.Author_lb.TabIndex = 2;
            this.Author_lb.Text = "Tên Tác Giả";
            // 
            // Name_txt
            // 
            this.Name_txt.Location = new System.Drawing.Point(6, 48);
            this.Name_txt.Name = "Name_txt";
            this.Name_txt.ReadOnly = true;
            this.Name_txt.Size = new System.Drawing.Size(261, 20);
            this.Name_txt.TabIndex = 1;
            // 
            // Name_lb
            // 
            this.Name_lb.AutoSize = true;
            this.Name_lb.Location = new System.Drawing.Point(6, 32);
            this.Name_lb.Name = "Name_lb";
            this.Name_lb.Size = new System.Drawing.Size(54, 13);
            this.Name_lb.TabIndex = 0;
            this.Name_lb.Text = "Tên Sách";
            // 
            // Thumbnail_pic
            // 
            this.Thumbnail_pic.Location = new System.Drawing.Point(12, 12);
            this.Thumbnail_pic.Name = "Thumbnail_pic";
            this.Thumbnail_pic.Size = new System.Drawing.Size(455, 399);
            this.Thumbnail_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Thumbnail_pic.TabIndex = 1;
            this.Thumbnail_pic.TabStop = false;
            // 
            // BookInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Thumbnail_pic);
            this.Controls.Add(this.BookInfor_grp);
            this.Name = "BookInfor";
            this.Text = "BookInfor";
            this.BookInfor_grp.ResumeLayout(false);
            this.BookInfor_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox BookInfor_grp;
        private System.Windows.Forms.TextBox Author_txt;
        private System.Windows.Forms.Label Author_lb;
        private System.Windows.Forms.TextBox Name_txt;
        private System.Windows.Forms.Label Name_lb;
        private System.Windows.Forms.TextBox Description_txt;
        private System.Windows.Forms.Label Description_lb;
        private System.Windows.Forms.TextBox PublishedDate_txt;
        private System.Windows.Forms.Label PublishedDate_lb;
        private System.Windows.Forms.PictureBox Thumbnail_pic;
    }
}