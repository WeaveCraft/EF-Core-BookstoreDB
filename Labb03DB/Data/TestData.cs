using Bokhandel.Models;

namespace Bokhandel
{
    public static class TestData
    {
        public static void AddBookswithAuthors()
        {
            using (var context = new BokhandelDBcontext())
            {

                    Author author01 = new Author
                    {
                        FirstName = "Viktor",
                        LastName = "Hurtig",
                        DateofBirth = new DateTime(1994, 01, 14)
                    };
                    Author author02 = new Author
                    {
                        FirstName = "Fatima",
                        LastName = "Payes",
                        DateofBirth = new DateTime(1993, 03, 15)
                    };
                    Author author03 = new Author
                    {
                        FirstName = "Rocelia",
                        LastName = "Hernandez",
                        DateofBirth = new DateTime(1995, 01, 01)
                    };
                    Author author04 = new Author
                    {
                        FirstName = "Alex",
                        LastName = "Nordfjäll",
                        DateofBirth = new DateTime(1994, 08, 11)
                    };
                    Author author05 = new Author
                    {
                        FirstName = "Akiko",
                        LastName = "Saito",
                        DateofBirth = new DateTime(1993, 04, 23)
                    };
                    Book book01 = new Book
                    {
                        Title = "Book01",
                        Price = 195,
                        LanguageId = 4,
                        AuthorId = 1,
                        PublisherDate = new DateTime(2010, 05, 15)

                    };
                    Book book02 = new Book
                    {
                        Title = "Book02",
                        Price = 125,
                        LanguageId = 1,
                        AuthorId = 1,
                        PublisherDate = new DateTime(2011, 06, 25)
                    };
                    Book book03 = new Book
                    {
                        Title = "Book03",
                        Price = 125,
                        LanguageId = 1,
                        AuthorId = 2,
                        PublisherDate = new DateTime(2015, 09, 01)
                    };
                    Book book04 = new Book
                    {
                        Title = "Book04",
                        Price = 195,
                        LanguageId = 2,
                        AuthorId = 2,
                        PublisherDate = new DateTime(2020, 01, 04)
                    };
                    Book book05 = new Book
                    {
                        Title = "Book05",
                        Price = 155,
                        LanguageId = 2,
                        AuthorId = 3,
                        PublisherDate = new DateTime(2010, 04, 01)
                    };
                    Book book06 = new Book
                    {
                        Title = "Book06",
                        Price = 125,
                        LanguageId = 3,
                        AuthorId = 3,
                        PublisherDate = new DateTime(2011, 06, 07)
                    };
                    Book book07 = new Book
                    {
                        Title = "Book07",
                        Price = 50,
                        LanguageId = 1,
                        AuthorId = 4,
                        PublisherDate = new DateTime(2012, 07, 07)
                    };
                    Book book08 = new Book
                    {
                        Title = "Book08",
                        Price = 95,
                        LanguageId = 2,
                        AuthorId = 4,
                        PublisherDate = new DateTime(2013, 06, 27)
                    };
                    Book book09 = new Book
                    {
                        Title = "Book09",
                        Price = 55,
                        LanguageId = 2,
                        AuthorId = 5,
                        PublisherDate = new DateTime(2015, 10, 16)
                    };
                    Book book10 = new Book
                    {
                        Title = "Book10",
                        Price = 75,
                        LanguageId = 5,
                        AuthorId = 5,
                        PublisherDate = new DateTime(2020, 12, 24)
                    };
                    author01.Books = new List<Book> { book01, book02 };
                    author02.Books = new List<Book> { book03, book04 };
                    author03.Books = new List<Book> { book05, book06 };
                    author04.Books = new List<Book> { book07, book08 };
                    author05.Books = new List<Book> { book09, book10 };
                    context.AddRange(author01, author02, author03, author04, author05);
                    context.SaveChanges();
            }
        }

        public static void AddStores()
        {
            using (var context = new BokhandelDBcontext())
            {
                var stores = new List<Store>()
        {
            new Store()
            {
                StoreName = "Store01",
                StoreAddress = "First Store 111"
            },
            new Store()
            {
                StoreName = "Store02",
                StoreAddress = "Second Store 222"
            },
            new Store()
            {
                StoreName = "Store03",
                StoreAddress = "Third Store 333"
            }
        };
                context.Stores.AddRange(stores);
                context.SaveChanges();
            }
        }

        public static void AddStock()
        {

            using (var context = new BokhandelDBcontext())
            {
                var stock = new List<Stock>()
                {
                    new Stock()
                    {
                        Book_Id = 1,
                        Store_Id = 1,
                        Quantity = 35
                    },
                    new Stock()
                    {
                        Book_Id = 1,
                        Store_Id = 2,
                        Quantity = 21
                    },
                     new Stock()
                    {
                        Book_Id = 1,
                        Store_Id = 3,
                        Quantity = 3
                    },
                      new Stock()
                    {
                        Book_Id = 2,
                        Store_Id = 1,
                        Quantity = 6
                    },
                     new Stock()
                    {
                        Book_Id = 2,
                        Store_Id = 2,
                        Quantity = 7
                    },
                      new Stock()
                    {
                        Book_Id = 2,
                        Store_Id = 3,
                        Quantity = 3
                    },
                     new Stock()
                    {
                        Book_Id = 3,
                        Store_Id = 1,
                        Quantity = 4
                    },
                      new Stock()
                    {
                        Book_Id = 3,
                        Store_Id = 2,
                        Quantity = 6
                    },
                     new Stock()
                    {
                        Book_Id = 3,
                        Store_Id = 3,
                        Quantity = 5
                    },
                     new Stock()
                    {
                        Book_Id = 4,
                        Store_Id = 1,
                        Quantity = 1
                    },
                     new Stock()
                    {
                        Book_Id = 4,
                        Store_Id = 2,
                        Quantity = 32
                    },
                      new Stock()
                    {
                        Book_Id = 4,
                        Store_Id = 3,
                        Quantity = 2
                    },
                     new Stock()
                    {
                        Book_Id = 5,
                        Store_Id = 1,
                        Quantity = 81
                    },
                     new Stock()
                    {
                        Book_Id = 5,
                        Store_Id = 2,
                        Quantity = 18
                    },
                     new Stock()
                    {
                        Book_Id = 5,
                        Store_Id = 3,
                        Quantity = 19
                    },
                     new Stock()
                    {
                        Book_Id = 6,
                        Store_Id = 1,
                        Quantity = 15
                    },
                     new Stock()
                    {
                        Book_Id = 6,
                        Store_Id = 2,
                        Quantity = 23
                    },
                     new Stock()
                    {
                        Book_Id = 6,
                        Store_Id = 3,
                        Quantity = 3
                    },
                     new Stock()
                    {
                        Book_Id = 7,
                        Store_Id = 1,
                        Quantity = 66
                    },
                     new Stock()
                    {
                        Book_Id = 7,
                        Store_Id = 2,
                        Quantity = 65
                    },
                     new Stock()
                    {
                        Book_Id = 7,
                        Store_Id = 3,
                        Quantity = 45
                    },
                     new Stock()
                    {
                        Book_Id = 8,
                        Store_Id = 1,
                        Quantity = 88
                    },
                     new Stock()
                    {
                        Book_Id = 8,
                        Store_Id = 2,
                        Quantity = 35
                    },
                     new Stock()
                    {
                        Book_Id = 8,
                        Store_Id = 3,
                        Quantity = 21
                    },
                       new Stock()
                    {
                        Book_Id = 9,
                        Store_Id = 1,
                        Quantity = 1
                    },
                      new Stock()
                    {
                        Book_Id = 9,
                        Store_Id = 2,
                        Quantity = 2
                    },
                      new Stock()
                    {
                        Book_Id = 9,
                        Store_Id = 3,
                        Quantity = 8
                    },
                     new Stock()
                    {
                        Book_Id = 10,
                        Store_Id = 1,
                        Quantity = 3
                    },
                      new Stock()
                    {
                        Book_Id = 10,
                        Store_Id = 2,
                        Quantity = 4
                    },
                       new Stock()
                    {
                        Book_Id = 10,
                        Store_Id = 3,
                        Quantity = 1
                    },

                };
                context.AddRange(stock);
                context.SaveChanges();
            }
        }

        public static void AddLanguages()
        {
            using (var context = new BokhandelDBcontext())
            {
                var language = new List<Language>()
    {
        new Language()
        {
            LanguageName = "Svenska"
        },
        new Language()
        {
            LanguageName = "Engelska"
        },
        new Language()
        {
            LanguageName = "Spanska"
        },
        new Language()
        {
            LanguageName = "Franska"
        },
        new Language()
        {
            LanguageName = "Japanska"
        }
    };
                context.Languages.AddRange(language);
                context.SaveChanges();
            }
        }

    }
}
