using AcademyWebApp.Data;
using AcademyWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebApp.Pages.Academy;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly AcademyContext _dbContext;


    public IndexModel(ILogger<IndexModel> logger, AcademyContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IEnumerable<Student> Students { get; set; }

    public void OnGet()
    {
        Students = _dbContext.Students.Include(s => s.Group);
    }
}