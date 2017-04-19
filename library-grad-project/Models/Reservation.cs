using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGradProject.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public long CheckOutDate { get; set; }
    }
}