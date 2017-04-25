using LibraryGradProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace LibraryGradProject.Repos
{
    public class BookRepository : IRepository<Book>
    {
        private string connectionStringName;
        public BookRepository()
        {
            connectionStringName = "LibraryConnection";
        }
        public BookRepository(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }

        private List<Book> _bookCollection = new List<Book>();

        public void Add(Book entity)
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                db.Books.Add(entity);
                db.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                return db.Books.ToArray();
            }
            
        }

        public Book Get(int id)
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                return db.Books.Where(book => book.Id == id).SingleOrDefault();
            }

        }

        public void Remove(int id)
        {
            Book bookToRemove;
            using (var db = new LibraryContext(connectionStringName))
            {
                bookToRemove = db.Books.Where(book => book.Id == id).SingleOrDefault();
                db.Books.Remove(bookToRemove);
                db.SaveChanges();
            }
        }
        public void Truncate()
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Books;");
                db.SaveChanges();
            }
        }

    }
}