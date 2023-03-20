using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class JobService: IJobService
{
    private readonly IJobRepository _jobRepository;
    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    public async Task<List<JobResponseModel>> GetAllJobs()
    {
        var jobs = await _jobRepository.GetAllJobs();
        var jobResponseModel = new List<JobResponseModel>();

        foreach (var job in jobs)
        {
            jobResponseModel.Add(new JobResponseModel
            {
                Id = job.Id, Description = job.Description, Title = job.Title, 
                StartDate=job.StartDate, NumberOfPositions = job.NumberOfPositions
            });
        }

        return jobResponseModel;
        
        /*
         Or you can use LINQ:
                return jobs.Select(job=>new JobResponseModel{Id = job.Id, Description = job.Description,
                 Title = job.Title}).ToList();
         */
    }

    public async Task<JobResponseModel> GetJobById(int id)
    {
        var job = await _jobRepository.GetJobById(id);
        var jobResponseModel = new JobResponseModel
        {
            Id = job.Id, Title = job.Title, StartDate = job.StartDate, Description = job.Description
        };
        return jobResponseModel;
    }
}