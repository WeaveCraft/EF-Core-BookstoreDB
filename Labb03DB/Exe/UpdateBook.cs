using Bokhandel;

namespace Labb03DB.Exe
{
    internal class UpdateBook
    {
        public static void Display()
        {
            ListBooks.Display();
            Console.Write("Select Book: ");
            string newBookId = Console.ReadLine();
            ulong updatedBookId = CheckInputUlong(newBookId);

            using (var context = new BokhandelDBcontext())
            {

                var author = context.Books.Find(updatedBookId);
                if (author != null)
                {
                    string newDate = SaveInput("Select New Date (YYYY-MM-DD): ");
                    DateTime updatedDate = NewDate(newDate);

                    string newTitle = SaveInput("Select Title: ");

                    ListAuthors.Display();
                    string newAuthor = SaveInput("Select Author ID: ");
                    int newAuthorId = CheckInputInt(newAuthor);
                    var testAuthor = context.Authors.Find(newAuthorId);
                    if (testAuthor == null)
                    {
                        Console.WriteLine("Error");
                        Console.ReadLine();
                        return;
                    }

                    ListLanguages.Display();
                    string newLanguage = SaveInput("Select Language:");
                    int newLanguageId = CheckInputInt(newLanguage);
                    var tempLanguage = context.Languages.Find(newLanguageId);

                    if (tempLanguage == null)
                    {
                        Console.WriteLine("Error");
                        Console.ReadLine();
                        return;
                    }

                    string price = SaveInput("Select Price: ");
                    decimal newUpdatedPrice = CheckInputDecimal(price);

                    author.Title = newTitle;
                    author.Price = newUpdatedPrice;
                    author.PublisherDate = updatedDate;
                    author.LanguageId = newLanguageId;
                    author.AuthorId = newAuthorId;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Book not found");
                    Console.ReadLine();
                }
            }
            #region ControlMethods
            DateTime NewDate(string input)
            {
                try
                {
                    DateTime date = Convert.ToDateTime(input);
                    return date;
                }
                catch
                {
                    return Convert.ToDateTime("2000-01-01");
                }
            }
            decimal CheckInputDecimal(string input)
            {
                bool x = decimal.TryParse(input, out decimal result);
                while (result < 0 || x == false)

                {
                    Console.WriteLine("Invalid, try again: ");
                    input = Console.ReadLine();
                    x = decimal.TryParse(input, out result);
                }
                return result;
            }

            ulong CheckInputUlong(string input)
            {
                bool x = ulong.TryParse(input, out ulong result);
                while (result < 0 || x == false)

                {
                    Console.WriteLine("Invalid, try again: ");
                    input = Console.ReadLine();
                    x = ulong.TryParse(input, out result);
                }
                return result;

            }
            int CheckInputInt(string input)
            {
                bool x = int.TryParse(input, out int result);
                while (result < 0 || x == false)
                {
                    Console.Write("Invalid, try again: ");
                    input = Console.ReadLine();
                    Console.WriteLine();
                    x = int.TryParse(input, out result);
                }
                return result;
            }
            string SaveInput(string input)
            {
                Console.Write($"{input}: ");
                string output = Console.ReadLine();
                return output;
            }
            #endregion
        }
    }

}
