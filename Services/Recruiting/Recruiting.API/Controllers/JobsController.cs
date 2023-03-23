using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    //Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        //add references for application core and Infra Projects
        //copy all the DI registration iincluding DBContext into API project program.cs
        //copy the connection string from MVC app.settings to API app.settings

        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //http:localhost/api
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();

            if (!jobs.Any())
            {
                //no jobs exists, then 404
                //can also return anonymous object
                return NotFound(new { error = "No open jobs found, please try later"});
            }
            
            //return JSON data and also HTTP status codes
            //serialization --> convert c# objects into json objects using System.Text.Json
            
            return Ok(jobs);
        }

        //http:localhost/api/id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { errorMessage = "No job found for this id" });
            }

            return Ok(job);
        }
        
    }
    
}
