using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSDAssignmentBOX.Models
{
    public class Staff
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Branch Assigned")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string BranchAssigned { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [RegularExpression(@"^[MF]+[a-z]+$", ErrorMessage = "Gender is required (Male/Female)")]
        [StringLength(7, MinimumLength = 4, ErrorMessage = "Gender is required (Male/Female)")]
        [Required (ErrorMessage = "Gender is required (Male/Female)")]
        public string Gender { get; set; }
    }
}
