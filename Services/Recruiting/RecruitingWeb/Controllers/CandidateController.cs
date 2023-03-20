using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class CandidateController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}