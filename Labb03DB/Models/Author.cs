namespace Bokhandel.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; } = DateTime.UtcNow;
        public List<Book>? Books { get; set; } = new List<Book>(); 
    }
}
