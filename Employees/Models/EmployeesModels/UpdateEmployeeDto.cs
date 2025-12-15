using System.ComponentModel.DataAnnotations;

namespace Employees.Models;

public class UpdateEmployeeDto
{
    [Required] [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required] [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required] [MaxLength(50)]
    public string Email { get; set; }
}