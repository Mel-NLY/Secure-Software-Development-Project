using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SSDAssignmentBOX.Models
{
    public class SSDAssignmentBOXContext : DbContext
    {
        public SSDAssignmentBOXContext (DbContextOptions<SSDAssignmentBOXContext> options)
            : base(options)
        {
        }

        public DbSet<SSDAssignmentBOX.Models.Book> Book { get; set; }
        public DbSet<SSDAssignmentBOX.Models.Reservation> Reservation { get; set; }
    }
}
