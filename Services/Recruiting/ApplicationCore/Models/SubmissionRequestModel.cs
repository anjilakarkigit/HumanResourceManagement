using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class SubmissionRequestModel
{
    [Required(ErrorMessage="Please enter your first name")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage="Please enter your last name")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage="Please enter your email")]
    public string Email  { get; set; }
    public int jobId { get; set; }
    public int candidateId { get; set; }
    public string RejectedReason { get; set; }
}