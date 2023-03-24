using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class SubmissionRepository: BaseRepository<Submission>, ISubmissionRepository
{
    public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
    }
}