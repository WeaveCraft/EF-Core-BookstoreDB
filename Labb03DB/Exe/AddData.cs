using Bokhandel;

namespace Labb03DB.Exe
{
    internal class AddData
    {
        public static void Display()
        {
            try
            {
                using (var context = new BokhandelDBcontext())
                {
                    bool insert = context.Books.Any();

                    if (insert != true)
                    {
                        BokhandelDBcontext.AddTestData();
                    }
                    else
                        Console.WriteLine("Data Added\nPress Any Key...");
                }

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Data Now Exists");
            }
        }
    }
}
