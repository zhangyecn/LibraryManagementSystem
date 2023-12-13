using LibraryManagementSystem;

namespace LibrarySystemTest
{
    [TestClass]
    public class InventoryTests
    {
        private Inventory _inventory;
        private Book _book1, _book2, _book3;

        [TestInitialize]
        public void TestInitialize()
        {
            // Test Data Set
            _book1 = new Book
            {
                Title = "Test Book 1",
                Isbn = "978-3-16-148410-0",
                Downloadable = false,
                Authors =
                {
                    "Brian Jensen"
                },
                Publisher = "Gyldendal",
                PublicationYear = 2012,
                Pages = 145,
                Location = new Location()
                {
                    RoomNo = 1,
                    RowNo = 2,
                    BookShelfNo = 3
                },
            };
            _book2 = new Book
            {
                Title = "Test Book 2",
                Isbn = "998-0-46-153820-1",
                Downloadable = false,
                Authors =
                {
                    "Peter Jensen",
                    "Hans Andersen"
                },
                Publisher = "Bergen",
                PublicationYear = 2001,
                Pages = 253,
                Location = new Location()
                {
                    RoomNo = 2,
                    RowNo = 1,
                    BookShelfNo = 1
                },
            };
            _book3 = new Book
            {
                Title = "Test Book 3",
                Isbn = "911-1-56-258320-5",
                Downloadable = false,
                Authors =
                {
                    "Martin Hansen",
                    "Hans Christian"
                },
                Publisher = "Bergen",
                PublicationYear = 2001,
                Pages = 253,
                Location = new Location()
                {
                    RoomNo = 2,
                    RowNo = 1,
                    BookShelfNo = 1
                },
            };

            // Initialize Inventory Object
            _inventory = new Inventory();
            _inventory.RegisterBook(_book1);
            _inventory.RegisterBook(_book2);
            _inventory.RegisterBook(_book3);
        }

        [TestMethod]
        public void MakeInventoryListByLocation_LocationIsGiven_Book1Returned()
        {
            // Arrange
            var loc = new Location()
            {
                RoomNo = 1,
                RowNo = 2,
                BookShelfNo = 3
            };

            // Act
            var result = _inventory.MakeInventoryListByLocation(loc);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var book = result.First();
            Assert.AreEqual("Test Book 1", book.Title);
        }

        [TestMethod]
        public void MakeInventoryListByLocation_LocationIsGiven_Book2Book3Returned()
        {
            // Arrange
            var loc = new Location()
            {
                RoomNo = 2,
                RowNo = 1,
                BookShelfNo = 1
            };

            // Act
            var result = _inventory.MakeInventoryListByLocation(loc);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            //use Any because the returned book may be in different order:
            Assert.IsTrue(result.Any(book => book.Title == "Test Book 2"));
            Assert.IsTrue(result.Any(book => book.Title == "Test Book 3"));
        }

        [TestMethod]
        public void GetBookLocationByIsbn_ExistingIsbnIsGiven_BookLocationReturned()
        {
            // Arrange
            var isbn = _book2.Isbn;
            var expectedLocation = new Location()
            {
                RoomNo = 2,
                RowNo = 1,
                BookShelfNo = 1
            };

            // Act
            var loc = _inventory.GetBookLocationByIsbn(isbn);

            // Assert
            Assert.IsNotNull(loc);
            Assert.AreEqual(expectedLocation, loc);
        }

        [TestMethod]
        public void GetBookLocationByIsbn_NonexistingIsbnIsGiven_NullReturned()
        {
            // Arrange
            var isbn = "911-1-56-258320-4";

            // Act
            var loc = _inventory.GetBookLocationByIsbn(isbn);

            // Assert
            Assert.IsNull(loc);
        }
    }
}