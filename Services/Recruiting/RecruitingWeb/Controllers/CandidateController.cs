using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers;

public class CandidateController : Controller
{
}
// GET
    // [HttpGet]
    // public IActionResult Create(int id)
    // {
    //     RecruitingDbContext  _dbContext = new RecruitingDbContext();
    //     // Query the database to get the job with the specified ID
    //     var job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
    //     var viewModel = new CandidateCreateViewModel
    //     {
    //         JobCode = job.JobCode,
    //         Title = job.Title,
    //         
    //     };
    //
    //     // Pass the view model to the view
    //     return View(viewModel);
    // }
    
// }