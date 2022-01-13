namespace Bokhandel.Models
{
    public class Stock
    {
        public int Quantity { get; set; } 

        public ulong Book_Id { get; set; } //Primary Key
        public Book Book { get; set; }  

        public int Store_Id { get; set; } //Primary Key
        public Store Store { get; set; } 



    }
}
