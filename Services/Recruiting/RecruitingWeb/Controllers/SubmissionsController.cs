using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class SubmissionsController : Controller
{
    // GET
    public IActionResult Create()
    {
        return View();
    }
}