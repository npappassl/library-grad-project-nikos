using LibraryGradProject.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LibraryGradProject.Repos
{
    public class FilledBookRepository : BookRepository
    {

        public FilledBookRepository()
            :base("LibraryConnection")
        {
            Add(new Book()
            {
                Title = "El pneumatico",
                Author = "Nikos Pappas",
                ISBN = "23123012093187",
                PublishDate = "21/4/1986"
            });

        }
    }
}