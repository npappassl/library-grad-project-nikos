using LibraryGradProject.Controllers;
using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using Moq;
using System;
using Xunit;

namespace LibraryGradProjectTests.Controllers
{
    public class ReservationsControllerTests
    {
        [Fact]
        public void Get_Calls_Repo_GetAll()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Reservation>>();
            mockRepo.Setup(mock => mock.GetAll());
            ReservationsController controller = new ReservationsController(mockRepo.Object);

            // Act
            controller.Get();

            // Assert
            mockRepo.Verify(mock => mock.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_With_Id_Calls_Repo_Get()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Reservation>>();
            mockRepo.Setup(mock => mock.Get(It.IsAny<int>()));
            ReservationsController controller = new ReservationsController(mockRepo.Object);

            // Act
            controller.Get(1);

            // Assert
            mockRepo.Verify(mock => mock.Get(It.Is<int>(x => x == 1)), Times.Once);
        }
        [Fact]
        public void Post_With_Reserv_Calls_Repo_Add()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Reservation>>();
            mockRepo.Setup(mock => mock.Add(It.IsAny<Reservation>()));
            ReservationsController controller = new ReservationsController(mockRepo.Object);

            Reservation newReserv = new Reservation() { CheckOutDate = 21312412413 };

            // Act
            controller.Post(newReserv);

            // Assert
            mockRepo.Verify(mock => mock.Add(It.Is<Reservation>(b => b == newReserv)), Times.Once);
        }

        [Fact]
        public void Delete_With_Id_Calls_Repo_Remove()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Reservation>>();
            mockRepo.Setup(mock => mock.Remove(It.IsAny<int>()));
            ReservationsController controller = new ReservationsController(mockRepo.Object);

            // Act
            controller.Delete(1);

            // Assert
            mockRepo.Verify(mock => mock.Remove(It.Is<int>(x => x == 1)), Times.Once);
        }
        [Fact]
        public void Put_With_Reserv_Calls_Repo_Get()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Reservation>>();
            mockRepo.Setup(mock => mock.Get(It.IsAny<int>()));
            ReservationsController controller = new ReservationsController(mockRepo.Object);

            // Act
            try
            {
                controller.Put(new Reservation() { Id = 2, CheckOutDate = 523514613462346 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // Assert
            mockRepo.Verify(mock => mock.Get(It.Is<int>(x => x == 2)), Times.Once);
        }

    }
}
