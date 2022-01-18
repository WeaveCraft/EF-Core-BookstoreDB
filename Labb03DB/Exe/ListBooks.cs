using Bokhandel;

namespace Labb03DB.Exe
{
    internal class ListBooks
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {
                var books = context.Books.ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"Book ID: {item.Id} \nBook Title: {item.Title} \nAuthors ID: {item.AuthorId} ");
                    Console.WriteLine();
                }
            }
        }
    }
}
