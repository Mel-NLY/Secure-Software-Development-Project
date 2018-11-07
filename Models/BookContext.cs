using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Models
{
    public class BookContext : IdentityDbContext<ApplicationUser, ApplicationRole, string> //BookContext class inherits from IdentityDbContext base class.
    {
        //DBset property for the entity set
        //Entity set corresponds to a row in the table

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 
            // Customize the ASP.NET Identity model and override the defaults if needed. 
            // For example, you can rename the ASP.NET Identity table names and more. 
            // Add your customizations after calling base.OnModelCreating(builder); 
        }

        //User names, passwords + other data will be stored in the SSDAssignmentBOX database.
        public DbSet<Book> Book { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<AuditRecord> AuditRecords { get; set; }
        public DbSet<Library> Library { get; set; }
    }
}
