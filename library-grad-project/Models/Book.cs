﻿namespace LibraryGradProject.Models
{
    public class Book
    {
        public Book()
        {

        }
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
    }
}