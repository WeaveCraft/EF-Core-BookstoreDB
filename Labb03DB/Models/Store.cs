namespace Bokhandel.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public List<Stock> Stocks { get; set; } 

    }
}
