using Microsoft.EntityFrameworkCore;
using Bokhandel.Models;

namespace Bokhandel
{
    public class BokhandelDBcontext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Language> Languages { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BookstoreDBV1H;Trusted_Connection=True");
        }



        public static void AddTestData()
        {
            TestData.AddLanguages();
            TestData.AddBookswithAuthors();
            TestData.AddStores();
            TestData.AddStock();
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder) //Primary Key for Models -> Stocks
        {
            modelBuilder.Entity<Stock>()
                .HasKey(t => new { t.Store_Id, t.Book_Id });

            modelBuilder.Entity<Stock>()
                .HasOne(b => b.Book)
                .WithMany(st => st.Stocks)
                .HasForeignKey(b => b.Book_Id);

            modelBuilder.Entity<Stock>()
                .HasOne(store => store.Store)
                .WithMany(st => st.Stocks)
                .HasForeignKey(store => store.Store_Id);
        }
    }

}
