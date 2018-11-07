using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSDAssignmentBOX.Models
{
    public class Feedback
    {
        public int feedbackId { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 1, ErrorMessage = "Please enter a valid Feedback")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 1, ErrorMessage = "Please enter a valid Subject")]
        public string Subject { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 5, ErrorMessage = "Please enter a valid Message")]
        public string Message { get; set; }
    }
}
