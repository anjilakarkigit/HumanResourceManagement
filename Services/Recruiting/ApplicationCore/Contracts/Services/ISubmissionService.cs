using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ISubmissionService
{
    Task<int> AddSubmission(SubmissionRequestModel model);
}