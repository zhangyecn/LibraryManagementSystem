using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Location
    {
        public int RoomNo { get; set; }
        public int RowNo { get; set; }
        public int BookShelfNo { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Location other &&
                   (this.RoomNo == other.RoomNo &&
                    this.RowNo == other.RowNo &&
                    this.BookShelfNo == other.BookShelfNo);
        }
    }
}
