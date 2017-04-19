using LibraryGradProject.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LibraryGradProject.Repos
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private List<Reservation> _reservationCollection = new List<Reservation>();

        public void Add(Reservation entity)
        {
            if(GetBookId(entity.Id) == null)
            {
                entity.Id = _reservationCollection.Count;
                _reservationCollection.Add(entity);
            } else
            {
                throw new Exception("book already reserved");
            }
        }

        public Reservation Get(int id)
        {
            return _reservationCollection.Where(reserv => reserv.Id == id).SingleOrDefault();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservationCollection;
        }

        public void Remove(int id)
        {
            Reservation reservToRemove = Get(id);
            _reservationCollection.Remove(reservToRemove);

        }
        private Reservation GetBookId(int id)
        {
            return _reservationCollection.Where(reserv => reserv.BookId == id).SingleOrDefault();
        }
    }
}