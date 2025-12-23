using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Location
    {
        public int LocationID { get; set; }

        public string LocationName { get; set; }

		public List<RentACar> RentACars { get; set; }

		public List<Reservation> PickUpReservation { get; set; }//Bir Tablo üzerinde birden fazla ID ile ilişki kurduk

		public List<Reservation> DropOffReservation { get; set; }
	}
}
