using Bokhandel;
using Bokhandel.Models;

namespace Labb03DB.Exe
{
    internal class AddToStore
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {
                ListBooks.Display();
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

                ListStores.Display();
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
            #region ControlMethods
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
            #endregion

        }
    }
}
