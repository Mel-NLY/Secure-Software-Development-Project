using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SSDAssignmentBOX.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(13)]
        [MinLength(13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ISBN must be numeric with 13 integers")]
        public string ISBN { get; set; }

        [StringLength(100000, MinimumLength = 3, ErrorMessage = "Please enter a valid Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z':.,""\s]*$", ErrorMessage = "Please enter a valid Title")]
        [Required]
        public string Title { get; set; }

        [StringLength(100000, MinimumLength = 1, ErrorMessage = "Please enter valid Author(s)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""':,.()\s-]*$", ErrorMessage = "Please enter valid Author(s)")]
        [Required]
        public string Author { get; set; }

        [StringLength(100000, MinimumLength = 1, ErrorMessage = "Please enter a valid Summary")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""':,.()\s-]*$", ErrorMessage = "Please enter a valid Summary")]
        [Required]
        public string Summary { get; set; }

        [Display(Name = "Date Published")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DatePublished { get; set; }

        //Genre must start with one or more capital letters and follow with zero or more letters, single or double quotes, whitespace characters, or dashes.
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter a valid Genre")]
        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [StringLength(100000, MinimumLength = 3, ErrorMessage = "Please enter a valid Language")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter a valid Language")]
        [Required]
        public string Language { get; set; }

        [StringLength(10000, MinimumLength = 3, ErrorMessage = "Please enter valid Characters of the Book")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""':,.()\s-]*$", ErrorMessage = "Please enter Characters of the Book")]
        public string Characters { get; set; }

        [Display(Name = "Date Received")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateReceived { get; set; }

        [StringLength(10000, MinimumLength = 3, ErrorMessage = "Please enter a valid Location")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter a valid Location")]
        [Required]
        public string Location { get; set; }

        public string Availability { get; set; }
    }
}
