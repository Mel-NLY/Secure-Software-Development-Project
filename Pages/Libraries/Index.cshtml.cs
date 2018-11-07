using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;
using System.ComponentModel.DataAnnotations;

namespace SSDAssignmentBOX.Pages.Libraries
{
    public class IndexModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public IndexModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IList<Library> Library { get;set; }

        public string SearchString { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            var libraries = from l in _context.Library
                        select l;

            if (!String.IsNullOrEmpty(SearchString))
            {
                SearchString = "%";
                string query = "SELECT * FROM Library WHERE BranchName like {0}";
                Library = await _context.Library.FromSql(query, SearchString).ToListAsync();
                libraries = libraries.Where(s => s.BranchName.Contains(SearchString));
            }
            Library = await libraries.ToListAsync();
        }
    }
}
