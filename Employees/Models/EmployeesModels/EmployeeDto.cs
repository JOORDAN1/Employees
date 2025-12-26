using System.ComponentModel.DataAnnotations;

namespace Employees.Models;

public class EmployeeDto 
{
    public int Id { get; set; }
    
    [Required] [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required] [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required] [MaxLength(50)]
    public string Email { get; set; }
    
    public List<string> ProjectNames { get; set; }
    
     public List<JobDto> Jobs { get; set; }
}