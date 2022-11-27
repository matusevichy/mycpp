using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Less7_hw.Areas.Identity.Pages.Account;

public class Roles : PageModel
{

    [BindProperty] 
    public InputRole Input { get; set; }
    
    [BindProperty]
    public IEnumerable<IdentityRole> AllRoles { get; set; }

    private readonly RoleManager<IdentityRole> _roleManager;
    
    public Roles(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public void OnGet()
    {
        AllRoles = _roleManager.Roles.ToList();
    }

    public class InputRole
    {
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string RoleName { get; set; }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _roleManager.CreateAsync(new IdentityRole(Input.RoleName));
        }

        return Page();
    }
}