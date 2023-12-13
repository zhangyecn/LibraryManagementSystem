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
}
