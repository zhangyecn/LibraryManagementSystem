using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Inventory
    {
        private List<Book> _books = new List<Book>();
        private Dictionary<string, Location> _isbnLocationMap = new Dictionary<string, Location>();
        private Dictionary<Location, List<Book>> _locationBooksMap = new Dictionary<Location, List<Book>>();

        public void RegisterBook(Book book)
        {
            _books.Add(book);
            _isbnLocationMap.Add(book.Isbn, book.Location);
            if (_locationBooksMap.TryGetValue(book.Location, out List<Book> books))
            {
                books.Add(book);
            }
            else
            {
                _locationBooksMap.Add(book.Location, new List<Book>() { book });
            }
        }

        public List<Book>? MakeInventoryListByLocation(Location loc)
        {
            _locationBooksMap.TryGetValue(loc, out var bookList);
            return bookList;
        }

        public Location? GetBookLocationByIsbn(string isbn)
        {
            _isbnLocationMap.TryGetValue(isbn, out var location);
            return location;
        }
    }
}
