using Bokhandel;

namespace Labb03DB.Exe
{
    internal class ListStores
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {
                var store = context.Stores.ToList();
                foreach (var item in store)
                {
                    Console.WriteLine($"{item.Id}: {item.StoreName}, {item.StoreAddress}");
                }
            }
        }
    }
}
