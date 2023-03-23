using System.Text.Json.Serialization;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobRepository: IJobRepository
{
    private RecruitingDbContext _dbContext;
    public JobRepository(RecruitingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    //go to the database and get the data
    //EF Core with LINQ
    public async Task<List<Job>> GetAllJobs()
    {
        var jobs = await _dbContext.Jobs.ToListAsync();
        return jobs;
    }

    public async Task<Job> GetJobById(int id)
    {
        var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        return job;
    }
}

















