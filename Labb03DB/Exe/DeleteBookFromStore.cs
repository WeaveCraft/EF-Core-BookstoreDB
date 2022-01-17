using Bokhandel;

namespace Labb03DB.Exe
{
    internal class DeleteBookFromStore
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {

                ListBooks.Display();
                Console.WriteLine();
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

                ListStores.Display();
                Console.WriteLine();
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
                    Console.WriteLine("All books have been deleted!");
                    Console.ReadLine();
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
