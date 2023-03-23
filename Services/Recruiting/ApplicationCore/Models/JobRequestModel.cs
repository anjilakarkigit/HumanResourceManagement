using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    
    public int Id { get; set; }
    
    [Required(ErrorMessage="Please enter the title of the job")]
    [StringLength(256)]
    public string Title { get; set; }
    
    [Required(ErrorMessage="Please enter the description of the job")]
    [StringLength(500)]
    public string Description { get; set; }
    
    
    public DateTime StartDate { get; set; }
    
    public int NumberOfPositions { get; set; }
}