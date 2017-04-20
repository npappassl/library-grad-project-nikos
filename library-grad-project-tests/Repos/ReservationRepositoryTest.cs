using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Xunit;


namespace LibraryGradProjectTests.Repos
{
    public class ReservationRepositoryTest
    {
        [Fact]
        public void New_Reserv_Repository_Is_Empty()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository();

            // Act
            IEnumerable<Reservation> reservs = repo.GetAll();

            // Asert
            Assert.Empty(reservs);

        }

        [Fact]
        public void Add_Inserts_New_Reservation()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository();
            Reservation newReserv = new Reservation() { BookId = 1 };

            // Act
            repo.Add(newReserv);
            IEnumerable<Reservation> reservs = repo.GetAll();

            // Asert
            Assert.Equal(new Reservation[] { newReserv }, reservs.ToArray());
        }
        ////////////////////////////////////////////////////////////////////

        [Fact]
        public void Add_Sets_New_Id()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository();
            Reservation newReservation = new Reservation() { BookId = 0 };

            // Act
            repo.Add(newReservation);
            IEnumerable<Reservation> books = repo.GetAll();

            // Asert
            Assert.Equal(0, books.First().Id);
        }

        [Fact]
        public void Get_Returns_Specific_Reservation()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository();
            Reservation newReservation1 = new Reservation() { Id = 0, BookId = 2 };
            Reservation newReservation2 = new Reservation() { Id = 1, BookId = 3 };
            repo.Add(newReservation1);
            repo.Add(newReservation2);

            // Act
            Reservation reserv = repo.Get(1);

            // Asert
            Assert.Equal(newReservation2, reserv);
        }

        [Fact]
        public void Get_All_Returns_All_Reservations()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository();
            Reservation newReservation1 = new Reservation() { BookId = 1 };
            Reservation newReservation2 = new Reservation() { BookId = 2 };
            repo.Add(newReservation1);
            repo.Add(newReservation2);

            // Act
            IEnumerable<Reservation> books = repo.GetAll();

            // Asert
            Assert.Equal(new Reservation[] { newReservation1, newReservation2 }, books.ToArray());
        }

        [Fact]
        public void Delete_Removes_Correct_Reservation()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository();
            Reservation newReservation1 = new Reservation() { BookId = 1 };
            Reservation newReservation2 = new Reservation() { BookId = 2 };
            Reservation newReservation3 = new Reservation() { BookId = 3 };
            repo.Add(newReservation1);
            repo.Add(newReservation2);
            repo.Add(newReservation3);

            // Act
            repo.Remove(1);
            IEnumerable<Reservation> books = repo.GetAll();

            // Asert
            Assert.Equal(new Reservation[] { newReservation1, newReservation3 }, books.ToArray());
        }
        [Fact]
        public void Add_Cannot_Add_Second_Reservation_On_Reserved_BookID()
        {
            // Arange
            ReservationRepository repo = new ReservationRepository();
            Reservation newReservation1 = new Reservation() { BookId = 1 };
            Reservation newReservation2 = new Reservation() { BookId = 1 };
            repo.Add(newReservation1);

            // Act
            try
            {
                repo.Add(newReservation2);
            } catch (Exception e)
            {
                Assert.Equal("book already reserved", e.Message);
            }

            // Assert
            Assert.Equal(1, repo.GetAll().Count());
        }
    }
}
