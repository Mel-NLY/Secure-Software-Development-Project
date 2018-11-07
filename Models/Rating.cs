using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSDAssignmentBOX.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        [Display(Name = "Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter a valid Book Title")]
        [StringLength(100000, MinimumLength = 3, ErrorMessage = "Please enter a valid Book Title")]
        [Required]
        public string BookTitle { get; set; }

        public string User { get; set; }

        [Display(Name = "Rating")]
        [Required]
        [RegularExpression("^[0-5]{1,1}$", ErrorMessage = "Rating has to be an integer, between 0 [Not Recommended to Read] to 5 [Strongly Recommended to Read]")]
        public int BookRating { get; set; }

        [Display(Name = "Comments")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please enter a valid Comment")]
        [StringLength(100000, MinimumLength = 1, ErrorMessage = "Please enter a valid Comment")]
        [Required]
        public string BookComments { get; set; }

        [Display(Name = "Time Rated")]
        public DateTime RatingTime { get; set; }
    }
}
