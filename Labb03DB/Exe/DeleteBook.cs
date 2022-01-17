using Bokhandel;
using Microsoft.EntityFrameworkCore;

namespace Labb03DB.Exe
{
    internal class DeleteBook
    {
        public static void Display()
        {
            ListBooks.Display();
            Console.WriteLine();
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
    }
}
