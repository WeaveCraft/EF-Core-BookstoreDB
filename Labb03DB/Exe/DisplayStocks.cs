using Bokhandel;

namespace Labb03DB
{
    internal class DisplayStocks
    {
        public static void Display()
        {
                using (var context = new BokhandelDBcontext())

                {

                    var data = (from b in context.Books
                                join s in context.Stocks
                                 on b.Id equals s.Book_Id
                                join q in context.Stores
                                on s.Store_Id equals q.Id into right
                                from right2 in right.DefaultIfEmpty()
                                select new 
                                {
                                    StoreName = (right2 == null ? "empty" : right2.StoreName),
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
