using System.Data.Entity;
using LibraryGradProject.Models;

namespace LibraryGradProject.Repos
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(string connectionStringName) 
        : base(connectionStringName)
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}