using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excercise_2
{
    public class GoogleBooksResponse
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Id { get; set; }
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Description { get; set; }
        public string PublishedDate { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
    }
}
