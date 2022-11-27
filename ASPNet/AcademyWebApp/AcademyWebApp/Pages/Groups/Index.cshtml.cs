using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcademyWebApp.Data;
using AcademyWebApp.Model;

namespace AcademyWebApp.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly AcademyWebApp.Data.AcademyContext _context;

        public IndexModel(AcademyWebApp.Data.AcademyContext context)
        {
            _context = context;
        }

        public IList<Group> Group { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Groups != null)
            {
                Group = await _context.Groups.ToListAsync();
            }
        }
    }
}
