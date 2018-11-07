using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SSDAssignmentBOX.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class 
    //A user in ASP.NET Identity is represented by the ApplicationUser class which inherits the IdentityUser base class
    public class ApplicationUser : IdentityUser //IdentityUser base class contains basic user details(Microsoft.AspNetCore.Identity) such as UserName, Password and Email.
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please Enter your Full Name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression("^(s|t)[0-9]{7}[a-jz]{1}$", ErrorMessage = "Please Enter a valid NRIC eg.S1234567X")]
        public string Nric { get; set; }

        [RegularExpression(@"^[MF]+[a-z]+$", ErrorMessage = "Gender is required (Male/Female)")]
        [StringLength(7, MinimumLength = 4, ErrorMessage = "Gender is required (Male/Female)")]
        [Required(ErrorMessage = "Gender is required (Male/Female)")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select a valid Birthdate")]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please Enter Your StudentID")]
        [RegularExpression("^(s|t)[0-9]{8}[a-jz]{1}$", ErrorMessage = "Please Enter a valid StudentID eg.S12345678X")]
        [Display(Name = "StudentID ")]
        public string StudentID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please Enter your School (e.g Ngee Ann Polytechnic) ")]
        [Display(Name = "School's Name")]
        public string SchoolName { get; set; }
    }
}