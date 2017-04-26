using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LibraryGradProjectTests.Repos
{
    public sealed class BookRepositoryTests : IDisposable
    {
        public void Dispose()
        {
            BookRepository repo = new BookRepository("LibraryConnectionTest");
            repo.Truncate();
        }
        [Fact]
        public void New_Book_Repository_Is_Empty()
        {
            // Arrange
            BookRepository repo = new BookRepository("LibraryConnectionTest");

            // Act
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Empty(books);
        }

        [Fact]
        public void Add_Inserts_New_Book()
        {
            // Arrange
            BookRepository repo = new BookRepository("LibraryConnectionTest");
            Book newBook = new Book() { Title = "Test" };

            // Act
            repo.Add(newBook);
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(newBook.Title, books.ToArray()[0].Title);
        }

        [Fact]
        public void Add_Sets_New_Id()
        {
            // Arrange
            BookRepository repo = new BookRepository("LibraryConnectionTest");
            Book newBook = new Book() { Title = "Test" };

            // Act
            repo.Add(newBook);
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(1, books.First().Id);
        }

        [Fact]
        public void Get_Returns_Specific_Book()
        {
            // Arrange
            BookRepository repo = new BookRepository("LibraryConnectionTest");
            Book newBook1 = new Book() { Id = 0, Title = "Test1" };
            Book newBook2 = new Book() { Id = 1, Title = "Test2" };
            repo.Add(newBook1);
            repo.Add(newBook2);

            // Act
            Book book = repo.Get(2);

            // Asert
            Assert.Equal(newBook2.Title, book.Title);
        }

        [Fact]
        public void Get_All_Returns_All_Books()
        {
            // Arrange
            BookRepository repo = new BookRepository("LibraryConnectionTest");
            Book newBook1 = new Book() { Title = "Test1" };
            Book newBook2 = new Book() { Title = "Test2" };
            repo.Add(newBook1);
            repo.Add(newBook2);

            // Act
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(newBook1.Title, books.ToArray()[0].Title);
            Assert.Equal(newBook2.Title, books.ToArray()[1].Title);

        }

        [Fact]
        public void Delete_Removes_Correct_Book()
        {
            // Arrange
            BookRepository repo = new BookRepository("LibraryConnectionTest");
            Book newBook1 = new Book() { Title = "Test1" };
            Book newBook2 = new Book() { Title = "Test2" };
            Book newBook3 = new Book() { Title = "Test3" };
            repo.Add(newBook1);
            repo.Add(newBook2);
            repo.Add(newBook3);

            // Act
            repo.Remove(2);
            IEnumerable<Book> books = repo.GetAll();

            // Asert
            Assert.Equal(newBook1.Title, books.ToArray()[0].Title);
            Assert.Equal(newBook3.Title, books.ToArray()[1].Title);

        }
    }
}
