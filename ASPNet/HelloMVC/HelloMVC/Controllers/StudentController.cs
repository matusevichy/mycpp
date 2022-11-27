using HelloMVC.Data;
using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Controllers;

public class StudentController : Controller
{
    private readonly AcademyContext _academyContext;
    private readonly ILogger<StudentController> _logger;

    public StudentController(AcademyContext academyContext, ILogger<StudentController> logger)
    {
        _academyContext = academyContext;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("List of all students");
        return View(_academyContext.Students);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        _logger.LogInformation($"Save student {student}");
        _academyContext.Students.Add(student);
        await _academyContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        return View(await _academyContext.Students.FirstOrDefaultAsync(s => s.Id == id));
    }

    [HttpPost]
    public async Task<IActionResult> Update(Student student)
    {
        _academyContext.Students.Update(student);
        await _academyContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        Student student = await _academyContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        _academyContext.Students.Remove(student);
        await _academyContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}