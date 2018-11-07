using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SSDAssignmentBOX.Models
{
    //There are already some properties(i.e.Name) in Identity role class . More properties like Description, CreatedDate. IPAddress can be added to the ApplicationRole class for storing the additional values. The ApplicationRole class extends this class. It is used to store the role information.
    public class ApplicationRole : IdentityRole //A role in ASP.NET Identity is represented by the ApplicationRole class which inherits the IdentityRole base class.
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Description { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public string IPAddress { get; set; }
    }
}
