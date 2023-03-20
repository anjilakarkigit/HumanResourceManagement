using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class SubmissionsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}