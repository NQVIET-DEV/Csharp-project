using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excercise_2
{
    public partial class BookInfor : Form
    {
        public BookInfor(Book book)
        {
            InitializeComponent();
            Name_txt.Text = book.Title;
            Author_txt.Text = book.Authors;
            PublishedDate_txt.Text = book.PublishedDate;
            Description_txt.Text = book.Description;
            if (!string.IsNullOrEmpty(book.Thumbnail))
            {
                Thumbnail_pic.Load(book.Thumbnail);
            }
            else
            {
                Thumbnail_pic.Image = null; // Hình ảnh mặc định
            }
        }
    }
}
