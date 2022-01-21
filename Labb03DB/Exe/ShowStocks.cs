using Bokhandel;

namespace Labb03DB
{
    internal class ShowStocks
    {
        public static void Display()
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



                    foreach (var items in data)
                    {
                        Console.WriteLine($"Store Name: {items.StoreName}\n  Title: {items.BookName}\nQuantity: {items.StockAmount}");
                    }
                }
        }
    }
}
