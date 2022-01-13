using Bokhandel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bokhandel
{
    public class Book
    {
        public ulong Id { get; set; } 
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public DateTime PublisherDate { get; set; } = DateTime.UtcNow;
        public int LanguageId { get; set; }
        public Language Languagetype { get; set; } 
        public List<Author> Authors { get; set; } 
        public List<Stock> Stocks { get; set; } 
    }
}
