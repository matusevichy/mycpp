using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers;

public class DemoController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Now = DateTime.Now;
        ViewData["Message"] = "Important message";
        TempData["TempData"] = "Temporal data";
        return View();
    }

    public IActionResult Now()
    {
        return View("Time", DateTime.Now);
    }

    public IActionResult Simple()
    {
        return new ContentResult{Content = "Hello World!", ContentType = "text/plain"};
    }
}