using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SSDAssignmentBOX.Models
{
    public class Library
    {

        public int Id { get; set; }

        [Display(Name = "Branch Name")]
        [StringLength(100000, MinimumLength = 3, ErrorMessage = "Please enter a valid Branch Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z':.,""\s]*$", ErrorMessage = "Please enter a valid Branch Name")]
        [Required]
        public string BranchName { get; set; }

        [Required]
        [Display(Name = "Branch Location")]
        [StringLength(100000, MinimumLength = 3, ErrorMessage = "Please enter a valid Branch Location")]
        [RegularExpression(@"(\d{1,3}.)?.+\s(\d{6})$", ErrorMessage = "Please enter a valid Branch Location")]
        public string BranchLocation { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"[^0-9][+-]?[0-9]{8,9}[^0-9]*$", ErrorMessage = "Please enter a Valid Phone Number")]
        public string PhoneNumber { get; set; }

    }

}
