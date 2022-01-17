using Bokhandel;

namespace Labb03DB.Exe
{
    internal class AddBook
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {

                ListAuthors.Display();
                Console.WriteLine();
                string x = SaveInput("Select Author: ");
                int author = CheckInputInt(x);

                var tempAuthor = context.Authors.Find(author);
                if (author != null)
                {
                    Console.WriteLine();
                    string title = SaveInput("Select Title: ");
                    Console.WriteLine();
                    string tempPrice = SaveInput("Select Price: ");
                    decimal price = CheckInputDecimal(tempPrice);

                    ListLanguages.Display();
                    Console.WriteLine();
                    string tempLanguage = SaveInput("Select Language: ");
                    int languageId = CheckInputInt(tempLanguage);
                    var language = context.Languages.Find(languageId);
                    if (language != null)
                    {
                        tempAuthor.Books.Add(new Book() { Title = title, Price = price, LanguageId = languageId, AuthorId = author });
                        context.SaveChanges();

                    }
                    else
                    {
                        Console.WriteLine("Can't find an Author with that name");
                        Console.ReadLine();
                    }

                }
                else
                {
                    Console.WriteLine("Can't find an Author with that ID");
                    Console.ReadLine();

                }
            }
            #region ControlMethods
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
            #endregion

        }
    }
}
