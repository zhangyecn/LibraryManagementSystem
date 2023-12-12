namespace LibraryManagementSystem;

public class Book : Item
{
    private static List<Book> _books = new List<Book>();
    public List<string> Authors { get; set; } = new List<string>();
    public string Publisher { get; set; }
    public int PublicationYear { get; set; }
    public int Pages { get; set; }
    public Location Location { get; set; }

    public static List<Book> ReadBooks(string input)
    {
        var bookInfoList = input.Split("Book:", StringSplitOptions.RemoveEmptyEntries);
        foreach (var bookInfo in bookInfoList)
        {
            var book = new Book();
            var bookProperties = bookInfo.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                
            foreach (var prop in bookProperties)
            {
                var p = prop.Split(":", StringSplitOptions.TrimEntries);
                switch (p[0])
                {
                    case "Author":
                        book.Authors.Add(p[1]);
                        break;
                    case "Title":
                        book.Title = p[1];
                        break;
                    case "Publisher":
                        book.Publisher = p[1];
                        break;
                    case "Published":
                        if (int.TryParse(p[1], out var year))
                        {
                            book.PublicationYear = year;
                        }
                        else
                        {
                            throw new Exception("Error: Input to published year is not a number!");
                        }
                        break;
                    case "NumberOfPages":
                        if (int.TryParse(p[1], out var pages))
                        {
                            book.Pages = pages;
                        }
                        else
                        {
                            throw new Exception("Error: Input to page number is not a number!");
                        }
                        break;
                    default:
                        break;
                }
            }
            _books.Add(book);
        }
        return _books;
    }

    public static List<Book> FindBooks(string searchString)
    {
        var foundedBooks = _books;
        var searchValues = searchString.Split("&", StringSplitOptions.TrimEntries);  
            
        if (searchValues.Length > 0)
        {
            searchValues = searchValues.Select(s => s.Replace("*", "")).ToArray();
            //foreach (var searchValue in searchValues)
            //{
            //    foundedBooks = SearchInBooks(searchValue, foundedBooks);
            //}

            //return foundedBooks;
            return searchValues.Aggregate(foundedBooks, (current, searchValue) => SearchInBooks(searchValue, current));
        }
        else { return foundedBooks; }
    }

    private static List<Book> SearchInBooks(string searchString, List<Book> books)
    {
        return books.FindAll(b => b.Title.Contains(searchString)
                                  || b.Authors.Any(a => a.Contains(searchString))
                                  || b.Publisher.Contains(searchString)
                                  || b.PublicationYear.ToString().Contains(searchString));
    }
}