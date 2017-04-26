using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Repos
{
    public class DbContextFactory
    {
        public LibraryContext Create(string connectionString)
        {
            return new LibraryContext(connectionString);
        }
    }
}