namespace ApplicationCore.Models;

public class CandidateCreateViewModel
{
    public Guid JobCode { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
