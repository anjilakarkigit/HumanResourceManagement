using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CandidateService: ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    public async Task<int> AddJob(SubmissionRequestModel model)
    {
        // call the repository that will use EF Core to save the data
        var CandidateEntity = new Candidate
        {
            FirstName = model.FirstName, LastName = model.LastName, Email = model.Email,
            CreatedOn = DateTime.UtcNow
            
        };

        var job = await _candidateRepository.AddAsync(CandidateEntity);
        return job.Id;
    }
}