using Microsoft.EntityFrameworkCore;
using Bokhandel.Models;

namespace Bokhandel
{
    public class Exe
    {
        public void PrintMenu()
        {

            string[] j = new string[] {
                "See List of Availiable Languages",
                "See List of Availiable Books",
                "See List of Availiable Authors",
                "See List of Availiable Bookstores",
                "See List of Available Stock Value ",
                " ",
                " ",
                "Add Book to a Specific Store",
                "Add New Book to a Specific Author",
                " ",
                "Delete book",
                "Delete books from store (Plural)",
                " ",
                "Update Book",
                " ",
                "Add Test Data",
                "", };

            int menyVal = 0;
            while (menyVal != j.Length + 1)
            {
                Console.Clear();

                for (int i = 0; i < j.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {j[i]}");
                }
                Console.WriteLine($"[{j.Length + 1}] Exit");

                menyVal = CheckInputInt(Console.ReadLine());

                Console.Clear();

                switch (menyVal)
                {
                    case 1:
                        {
                            ListLanguages();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            ListBooks();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            ListAuthors();
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            ListStores();
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            ShowStocks();
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            AddToStore();
                            Console.ReadKey();
                            break;
                        }
                    case 9:
                        {
                            AddBook();
                            Console.ReadKey();
                            break;
                        }
                    case 11:
                        {
                            DeleteBook();
                            Console.ReadKey();
                            break;
                        }
                    case 12:
                        {
                            DeleteBookFromStore();
                            Console.ReadKey();
                            break;
                        }
                    case 14:
                        {
                            UpdateBook();
                            Console.ReadKey();
                            break;
                        }
                    case 16:
                        {
                            try
                            {
                                using (var context = new BokhandelDBcontext())
                                {
                                    bool test = context.Books.Any();

                                    if (test != true)
                                    {
                                        AddTestData();
                                    }
                                    else
                                        Console.WriteLine("Data Added\nPress Any Key...");
                                }

                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Data Now Exists");
                            }
                            Console.ReadLine();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error");
                            Console.ReadLine();
                            break;
                        }
                }
            }

        }
        void AddTestData() 
        {
            TestData.AddLanguages();
            TestData.AddAuthorswithBooks();
            TestData.AddStarterStores();
            TestData.AddStarterToStores();
        }


        #region Add

        void AddToStore()
        {
            using (var context = new BokhandelDBcontext())
            {
                ListBooks();
                Console.Write("Book ID: ");
                ulong id = CheckInputUlong(Console.ReadLine());
                bool book = context.Books.Any(x => x.Id == id);
                if (book != true)
                {
                    Console.WriteLine("Error");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine();

                ListStores();
                Console.Write("Select Store: ");
                int storeId = CheckInputInt(Console.ReadLine());
                bool store = context.Stores.Any(x => x.Id == storeId);
                if (store != true)
                {
                    Console.WriteLine("Error");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine();

                Console.WriteLine("Book Quantity: ");
                int quantity = CheckInputInt(Console.ReadLine());

                var search = context.Stocks.Where(x => x.Store_Id == storeId && x.Book_Id == id).FirstOrDefault();
                if (search == null)
                {
                    var nr = new Stock
                    {
                        Store_Id = storeId,
                        Book_Id = id,
                        Quantity = quantity
                    };
                    context.Add(nr);
                    context.SaveChanges();
                }
                else
                {
                    search.Quantity += quantity;
                    context.SaveChanges();
                }

            }
        }
        void AddBook()
        {
            using (var context = new BokhandelDBcontext())
            {

                ListAuthors();
                string x = SaveInput("Select Author: ");
                int author = CheckInputInt(x);

                var tempAuthor = context.Authors.Find(author);
                if (author != null)
                {

                    string title = SaveInput("Select Title: ");

                    string tempPrice = SaveInput("Select Price: ");
                    decimal price = CheckInputDecimal(tempPrice);

                    ListLanguages();
                    string tempLanguage = SaveInput("Select Language: ");
                    int languageId = CheckInputInt(tempLanguage);
                    var language = context.Languages.Find(languageId);
                    if (language != null)
                    {
                        tempAuthor.Books.Add(new Book() { Title = title, Price = price, LanguageId = languageId, AuthorId = author });
                        context.SaveChanges();

                    }
                    else
                    {
                        Console.WriteLine("Can't find an Author with that name");
                        Console.ReadLine();
                    }

                }
                else
                {
                    Console.WriteLine("Can't find an Author with that ID");
                    Console.ReadLine();

                }
            }
        }
        #endregion

        #region Update
        void UpdateBook()
        {
            ListBooks();
            Console.Write("Select Book: ");
            string newBookId = Console.ReadLine();
            ulong updatedBookId = CheckInputUlong(newBookId);

            using (var context = new BokhandelDBcontext())
            {

                var author = context.Books.Find(updatedBookId);
                if (author != null)
                {
                    string newDate = SaveInput("Select New Date (YYYY-MM-DD): ");
                    DateTime updatedDate = NewDate(newDate);

                    string newTitle = SaveInput("Select Title: ");

                    ListAuthors();
                    string newAuthor = SaveInput("Select Author ID: ");
                    int newAuthorId = CheckInputInt(newAuthor);
                    var testAuthor = context.Authors.Find(newAuthorId);
                    if (testAuthor == null)
                    {
                        Console.WriteLine("Error");
                        Console.ReadLine();
                        return;
                    }

                    ListLanguages();
                    string newLanguage = SaveInput("Select Language:");
                    int newLanguageId = CheckInputInt(newLanguage);
                    var tempLanguage = context.Languages.Find(newLanguageId);

                    if (tempLanguage == null)
                    {
                        Console.WriteLine("Error");
                        Console.ReadLine();
                        return;
                    }

                    string price = SaveInput("Select Price: ");
                    decimal newUpdatedPrice = CheckInputDecimal(price);

                    author.Title = newTitle;
                    author.Price = newUpdatedPrice;
                    author.PublisherDate = updatedDate;
                    author.LanguageId = newLanguageId;
                    author.AuthorId = newAuthorId;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Book not found");
                    Console.ReadLine();
                }
            }
        }
        DateTime NewDate(string input)
        {
            try
            {
                DateTime date = Convert.ToDateTime(input);
                return date;
            }
            catch
            {
                return Convert.ToDateTime("2000-01-01");
            }
        }

        #endregion

        #region Delete
        void DeleteBook()
        {
            ListBooks();
            Console.Write("Select Book ID: ");
            string input = Console.ReadLine();
            bool boolInput = ulong.TryParse(input, out ulong checkInput);

            while (boolInput != true)
            {
                Console.WriteLine("Invalid Number");
                input = Console.ReadLine();
                boolInput = ulong.TryParse(input, out checkInput);
            }
            using (var context = new BokhandelDBcontext())
            {
                var book = context.Books.Find(checkInput);

                if (book != null)
                {
                    context.Entry(book).State = EntityState.Deleted;
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Error");
                    Console.ReadLine();
                }

            }
            Console.WriteLine("\nDeleted\nPress Any Key to Continue...");

        }
        void DeleteBookFromStore()
        {
            using (var context = new BokhandelDBcontext())
            {

                ListBooks();
                Console.Write("Type in a Book ID: ");
                ulong id = CheckInputUlong(Console.ReadLine());
                bool ifFindBook = context.Books.Any(x => x.Id == id);
                if (ifFindBook != true)
                {
                    Console.WriteLine("Could not find book!");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine();

                ListStores();
                Console.Write("Select Store: ");
                int storeId = CheckInputInt(Console.ReadLine());
                bool ifFindStore = context.Stores.Any(x => x.Id == storeId);
                if (ifFindStore != true)
                {
                    Console.WriteLine("Could not find store");
                    Console.ReadLine();
                    return;
                }



                var track = context.Stocks.Where(x => x.Store_Id == storeId && x.Book_Id == id).FirstOrDefault();
                if (track != null)
                {
                    context.Remove(track);
                    context.SaveChanges();
                    Console.WriteLine("Alla böckerna borttagna!");
                    Console.ReadLine();
                }
            }
        }
        #endregion

        #region SQL
        void ShowStocks()
        {
            using (var context = new BokhandelDBcontext())
            {
                var data = (from b in context.Books
                            join s in context.Stocks
                             on b.Id equals s.Book_Id
                            join q in context.Stores
                            on s.Store_Id equals q.Id into left
                            from left2 in left.DefaultIfEmpty()
                            select new
                            {
                                StoreName = (left2 == null ? "null" : left2.StoreName),
                                StockAmount = s.Quantity,
                                BookName = b.Title
                            }).ToList();
                foreach (var item in data)
                {
                    Console.WriteLine($"Store Name: {item.StoreName}\n Quantity: {item.StockAmount}\n Title: {item.BookName}");
                }
            }
        }
        #endregion

        #region Control
        ulong CheckInputUlong(string input)
        {
            bool x = ulong.TryParse(input, out ulong result);
            while (result < 0 || x == false)

            {
                Console.WriteLine("Invalid, try again: ");
                input = Console.ReadLine();
                x = ulong.TryParse(input, out result);
            }
            return result;

        }
        int CheckInputInt(string input)
        {
            bool x = int.TryParse(input, out int result);
            while (result < 0 || x == false)
            {
                Console.Write("Invalid, try again: ");
                input = Console.ReadLine();
                Console.WriteLine();
                x = int.TryParse(input, out result);
            }
            return result;
        }

        decimal CheckInputDecimal(string input)
        {
            bool x = decimal.TryParse(input, out decimal result);
            while (result < 0 || x == false)

            {
                Console.WriteLine("Invalid, try again: ");
                input = Console.ReadLine();
                x = decimal.TryParse(input, out result);
            }
            return result;
        }

        string SaveInput(string input)
        {
            Console.Write($"{input}: ");
            string output = Console.ReadLine();
            return output;
        }

        #endregion

        #region List
        void ListLanguages()
        {
            using (var context = new BokhandelDBcontext())
            {
                var language = context.Languages
                    .ToList();

                foreach (var item in language)
                {
                    Console.WriteLine($"{item.Id} {item.LanguageName}");
                }
            }
        }
        void ListAuthors()
        {
            using (var context = new BokhandelDBcontext())
            {
                var allAuthors = context.Authors.ToList();
                foreach (var item in allAuthors)
                {
                    Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.DateofBirth}");
                }
            }
        }
        void ListBooks()
        {
            using (var context = new BokhandelDBcontext())
            {
                var books = context.Books.ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, AuthorsId: {item.AuthorId} ");
                }
            }
        }
        void ListStores()
        {
            using (var context = new BokhandelDBcontext())
            {
                var store = context.Stores.ToList();
                foreach (var item in store)
                {
                    Console.WriteLine($"{item.Id}: {item.StoreName}, {item.StoreAddress}");
                }
            }
        }

        #endregion

    }
}
