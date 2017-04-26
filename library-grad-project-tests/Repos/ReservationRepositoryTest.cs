using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;


namespace LibraryGradProjectTests.Repos
{
    public sealed class ReservationRepositoryTest : IDisposable
    {
        public void Dispose()
        {
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");
            repo.Truncate();
        }
        [Fact]
        public void New_Reserv_Repository_Is_Empty()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");

            // Act
            IEnumerable<Reservation> reservs = repo.GetAll();
            // Asert
            Assert.Equal(reservs.Count(),0);

        }

        [Fact]
        public void Add_Inserts_New_Reservation()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");
            Reservation newReserv = new Reservation() { BookId = 2 };

            // Act
            repo.Add(newReserv);
            IEnumerable<Reservation> reservs = repo.GetAll();

            // Asert
            Assert.Equal(2, reservs.ToArray()[0].BookId);
        }
        ////////////////////////////////////////////////////////////////////


        [Fact]
        public void Get_Returns_Specific_Reservation()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");
            Reservation newReservation1 = new Reservation() { BookId = 2 };
            Reservation newReservation2 = new Reservation() { BookId = 3 };
            Reservation newReservation3 = new Reservation() { BookId = 7 };
            repo.Add(newReservation1);
            repo.Add(newReservation2);
            repo.Add(newReservation3);

            // Act
            Reservation reserv = repo.Get(2);

            // Asert
            Assert.Equal(newReservation2.BookId, reserv.BookId);
        }

        [Fact]
        public void Get_All_Returns_All_Reservations()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");
            Reservation newReservation1 = new Reservation() { BookId = 1 };
            Reservation newReservation2 = new Reservation() { BookId = 2 };
            repo.Add(newReservation1);
            repo.Add(newReservation2);

            // Act
            IEnumerable<Reservation> reservs = repo.GetAll();
            Reservation[] reservsArray = reservs.ToArray();

            // Asert
            Assert.Equal(newReservation1.BookId, reservsArray[0].BookId);
            Assert.Equal(newReservation2.BookId, reservsArray[1].BookId);
        }

        [Fact]
        public void Delete_Removes_Correct_Reservation()
        {
            // Arrange
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");
            Reservation newReservation1 = new Reservation() { BookId = 1 };
            Reservation newReservation2 = new Reservation() { BookId = 2 };
            Reservation newReservation3 = new Reservation() { BookId = 3 };
            repo.Add(newReservation1);
            repo.Add(newReservation2);
            repo.Add(newReservation3);

            // Act
            repo.Remove(2);
            IEnumerable<Reservation> reservs = repo.GetAll();
            Reservation[] reservsArray = reservs.ToArray();
            // Asert
            Assert.Equal(newReservation1.BookId, reservsArray[0].BookId);
            Assert.Equal(newReservation3.BookId, reservsArray[1].BookId);
        }
        [Fact]
        public void Add_Cannot_Add_Second_Reservation_On_Reserved_BookID()
        {
            // Arange
            ReservationRepository repo = new ReservationRepository("LibraryConnectionTest");
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
