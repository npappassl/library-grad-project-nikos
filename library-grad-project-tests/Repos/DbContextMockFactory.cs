using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Repos
{
    public class DbContextMockFactory : IDbContextFactory<LibraryContext>
    {
        public LibraryContext Create(string connectionString)
        {
            return new LibraryContext(connectionString);
        }
        public LibraryContext Create()
        {
            return new LibraryContext("LibraryConnectionTest");
        }
    }
}