using Bokhandel;

namespace Labb03DB.Exe
{
    internal class ListAuthors
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {
                var allAuthors = context.Authors.ToList();
                foreach (var item in allAuthors)
                {
                    Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.DateofBirth}");
                }
            }
        }
    }
}
