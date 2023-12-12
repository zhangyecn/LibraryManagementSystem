using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem
{
    public class Item
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public bool Downloadable { get; set; }
    }

    public enum MediaType
    {
        Cd = 0,
        Dvd,
        BlueRay
    }

    public class MultiMediaRecord
    {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class MultilMediaItem : Item
    {
        public ICollection<MultiMediaRecord> Tracks { get; set; }
        public MediaType Media { get; set; }
    }
}
