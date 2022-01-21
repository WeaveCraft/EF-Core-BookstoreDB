using Labb03DB;
using Labb03DB.Exe;

namespace Bokhandel
{
    public class PrintMenu
    {
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1 See List of Availiable Languages");
                Console.WriteLine("2 See List of Availiable Books");
                Console.WriteLine("3 See List of Availiable Authors");
                Console.WriteLine("4 See List of Availiable Bookstores");
                Console.WriteLine("5 See List of Available Stock Value");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("6 Add Book to a Specific Store");
                Console.WriteLine("7 Add New Book to a Specific Author");
                Console.WriteLine();
                Console.WriteLine("8 Delete book");
                Console.WriteLine("9 Delete books from store");
                Console.WriteLine();
                Console.WriteLine("10 Update Book");
                Console.WriteLine();
                Console.WriteLine("0 Add Test Data");

                try
                {
                    int userInput = CheckInputInt(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                            Console.Clear();
                            DisplayLanguages.Display();
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.Clear();
                            DisplayBook.Display();
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.Clear();
                            DisplayAuthors.Display();
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.Clear();
                            DisplayStores.Display();
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            ShowStocks.Display();
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.Clear();
                            AddToStore.Display();
                            Console.ReadKey();
                            break;

                        case 7:
                            Console.Clear();
                            AddBook.Display();
                            Console.ReadKey();
                            break;

                        case 8:
                            Console.Clear();
                            DeleteBook.Display();
                            Console.ReadKey();
                            break;

                        case 9:
                            Console.Clear();
                            DeleteBookFromStore.Display();
                            Console.ReadKey();
                            break;

                        case 10:
                            Console.Clear();
                            UpdateBook.Display();
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.Clear();
                            AddData.Display();
                            Console.ReadKey();
                            break;

                        default:
                            MainMenu();
                            break;
                    }
                }
                catch (Exception)
                {
                    MainMenu();
                    throw;
                }
            }
        }
        public static int CheckInputInt(string input)
        {
            bool inputInt = int.TryParse(input, out int result);

            while (result < 0 || inputInt == false)
            {
                Console.Write("Invalid, try again: ");
                input = Console.ReadLine();
                Console.WriteLine();
                inputInt = int.TryParse(input, out result);
            }
            return result;
        }
    }
}
