using LibraryGradProject.Models;
using LibraryGradProject.Repos;
using System.Collections.Generic;
using System.Web.Http;

namespace LibraryGradProject.Controllers
{
    public class ReservationsController : ApiController
    {
        private IRepository<Reservation> _reservationRepo;

        public ReservationsController(IRepository<Reservation> reservationRepository)
        {
            _reservationRepo = reservationRepository;
        }

        // Get api/reservations
        public IEnumerable<Reservation> Get()
        {
            return _reservationRepo.GetAll();
        }

        // GET api/reservations/{int}
        public Reservation Get(int id)
        {
            return _reservationRepo.Get(id);
        }

        // POST api/reservations
        public void Post(Reservation newBook)
        {
            _reservationRepo.Add(newBook);
        }

        // DELETE api/reservations/{int}
        public void Delete(int id)
        {
            _reservationRepo.Remove(id);
        }
        // This method needs the newReserv to be a complete object 
        // any null values will propagate to the database.
        // PUT api/reservations/{int}
        public void Put(Reservation newReserv)
        {
            Reservation oldReserv = _reservationRepo.Get(newReserv.Id);
            if (oldReserv != null)
            {
                oldReserv.BookId = newReserv.BookId;
                oldReserv.CheckOutDate = newReserv.CheckOutDate;
            }
            else
            {
                throw new System.Exception("not found");
            }
        }
    }
}
