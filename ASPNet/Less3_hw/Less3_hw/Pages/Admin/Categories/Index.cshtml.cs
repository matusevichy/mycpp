using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Less3_hw.DAL.Database;
using Less3_hw.DAL.Models;

namespace Less3_hw.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Less3_hw.DAL.Database.DatabaseContext _context;

        public IndexModel(Less3_hw.DAL.Database.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
