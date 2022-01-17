using Microsoft.EntityFrameworkCore;
using Bokhandel.Models;
using Labb03DB;
using Labb03DB.Exe;

namespace Bokhandel
{
    public class PrintMenu
    {
        public void Menu()
        {

            string[] menu = new string[] {
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
            while (menyVal != menu.Length + 1)
            {
                Console.Clear();

                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {menu[i]}");
                }
                Console.WriteLine($"[{menu.Length + 1}] Exit");

                menyVal = CheckInputInt(Console.ReadLine());

                Console.Clear();

                switch (menyVal)
                {
                    case 1:
                        {
                            ListLanguages.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            ListBooks.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            ListAuthors.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            ListStores.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            ShowStocks.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            AddToStore.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 9:
                        {
                            AddBook.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 11:
                        {
                            DeleteBook.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 12:
                        {
                            DeleteBookFromStore.Display();
                            Console.ReadKey();
                            break;
                        }
                    case 14:
                        {
                            UpdateBook.Display();
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
                                        BokhandelDBcontext.AddTestData();
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
    }
}
