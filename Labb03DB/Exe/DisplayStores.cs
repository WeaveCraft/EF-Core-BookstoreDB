using Bokhandel;

namespace Labb03DB.Exe
{
    internal class DisplayStores
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {
                var store = context.Stores.ToList();
                foreach (var item in store)
                {
                    Console.WriteLine($"Store ID: {item.Id} \nStore Name: {item.StoreName}, \nAdress: {item.StoreAddress}");
                    Console.WriteLine();
                }
            }
        }
    }
}
