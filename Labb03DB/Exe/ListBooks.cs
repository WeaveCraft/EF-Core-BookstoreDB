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
                    Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, AuthorsId: {item.AuthorId} ");
                }
            }
        }
    }
}
