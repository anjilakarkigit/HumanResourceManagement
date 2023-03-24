using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Services;

public class SubmissionService: ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;

    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    public async Task<int> AddSubmission(SubmissionRequestModel model)
    {
        // call the repository that will use EF Core to save the data
        var SubmissionEntity = new Submission
        {
           JobId = model.jobId, CandidateId = model.candidateId, RejectedReason = "TBD"
        };

        var job = await _submissionRepository.AddAsync(SubmissionEntity);
        return job.Id;
    }
}