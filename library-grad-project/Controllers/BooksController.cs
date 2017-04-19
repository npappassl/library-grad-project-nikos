﻿using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Web.Http;

namespace LibraryGradProject.Controllers
{
    public class BooksController : ApiController
    {
        private IRepository<Book> _bookRepo;
        
        public BooksController(IRepository<Book> bookRepository)
        {
            _bookRepo = bookRepository;
        }
        
        // GET api/books
        public IEnumerable<Book> Get()
        {
            return _bookRepo.GetAll();
        }

        // GET api/books/{int}
        public Book Get(int id)
        {
            return _bookRepo.Get(id);
        }

        // POST api/books
        public void Post(Book newBook)
        {
            _bookRepo.Add(newBook);
        }
        
        // DELETE api/books/{int}
        public void Delete(int id)
        {
            _bookRepo.Remove(id);
        }

        // PUT api/books/{int}
        public void Put(Book newBook)
        {
            Book oldBook = _bookRepo.Get(newBook.Id);
            if(oldBook != null)
            {
                oldBook.ISBN = newBook.ISBN;
                oldBook.Author = newBook.Author;
                oldBook.Title = newBook.Title;
                oldBook.PublishDate = newBook.PublishDate;

            } else
            {
                throw new System.Exception("not found");
            }
        }
    }
}
