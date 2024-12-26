using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using Google.Apis.Auth.OAuth2;

namespace excercise_2
{
    public partial class FindBook : Form
    {
        private string apiKey = "AIzaSyA02f3GRfEboWT2M4Rg_kgX_LGgyqZV7uE";
        private string accessToken;
        private string Username;
        private string Email;
        private bool isFirstLoad = true;
        private Book selectedBook;
        private BookShelf selectedShelf;
        private List<BookShelf> bookShelves = new List<BookShelf>();
        private List<Book> Books = new List<Book>();
     
        public FindBook(string username, string email)
        {
            Username = username;
            Email = email;
            InitializeComponent();
            OAuth(email);
            Username_txt.Text = Username;
            Email_txt.Text = Email;
        }

        //lấy mã xác thực
        private async void OAuth(string email)
        {
            try
            {
                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = "1065370628148-keskipl391b4lthrpc6rksahkeus06on.apps.googleusercontent.com",
                        ClientSecret = "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"
                    },
                    new[] { "https://www.googleapis.com/auth/books","email" },
                    email,
                    CancellationToken.None
                );

                accessToken = await credential.GetAccessTokenForRequestAsync();

                if (string.IsNullOrEmpty(accessToken))
                {
                    MessageBox.Show("Lỗi xác thực! Không thể lấy access token.");
                }
                else
                {
                    MessageBox.Show("Xác thực thành công! Access token đã được lấy.");
                    Console.WriteLine($"Access Token: {accessToken}");
                    Console.WriteLine($"User Email: {email}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi OAuth: {ex.Message}");
            }
        }
        // nút tìm sách
        private async void Search_btn_Click(object sender, EventArgs e)
        {
            string keyword = Search_txt.Text;
            if (!string.IsNullOrEmpty(keyword))
            {
                var books = await SearchBooks(keyword);
                DisplayBooks(books);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }
        //hàm tìm sách
        private async Task<List<Book>> SearchBooks(string keyword)
        {

            string url = $"https://www.googleapis.com/books/v1/volumes?q={keyword}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<GoogleBooksResponse>(response);
                return data.Items.Select(item => new Book
                {
                    Id = item.Id,
                    Title = item.VolumeInfo.Title ?? "Chưa có tiêu đề",
                    Authors = item.VolumeInfo.Authors != null ? string.Join(", ", item.VolumeInfo.Authors) : "Chưa có tác giả",
                    Description = item.VolumeInfo.Description ?? "Không có mô tả",
                    PublishedDate = item.VolumeInfo.PublishedDate ?? "Chưa có thông tin",
                    Thumbnail = item.VolumeInfo.ImageLinks?.Thumbnail
                }).ToList();
            }
        }
        //hiển thị sách lên datagridview
        private void DisplayBooks(List<Book> books)
        {
            Books = books;
            dgvBooks.Rows.Clear();
            foreach (var book in books)
            {
                dgvBooks.Rows.Add(book.Title, book.Authors, book.PublishedDate);
            }
        }
        //hiển thị chi tiết sách
        private async void DgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
                return;
            }

            if (dgvBooks.SelectedRows.Count > 0)
            {
                var rowIndex = dgvBooks.SelectedRows[0].Index;
                selectedBook = Books[rowIndex];
                if (!string.IsNullOrEmpty(selectedBook.Id))
                {

                    var bookDetail = await GetBookDetails(selectedBook.Id);

                    if (bookDetail != null)
                    {
                        BookInfor detailForm = new BookInfor(bookDetail);
                        detailForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin chi tiết của cuốn sách.");
                    }
                }
            }
        }

        //hàm lấy chi tiết sách
        private async Task<Book> GetBookDetails(string id)
        {

            string url = $"https://www.googleapis.com/books/v1/volumes?q={id}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<GoogleBooksResponse>(response);


                var item = data.Items?.FirstOrDefault();

                if (item != null)
                {
                    return new Book
                    {
                        Id = item.Id,
                        Title = item.VolumeInfo.Title,
                        Authors = string.Join(", ", item.VolumeInfo.Authors),
                        Description = item.VolumeInfo.Description,
                        PublishedDate = item.VolumeInfo.PublishedDate,
                        Thumbnail = item.VolumeInfo.ImageLinks?.Thumbnail
                    };
                }
            }

            return null;
        }

        //chọn kệ sách 
        private  void DgvShelves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                selectedShelf = bookShelves[e.RowIndex];
            }
        }
        //nút thêm sách vào kệ
        private async void AddBook_btn_Click(object sender, EventArgs e)
        {
            if (selectedBook != null && selectedShelf != null)
            {
                bool success = await AddBookToShelf(selectedShelf.Id, selectedBook.Id);
                if (success)
                {
                    MessageBox.Show("Đã thêm sách vào kệ thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể thêm sách vào kệ.");
                }
            }
            else if (selectedBook == null)
            {
                MessageBox.Show("Vui lòng chọn sách.");
            }
            else if (selectedShelf == null)
            {
                MessageBox.Show("Vui lòng chọn kệ  sách.");
            }
        }
        //hàm thêm sách vào kệ
        private async Task<bool> AddBookToShelf(string shelfId, string volumeId)
        {
            string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/addVolume?volumeId={volumeId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.PostAsync(url, null);
                return response.IsSuccessStatusCode;
            }
        }

        //nút hiển thị sách trong kệ
        private async void Display_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                List<BookShelf> bookshelves = await GetBookshelves(accessToken);
                DisplayShelves(bookshelves);
            }
            else
            {
                MessageBox.Show("Không có access token.");
            }

        }
        //hàm hiển thị kệ lên datagridview
        private void DisplayShelves(List<BookShelf> shelves)
        {
            bookShelves = shelves;
            dgvShelves.Rows.Clear();

            foreach (var shelf in shelves)
            {
                dgvShelves.Rows.Add(shelf.Title, shelf.Description, shelf.BookCount);
            }
        }

        //hàm để lấy kệ sách
        private async Task<List<BookShelf>> GetBookshelves(string accesstoken)
        {
            string url = "https://www.googleapis.com/books/v1/mylibrary/bookshelves";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var bookshelves = JsonConvert.DeserializeObject<ShelvesResponse>(responseData);
                    return bookshelves.Items;
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin kệ sách.");
                    return null;
                }
            }
        }
        //nút để show sách có trong kệ
        private async void BookInShelf_btn_Click(object sender, EventArgs e)
        {
            if (selectedShelf != null)
            {
                List<Book> booksInShelf = await GetBooksInShelf(selectedShelf.Id); 
                DisplayBooks(booksInShelf); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một kệ sách.");
            }
        }
        //hàm để show sách trong kệ
        private async Task<List<Book>> GetBooksInShelf(string shelfId)
        {
            string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/volumes";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GoogleBooksResponse>(responseData);

                    return data.Items?.Select(item => new Book
                    {
                        Id = item?.Id ?? "Không có ID", 
                        Title = item?.VolumeInfo?.Title ?? "Chưa có tiêu đề",  
                        Authors = item?.VolumeInfo?.Authors != null ? string.Join(", ", item.VolumeInfo.Authors) : "Chưa có tác giả",  
                        Description = item?.VolumeInfo?.Description ?? "Không có mô tả",  
                        PublishedDate = item?.VolumeInfo?.PublishedDate ?? "Chưa có thông tin",  
                        Thumbnail = item?.VolumeInfo?.ImageLinks?.Thumbnail  
                    }).ToList() ?? new List<Book>();
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin sách trong kệ.");
                    return new List<Book>();
                }
            }
        }
        //nút xóa sách trong kệ
        private async void Delete_btn_Click(object sender, EventArgs e)
        {
            if (selectedBook != null && selectedShelf != null)
            {
                bool success = await DeleteFromShelf(selectedShelf.Id, selectedBook.Id);
                if (success)
                {
                    MessageBox.Show("Đã xóa sách khỏi  kệ thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể xóa sách khỏi  kệ.");
                }
            }
            else if (selectedBook == null)
            {
                MessageBox.Show("Vui lòng chọn sách.");
            }
            else if (selectedShelf == null)
            {
                MessageBox.Show("Vui lòng chọn kệ  sách.");
            }
        }
        //hàm xóa sách trong kệ 
        private async Task<bool> DeleteFromShelf(string shelfId, string volumeId)
        {
            string url = $"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{shelfId}/removeVolume?volumeId={volumeId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.PostAsync(url, null);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
