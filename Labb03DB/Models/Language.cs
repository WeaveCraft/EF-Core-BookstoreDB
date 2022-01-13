namespace Bokhandel
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public List<Book> Book { get; set; } 
    }
}
