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
                Id = job.Id,
                JobCode=job.JobCode, 
                NumberOfPositions = job.NumberOfPositions,  
                Title = job.Title, 
                Description = job.Description, 
                StartDate=job.StartDate
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

        if (job == null)
        {
            return null;
        }
        var jobResponseModel = new JobResponseModel
        {
            JobCode = job.JobCode,
            Title = job.Title,
            Description = job.Description,
            NumberOfPositions = job.NumberOfPositions,
            IsActive = job.IsActive,
            CreatedOn = job.CreatedOn
        };
    
        return jobResponseModel;
    }
    public async Task<int> AddJob(JobRequestModel model)
    {
        // call the repository that will use EF Core to save the data
        var jobEntity = new Job
        {
            Title = model.Title, StartDate = model.StartDate, Description = model.Description,
            CreatedOn = DateTime.UtcNow, NumberOfPositions = model.NumberOfPositions,
            JobStatusLookUpId = 1
            
        };

        var job = await _jobRepository.AddAsync(jobEntity);
        return job.Id;
    }
    }