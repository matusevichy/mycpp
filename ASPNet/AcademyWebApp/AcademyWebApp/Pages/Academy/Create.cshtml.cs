using AcademyWebApp.Data;
using AcademyWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcademyWebApp.Pages.Academy;

public class CreateModel : PageModel
{
    private readonly ILogger<CreateModel> _logger;
    private readonly AcademyContext _dbContext;
    public List<Group> Groups { get; set; }

    public CreateModel(ILogger<CreateModel> logger, AcademyContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult OnGet()
    {
        Groups = _dbContext.Groups.ToList();
        return Page();
    }

    [BindProperty]
    public Student? Student { get; set; }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Student != null)
        {
            await _dbContext.Students.AddAsync(Student);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        ViewData["Error"] = "Student shouldn't be null";
        return Page();
    }
}