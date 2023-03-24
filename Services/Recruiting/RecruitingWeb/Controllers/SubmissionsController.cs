using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class SubmissionsController : Controller
{
    private readonly ISubmissionService _submissionService;
    private readonly IJobService _jobService;

    public SubmissionsController(ISubmissionService submissionService, IJobService jobService)
    {
        _submissionService = submissionService;
        _jobService = jobService;
    }

    // GET
    [HttpGet]
    public async Task< IActionResult> Create()
    {
       // var job = await _jobService.GetJobById(Id);
        var submission = new SubmissionRequestModel{ jobId = 1, candidateId = 1, 
            RejectedReason = "N/A"  };
        return View(submission);
    }

    [HttpPost]
     public async Task<IActionResult> Create(SubmissionRequestModel Model)
     {
         if (!ModelState.IsValid)
         {
             return View();
         }
         // save the data in database
         // return to the index view
       
         await _submissionService.AddSubmission(Model);
         return RedirectToAction("Create");
     }
}