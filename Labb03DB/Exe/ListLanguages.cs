using Bokhandel;

namespace Labb03DB.Exe
{
    internal class ListLanguages
    {
        public static void Display()
        {
            using (var context = new BokhandelDBcontext())
            {
                var language = context.Languages
                    .ToList();

                foreach (var item in language)
                {
                    Console.WriteLine($"Language ID: {item.Id} {item.LanguageName}");
                }
            }
        }
    }
}
