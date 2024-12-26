using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excercise_2
{
    public   class BookShelf
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("volumeCount")]
        public int BookCount { get; set; }

    }
    public class ShelvesResponse
    {
        [JsonProperty("items")]
        public List<BookShelf> Items { get; set; }
    }
}
