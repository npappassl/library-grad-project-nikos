using LibraryGradProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace LibraryGradProject.Repos
{
    public class BookRepository : IRepository<Book>
    {
        private IDbContextFactory<LibraryContext> _dbContextFactory;
        public BookRepository(IDbContextFactory<LibraryContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public BookRepository()
        {
            _dbContextFactory = new DbContextFactory();
        }

        private List<Book> _bookCollection = new List<Book>();

        public void Add(Book entity)
        {
            using (var db = _dbContextFactory.Create())
            {
                db.Books.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (var db = _dbContextFactory.Create())
            {
                return db.Books.ToArray();
            }
            
        }

        public Book Get(int id)
        {
            using (var db = _dbContextFactory.Create())
            {
                return db.Books.Where(book => book.Id == id).SingleOrDefault();
            }

        }

        public void Remove(int id)
        {
            Book bookToRemove;
            using (var db = _dbContextFactory.Create())
            {
                bookToRemove = db.Books.Where(book => book.Id == id).SingleOrDefault();
                db.Books.Remove(bookToRemove);
                db.SaveChanges();
            }
        }
        public void Truncate()
        {
            using (var db = _dbContextFactory.Create())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Books;");
                db.SaveChanges();
            }
        }

    }
}