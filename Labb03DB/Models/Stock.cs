using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bokhandel.Models
{
    public class Stock
    {
        public int Quantity { get; set; } 

        [Key]
        [Column("Book_Id")]
        public ulong Book_Id { get; set; } //Primary Key
        public Book Book { get; set; }  
        [Key]
        [Column("Store_Id")]
        public int Store_Id { get; set; } //Primary Key
        public Store Store { get; set; } 



    }
}
