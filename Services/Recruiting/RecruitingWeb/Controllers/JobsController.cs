using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class JobsController : Controller
{
    
    private readonly IJobService _jobService;
    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //return all the jobs so that candidates can apply to the job
        var jobs = await _jobService.GetAllJobs();
        return View(jobs);
    }
    
    //get the job detailed information
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        // get job by Id
        var job = await _jobService.GetJobById(id);
        return View(job);
    }
    
    //Users should be authenticated and user should have role for creating new job
    //HR/Manager
    [HttpPost]
    public IActionResult Create()
    {
        //take the information from the View and save to DB
        return View();
    }
}