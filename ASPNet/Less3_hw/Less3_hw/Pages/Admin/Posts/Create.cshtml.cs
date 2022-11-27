using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Less3_hw.DAL.Database;
using Less3_hw.DAL.Models;

namespace Less3_hw.Pages.Admin.Postes
{
    public class CreateModel : PageModel
    {
        private readonly Less3_hw.DAL.Database.DatabaseContext _context;

        public CreateModel(Less3_hw.DAL.Database.DatabaseContext context)
        {
            _context = context;
            Categories = context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public List<int> SelectedCategories { get; set; }
        public List<SelectListItem> Categories { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (Post==null)
            {
                return Page();
            }
            var postCategories = _context.Categories.Where(c => SelectedCategories.Contains(c.Id)).ToList();
            Post.Categories = postCategories;
            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
