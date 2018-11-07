using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSDAssignmentBOX.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public string Borrower { get; set; }

        [Display(Name = "Date Due")]
        [DataType(DataType.Date)]
        public DateTime dueDate { get; set; }

        [Display(Name = "Date Borrowed")]
        [DataType(DataType.Date)]
        public DateTime dateBorrowed { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Summary { get; set; }

        public DateTime DatePublished { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public string Characters { get; set; }

        public DateTime DateReceived { get; set; }

        public string Location { get; set; }

        public string Availability { get; set; }
    }
}
