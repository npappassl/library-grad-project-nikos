using LibraryGradProject.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LibraryGradProject.Repos
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private string connectionStringName;
        public ReservationRepository()
        {
            connectionStringName = "LibraryConnection";
        }
        public ReservationRepository(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }
        //private List<Reservation> _reservationCollection = new List<Reservation>();
        //private ReservationContext _library = new ReservationContext();

        public void Add(Reservation entity)
        {

            if (GetBookId(entity.BookId) == null)
            {
                using (var db = new LibraryContext(connectionStringName))
                {

                    db.Reservations.Add(entity);
                    db.SaveChanges();
                }

            }
            else
            {
                throw new Exception("book already reserved");
            }
        }

        public Reservation Get(int id)
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                return db.Reservations.Where(reserv => reserv.Id == id).SingleOrDefault();
            }

        }

        public IEnumerable<Reservation> GetAll()
        {
            using (var db = new LibraryContext(connectionStringName))
            {
               return  db.Reservations.ToArray<Reservation>();
            }

        }

        public void Remove(int id)
        {

            Reservation reservToRemove;

            using (var db = new LibraryContext(connectionStringName))
            {
                reservToRemove = db.Reservations.Where(reserv => reserv.Id == id).SingleOrDefault();
                if(reservToRemove == null)
                {
                    throw new Exception("Reservation not found");
                }
                db.Reservations.Remove(reservToRemove);
                db.SaveChanges();
            }

        }
        public void Truncate()
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Reservations;");
                db.SaveChanges();
            }
        }
        private Reservation GetBookId(int id)
        {
            using (var db = new LibraryContext(connectionStringName))
            {
                return db.Reservations.Where(reserv => reserv.BookId == id).SingleOrDefault();
            }

            //return _reservationCollection.Where(reserv => reserv.BookId == id).SingleOrDefault();
        }
    }
}